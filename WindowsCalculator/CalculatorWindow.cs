using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsCalculator.Actions;
using WindowsCalculator.Classes;

namespace WindowsCalculator
{
    public partial class CalculatorWindow : Form
    {
        string _buffer = String.Empty;
        readonly Calc calc = new();
        public CalculatorWindow()
        {
            InitializeComponent();
            KeyPreview = true;
        }
        
        private void PrintValues()
        {
            resultsView.Text = calc.ToString();
        }

        private void InitializeCalc()
        {
            try
            {
                if (calc.IsActionNull())
                {
                    calc.Number1 = double.Parse(_buffer);
                }
                else
                {
                    calc.Number2 = double.Parse(_buffer);
                }
            }
            catch (Exception)
            {
                // ignored
            }
            
            PrintValues();
        }

        #region Click event for buttons
        private void clear_Click(object sender, EventArgs e)
        {
            calc.Number2 = null;
            calc.Number1 = null;
            calc.Action = null;
            _buffer = string.Empty;
            
            PrintValues();
            
        }
        private void seven_Click(object sender, EventArgs e)
        {
            _buffer += 7;
            
            InitializeCalc();
            
        }
        private void eight_Click(object sender, EventArgs e)
        {
            _buffer += 8;
            
            InitializeCalc();
            
        }
        private void nine_Click(object sender, EventArgs e)
        {
            _buffer += 9;
            
            InitializeCalc();
            
        }
        private void four_Click(object sender, EventArgs e)
        {
            _buffer += 4;
            
            InitializeCalc();
            
        }
        private void five_Click(object sender, EventArgs e)
        {
            _buffer += 5;
            
            InitializeCalc();
            
        }
        private void six_Click(object sender, EventArgs e)
        {
            _buffer += 6;
            
            InitializeCalc();
            
        }
        private void one_Click(object sender, EventArgs e)
        {
            _buffer += 1;
            
            InitializeCalc();
            
        }
        private void two_Click(object sender, EventArgs e)
        {
            _buffer += 2;
            InitializeCalc();
        }
        private void three_Click(object sender, EventArgs e)
        {
            _buffer += 3;
            
            InitializeCalc();
            
        }
        private void zero_Click(object sender, EventArgs e)
        {
            _buffer += 0;
            
            InitializeCalc();
            
        }
        private void dot_Click(object sender, EventArgs e)
        {
            _buffer += ",";
            InitializeCalc();
        }
        private void division_Click(object sender, EventArgs e)
        {
            _buffer = string.Empty;
            
            calc.Action = new DivisionAction();
            
        }
        private void multiply_Click(object sender, EventArgs e)
        {
            _buffer = string.Empty;
            calc.Action = new MultiplyAction();
        }
        private void minus_Click(object sender, EventArgs e)
        {
            _buffer = String.Empty;
            
            calc.Action = new MinusAction();
            
        }
        private void plus_Click(object sender, EventArgs e)
        {
            _buffer = String.Empty;
            
            calc.Action = new PlusAction();
            
        }
        private void result_Click(object sender, EventArgs e)
        {
            if (calc.Number1 != null && calc.Action != null && calc.Number2 != null || calc.Number1 != null && (sender == not || sender == sqrt))
            {
                try
                {
                    calc.Number1 = calc.Calculate();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, @"Error", MessageBoxButtons.OK);
                }
                
                calc.Action = null;
                calc.Number2 = null;
                
                _buffer = string.Empty;
                
                PrintValues();
                
            }
        }
        private void not_Click(object sender, EventArgs e)
        {
            _buffer = string.Empty;
            
            calc.Action = new NotAction();
            
            result_Click(sender, e);
            
        }
        private void sqrt_Click(object sender, EventArgs e)
        {
            _buffer = string.Empty;
            
            calc.Action = new SquareRootAction();
            
            result_Click(sender, e);
            
        }
        private void percent_Click(object sender, EventArgs e)
        {
            IAction buffer = calc.Action;
            
            calc.Action = new GetPercentAction();
            calc.Number2 = calc.Calculate();
            calc.Action = buffer;
            
            PrintValues();
            
        }
        private void denominator_Click(object sender, EventArgs e)
        {
            calc.Action = new DenominatorAction();
            double? buffer = calc.Calculate();
            
            clear_Click(sender, e);
            
            calc.Number1 = buffer;
            
            PrintValues();
            
        }
        private void memoryClean_Click(object sender, EventArgs e)
        {
            calc.Memory = null;
            memorySave.BackColor = default(Color);
        }
        private void memoryRead_Click(object sender, EventArgs e)
        {
            _buffer = calc.Memory.ToString();
            InitializeCalc();
        }
        private void memorySave_Click(object sender, EventArgs e)
        {
            if (calc.Number2 == null)
            {
                calc.Memory = calc.Number1;
            }
            else
            {
                calc.Memory = calc.Number2;
            }
        }
        private void memoryPlus_Click(object sender, EventArgs e)
        {
            calc.Memory += calc.Number1;
            _buffer = calc.Memory.ToString();
            
            InitializeCalc();
            
        }
        private void memoryMinus_Click(object sender, EventArgs e)
        {
            calc.Memory -= calc.Number1;
            _buffer = calc.Memory.ToString();
            
            InitializeCalc();
            
        }
        #endregion

        private void buttons_MouseMove(object sender, MouseEventArgs e)
        {
            ((Button)sender).BackColor = Color.FromArgb(255, 170, 0);
        }
        private void buttons_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = default;
            
            if (sender == memorySave && calc.Memory != null)
            {
                ((Button)sender).BackColor = Color.FromArgb(218, 45, 0, 255);
            }
        }

        private void Calculator_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 48:
                    zero_Click(sender, e);
                    break;
                case 49:
                    one_Click(sender, e);
                    break;
                case 50:
                    two_Click(sender, e);
                    break;
                case 51:
                    three_Click(sender, e);
                    break;
                case 52:
                    four_Click(sender, e);
                    break;
                case 53:
                    five_Click(sender, e);
                    break;
                case 54:
                    six_Click(sender, e);
                    break;
                case 55:
                    seven_Click(sender, e);
                    break;
                case 56:
                    eight_Click(sender, e);
                    break;
                case 57:
                    nine_Click(sender, e);
                    break;
                case 96:
                    zero_Click(sender, e);
                    break;
                case 97:
                    one_Click(sender, e);
                    break;
                case 98:
                    two_Click(sender, e);
                    break;
                case 99:
                    three_Click(sender, e);
                    break;
                case 100:
                    four_Click(sender, e);
                    break;
                case 101:
                    five_Click(sender, e);
                    break;
                case 102:
                    six_Click(sender, e);
                    break;
                case 103:
                    seven_Click(sender, e);
                    break;
                case 104:
                    eight_Click(sender, e);
                    break;
                case 105:
                    nine_Click(sender, e);
                    break;
                case 107:
                    plus_Click(sender, e);
                    break;
                case 109:
                    minus_Click(sender, e);
                    break;
                case 106:
                    multiply_Click(sender, e);
                    break;
                case 111:
                    division_Click(sender, e);
                    break;
                case 110:
                    dot_Click(sender, e);
                    break;
                case 190:
                    dot_Click(sender, e);
                    break;
                case 191:
                    dot_Click(sender, e);
                    break;
            }
        }
    }
}
