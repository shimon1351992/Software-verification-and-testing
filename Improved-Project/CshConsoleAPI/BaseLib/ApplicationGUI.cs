using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CshConsoleAPI
{
	public partial class ApplicationGUI : Form
	{
		public ApplicationGUI()
		{
			InitializeComponent();
		}

		private void Multiply_Click(object sender, EventArgs e)
		{
			int num1 = Int32.Parse(Number2Text.Text);
			int num2 = Int32.Parse(Number1Text.Text);
			ResultText.Text = (num1 * num2).ToString();
		}
		delegate void SetTextCallback(string num1, string num2);

		private void SetText(string num1, string num2)
		{
			// InvokeRequired required compares the thread ID of the
			// calling thread to the thread ID of the creating thread.
			// If these threads are different, it returns true.
			if (this.Number2Text.InvokeRequired && this.Number1Text.InvokeRequired)
			{
				
				SetTextCallback d = new SetTextCallback(SetText);
				this.Invoke(d, new object[] { num1, num2 });
			}
			else
			{
				
				this.Number2Text.Text = num1;
				this.Number1Text.Text = num2;
				int value1 = Int32.Parse(Number2Text.Text);
				int value2 = Int32.Parse(Number1Text.Text);
				this.ResultText.Text = (value1 * value2).ToString();
			}
		}
		public string CmdMultiply(string num1, string num2)
		{

			SetText(num1, num2);

			return "ok";
		}
	}
}
