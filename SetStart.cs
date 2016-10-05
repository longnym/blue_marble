using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Dialogs
{
	/// <summary>
	/// SetStart에 대한 요약 설명입니다.
	/// </summary>
	public class SetStart : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button StartButton;
		private System.Windows.Forms.TextBox PNameBox1;
		private System.Windows.Forms.TextBox PNameBox2;
		private System.Windows.Forms.TextBox PNameBox3;
		private System.Windows.Forms.TextBox PNameBox4;
		private System.Windows.Forms.Label name1;
		private System.Windows.Forms.Label name2;
		private System.Windows.Forms.Label name3;
		private System.Windows.Forms.Label name4;
		private System.Windows.Forms.GroupBox NamegroupBox;
		private System.Windows.Forms.GroupBox PlayerNumBox;
		public System.Windows.Forms.RadioButton radioButton1;
		public System.Windows.Forms.RadioButton radioButton2;
		public System.Windows.Forms.RadioButton radioButton3;

		public string PlayerName1 = "";
		public string PlayerName2 = "";
		public string PlayerName3 = "";
		public string PlayerName4 = "";
		public int MaxPlayer;
		public int StartMoney = 3000000;

		public int Player1Avatar;
		public int Player2Avatar;
		public int Player3Avatar;
		public int Player4Avatar;

		private System.Windows.Forms.Label MoneyLabel;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Button B_Avater1;
		private System.Windows.Forms.Button B_Avater2;
		private System.Windows.Forms.Button B_Avater3;
		private System.Windows.Forms.Button B_Avater4;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SetStart()
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();
			radioButton1.Checked = true;
			MaxPlayer = 2;

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
			this.StartButton = new System.Windows.Forms.Button();
			this.PNameBox1 = new System.Windows.Forms.TextBox();
			this.PNameBox2 = new System.Windows.Forms.TextBox();
			this.PNameBox3 = new System.Windows.Forms.TextBox();
			this.PNameBox4 = new System.Windows.Forms.TextBox();
			this.name1 = new System.Windows.Forms.Label();
			this.name2 = new System.Windows.Forms.Label();
			this.name3 = new System.Windows.Forms.Label();
			this.name4 = new System.Windows.Forms.Label();
			this.NamegroupBox = new System.Windows.Forms.GroupBox();
			this.PlayerNumBox = new System.Windows.Forms.GroupBox();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.MoneyLabel = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.B_Avater1 = new System.Windows.Forms.Button();
			this.B_Avater2 = new System.Windows.Forms.Button();
			this.B_Avater3 = new System.Windows.Forms.Button();
			this.B_Avater4 = new System.Windows.Forms.Button();
			this.NamegroupBox.SuspendLayout();
			this.PlayerNumBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// StartButton
			// 
			this.StartButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.StartButton.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.StartButton.Location = new System.Drawing.Point(80, 288);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(152, 24);
			this.StartButton.TabIndex = 0;
			this.StartButton.Text = "게임 시작";
			// 
			// PNameBox1
			// 
			this.PNameBox1.Location = new System.Drawing.Point(80, 32);
			this.PNameBox1.Name = "PNameBox1";
			this.PNameBox1.Size = new System.Drawing.Size(144, 21);
			this.PNameBox1.TabIndex = 1;
			this.PNameBox1.Text = "";
			this.PNameBox1.TextChanged += new System.EventHandler(this.PNameBox1_TextChanged);
			// 
			// PNameBox2
			// 
			this.PNameBox2.Location = new System.Drawing.Point(80, 64);
			this.PNameBox2.Name = "PNameBox2";
			this.PNameBox2.Size = new System.Drawing.Size(144, 21);
			this.PNameBox2.TabIndex = 2;
			this.PNameBox2.Text = "";
			this.PNameBox2.TextChanged += new System.EventHandler(this.PNameBox2_TextChanged);
			// 
			// PNameBox3
			// 
			this.PNameBox3.Enabled = false;
			this.PNameBox3.Location = new System.Drawing.Point(80, 96);
			this.PNameBox3.Name = "PNameBox3";
			this.PNameBox3.Size = new System.Drawing.Size(144, 21);
			this.PNameBox3.TabIndex = 3;
			this.PNameBox3.Text = "";
			this.PNameBox3.TextChanged += new System.EventHandler(this.PNameBox3_TextChanged);
			// 
			// PNameBox4
			// 
			this.PNameBox4.Enabled = false;
			this.PNameBox4.Location = new System.Drawing.Point(80, 128);
			this.PNameBox4.Name = "PNameBox4";
			this.PNameBox4.Size = new System.Drawing.Size(144, 21);
			this.PNameBox4.TabIndex = 4;
			this.PNameBox4.Text = "";
			this.PNameBox4.TextChanged += new System.EventHandler(this.PNameBox4_TextChanged);
			// 
			// name1
			// 
			this.name1.Location = new System.Drawing.Point(8, 32);
			this.name1.Name = "name1";
			this.name1.Size = new System.Drawing.Size(64, 16);
			this.name1.TabIndex = 5;
			this.name1.Text = "플레이어1";
			// 
			// name2
			// 
			this.name2.Location = new System.Drawing.Point(8, 64);
			this.name2.Name = "name2";
			this.name2.Size = new System.Drawing.Size(64, 16);
			this.name2.TabIndex = 6;
			this.name2.Text = "플레이어2";
			// 
			// name3
			// 
			this.name3.Location = new System.Drawing.Point(8, 96);
			this.name3.Name = "name3";
			this.name3.Size = new System.Drawing.Size(64, 16);
			this.name3.TabIndex = 7;
			this.name3.Text = "플레이어3";
			// 
			// name4
			// 
			this.name4.Location = new System.Drawing.Point(8, 128);
			this.name4.Name = "name4";
			this.name4.Size = new System.Drawing.Size(64, 16);
			this.name4.TabIndex = 8;
			this.name4.Text = "플레이어4";
			// 
			// NamegroupBox
			// 
			this.NamegroupBox.Controls.AddRange(new System.Windows.Forms.Control[] {
																					   this.B_Avater4,
																					   this.B_Avater3,
																					   this.B_Avater2,
																					   this.B_Avater1,
																					   this.PNameBox1,
																					   this.name1,
																					   this.name2,
																					   this.PNameBox2,
																					   this.name3,
																					   this.PNameBox3,
																					   this.name4,
																					   this.PNameBox4});
			this.NamegroupBox.Location = new System.Drawing.Point(8, 80);
			this.NamegroupBox.Name = "NamegroupBox";
			this.NamegroupBox.Size = new System.Drawing.Size(296, 160);
			this.NamegroupBox.TabIndex = 9;
			this.NamegroupBox.TabStop = false;
			this.NamegroupBox.Text = "플레이어 이름";
			// 
			// PlayerNumBox
			// 
			this.PlayerNumBox.Controls.AddRange(new System.Windows.Forms.Control[] {
																					   this.radioButton3,
																					   this.radioButton2,
																					   this.radioButton1});
			this.PlayerNumBox.Location = new System.Drawing.Point(8, 8);
			this.PlayerNumBox.Name = "PlayerNumBox";
			this.PlayerNumBox.Size = new System.Drawing.Size(296, 64);
			this.PlayerNumBox.TabIndex = 10;
			this.PlayerNumBox.TabStop = false;
			this.PlayerNumBox.Text = "플레이어 수";
			// 
			// radioButton3
			// 
			this.radioButton3.Location = new System.Drawing.Point(232, 32);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(48, 24);
			this.radioButton3.TabIndex = 2;
			this.radioButton3.Text = "4인";
			this.radioButton3.Click += new System.EventHandler(this.radioButton3_Click);
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(128, 32);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(48, 24);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.Text = "3인";
			this.radioButton2.Click += new System.EventHandler(this.radioButton2_Click);
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(24, 32);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(48, 24);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.Text = "2인";
			this.radioButton1.Click += new System.EventHandler(this.radioButton1_Click);
			// 
			// MoneyLabel
			// 
			this.MoneyLabel.Location = new System.Drawing.Point(80, 248);
			this.MoneyLabel.Name = "MoneyLabel";
			this.MoneyLabel.Size = new System.Drawing.Size(48, 16);
			this.MoneyLabel.TabIndex = 11;
			this.MoneyLabel.Text = "소지금";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Increment = new System.Decimal(new int[] {
																			 100000,
																			 0,
																			 0,
																			 0});
			this.numericUpDown1.Location = new System.Drawing.Point(128, 248);
			this.numericUpDown1.Maximum = new System.Decimal(new int[] {
																		   10000000,
																		   0,
																		   0,
																		   0});
			this.numericUpDown1.Minimum = new System.Decimal(new int[] {
																		   1000000,
																		   0,
																		   0,
																		   0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.ReadOnly = true;
			this.numericUpDown1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.numericUpDown1.Size = new System.Drawing.Size(96, 21);
			this.numericUpDown1.TabIndex = 13;
			this.numericUpDown1.Value = new System.Decimal(new int[] {
																		 3000000,
																		 0,
																		 0,
																		 0});
			this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
			// 
			// B_Avater1
			// 
			this.B_Avater1.Location = new System.Drawing.Point(232, 32);
			this.B_Avater1.Name = "B_Avater1";
			this.B_Avater1.Size = new System.Drawing.Size(56, 24);
			this.B_Avater1.TabIndex = 9;
			this.B_Avater1.Text = "아바타";
			this.B_Avater1.Click += new System.EventHandler(this.B_Avater1_Click);
			// 
			// B_Avater2
			// 
			this.B_Avater2.Location = new System.Drawing.Point(232, 64);
			this.B_Avater2.Name = "B_Avater2";
			this.B_Avater2.Size = new System.Drawing.Size(56, 24);
			this.B_Avater2.TabIndex = 10;
			this.B_Avater2.Text = "아바타";
			this.B_Avater2.Click += new System.EventHandler(this.B_Avater2_Click);
			// 
			// B_Avater3
			// 
			this.B_Avater3.Enabled = false;
			this.B_Avater3.Location = new System.Drawing.Point(232, 96);
			this.B_Avater3.Name = "B_Avater3";
			this.B_Avater3.Size = new System.Drawing.Size(56, 24);
			this.B_Avater3.TabIndex = 11;
			this.B_Avater3.Text = "아바타";
			this.B_Avater3.Click += new System.EventHandler(this.B_Avater3_Click);
			// 
			// B_Avater4
			// 
			this.B_Avater4.Enabled = false;
			this.B_Avater4.Location = new System.Drawing.Point(232, 128);
			this.B_Avater4.Name = "B_Avater4";
			this.B_Avater4.Size = new System.Drawing.Size(56, 24);
			this.B_Avater4.TabIndex = 12;
			this.B_Avater4.Text = "아바타";
			this.B_Avater4.Click += new System.EventHandler(this.B_Avater4_Click);
			// 
			// SetStart
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(314, 332);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.numericUpDown1,
																		  this.MoneyLabel,
																		  this.PlayerNumBox,
																		  this.NamegroupBox,
																		  this.StartButton});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SetStart";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "시작 설정";
			this.NamegroupBox.ResumeLayout(false);
			this.PlayerNumBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void radioButton1_Click(object sender, System.EventArgs e)
		{
			PNameBox3.Enabled = false;
			PNameBox4.Enabled = false;
			B_Avater3.Enabled = false;
			B_Avater4.Enabled = false;
			MaxPlayer = 2;
		}

		private void radioButton2_Click(object sender, System.EventArgs e)
		{
			PNameBox3.Enabled = true;
			PNameBox4.Enabled = false;
			B_Avater3.Enabled = true;
			B_Avater4.Enabled = false;
			MaxPlayer = 3;
		}

		private void radioButton3_Click(object sender, System.EventArgs e)
		{
			PNameBox3.Enabled = true;
			PNameBox4.Enabled = true;
			B_Avater3.Enabled = true;
			B_Avater4.Enabled = true;
			MaxPlayer = 4;
		}

		private void PNameBox1_TextChanged(object sender, System.EventArgs e)
		{
			PlayerName1 = PNameBox1.Text;
		}

		private void PNameBox2_TextChanged(object sender, System.EventArgs e)
		{
			PlayerName2 = PNameBox2.Text;
		}

		private void PNameBox3_TextChanged(object sender, System.EventArgs e)
		{
			PlayerName3 = PNameBox3.Text;
		}

		private void PNameBox4_TextChanged(object sender, System.EventArgs e)
		{
			PlayerName4 = PNameBox4.Text;
		}

		private void numericUpDown1_ValueChanged(object sender, System.EventArgs e)
		{
			StartMoney = Convert.ToInt32(numericUpDown1.Value);
		}

		private void B_Avater1_Click(object sender, System.EventArgs e)
		{
			SetAvatar AvatarDlg = new SetAvatar();
			if(AvatarDlg.ShowDialog() == DialogResult.OK)
			{
				Player1Avatar = AvatarDlg.avatarNum;
			}
		}

		private void B_Avater2_Click(object sender, System.EventArgs e)
		{
			SetAvatar AvatarDlg = new SetAvatar();
			if(AvatarDlg.ShowDialog() == DialogResult.OK)
			{
				Player2Avatar = AvatarDlg.avatarNum;
			}
		}

		private void B_Avater3_Click(object sender, System.EventArgs e)
		{
			SetAvatar AvatarDlg = new SetAvatar();
			if(AvatarDlg.ShowDialog() == DialogResult.OK)
			{
				Player3Avatar = AvatarDlg.avatarNum;
			}
		}

		private void B_Avater4_Click(object sender, System.EventArgs e)
		{
			SetAvatar AvatarDlg = new SetAvatar();
			if(AvatarDlg.ShowDialog() == DialogResult.OK)
			{
				Player4Avatar = AvatarDlg.avatarNum;
			}
		}
	}
}
