using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Windows.Forms;

namespace SimpleAdditionApp
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

        public MainForm()
        {
            // Initialize components
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            addButton = new Button();

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

            // Add controls to the form
            this.Controls.Add(textBox1);
            this.Controls.Add(textBox2);
            this.Controls.Add(addButton);

            // Set form properties
            this.Text = "Simple Addition";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(200, 160);
        }

        // Event handler for addButton click
        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                int num1 = int.Parse(textBox1.Text);
                int num2 = int.Parse(textBox2.Text);
                int sum = num1 + num2;
                MessageBox.Show("Sum: " + sum.ToString(), "Result");
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid integers.", "Error");
            }
        }
    }
}
