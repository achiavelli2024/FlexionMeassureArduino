#include <Wire.h>
#include <Adafruit_Sensor.h>
#include <Adafruit_ADXL345_U.h>

// Inicializa o sensor ADXL345
Adafruit_ADXL345_Unified accel = Adafruit_ADXL345_Unified(12345);

// Variáveis globais
float referenceX = 0.0;          // Valor inicial do eixo X (calibração)
const int numSamples = 50;       // Número de amostras para o filtro

void setup() {
  Serial.begin(9600);
  Serial.println("Sistema de Medição de Flexão Horizontal Iniciado...");

  // Inicializa o sensor ADXL345
  if (!accel.begin()) {
    Serial.println("Erro: Sensor ADXL345 não encontrado.");
    while (1);
  }

  // Configura o sensor em modo de alta resolução
  accel.setRange(ADXL345_RANGE_16_G);
  Serial.println("Sensor ADXL345 inicializado com sucesso!");
}

void loop() {
  // Verifica se um comando foi enviado pela porta serial
  if (Serial.available() > 0) {
    char command = Serial.read();
    if (command == 'c') {
      calibrate();
    }
  }

  // Envia leituras contínuas do sensor para o monitor serial
  sensors_event_t event;
  accel.getEvent(&event);

  // Calcula a flexão atual
  float deltaX = event.acceleration.x - referenceX;
  float flexionAngle = atan2(deltaX, 1.0) * 180.0 / PI;

  // Corrige pequenas variações próximas de zero
  if (abs(flexionAngle) < 0.1) {
    flexionAngle = 0.0;
  }

  // Envia o ângulo de flexão para o PC
  Serial.print(flexionAngle, 2);
  Serial.println(" graus");

  delay(200); // Frequência de leitura: 5 Hz
}

// Função para calibrar o sensor
void calibrate() {
  Serial.println("Iniciando calibração...");

  float sumX = 0.0;

  // Realiza múltiplas leituras para calcular a média
  for (int i = 0; i < numSamples; i++) {
    sensors_event_t event;
    accel.getEvent(&event);
    sumX += event.acceleration.x;
    delay(20); // Pequeno intervalo entre leituras
  }

  // Define o valor médio como referência
  referenceX = sumX / numSamples;

  // Envia o valor de referência com o prefixo "REF:"
  Serial.print("REF:");
  Serial.println(referenceX, 4);

  Serial.println("Calibração concluída!");
}
