using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BlueMarble
{
	/// <summary>
	/// WinDialog에 대한 요약 설명입니다.
	/// </summary>
	public class WinDialog : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button OK;
		private System.Windows.Forms.Label L_Win;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public WinDialog()
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();
			L_Win.Text = UserBuffer.winner + "님이 승리하였습니다.";

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
			this.OK.Text = "게임 종료";
			// 
			// L_Win
			// 
			this.L_Win.BackColor = System.Drawing.Color.Transparent;
			this.L_Win.Font = new System.Drawing.Font("바탕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
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
			this.Text = "게임 오버";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
