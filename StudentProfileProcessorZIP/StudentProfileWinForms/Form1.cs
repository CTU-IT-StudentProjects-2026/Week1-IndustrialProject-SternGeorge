using System;
using System.Drawing;
using System.Windows.Forms;

namespace StudentProfileWinForms
{
    public partial class Form1 : Form
    {
        // Global scope variable
        private string institution = "Kitumaini Digital Solutions";

        // UI Controls
        private TextBox txtName, txtAge, txtModule1, txtModule2, txtModule3;
        private Button btnCalculate, btnClear;
        private RichTextBox rtbResult;   

        public Form1()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Smart Student Profile Processor";
            this.Size = new Size(550, 600);   // Taller window
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(500, 500);  // Allow resizing but prevent going too small

            // Labels and TextBoxes
            Label lblName = new Label() { Text = "Student Name:", Location = new Point(30, 30), Size = new Size(100, 25) };
            txtName = new TextBox() { Location = new Point(140, 30), Size = new Size(250, 25) };

            Label lblAge = new Label() { Text = "Age:", Location = new Point(30, 70), Size = new Size(100, 25) };
            txtAge = new TextBox() { Location = new Point(140, 70), Size = new Size(250, 25) };

            Label lblM1 = new Label() { Text = "Module 1 (0-100):", Location = new Point(30, 110), Size = new Size(120, 25) };
            txtModule1 = new TextBox() { Location = new Point(160, 110), Size = new Size(230, 25) };

            Label lblM2 = new Label() { Text = "Module 2 (0-100):", Location = new Point(30, 150), Size = new Size(120, 25) };
            txtModule2 = new TextBox() { Location = new Point(160, 150), Size = new Size(230, 25) };

            Label lblM3 = new Label() { Text = "Module 3 (0-100):", Location = new Point(30, 190), Size = new Size(120, 25) };
            txtModule3 = new TextBox() { Location = new Point(160, 190), Size = new Size(230, 25) };

            btnCalculate = new Button() { Text = "Calculate Readiness", Location = new Point(80, 240), Size = new Size(150, 35) };
            btnClear = new Button() { Text = "Clear", Location = new Point(260, 240), Size = new Size(100, 35) };

            // RichTextBox for scrollable results
            rtbResult = new RichTextBox()
            {
                Location = new Point(30, 300),
                Size = new Size(480, 220),
                ReadOnly = true,
                BackColor = Color.LightGray,
                Font = new Font("Consolas", 10),   
                ScrollBars = RichTextBoxScrollBars.Vertical   
            };

            // Add controls to form
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblAge);
            Controls.Add(txtAge);
            Controls.Add(lblM1);
            Controls.Add(txtModule1);
            Controls.Add(lblM2);
            Controls.Add(txtModule2);
            Controls.Add(lblM3);
            Controls.Add(txtModule3);
            Controls.Add(btnCalculate);
            Controls.Add(btnClear);
            Controls.Add(rtbResult);

            // Event handlers
            btnCalculate.Click += BtnCalculate_Click;
            btnClear.Click += (s, e) => ClearFields();
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            // Input validation
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter student name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtAge.Text, out int age) || age < 0)
            {
                MessageBox.Show("Age must be a non-negative integer.", "Validation Error");
                return;
            }

            if (!double.TryParse(txtModule1.Text, out double m1) || m1 < 0 || m1 > 100 ||
                !double.TryParse(txtModule2.Text, out double m2) || m2 < 0 || m2 > 100 ||
                !double.TryParse(txtModule3.Text, out double m3) || m3 < 0 || m3 > 100)
            {
                MessageBox.Show("All module scores must be numbers between 0 and 100.", "Validation Error");
                return;
            }

            // Demonstrate method overloading
            double avgTwo = CalculateReadiness(m1, m2);
            double avgThree = CalculateReadiness(m1, m2, m3);
            string readiness = GetReadinessLevel(avgThree);

            //  result string 
            string resultText =
                "========== STUDENT PROFILE ==========\r\n" +
                $"Institution : {institution}\r\n" +
                $"Student Name: {txtName.Text.ToUpper()}\r\n" +
                $"Age         : {age}\r\n" +
                "--------------------------------------\r\n" +
                "Module Scores:\r\n" +
                $"  Module 1   : {m1:F2}\r\n" +
                $"  Module 2   : {m2:F2}\r\n" +
                $"  Module 3   : {m3:F2}\r\n" +
                "--------------------------------------\r\n" +
                $"Average (3 modules): {avgThree:F2}\r\n" +
                $"Readiness Level   : {readiness}\r\n" +
                $"(Demo: Overloaded avg of first 2 modules = {avgTwo:F2})\r\n" +
                $"Rounded average (type casting): {(int)avgThree}\r\n" +
                "======================================";

            rtbResult.Text = resultText;
        }

        // Overloaded method (two parameters)
        private double CalculateReadiness(double score1, double score2)
        {
            return (score1 + score2) / 2;
        }

        // Overloaded method (three parameters)
        private double CalculateReadiness(double score1, double score2, double score3)
        {
            return (score1 + score2 + score3) / 3;
        }

        private string GetReadinessLevel(double average)
        {
            if (average >= 75)
                return "Ready";
            else if (average >= 50)
                return "Partially Ready";
            else
                return "Not Ready";
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtAge.Clear();
            txtModule1.Clear();
            txtModule2.Clear();
            txtModule3.Clear();
            rtbResult.Clear();
            txtName.Focus();
        }
    }
}