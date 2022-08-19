using System.Linq.Expressions;

namespace ChristmasLights
{
    public partial class Form1 : Form
    {
        bool isStopPressed = true;
        int boxNumber = -1;
        int delay = 1000;

        public Form1()
        {
            InitializeComponent();
            delayTextBox.Text = delay.ToString();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            isStopPressed = !isStopPressed;
            if (!isStopPressed)
            {
                bool isTextNumber = int.TryParse(delayTextBox.Text, out delay);
                if (!isTextNumber)
                {
                    errorLabel.Visible = true;
                    return;
                }
                errorLabel.Visible = false;
                startButton.Text = "Stop";
                LightUp();
                
            }
            else
            {
                startButton.Text = "Start";
                TurnLightsOff();
            }


        }

        private async void LightUp()
        {
            while (!isStopPressed)
            {
                if (boxNumber >= 0 && boxNumber < 7)
                {
                    await Task.Delay(delay);
                }
                if (isStopPressed)
                {
                    return;
                }
                boxNumber++;
                switch (boxNumber)
                {
                    case 0:
                        pictureBox7.BackColor = Color.DarkGreen;
                        pictureBox1.BackColor = Color.Red;
                        break;
                    case 1:
                        pictureBox1.BackColor = Color.DarkRed;
                        pictureBox2.BackColor = Color.Green;
                        break;
                    case 2:
                        pictureBox2.BackColor = Color.DarkGreen;
                        pictureBox3.BackColor = Color.Blue;
                        break;
                    case 3:
                        pictureBox3.BackColor = Color.DarkBlue;
                        pictureBox4.BackColor = Color.Yellow;
                        break;
                    case 4:
                        pictureBox4.BackColor = Color.Gold;
                        pictureBox5.BackColor = Color.Magenta;
                        break;
                    case 5:
                        pictureBox5.BackColor = Color.DarkMagenta;
                        pictureBox6.BackColor = Color.Red;
                        break;
                    case 6:
                        pictureBox6.BackColor = Color.DarkRed;
                        pictureBox7.BackColor = Color.Green;
                        break;
                    default:
                        boxNumber = -1;
                        TurnLightsOff();
                        break;
                }
            }  

        }

        private void TurnLightsOff()
        {
            pictureBox7.BackColor = Color.DarkGreen;
            pictureBox1.BackColor = Color.DarkRed;
            pictureBox2.BackColor = Color.DarkGreen;
            pictureBox3.BackColor = Color.DarkBlue;
            pictureBox4.BackColor = Color.Gold;
            pictureBox5.BackColor = Color.DarkMagenta;
            pictureBox6.BackColor = Color.DarkRed;
        }
    }
}