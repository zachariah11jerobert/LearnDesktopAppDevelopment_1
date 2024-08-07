using System;
using System.Windows.Forms;

namespace SimpleCalculatorApp3
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
        private Button addButton;
        private Button subtractButton;
        private Button multiplyButton;
        private Button divideButton;
        private Label resultLabel;

        public MainForm()
        {
            // Initialize components
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            addButton = new Button();
            subtractButton = new Button();
            multiplyButton = new Button();
            divideButton = new Button();
            resultLabel = new Label();

            // Set properties of textBox1
            textBox1.Location = new System.Drawing.Point(20, 20);
            textBox1.Size = new System.Drawing.Size(100, 20);

            // Set properties of textBox2
            textBox2.Location = new System.Drawing.Point(20, 50);
            textBox2.Size = new System.Drawing.Size(100, 20);

            // Set properties of addButton
            addButton.Location = new System.Drawing.Point(20, 80);
            addButton.Size = new System.Drawing.Size(100, 30);
            addButton.Text = "Add";
            addButton.Click += new EventHandler(AddButton_Click);

            // Set properties of subtractButton
            subtractButton.Location = new System.Drawing.Point(140, 80);
            subtractButton.Size = new System.Drawing.Size(100, 30);
            subtractButton.Text = "Subtract";
            subtractButton.Click += new EventHandler(SubtractButton_Click);

            // Set properties of multiplyButton
            multiplyButton.Location = new System.Drawing.Point(20, 120);
            multiplyButton.Size = new System.Drawing.Size(100, 30);
            multiplyButton.Text = "Multiply";
            multiplyButton.Click += new EventHandler(MultiplyButton_Click);

            // Set properties of divideButton
            divideButton.Location = new System.Drawing.Point(140, 120);
            divideButton.Size = new System.Drawing.Size(100, 30);
            divideButton.Text = "Divide";
            divideButton.Click += new EventHandler(DivideButton_Click);

            // Set properties of resultLabel
            resultLabel.Location = new System.Drawing.Point(20, 160);
            resultLabel.Size = new System.Drawing.Size(220, 30);
            resultLabel.Text = "Result will be shown here";

            // Add controls to the form
            this.Controls.Add(textBox1);
            this.Controls.Add(textBox2);
            this.Controls.Add(addButton);
            this.Controls.Add(subtractButton);
            this.Controls.Add(multiplyButton);
            this.Controls.Add(divideButton);
            this.Controls.Add(resultLabel);

            // Set form properties
            this.Text = "Simple Calculator";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(280, 240);
        }

        // Event handler for addButton click
        private void AddButton_Click(object sender, EventArgs e)
        {
            PerformAddition();
        }

        // Event handler for subtractButton click
        private void SubtractButton_Click(object sender, EventArgs e)
        {
            PerformSubtraction();
        }

        // Event handler for multiplyButton click
        private void MultiplyButton_Click(object sender, EventArgs e)
        {
            PerformMultiplication();
        }

        // Event handler for divideButton click
        private void DivideButton_Click(object sender, EventArgs e)
        {
            PerformDivision();
        }

        // Method to perform addition
        private void PerformAddition()
        {
            if (TryGetInput(out int num1, out int num2))
            {
                int result = num1 + num2;
                resultLabel.Text = "Sum: " + result;
            }
        }

        // Method to perform subtraction
        private void PerformSubtraction()
        {
            if (TryGetInput(out int num1, out int num2))
            {
                int result = num1 - num2;
                resultLabel.Text = "Difference: " + result;
            }
        }

        // Method to perform multiplication
        private void PerformMultiplication()
        {
            if (TryGetInput(out int num1, out int num2))
            {
                int result = num1 * num2;
                resultLabel.Text = "Product: " + result;
            }
        }

        // Method to perform division
        private void PerformDivision()
        {
            if (TryGetInput(out int num1, out int num2))
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
        }

        // Helper method to get and validate input from textboxes
        private bool TryGetInput(out int num1, out int num2)
        {
            // Initialize output parameters
            num1 = 0;
            num2 = 0;

            bool isValid = int.TryParse(textBox1.Text, out num1) && int.TryParse(textBox2.Text, out num2);
            if (!isValid)
            {
                resultLabel.Text = "Please enter valid integers.";
            }
            return isValid;
        }
    }
}
