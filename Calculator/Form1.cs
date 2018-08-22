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
	public partial class Form1 : Form
	{
		Double value = 0;
		String operation = "";
		bool operation_pressed = false;
		bool isEqualsPressed = false;
		bool isOperatorPressed = false;

		public Form1()
		{
			InitializeComponent();
		}

		private void button_Click(object sender, EventArgs e)
		{
			if((result.Text == "0") || (operation_pressed))
			{
				result.Clear();
			}

			operation_pressed = false;
			//takes the "sender" parameter and converts it into a button
			Button b = (Button)sender;
			//checks for decimal point
			if(b.Text == ".")
			{
				if (!result.Text.Contains("."))
				{
					result.Text = result.Text + b.Text;
					isOperatorPressed = true;
				}
			}
			else
			{
				result.Text = result.Text + b.Text;
			}

			if (isEqualsPressed)
			{
				result.Text = "";
				result.Text = result.Text + b.Text;
				isEqualsPressed = false;
			}

			isOperatorPressed = false;
		}



		private void operator_Click(object sender, EventArgs e)
		{

			if (!isOperatorPressed)
			{
				Button b = (Button)sender;
				if (value != 0)
				{
					equalsButton.PerformClick();
					operation_pressed = true;
					operation = b.Text;
					equation.Text = value + " " + operation;
				}
				else
				{
					operation = b.Text;
					value = Double.Parse(result.Text);
					operation_pressed = true;
					equation.Text = value + " " + operation;
				}
			}
			isOperatorPressed = true;
			isEqualsPressed = false;
		}

		private void equals_Click(object sender, EventArgs e)
		{
			if (!isOperatorPressed)
			{
				isEqualsPressed = true;
				switch (operation)
				{
					case "+":
						result.Text = (value + Double.Parse(result.Text)).ToString();
						break;
					case "-":
						result.Text = (value - Double.Parse(result.Text)).ToString();
						break;
					case "*":
						result.Text = (value * Double.Parse(result.Text)).ToString();
						break;
					case "/":
						result.Text = (value / Double.Parse(result.Text)).ToString();
						break;
					default:
						break;

				}//end switch
				value = Int32.Parse(result.Text);
				operation = "";
				equation.Text = "";
			}
			//isOperatorPressed = false;
		}

		private void CE_Click(object sender, EventArgs e)
		{
			result.Clear();
			result.Text = "0";
			equation.Text = "";
			operation = "";
			isOperatorPressed = false;
			isEqualsPressed = false;

		}

		private void clear_Click(object sender, EventArgs e)
		{
			result.Text = "0";
			value = 0;

			isEqualsPressed = false;

		}
	}
}
