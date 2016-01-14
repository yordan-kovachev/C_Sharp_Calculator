using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    //@FW for Future Work
    //@EH for Event Handler

    public partial class Calculator : Form
    {
        Double value = 0;//for storing any integer values when calculating 
        String calculationType = "";//will hold the type of mathematical operators used
        bool operatorPressed = false;//will tell if a mathematical operator is pressed or not

        public Calculator()
        {
            InitializeComponent();
        }
        
        private void buttonNumber_Click(object sender, EventArgs e)
        {
            //clear the 0 from the reuslt Text Box
            //keep the result in the entryStatus Label Box...
            if (result.Text == "0" || operatorPressed == true)
            {
                result.Clear();
            }
            //...before you press any number
            operatorPressed = false;//reset the bool operatorPressed
            Button button = (Button)sender;
            result.Text = result.Text + button.Text;//display what buttonNumber is pressed in the Result Box
        }

        private void buttonOperator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;//capture what button is pressed
            if (operatorPressed == true && value == 0) //case ID operatorPressed == true when result area contains a result or a number of previous calculation. Still continue to work  
            {//on operator click perform equal button click to continue adding multiple thread of numbers
                buttonEquals.PerformClick();
                operatorPressed = true;//changes to true when any operator is pressed
                calculationType = button.Text;
                entryStatus.Text = value + " " + calculationType;
                result.Text = "";//clear Result Box on operator Pressed
            }
            else
            {//perform normal operator funcrion
                calculationType = button.Text;//assign the operator to the operation varibale
                value = Double.Parse(result.Text);
                operatorPressed = true;//changes to true when any operator is pressed
                entryStatus.Text = value + " " + calculationType;
                result.Text = "";//clear Result Box on operator Pressed
            }
        }
        
        private void buttonPeriod_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;//capture what button is pressed
            if (!result.Text.Contains("."))//if does Not contain  period will add it otherwise will not add another one
            {
                result.Text = result.Text + button.Text;
            }
        } 

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            switch (calculationType)
            {
                case "+":
                    result.Text = (value + Double.Parse(result.Text)).ToString();
                    break;
                case "-":
                    result.Text = (value - Double.Parse(result.Text)).ToString();
                    break;
                case "x":
                    result.Text = (value * Double.Parse(result.Text)).ToString();
                    break;
                case "/":
                    result.Text = (value / Double.Parse(result.Text)).ToString();
                    break;
                default:
                    result.Text = "0";//if none of the above calculationTypes is pressed the Result Box will return always to 0
                    break;
            }
            entryStatus.Text = "";//clear the Label Text once the equal button is pressed
            calculationType = "";
            value = Double.Parse(result.Text);//reset variable value with the result from swich calculation

        }

        private void buttonNegative_Click(object sender, EventArgs e)
        {
            //alternative code for porfolio showcase
            //health: good
            Button button = (Button)sender;//generic event handler what button is pressed
            result.Clear();
            //      p = True                  q = True    
            if /*(button.Text == "-" &&*/ (button.Text != "-")
            {//true for pressing the negative button first
                result.Text = button.Text + result.Text;
            }
            //      p = True                  q = False
            else if /*(button.Text == "" &&*/ (button.Text != "-")
            {//false for presseing the negative button sesond time
                button.IsAccessible = true;
            }
            else
            {//true for pressing any other number different than Negative
                result.Text = result.Text + button.Text;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            result.Text = "0";
            value = 0;
            entryStatus.Text = "";
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            result.Text = "";
        }

        private void Calculator_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar.ToString())
            {
                case "0":
                    button0.PerformClick();
                    break;
                case ".":
                    buttonPeriod.PerformClick();
                    break;
                case "1":
                    button1.PerformClick();
                    break;
                case "2":
                    button2.PerformClick();
                    break;
                case "3":
                    button3.PerformClick();
                    break;
                case "4":
                    button4.PerformClick();
                    break;
                case "5":
                    button5.PerformClick();
                    break;
                case "6":
                    button6.PerformClick();
                    break;
                case "7":
                    button7.PerformClick();
                    break;
                case "8":
                    button8.PerformClick();
                    break;
                case "9":
                    button9.PerformClick();
                    break;
                case "+":
                    buttonPlus.PerformClick();
                    break;
                case "-":
                    buttonMinus.PerformClick();
                    break;
                case "*":
                    buttonMultiply.PerformClick();
                    break;
                case "/":
                    buttonDivide.PerformClick();
                    break;
                case "=":
                    buttonEquals.PerformClick();
                    break;
                default:
                    result.Text = "0";
                    break;
            }
        }

        private void ButtonPercentage_Click(object sender, EventArgs e)
        {
            //Button button = (Button)sender;
            //var secondValue = Double.Parse(button.Text);
            //result.Text = Double.Parse(result.Text / value);
        }
        private void result_TextChanged(object sender, EventArgs e)

        {

        }       
        
        private void Calculator_Load(object sender, EventArgs e)
        {

        }
    }
}
