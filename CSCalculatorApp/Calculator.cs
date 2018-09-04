using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSCalculatorApp
{
    public partial class Calculator : Form
    {
        string  _input = "";
        string _operand1 = "";
        string _operand2 = "";
        string _operation = "";

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            this.TextBox.Text += _input;
        }


        public Calculator()
        {
            InitializeComponent();
        }

        private void SquareRoot_MouseClick(object sender, EventArgs e)
        {
            double op;
            double.TryParse( _input, out op);
            double result = Math.Sqrt(op);
            _input = result.ToString();
            this.TextBox.Text = _input;
        }

        private void Square_MouseClick(object sender, EventArgs e)
        {
            double op;
            double.TryParse( _input, out op);
            double result = op * op;
            _input = result.ToString();
            this.TextBox.Text = _input;
        }

        private void PowerOf_MouseClick(object sender, EventArgs e)
        {
            operationInit("^");
        }

        private void OneDividedBy_MouseClick(object sender, EventArgs e)
        {
            double op;
            double.TryParse( _input, out op);
            double result = 1 / op;
            _input = result.ToString();
            this.TextBox.Text = _input;
        }

        private void Clear_MouseClick(object sender, EventArgs e)
        {
            this.TextBox.Text = "";
            _input = "";
            if(this._operand2 == "")
            {
                this._operand1 = "";
            }
            else
            {
                this._operand2 = "";
            }
        }

        private void AllClear_MouseClick(object sender, EventArgs e)
        {;
            this.TextBox.Text = "";
            _input = "";
            this._operand1 = "";
            this._operand2 = "";
        }

        private void Backspace_MouseClick(object sender, EventArgs e)
        {
            this.performBackspace();
        }

        private void performBackspace()
        {
            if (_input.Length > 0)
            {
                _input = _input.Substring(0, _input.Length - 1);
                this.TextBox.Text = _input;
            }
        }

        private void Divide_MouseClick(object sender, EventArgs e)
        {
            operationInit("/");
        }

        private void Seven_MouseClick(object sender, EventArgs e)
        {
            numberChangeInit("7");
        }

        private void Eight_MouseClick(object sender, EventArgs e)
        {
            numberChangeInit("8");
        }

        private void Nine_MouseClick(object sender, EventArgs e)
        {
            numberChangeInit("9");
        }

        private void Four_MouseClick(object sender, EventArgs e)
        {
            numberChangeInit("4");
        }

        private void Five_MouseClick(object sender, EventArgs e)
        {
            numberChangeInit("5");
        }

        private void Six_MouseClick(object sender, EventArgs e)
        {
            numberChangeInit("6");
        }

        private void One_MouseClick(object sender, EventArgs e)
        {
            numberChangeInit("1");
        }

        private void Two_MouseClick(object sender, EventArgs e)
        {
            numberChangeInit("2");
        }

        private void Three_MouseClick(object sender, EventArgs e)
        {
            numberChangeInit("3");
        }

        private void Zero_MouseClick(object sender, EventArgs e)
        {
            numberChangeInit("0");
        }

        private void Equals_Click(object sender, EventArgs e)
        {
            this.performOperation();
        }

        private void performOperation()
        {
            _operand2 = _input;
            double op1, op2;

            double.TryParse(_operand1, out op1);
            double.TryParse(_operand2, out op2);

            string result;

            result = calculate(op1, op2, _operation);
            if (result == "undefined")
                _input = "";
            else
                _input = result;

            this.TextBox.Text = result.ToString();
        }

        private string calculate(double op1, double op2, string _operation)
        {
            switch(_operation)
            {
                case "-": return (op1 - op2).ToString();
                case "+": return (op1 + op2).ToString();
                case "/":
                    if(_operand2 == "0")
                    {
                        _input = "";
                        return "undefined";
                    }
                    return (op1 / op2).ToString();
                case "*": return (op1 * op2).ToString();
                case "^": return (Math.Pow(op1, op2)).ToString();                    
            }

            return "";
        }

        private void Multiply_MouseClick(object sender, EventArgs e)
        {
            operationInit("*");
        }

        private void Plus_MouseClick(object sender, EventArgs e)
        {
            operationInit("+");
        }

        private void Subtract_MouseClick(object sender, EventArgs e)
        {
            operationInit("-");
        }

        private void Period_MouseClick(object sender, EventArgs e)
        {
            numberChangeInit(".");
        }


        private void operationInit(string opString)
        {
            _operation = opString;
            _operand1 = _input;
            _input = "";
            this.TextBox.Text = "";
        }

        private void numberChangeInit(string num)
        {
            _input += num;
            this.TextBox.Text = _input;
        }

        private void Calculator_KeyPress(object sender, KeyPressEventArgs e)
        {
            string[] validOperations = { "-", "+", "/", "*", "^" };

            string key = e.KeyChar.ToString();
            
            if ( key == "=")
            {
                Equals.PerformClick();
            }
            else if ((String.Compare(key, "0") >= 0 && String.Compare("9", key) >= 0) || key == ".")
            {
                this.numberChangeInit(key);
            }
            else if (validOperations.Contains(key))
            {
                this.operationInit(key);
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            this.TextBox.Text = _input;
        }

        private void Calculator_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Equals.PerformClick();
            }
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                this.performBackspace();
            }
        }


    }
}
