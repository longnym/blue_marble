using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using BlueMarble;

namespace Dialogs
{
	/// <summary>
	/// CityDialog�� ���� ��� �����Դϴ�.
	/// </summary>
	public class CityDialog1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button OK;
		private System.Windows.Forms.GroupBox Build;
		public System.Windows.Forms.RadioButton radioButton1;
		public System.Windows.Forms.RadioButton radioButton2;
		public System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.Label cname;
		private System.Windows.Forms.Button cancel;
		private System.Windows.Forms.Label talk;
		private System.Windows.Forms.GroupBox infobox;
		private System.Windows.Forms.Label info;
		private System.Windows.Forms.PictureBox PicFlag;
		/// <summary>
		/// �ʼ� �����̳� �����Դϴ�.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private Image flag = Image.FromFile("flags/city"+UserBuffer.BufferInt5+".png");

		public CityDialog1()
		{
			//
			// Windows Form �����̳� ������ �ʿ��մϴ�.
			//
			InitializeComponent();

			PicFlag.Image = (Image)flag;
			info.Text = UserBuffer.BufferStr3;

			radioButton1.Text = "���� - " + UserBuffer.BufferInt2 + "��";
			radioButton2.Text = "���� - " + UserBuffer.BufferInt3 + "��";
			radioButton3.Text = "ȣ�� - " + UserBuffer.BufferInt4 + "��";

			cname.Text = UserBuffer.BufferStr1;
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
			this.Build = new System.Windows.Forms.GroupBox();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.cname = new System.Windows.Forms.Label();
			this.cancel = new System.Windows.Forms.Button();
			this.talk = new System.Windows.Forms.Label();
			this.infobox = new System.Windows.Forms.GroupBox();
			this.info = new System.Windows.Forms.Label();
			this.PicFlag = new System.Windows.Forms.PictureBox();
			this.Build.SuspendLayout();
			this.infobox.SuspendLayout();
			this.SuspendLayout();
			// 
			// OK
			// 
			this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OK.Location = new System.Drawing.Point(264, 256);
			this.OK.Name = "OK";
			this.OK.Size = new System.Drawing.Size(88, 24);
			this.OK.TabIndex = 0;
			this.OK.Text = "�����ϱ�";
			// 
			// Build
			// 
			this.Build.Controls.AddRange(new System.Windows.Forms.Control[] {
																				this.radioButton3,
																				this.radioButton2,
																				this.radioButton1});
			this.Build.Location = new System.Drawing.Point(8, 192);
			this.Build.Name = "Build";
			this.Build.Size = new System.Drawing.Size(200, 120);
			this.Build.TabIndex = 1;
			this.Build.TabStop = false;
			this.Build.Text = "�ǹ� ����";
			// 
			// radioButton3
			// 
			this.radioButton3.Location = new System.Drawing.Point(16, 88);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(176, 24);
			this.radioButton3.TabIndex = 2;
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(16, 56);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(176, 24);
			this.radioButton2.TabIndex = 1;
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(16, 24);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(176, 24);
			this.radioButton1.TabIndex = 0;
			// 
			// cname
			// 
			this.cname.Font = new System.Drawing.Font("����", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.cname.Location = new System.Drawing.Point(16, 96);
			this.cname.Name = "cname";
			this.cname.Size = new System.Drawing.Size(192, 88);
			this.cname.TabIndex = 2;
			// 
			// cancel
			// 
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel.Location = new System.Drawing.Point(264, 288);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(88, 24);
			this.cancel.TabIndex = 3;
			this.cancel.Text = "���";
			// 
			// talk
			// 
			this.talk.ForeColor = System.Drawing.Color.Blue;
			this.talk.Location = new System.Drawing.Point(216, 200);
			this.talk.Name = "talk";
			this.talk.Size = new System.Drawing.Size(128, 40);
			this.talk.TabIndex = 4;
			this.talk.Text = "�̹� ���ø� �����ϰ� �����Ƿ� �ǹ��� ������ �� �ֽ��ϴ�.";
			// 
			// infobox
			// 
			this.infobox.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.info});
			this.infobox.Location = new System.Drawing.Point(216, 8);
			this.infobox.Name = "infobox";
			this.infobox.Size = new System.Drawing.Size(144, 176);
			this.infobox.TabIndex = 5;
			this.infobox.TabStop = false;
			this.infobox.Text = "����";
			// 
			// info
			// 
			this.info.Location = new System.Drawing.Point(8, 24);
			this.info.Name = "info";
			this.info.Size = new System.Drawing.Size(128, 144);
			this.info.TabIndex = 0;
			// 
			// PicFlag
			// 
			this.PicFlag.Location = new System.Drawing.Point(16, 16);
			this.PicFlag.Name = "PicFlag";
			this.PicFlag.Size = new System.Drawing.Size(100, 66);
			this.PicFlag.TabIndex = 7;
			this.PicFlag.TabStop = false;
			// 
			// CityDialog1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(370, 324);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.PicFlag,
																		  this.infobox,
																		  this.talk,
																		  this.cancel,
																		  this.cname,
																		  this.Build,
																		  this.OK});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CityDialog1";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "���� �ǹ� ����";
			this.Build.ResumeLayout(false);
			this.infobox.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


	}
}
