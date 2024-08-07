using System;
using System.Windows.Forms;

namespace SimpleCalculatorAppRadio
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Initialize and run the form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

    public class MainForm : Form
    {
        private TextBox textBox1;
        private TextBox textBox2;
        private RadioButton addRadioButton;
        private RadioButton subtractRadioButton;
        private RadioButton multiplyRadioButton;
        private RadioButton divideRadioButton;
        private Button calculateButton;
        private Label resultLabel;

        public MainForm()
        {
            // Initialize components
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            addRadioButton = new RadioButton();
            subtractRadioButton = new RadioButton();
            multiplyRadioButton = new RadioButton();
            divideRadioButton = new RadioButton();
            calculateButton = new Button();
            resultLabel = new Label();

            // Set properties of textBox1
            textBox1.Location = new System.Drawing.Point(20, 20);
            textBox1.Size = new System.Drawing.Size(100, 20);

            // Set properties of textBox2
            textBox2.Location = new System.Drawing.Point(20, 50);
            textBox2.Size = new System.Drawing.Size(100, 20);

            // Set properties of addRadioButton
            addRadioButton.Location = new System.Drawing.Point(140, 20);
            addRadioButton.Text = "Add";
            addRadioButton.AutoSize = true;

            // Set properties of subtractRadioButton
            subtractRadioButton.Location = new System.Drawing.Point(140, 50);
            subtractRadioButton.Text = "Subtract";
            subtractRadioButton.AutoSize = true;

            // Set properties of multiplyRadioButton
            multiplyRadioButton.Location = new System.Drawing.Point(140, 80);
            multiplyRadioButton.Text = "Multiply";
            multiplyRadioButton.AutoSize = true;

            // Set properties of divideRadioButton
            divideRadioButton.Location = new System.Drawing.Point(140, 110);
            divideRadioButton.Text = "Divide";
            divideRadioButton.AutoSize = true;

            // Set properties of calculateButton
            calculateButton.Location = new System.Drawing.Point(20, 140);
            calculateButton.Size = new System.Drawing.Size(100, 30);
            calculateButton.Text = "Calculate";
            calculateButton.Click += new EventHandler(CalculateButton_Click);

            // Set properties of resultLabel
            resultLabel.Location = new System.Drawing.Point(20, 180);
            resultLabel.Size = new System.Drawing.Size(220, 30);
            resultLabel.Text = "Result will be shown here";

            // Add controls to the form
            this.Controls.Add(textBox1);
            this.Controls.Add(textBox2);
            this.Controls.Add(addRadioButton);
            this.Controls.Add(subtractRadioButton);
            this.Controls.Add(multiplyRadioButton);
            this.Controls.Add(divideRadioButton);
            this.Controls.Add(calculateButton);
            this.Controls.Add(resultLabel);

            // Set form properties
            this.Text = "Simple Calculator";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(280, 240);
        }

        // Event handler for calculateButton click
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            int num1 = GetNumberFromTextBox(textBox1);
            int num2 = GetNumberFromTextBox(textBox2);

            if (num1 != int.MinValue && num2 != int.MinValue)
            {
                if (addRadioButton.Checked)
                {
                    int result = num1 + num2;
                    resultLabel.Text = "Sum: " + result;
                }
                else if (subtractRadioButton.Checked)
                {
                    int result = num1 - num2;
                    resultLabel.Text = "Difference: " + result;
                }
                else if (multiplyRadioButton.Checked)
                {
                    int result = num1 * num2;
                    resultLabel.Text = "Product: " + result;
                }
                else if (divideRadioButton.Checked)
                {
                    if (num2 == 0)
                    {
                        resultLabel.Text = "Cannot divide by zero.";
                    }
                    else
                    {
                        int result = num1 / num2;
                        resultLabel.Text = "Quotient: " + result;
                    }
                }
                else
                {
                    resultLabel.Text = "Please select an operation.";
                }
            }
        }

        // Method to get and validate number from TextBox
        private int GetNumberFromTextBox(TextBox textBox)
        {
            if (int.TryParse(textBox.Text, out int number))
            {
                return number;
            }
            else
            {
                resultLabel.Text = "Please enter a valid integer.";
                return int.MinValue; // Use int.MinValue to indicate an invalid input
            }
        }
    }
}
