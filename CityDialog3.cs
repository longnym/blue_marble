using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Dialogs
{
	/// <summary>
	/// CityDialog3에 대한 요약 설명입니다.
	/// </summary>
	public class CityDialog3 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label Message;
		private System.Windows.Forms.Button Sell;
		private System.Windows.Forms.Button Cancel;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CityDialog3()
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();
			Message.Text = "정말 도시를 매각하겠습니까?  \n도시를 매각하면 건물을 포함하여 구입할때 가격의 75%를 받습니다.  ";
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
			this.Sell.Text = "매각";
			// 
			// Cancel
			// 
			this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel.Location = new System.Drawing.Point(336, 48);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(88, 24);
			this.Cancel.TabIndex = 1;
			this.Cancel.Text = "취소";
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
			this.Text = "도시 매각";
			this.ResumeLayout(false);

		}
		#endregion

	}
}
