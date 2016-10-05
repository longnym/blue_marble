using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BlueMarble
{
	/// <summary>
	/// WinDialog�� ���� ��� �����Դϴ�.
	/// </summary>
	public class WinDialog : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button OK;
		private System.Windows.Forms.Label L_Win;
		/// <summary>
		/// �ʼ� �����̳� �����Դϴ�.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public WinDialog()
		{
			//
			// Windows Form �����̳� ������ �ʿ��մϴ�.
			//
			InitializeComponent();
			L_Win.Text = UserBuffer.winner + "���� �¸��Ͽ����ϴ�.";

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(WinDialog));
			this.OK = new System.Windows.Forms.Button();
			this.L_Win = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// OK
			// 
			this.OK.BackColor = System.Drawing.Color.Transparent;
			this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OK.Location = new System.Drawing.Point(384, 328);
			this.OK.Name = "OK";
			this.OK.Size = new System.Drawing.Size(112, 32);
			this.OK.TabIndex = 0;
			this.OK.Text = "���� ����";
			// 
			// L_Win
			// 
			this.L_Win.BackColor = System.Drawing.Color.Transparent;
			this.L_Win.Font = new System.Drawing.Font("����", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.L_Win.Location = new System.Drawing.Point(16, 24);
			this.L_Win.Name = "L_Win";
			this.L_Win.Size = new System.Drawing.Size(480, 48);
			this.L_Win.TabIndex = 1;
			// 
			// WinDialog
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackgroundImage = ((System.Drawing.Bitmap)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(512, 378);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.L_Win,
																		  this.OK});
			this.Name = "WinDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "���� ����";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
