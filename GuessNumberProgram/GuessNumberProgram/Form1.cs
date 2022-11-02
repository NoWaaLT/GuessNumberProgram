using System.Security.Cryptography;

namespace GuessNumberProgram
{
    public partial class Form1 : Form
    {
        int randomNumber, minValueFlag = 0,
            maxValueFlag, trackBar3Value;
        const int START_POINT = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numericUpDownValue = (int)numericUpDown1.Value;
            label1.Text = Convert.ToString(START_POINT);
            trackBar1.Value = START_POINT;
            trackBar1.Maximum = numericUpDownValue;
            label2.Text = numericUpDown1.Value.ToString();
            trackBar2.Maximum = numericUpDownValue;
            trackBar2.Value = numericUpDownValue;
            trackBar3.Enabled = true;
            trackBar3.Maximum = numericUpDownValue;
            trackBar3.Value = START_POINT;
            label3.Text = Convert.ToString(trackBar3.Value);
            randomNumber = RandomNumberGenerator.GetInt32(1, numericUpDownValue);
            button1.Enabled = false;
            button2.Enabled = true;
            maxValueFlag = numericUpDownValue;
            numericUpDown1.Enabled = false;
            ActiveControl = trackBar3;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            trackBar3.Enabled = false;
            minValueFlag = 0;
            numericUpDown1.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            trackBar3Value = trackBar3.Value;
            if (trackBar3Value < minValueFlag)
            {
                trackBar3.Value = minValueFlag;
                label3.Text = Convert.ToString(minValueFlag);
            }

            if (trackBar3Value > maxValueFlag)
            {
                trackBar3.Value = maxValueFlag;
                label3.Text = Convert.ToString(maxValueFlag);
            }

            if (trackBar3Value >= minValueFlag && trackBar3Value <= maxValueFlag)
                label3.Text = Convert.ToString(trackBar3Value);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            trackBar3Value = trackBar3.Value;
            if (trackBar3Value == randomNumber)
            {
                label4.Text = "Atspėjote!";
                label4.BackColor = Color.Green;
            }
            else if (trackBar3Value < randomNumber)
            {
                label4.Text = "Skaičius yra didesnis!";
                label4.BackColor = Color.Red;
                minValueFlag = trackBar3.Value;
                trackBar1.Value = trackBar3Value;
                label1.Text = trackBar1.Value.ToString();
            }
            else
            {
                label4.Text = "Skaičius yra mažesnis!";
                label4.BackColor = Color.Red;
                maxValueFlag = trackBar3.Value;
                trackBar2.Value = trackBar3Value;
                label2.Text = trackBar2.Value.ToString();
            }
            ActiveControl = trackBar3;
        }
    }
}