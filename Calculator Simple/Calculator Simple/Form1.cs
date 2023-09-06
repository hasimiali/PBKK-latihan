using System.Linq.Expressions;

namespace Calculator_Simple
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static float EvaluateExpression(string expression)
        {
            expression = expression.Replace(" ", ""); // Remove spaces

            try
            {
                return EvaluateTerm(ref expression);
            }
            catch (FormatException)
            {
                throw new Exception("Invalid expression format.");
            }
        }

        static float EvaluateTerm(ref string expression)
        {
            float leftOperand = EvaluateFactor(ref expression);

            while (expression.Length > 0)
            {
                char op = expression[0];
                if (op != '+' && op != '-')
                    break;

                expression = expression.Substring(1); // Remove the operator
                float rightOperand = EvaluateFactor(ref expression);

                if (op == '+')
                    leftOperand += rightOperand;
                else
                    leftOperand -= rightOperand;
            }

            return leftOperand;
        }

        static float EvaluateFactor(ref string expression)
        {
            float leftOperand = EvaluateValue(ref expression);

            while (expression.Length > 0)
            {
                char op = expression[0];
                if (op != '*' && op != '/')
                    break;

                expression = expression.Substring(1); // Remove the operator
                float rightOperand = EvaluateValue(ref expression);

                if (op == '*')
                    leftOperand *= rightOperand;
                else
                {
                    if (rightOperand == 0)
                        throw new DivideByZeroException("Division by zero.");
                    leftOperand /= rightOperand;
                }
            }

            return leftOperand;
        }

        static float EvaluateValue(ref string expression)
        {
            if (expression.Length == 0)
                throw new FormatException("Unexpected end of expression.");

            if (expression[0] == '(')
            {
                // Handle parentheses
                int closingIndex = expression.IndexOf(')');
                if (closingIndex == -1)
                    throw new FormatException("Unmatched opening parenthesis.");

                string subExpression = expression.Substring(1, closingIndex - 1);
                expression = expression.Substring(closingIndex + 1); // Remove the processed part
                return EvaluateTerm(ref subExpression);
            }

            int endIndex = expression.IndexOfAny(new char[] { '+', '-', '*', '/', ')' });

            if (endIndex == -1)
                endIndex = expression.Length;

            string valueStr = expression.Substring(0, endIndex);
            expression = expression.Substring(endIndex); // Remove the processed part

            if (!float.TryParse(valueStr, out float value))
                throw new FormatException("Invalid numeric value.");

            return value;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + "0";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + "7";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + "1";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + "2";
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            textBox5.Text = string.Empty;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + "/";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + "*";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + "-";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + "+";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            float result = EvaluateExpression(textBox5.Text);
            textBox5.Text = result.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + "6";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + "9";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + "8";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + "(";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + ")";
        }
    }
}