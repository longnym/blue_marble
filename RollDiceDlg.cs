using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using BlueMarble;

namespace Dialogs
{
	public class DiceNums
	{
		static public int dicenum1;
		static public int dicenum2;
	}
	/// <summary>
	/// RollDice�� ���� ��� �����Դϴ�.
	/// </summary>
	public class RollDiceDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox Dice1;
		private System.Windows.Forms.PictureBox Dice2;
		/// <summary>
		/// �ʼ� �����̳� �����Դϴ�.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private Image dice1 = Image.FromFile("dice/dice"+DiceNums.dicenum1+".gif");
		private System.Windows.Forms.Button OK;
		private Image dice2 = Image.FromFile("dice/dice"+DiceNums.dicenum2+".gif");

		public RollDiceDlg()
		{
			//
			// Windows Form �����̳� ������ �ʿ��մϴ�.
			//
			InitializeComponent();
			
			
			for (int i = 1; i <= 100000000; i++)
			{
			}

			Dice1.Image = dice1;
			Dice2.Image = dice2;

			
			//
			// TODO: InitializeComponent�� ȣ���� ���� ������ �ڵ带 �߰��մϴ�.
			//
		}

		/// <summary>
		/// ��� ���� ��� ���ҽ��� �����մϴ�.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// �����̳� ������ �ʿ��� �޼����Դϴ�.
		/// �� �޼����� ������ �ڵ� ������� �������� ���ʽÿ�.
		/// </summary>
		private void InitializeComponent()
		{
			this.Dice1 = new System.Windows.Forms.PictureBox();
			this.Dice2 = new System.Windows.Forms.PictureBox();
			this.OK = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// Dice1
			// 
			this.Dice1.Location = new System.Drawing.Point(8, 8);
			this.Dice1.Name = "Dice1";
			this.Dice1.Size = new System.Drawing.Size(60, 54);
			this.Dice1.TabIndex = 0;
			this.Dice1.TabStop = false;
			// 
			// Dice2
			// 
			this.Dice2.Location = new System.Drawing.Point(72, 8);
			this.Dice2.Name = "Dice2";
			this.Dice2.Size = new System.Drawing.Size(60, 54);
			this.Dice2.TabIndex = 1;
			this.Dice2.TabStop = false;
			// 
			// OK
			// 
			this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OK.Location = new System.Drawing.Point(24, 72);
			this.OK.Name = "OK";
			this.OK.Size = new System.Drawing.Size(88, 24);
			this.OK.TabIndex = 2;
			this.OK.Text = "Ȯ��";
			// 
			// RollDiceDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(138, 100);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.OK,
																		  this.Dice2,
																		  this.Dice1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "RollDiceDlg";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "�ֻ��� ������";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
