#include <Wire.h>
#include <Adafruit_Sensor.h>
#include <Adafruit_ADXL345_U.h>

// Inicializa o sensor ADXL345
Adafruit_ADXL345_Unified accel = Adafruit_ADXL345_Unified(12345);

// Variáveis globais
float referenceX = 0.0;  // Valor inicial do eixo X (calibração)
float tubeLength = 1.0;  // Comprimento do tubo (L), padrão = 1.0
const int numSamples = 50; // Número de amostras para o filtro

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

  Serial.println("Para definir o comprimento do tubo, envie 'L:<valor>' pela porta serial.");
}

void loop() {
  // Verifica se um comando foi enviado pela porta serial
  if (Serial.available() > 0) {
    String command = Serial.readStringUntil('\n'); // Lê o comando enviado
    command.trim(); // Remove espaços em branco extras

    // Verifica se o comando é para definir o comprimento do tubo
    if (command.startsWith("L:")) {
      tubeLength = command.substring(2).toFloat();
      Serial.print("Comprimento do tubo atualizado: ");
      Serial.print(tubeLength, 2);
      Serial.println(" metros");
    }
    else if (command == "c") {
      calibrate();
    }
  }

  // Lê os dados do sensor
  sensors_event_t event;
  accel.getEvent(&event);

  // Calcula a flexão atual
  float deltaX = event.acceleration.x - referenceX;
  float flexionAngle = atan2(deltaX, tubeLength) * 180.0 / PI;

  // Corrige pequenas variações próximas de zero
  if (abs(flexionAngle) < 0.1) {
    flexionAngle = 0.0;
  }

  // Envia os valores de flexão
  Serial.print("Flexão:");
  Serial.println(flexionAngle, 2);

  // Envia os valores dos eixos X, Y, Z
  Serial.print("Eixos: X:");
  Serial.print(event.acceleration.x, 4);
  Serial.print(" Y:");
  Serial.print(event.acceleration.y, 4);
  Serial.print(" Z:");
  Serial.println(event.acceleration.z, 4);

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
