using System;
using System.IO.Ports;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace FlexaoTuboInterface
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort;
        private bool isConnected = false;
        private string referenceValue = "N/D";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Atualiza a lista de portas COM ao carregar a interface
            UpdateCOMPorts();
        }

        private void UpdateCOMPorts()
        {
            try
            {
                comboBoxCOM.Items.Clear(); // Limpa as opções atuais
                string[] ports = SerialPort.GetPortNames(); // Obtém as portas disponíveis
                comboBoxCOM.Items.AddRange(ports);

                if (ports.Length > 0)
                {
                    comboBoxCOM.SelectedIndex = 0; // Seleciona a primeira porta automaticamente
                }
                else
                {
                    comboBoxCOM.Text = "Nenhuma porta disponível";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao listar portas COM: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                // Lê os dados enviados pelo Arduino
                string data = serialPort.ReadLine().Trim();

                // Identifica o tipo de mensagem recebida
                if (data.StartsWith("Flexão:"))
                {
                    // Processa o valor de flexão
                    string flexionValue = data.Split(':')[1].Trim();
                    Invoke(new MethodInvoker(delegate
                    {
                        labelFlexion.Text = $"Flexão Atual: {flexionValue} graus";
                    }));
                }
                else if (data.StartsWith("Eixos:"))
                {
                    // Processa os valores dos eixos X, Y, Z
                    string[] values = data.Substring(7).Split(' '); // Remove "Eixos: " e divide os eixos

                    string xValue = values[0].Split(':')[1];
                    string yValue = values[1].Split(':')[1];
                    string zValue = values[2].Split(':')[1];

                    // Atualiza os Labels na interface
                    Invoke(new MethodInvoker(delegate
                    {
                        labelX.Text = $"X: {xValue}";
                        labelY.Text = $"Y: {yValue}";
                        labelZ.Text = $"Z: {zValue}";
                    }));
                }
                else if (data.StartsWith("REF:"))
                {
                    // Processa o valor de referência
                    string referenceValue = data.Substring(4).Trim();
                    Invoke(new MethodInvoker(delegate
                    {
                        labelReference.Text = $"Referência: {referenceValue}";
                    }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao processar dados recebidos: {ex.Message}");
            }
        }




        private void buttonRefreshCOMPorts_Click(object sender, EventArgs e)
        {
            // Botão para atualizar as portas COM manualmente
            UpdateCOMPorts();
        }

        private void buttonConnect_Click_1(object sender, EventArgs e)
        {

            if (!isConnected)
            {
                try
                {
                    if (comboBoxCOM.SelectedItem == null || comboBoxCOM.SelectedItem.ToString() == "Nenhuma porta disponível")
                    {
                        MessageBox.Show("Selecione uma porta COM antes de conectar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Configura e abre a porta serial
                    serialPort = new SerialPort(comboBoxCOM.SelectedItem.ToString(), 9600);
                    serialPort.DataReceived += SerialPort_DataReceived;
                    serialPort.Open();

                    isConnected = true;
                    buttonConnect.Text = "Desconectar";
                    labelStatus.Text = "Conectado";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao conectar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Desconecta e fecha a porta serial
                if (serialPort != null && serialPort.IsOpen)
                {
                    serialPort.Close();
                }

                isConnected = false;
                buttonConnect.Text = "Conectar";
                labelStatus.Text = "Desconectado";
            }



        }

        private void buttonCalibrate_Click_1(object sender, EventArgs e)
        {
            if (isConnected && serialPort != null && serialPort.IsOpen)
            {
                try
                {
                    // Envia o comando de calibração
                    serialPort.WriteLine("c");

                    // Atualiza a interface indicando que a calibração está em andamento
                    labelReference.Text = "Calibrando...";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao enviar comando de calibração: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Conecte ao Arduino antes de calibrar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonSetLength_Click(object sender, EventArgs e)
        {
            if (isConnected && serialPort != null && serialPort.IsOpen)
            {
                try
                {
                    string length = textBoxTubeLength.Text; // Campo onde o usuário insere o comprimento
                    serialPort.WriteLine($"L:{length}");
                    MessageBox.Show($"Comprimento do tubo definido para {length} metros.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao definir comprimento do tubo: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Conecte ao Arduino antes de definir o comprimento do tubo.");
            }
        }
    }
}
