using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Dialogs
{
	/// <summary>
	/// CityDialog3�� ���� ��� �����Դϴ�.
	/// </summary>
	public class CityDialog3 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label Message;
		private System.Windows.Forms.Button Sell;
		private System.Windows.Forms.Button Cancel;
		/// <summary>
		/// �ʼ� �����̳� �����Դϴ�.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CityDialog3()
		{
			//
			// Windows Form �����̳� ������ �ʿ��մϴ�.
			//
			InitializeComponent();
			Message.Text = "���� ���ø� �Ű��ϰڽ��ϱ�?  \n���ø� �Ű��ϸ� �ǹ��� �����Ͽ� �����Ҷ� ������ 75%�� �޽��ϴ�.  ";
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
			this.Sell = new System.Windows.Forms.Button();
			this.Cancel = new System.Windows.Forms.Button();
			this.Message = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Sell
			// 
			this.Sell.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Sell.Location = new System.Drawing.Point(240, 48);
			this.Sell.Name = "Sell";
			this.Sell.Size = new System.Drawing.Size(88, 24);
			this.Sell.TabIndex = 0;
			this.Sell.Text = "�Ű�";
			// 
			// Cancel
			// 
			this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel.Location = new System.Drawing.Point(336, 48);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(88, 24);
			this.Cancel.TabIndex = 1;
			this.Cancel.Text = "���";
			// 
			// Message
			// 
			this.Message.ForeColor = System.Drawing.Color.Red;
			this.Message.Location = new System.Drawing.Point(24, 8);
			this.Message.Name = "Message";
			this.Message.Size = new System.Drawing.Size(392, 32);
			this.Message.TabIndex = 2;
			// 
			// CityDialog3
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(434, 84);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.Message,
																		  this.Cancel,
																		  this.Sell});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CityDialog3";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "���� �Ű�";
			this.ResumeLayout(false);

		}
		#endregion

	}
}
