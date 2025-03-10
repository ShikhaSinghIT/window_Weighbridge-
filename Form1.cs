using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;
using System.IO;
using System.Data.OracleClient;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private const string ErrorLogFilePath = "C:\\error_log.txt";

        private SerialPort _serialPort;
        private const int BaudRate = 9600;
       

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (_serialPort != null && _serialPort.IsOpen)
                {
                    _serialPort.Close();
                    _serialPort.Dispose();
                }

                string[] portNames = SerialPort.GetPortNames();
                
                if (portNames.Length == 0)
                {
                    MessageBox.Show("No serial ports detected. Please connect the weighing machine.");
                    return;
                }
                textBox1.Text = portNames[0];
                _serialPort = new SerialPort(portNames[0], BaudRate, Parity.None, 8, StopBits.One);
                _serialPort.Open();
                _serialPort.ReadTimeout = 1500;
                Thread.Sleep(1500);

                string receivedData = _serialPort.ReadExisting();

                // Remove special characters and alphabets, keep only digits and decimal point
                string cleanData = "";
                foreach (char c in receivedData)
                {
                    if (char.IsDigit(c) || c == '.')
                    {
                        cleanData += c;
                    }
                }

                // Display the cleaned data
                getWgt.Text = cleanData;

                // Close the serial port
                _serialPort.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                // Log the error to a file
                LogError(ex.Message);
            }
        }

        private void LogError(string errorMessage)
        {
            try
            {
                string errorLogFile = "error_log.txt";

                // Write the error message along with timestamp to the log file
                using (StreamWriter writer = new StreamWriter(errorLogFile, true))
                {
                    writer.WriteLine(DateTime.Now + ": " + errorMessage);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while logging the error : " + errorMessage);
            }
        }

        private void getWgt_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
  

        

       


    }
}
