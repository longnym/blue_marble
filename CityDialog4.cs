using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using BlueMarble;

namespace Dialogs
{
	/// <summary>
	/// CityDialog4�� ���� ��� �����Դϴ�.
	/// </summary>
	public class CityDialog4 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button OK;
		private System.Windows.Forms.Label talk;
		private System.Windows.Forms.Label cname;
		private System.Windows.Forms.GroupBox InfoBox;
		private System.Windows.Forms.Label info;
		private System.Windows.Forms.Button UseItem;
		private System.Windows.Forms.PictureBox PicFlag;
		/// <summary>
		/// �ʼ� �����̳� �����Դϴ�.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private Image flag = Image.FromFile("flags/city"+UserBuffer.BufferInt5+".png");

		public CityDialog4()
		{
			//
			// Windows Form �����̳� ������ �ʿ��մϴ�.
			//
			InitializeComponent();
			PicFlag.Image = (Image)flag;
			talk.Text = UserBuffer.BufferStr2;
			cname.Text = UserBuffer.BufferStr1;
			info.Text = UserBuffer.BufferStr3;
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
			this.OK = new System.Windows.Forms.Button();
			this.talk = new System.Windows.Forms.Label();
			this.cname = new System.Windows.Forms.Label();
			this.InfoBox = new System.Windows.Forms.GroupBox();
			this.info = new System.Windows.Forms.Label();
			this.UseItem = new System.Windows.Forms.Button();
			this.PicFlag = new System.Windows.Forms.PictureBox();
			this.InfoBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// OK
			// 
			this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OK.Location = new System.Drawing.Point(224, 248);
			this.OK.Name = "OK";
			this.OK.Size = new System.Drawing.Size(112, 32);
			this.OK.TabIndex = 0;
			this.OK.Text = "����� ����";
			// 
			// talk
			// 
			this.talk.ForeColor = System.Drawing.Color.Red;
			this.talk.Location = new System.Drawing.Point(16, 224);
			this.talk.Name = "talk";
			this.talk.Size = new System.Drawing.Size(192, 56);
			this.talk.TabIndex = 1;
			// 
			// cname
			// 
			this.cname.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.cname.Location = new System.Drawing.Point(16, 96);
			this.cname.Name = "cname";
			this.cname.Size = new System.Drawing.Size(184, 88);
			this.cname.TabIndex = 2;
			// 
			// InfoBox
			// 
			this.InfoBox.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.info});
			this.InfoBox.Location = new System.Drawing.Point(208, 8);
			this.InfoBox.Name = "InfoBox";
			this.InfoBox.Size = new System.Drawing.Size(144, 176);
			this.InfoBox.TabIndex = 3;
			this.InfoBox.TabStop = false;
			this.InfoBox.Text = "����";
			// 
			// info
			// 
			this.info.Location = new System.Drawing.Point(8, 24);
			this.info.Name = "info";
			this.info.Size = new System.Drawing.Size(128, 144);
			this.info.TabIndex = 0;
			// 
			// UseItem
			// 
			this.UseItem.DialogResult = System.Windows.Forms.DialogResult.Abort;
			this.UseItem.Location = new System.Drawing.Point(224, 208);
			this.UseItem.Name = "UseItem";
			this.UseItem.Size = new System.Drawing.Size(112, 32);
			this.UseItem.TabIndex = 4;
			this.UseItem.Text = "���� ���";
			// 
			// PicFlag
			// 
			this.PicFlag.Location = new System.Drawing.Point(16, 16);
			this.PicFlag.Name = "PicFlag";
			this.PicFlag.Size = new System.Drawing.Size(100, 66);
			this.PicFlag.TabIndex = 6;
			this.PicFlag.TabStop = false;
			// 
			// CityDialog4
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(362, 298);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.PicFlag,
																		  this.UseItem,
																		  this.InfoBox,
																		  this.cname,
																		  this.talk,
																		  this.OK});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CityDialog4";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "���� ����� ����";
			this.InfoBox.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

	}
}
