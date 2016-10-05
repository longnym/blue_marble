using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using BlueMarble;

namespace Dialogs
{
	/// <summary>
	/// CityDialog에 대한 요약 설명입니다.
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
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private Image flag = Image.FromFile("flags/city"+UserBuffer.BufferInt5+".png");

		public CityDialog1()
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			PicFlag.Image = (Image)flag;
			info.Text = UserBuffer.BufferStr3;

			radioButton1.Text = "별장 - " + UserBuffer.BufferInt2 + "원";
			radioButton2.Text = "빌딩 - " + UserBuffer.BufferInt3 + "원";
			radioButton3.Text = "호텔 - " + UserBuffer.BufferInt4 + "원";

			cname.Text = UserBuffer.BufferStr1;
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
			this.OK.Text = "구입하기";
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
			this.Build.Text = "건물 구입";
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
			this.cname.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
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
			this.cancel.Text = "취소";
			// 
			// talk
			// 
			this.talk.ForeColor = System.Drawing.Color.Blue;
			this.talk.Location = new System.Drawing.Point(216, 200);
			this.talk.Name = "talk";
			this.talk.Size = new System.Drawing.Size(128, 40);
			this.talk.TabIndex = 4;
			this.talk.Text = "이미 도시를 소유하고 있으므로 건물을 구입할 수 있습니다.";
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
			this.infobox.Text = "정보";
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
			this.Text = "도시 건물 구입";
			this.Build.ResumeLayout(false);
			this.infobox.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


	}
}
