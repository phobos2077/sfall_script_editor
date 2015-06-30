/*
 * Created by SharpDevelop.
 * User: Phobos2077
 * Date: 21.07.2014
 * Time: 1:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScriptEditor
{
	/// <summary>
	/// Description of GoToLine.
	/// </summary>
	public partial class GoToLine : Form
	{
		public GoToLine()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public int GetLineNumber()
		{
			int n;
			try {
            	n=Convert.ToInt32(tbLine.Text);
            } catch (System.FormatException) {
            	n = 1;
            }
			if (n < 1 || n > (int)tbLine.Tag) {
				n = 1;
			}
			return n;
		}
		void TbLineTextChanged(object sender, EventArgs e)
		{
			string txt = Convert.ToString(GetLineNumber());
			bool changed = (tbLine.Text != txt);
			tbLine.Text=txt;
			if (changed) {
				tbLine.SelectAll();
			}
		}
		void GoToLineKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape) {
				Close();
			}
		}
		void TbLineKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter) {
				bGo.PerformClick();
			}
		}
	}
}
