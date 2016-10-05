using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using BlueMarble;

namespace Dialogs
{
	/// <summary>
	/// CityDialog2에 대한 요약 설명입니다.
	/// </summary>
	public class CityDialog2 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label CName;
		private System.Windows.Forms.Button OK;
		private System.Windows.Forms.Label talk;
		private System.Windows.Forms.Button cancel;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.PictureBox PicFlag;
		private Image flag = Image.FromFile("flags/city"+UserBuffer.BufferInt5+".png");

		public CityDialog2()
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();
			PicFlag.Image = (Image)flag;
			CName.Text = UserBuffer.BufferStr1;

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
			this.CName = new System.Windows.Forms.Label();
			this.OK = new System.Windows.Forms.Button();
			this.talk = new System.Windows.Forms.Label();
			this.cancel = new System.Windows.Forms.Button();
			this.PicFlag = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// CName
			// 
			this.CName.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.CName.Location = new System.Drawing.Point(16, 16);
			this.CName.Name = "CName";
			this.CName.Size = new System.Drawing.Size(176, 72);
			this.CName.TabIndex = 1;
			// 
			// OK
			// 
			this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OK.Location = new System.Drawing.Point(216, 96);
			this.OK.Name = "OK";
			this.OK.Size = new System.Drawing.Size(80, 24);
			this.OK.TabIndex = 2;
			this.OK.Text = "구입하기";
			// 
			// talk
			// 
			this.talk.ForeColor = System.Drawing.Color.Blue;
			this.talk.Location = new System.Drawing.Point(16, 104);
			this.talk.Name = "talk";
			this.talk.Size = new System.Drawing.Size(176, 32);
			this.talk.TabIndex = 3;
			this.talk.Text = "소유자가 없는곳이므로 도시를 구입할 수 있습니다.";
			// 
			// cancel
			// 
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel.Location = new System.Drawing.Point(216, 128);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(80, 24);
			this.cancel.TabIndex = 4;
			this.cancel.Text = "취소";
			// 
			// PicFlag
			// 
			this.PicFlag.Location = new System.Drawing.Point(200, 16);
			this.PicFlag.Name = "PicFlag";
			this.PicFlag.Size = new System.Drawing.Size(100, 66);
			this.PicFlag.TabIndex = 5;
			this.PicFlag.TabStop = false;
			// 
			// CityDialog2
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(314, 164);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.PicFlag,
																		  this.cancel,
																		  this.talk,
																		  this.OK,
																		  this.CName});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CityDialog2";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "도시 구입";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
