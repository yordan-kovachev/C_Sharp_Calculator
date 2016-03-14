﻿using System;
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
    public partial class CALCULATOR : Form
    {
        Double value = 0;//for storing any integer values when calculating 
        String calculationType = "";//will hold the type of mathematical operators used
        bool operatorPressed = false;//will tell if a mathematical operator is pressed or not

        public CALCULATOR()
        {
            InitializeComponent();
            if (!SystemInformation.HighContrast)
            {
                BackColor = Color.White;
                buttonClear.BackColor = Color.IndianRed;
                buttonDelete.BackColor = Color.Orange;
                buttonEquals.BackColor = Color.DarkTurquoise;
            }
            else
            {
                BackColor = SystemColors.Window;
                buttonClear.BackColor = SystemColors.AppWorkspace;
                buttonDelete.BackColor = SystemColors.AppWorkspace;
                buttonEquals.BackColor = SystemColors.AppWorkspace;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.C))
            {
                calculatorMenu.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        
        private void buttonNumber_Click(object sender, EventArgs e)
        {
            //clear the 0 from the reuslt Text Box
            //keep the result in the entryStatus Label Box...
            if (result.Text == "0" || operatorPressed == true)
            {
                result.Clear();
            }
            //else
            //{
            //    entryStatus.Text = "";
            //}
            //...before you press any number
            operatorPressed = false;//reset bool val operatorPressed
            Button button = (Button)sender;
            result.Text += button.Text;//result.Text + display what buttonNumber is pressed in the Result Box
        }

        private void buttonOperator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;//capture what button is pressed
            if (result.Text == "" || calculationType != null)//quard clause filtering the garbbeg 
            {
                try
                {
                    entryStatus.Text = value + " ";
                    calculationType = button.Text;
                }
                catch (FormatException)
                {
                    entryStatus.Text = value + " " + calculationType;
                }
            }
            entryStatus.Text = value + " " + calculationType;
                        
            if (operatorPressed == false && value == 0) //case ID operatorPressed == true when result area contains a result or a number of previous calculation. Still continue to work  
            {
                //perform normal operator funcrion
                value = Double.Parse(result.Text);
                operatorPressed = true;//changes to true when any operator is pressed
                calculationType = button.Text;//assign the operator to the operation varibale
                entryStatus.Text = value + " " + calculationType;
                result.Text = "";//clear Result Box on operator Pressed
            }
        }
        
        private void buttonPeriod_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (!result.Text.Contains("."))//Validation, if does Not contain  period will add it otherwise will not
            {
                result.Text += button.Text;
            }
            else
            {
                result.Text = "0" + button.Text;
            }
        } 

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            if(entryStatus.Text !="" || result.Text == "")
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
                            result.Text = result.Text;
                            break;
                    }
                    entryStatus.Text = "";//clear the Label Text once the equal button is pressed
                    calculationType = "";
                    //value = Double.Parse(result.Text);//reset variable value with the result from switch calculation
            }
            //else
            //{
            //    Button button = (Button)sender;
            //    if(operatorPressed == true)
            //    {
            //        try
            //        {
            //            entryStatus.Text = calculationType;
            //        }
            //        catch
            //        {
            //            throw new Exception();
            //        }
            //    }
            //    button.Text = calculationType;
            //}
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
            entryStatus.Text = "0";
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
                case "%":
                    buttonPercentage.PerformClick();
                    break;
                default:
                    result.Text = "0";
                    entryStatus.Text = "0";
                    break;
            }
        }

        private void ButtonPercentage_Click(object sender, EventArgs e)
        {
            value = Double.Parse(result.Text);
            Double percentage = value / 100;
            result.Text = (percentage).ToString();
            value = 0;
        }

        private void calculatorMenu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
