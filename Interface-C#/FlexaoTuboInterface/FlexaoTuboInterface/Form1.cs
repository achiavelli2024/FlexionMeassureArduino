using System;
using System.IO.Ports;
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
                // Lê os dados recebidos do Arduino
                string data = serialPort.ReadLine().Trim();

                // Verifica se a mensagem é o valor de referência
                if (data.StartsWith("REF:"))
                {
                    // Extrai o valor de referência da mensagem
                    string referenceValue = data.Substring(4);

                    // Atualiza o label de referência na interface
                    Invoke(new MethodInvoker(delegate
                    {
                        labelReference.Text = $"Referência: {referenceValue}";
                    }));
                }
                else
                {
                    // Atualiza o valor de flexão na interface
                    Invoke(new MethodInvoker(delegate
                    {
                        labelFlexion.Text = $"Flexão Atual: {data} graus";
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
    }
}
