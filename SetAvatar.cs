using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Dialogs
{
	/// <summary>
	/// SetAvatar에 대한 요약 설명입니다.
	/// </summary>
	public class SetAvatar : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button OK;
		private System.Windows.Forms.PictureBox P_Avater1;
		private System.Windows.Forms.PictureBox P_Avater2;
		private System.Windows.Forms.PictureBox P_Avater3;
		private System.Windows.Forms.PictureBox P_Avater4;
		private System.Windows.Forms.PictureBox P_Avater5;
		private System.Windows.Forms.PictureBox P_Avater6;
		private System.Windows.Forms.PictureBox P_Avater7;
		private System.Windows.Forms.PictureBox P_Avater8;
		private System.Windows.Forms.RadioButton R_Avater1;
		private System.Windows.Forms.RadioButton R_Avater2;
		private System.Windows.Forms.RadioButton R_Avater3;
		private System.Windows.Forms.RadioButton R_Avater4;
		private System.Windows.Forms.RadioButton R_Avater5;
		private System.Windows.Forms.RadioButton R_Avater6;
		private System.Windows.Forms.RadioButton R_Avater7;
		private System.Windows.Forms.RadioButton R_Avater8;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public int avatarNum;

		public SetAvatar()
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();
			R_Avater1.Checked = true;
			P_Avater1.Image = Image.FromFile("avatar/avatar0.gif");
			P_Avater2.Image = Image.FromFile("avatar/avatar1.gif");
			P_Avater3.Image = Image.FromFile("avatar/avatar2.gif");
			P_Avater4.Image = Image.FromFile("avatar/avatar3.gif");
			P_Avater5.Image = Image.FromFile("avatar/avatar4.gif");
			P_Avater6.Image = Image.FromFile("avatar/avatar5.gif");
			P_Avater7.Image = Image.FromFile("avatar/avatar6.gif");
			P_Avater8.Image = Image.FromFile("avatar/avatar7.gif");
			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
		}

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
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
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
			this.OK = new System.Windows.Forms.Button();
			this.P_Avater1 = new System.Windows.Forms.PictureBox();
			this.P_Avater2 = new System.Windows.Forms.PictureBox();
			this.P_Avater3 = new System.Windows.Forms.PictureBox();
			this.P_Avater4 = new System.Windows.Forms.PictureBox();
			this.P_Avater5 = new System.Windows.Forms.PictureBox();
			this.P_Avater6 = new System.Windows.Forms.PictureBox();
			this.P_Avater7 = new System.Windows.Forms.PictureBox();
			this.P_Avater8 = new System.Windows.Forms.PictureBox();
			this.R_Avater1 = new System.Windows.Forms.RadioButton();
			this.R_Avater2 = new System.Windows.Forms.RadioButton();
			this.R_Avater3 = new System.Windows.Forms.RadioButton();
			this.R_Avater4 = new System.Windows.Forms.RadioButton();
			this.R_Avater5 = new System.Windows.Forms.RadioButton();
			this.R_Avater6 = new System.Windows.Forms.RadioButton();
			this.R_Avater7 = new System.Windows.Forms.RadioButton();
			this.R_Avater8 = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
			// 
			// OK
			// 
			this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OK.Location = new System.Drawing.Point(208, 392);
			this.OK.Name = "OK";
			this.OK.Size = new System.Drawing.Size(104, 24);
			this.OK.TabIndex = 0;
			this.OK.Text = "확인";
			// 
			// P_Avater1
			// 
			this.P_Avater1.Location = new System.Drawing.Point(8, 8);
			this.P_Avater1.Name = "P_Avater1";
			this.P_Avater1.Size = new System.Drawing.Size(120, 152);
			this.P_Avater1.TabIndex = 1;
			this.P_Avater1.TabStop = false;
			// 
			// P_Avater2
			// 
			this.P_Avater2.Location = new System.Drawing.Point(136, 8);
			this.P_Avater2.Name = "P_Avater2";
			this.P_Avater2.Size = new System.Drawing.Size(120, 152);
			this.P_Avater2.TabIndex = 2;
			this.P_Avater2.TabStop = false;
			// 
			// P_Avater3
			// 
			this.P_Avater3.Location = new System.Drawing.Point(264, 8);
			this.P_Avater3.Name = "P_Avater3";
			this.P_Avater3.Size = new System.Drawing.Size(120, 152);
			this.P_Avater3.TabIndex = 3;
			this.P_Avater3.TabStop = false;
			// 
			// P_Avater4
			// 
			this.P_Avater4.Location = new System.Drawing.Point(392, 8);
			this.P_Avater4.Name = "P_Avater4";
			this.P_Avater4.Size = new System.Drawing.Size(120, 152);
			this.P_Avater4.TabIndex = 4;
			this.P_Avater4.TabStop = false;
			// 
			// P_Avater5
			// 
			this.P_Avater5.Location = new System.Drawing.Point(8, 200);
			this.P_Avater5.Name = "P_Avater5";
			this.P_Avater5.Size = new System.Drawing.Size(120, 152);
			this.P_Avater5.TabIndex = 5;
			this.P_Avater5.TabStop = false;
			// 
			// P_Avater6
			// 
			this.P_Avater6.Location = new System.Drawing.Point(136, 200);
			this.P_Avater6.Name = "P_Avater6";
			this.P_Avater6.Size = new System.Drawing.Size(120, 152);
			this.P_Avater6.TabIndex = 6;
			this.P_Avater6.TabStop = false;
			// 
			// P_Avater7
			// 
			this.P_Avater7.Location = new System.Drawing.Point(264, 200);
			this.P_Avater7.Name = "P_Avater7";
			this.P_Avater7.Size = new System.Drawing.Size(120, 152);
			this.P_Avater7.TabIndex = 7;
			this.P_Avater7.TabStop = false;
			// 
			// P_Avater8
			// 
			this.P_Avater8.Location = new System.Drawing.Point(392, 200);
			this.P_Avater8.Name = "P_Avater8";
			this.P_Avater8.Size = new System.Drawing.Size(120, 152);
			this.P_Avater8.TabIndex = 8;
			this.P_Avater8.TabStop = false;
			// 
			// R_Avater1
			// 
			this.R_Avater1.Location = new System.Drawing.Point(32, 168);
			this.R_Avater1.Name = "R_Avater1";
			this.R_Avater1.Size = new System.Drawing.Size(72, 24);
			this.R_Avater1.TabIndex = 9;
			this.R_Avater1.Text = "아바타1";
			this.R_Avater1.CheckedChanged += new System.EventHandler(this.R_Avater1_CheckedChanged);
			// 
			// R_Avater2
			// 
			this.R_Avater2.Location = new System.Drawing.Point(160, 168);
			this.R_Avater2.Name = "R_Avater2";
			this.R_Avater2.Size = new System.Drawing.Size(72, 24);
			this.R_Avater2.TabIndex = 10;
			this.R_Avater2.Text = "아바타2";
			this.R_Avater2.CheckedChanged += new System.EventHandler(this.R_Avater2_CheckedChanged);
			// 
			// R_Avater3
			// 
			this.R_Avater3.Location = new System.Drawing.Point(288, 168);
			this.R_Avater3.Name = "R_Avater3";
			this.R_Avater3.Size = new System.Drawing.Size(72, 24);
			this.R_Avater3.TabIndex = 11;
			this.R_Avater3.Text = "아바타3";
			this.R_Avater3.CheckedChanged += new System.EventHandler(this.R_Avater3_CheckedChanged);
			// 
			// R_Avater4
			// 
			this.R_Avater4.Location = new System.Drawing.Point(416, 168);
			this.R_Avater4.Name = "R_Avater4";
			this.R_Avater4.Size = new System.Drawing.Size(72, 24);
			this.R_Avater4.TabIndex = 12;
			this.R_Avater4.Text = "아바타4";
			this.R_Avater4.CheckedChanged += new System.EventHandler(this.R_Avater4_CheckedChanged);
			// 
			// R_Avater5
			// 
			this.R_Avater5.Location = new System.Drawing.Point(32, 360);
			this.R_Avater5.Name = "R_Avater5";
			this.R_Avater5.Size = new System.Drawing.Size(72, 24);
			this.R_Avater5.TabIndex = 13;
			this.R_Avater5.Text = "아바타5";
			this.R_Avater5.CheckedChanged += new System.EventHandler(this.R_Avater5_CheckedChanged);
			// 
			// R_Avater6
			// 
			this.R_Avater6.Location = new System.Drawing.Point(160, 360);
			this.R_Avater6.Name = "R_Avater6";
			this.R_Avater6.Size = new System.Drawing.Size(72, 24);
			this.R_Avater6.TabIndex = 14;
			this.R_Avater6.Text = "아바타6";
			this.R_Avater6.CheckedChanged += new System.EventHandler(this.R_Avater6_CheckedChanged);
			// 
			// R_Avater7
			// 
			this.R_Avater7.Location = new System.Drawing.Point(288, 360);
			this.R_Avater7.Name = "R_Avater7";
			this.R_Avater7.Size = new System.Drawing.Size(72, 24);
			this.R_Avater7.TabIndex = 15;
			this.R_Avater7.Text = "아바타7";
			this.R_Avater7.CheckedChanged += new System.EventHandler(this.R_Avater7_CheckedChanged);
			// 
			// R_Avater8
			// 
			this.R_Avater8.Location = new System.Drawing.Point(416, 360);
			this.R_Avater8.Name = "R_Avater8";
			this.R_Avater8.Size = new System.Drawing.Size(72, 24);
			this.R_Avater8.TabIndex = 16;
			this.R_Avater8.Text = "아바타8";
			this.R_Avater8.CheckedChanged += new System.EventHandler(this.R_Avater8_CheckedChanged);
			// 
			// SetAvatar
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(520, 426);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.R_Avater8,
																		  this.R_Avater7,
																		  this.R_Avater6,
																		  this.R_Avater5,
																		  this.R_Avater4,
																		  this.R_Avater3,
																		  this.R_Avater2,
																		  this.R_Avater1,
																		  this.P_Avater8,
																		  this.P_Avater7,
																		  this.P_Avater6,
																		  this.P_Avater5,
																		  this.P_Avater4,
																		  this.P_Avater3,
																		  this.P_Avater2,
																		  this.P_Avater1,
																		  this.OK});
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SetAvatar";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "아바타 선택";
			this.ResumeLayout(false);

		}
		#endregion

		private void R_Avater1_CheckedChanged(object sender, System.EventArgs e)
		{
			avatarNum = 0;
		}

		private void R_Avater2_CheckedChanged(object sender, System.EventArgs e)
		{
			avatarNum = 1;
		}

		private void R_Avater3_CheckedChanged(object sender, System.EventArgs e)
		{
			avatarNum = 2;
		}

		private void R_Avater4_CheckedChanged(object sender, System.EventArgs e)
		{
			avatarNum = 3;
		}

		private void R_Avater5_CheckedChanged(object sender, System.EventArgs e)
		{
			avatarNum = 4;
		}

		private void R_Avater6_CheckedChanged(object sender, System.EventArgs e)
		{
			avatarNum = 5;
		}

		private void R_Avater7_CheckedChanged(object sender, System.EventArgs e)
		{
			avatarNum = 6;
		}

		private void R_Avater8_CheckedChanged(object sender, System.EventArgs e)
		{
			avatarNum = 7;
		}
	}
}
