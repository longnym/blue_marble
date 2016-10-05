using System;
using System.Drawing;
using System.Windows.Forms;
using Dialogs;
using System.Media;
using MediaPlayer;

namespace BlueMarble
{
    public class Board : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem M_Game;
		private System.Windows.Forms.MenuItem M_Help;
		private System.Windows.Forms.MenuItem M_About;
		private System.Windows.Forms.MenuItem M_GameStart;
		private System.Windows.Forms.MenuItem M_GameStop;
		private System.Windows.Forms.MenuItem M_GameSet;
		private System.Windows.Forms.MenuItem M_Exit;
		private System.Windows.Forms.GroupBox G_Player1;
		private System.Windows.Forms.GroupBox G_Player2;
		private System.Windows.Forms.GroupBox G_Player3;
		private System.Windows.Forms.GroupBox G_Player4;
		private System.Windows.Forms.Button B_Roll;
		private System.Windows.Forms.Label L_Player1;
		private System.Windows.Forms.Label L_Player2;
		private System.Windows.Forms.Label L_Player3;
		private System.Windows.Forms.Label L_Player4;
		private System.Windows.Forms.PictureBox BoardPic;
		private System.Windows.Forms.GroupBox CityInfo;
		private System.Windows.Forms.Button Buy;
		private System.Windows.Forms.Button NextPlayer;
		private System.Windows.Forms.Label City1;
		private System.Windows.Forms.Label City2;
		private System.Windows.Forms.Label City3;
		private System.Windows.Forms.Label City4;
		private System.Windows.Forms.Label City5;
		private System.Windows.Forms.Label City6;
		private System.Windows.Forms.Label City7;
		private System.Windows.Forms.Label City8;
		private System.Windows.Forms.Label City9;
		private System.Windows.Forms.Label City10;
		private System.Windows.Forms.Label City11;
		private System.Windows.Forms.Label City12;
		private System.Windows.Forms.Label City13;
		private System.Windows.Forms.Label City14;
		private System.Windows.Forms.Label City15;
		private System.Windows.Forms.Label City16;
		private System.Windows.Forms.Label City17;
		private System.Windows.Forms.Label City18;
		private System.Windows.Forms.Label City19;
		private System.Windows.Forms.Label City20;
		private System.Windows.Forms.Label City21;
		private System.Windows.Forms.Label City22;
		private System.Windows.Forms.Label City23;
		private System.Windows.Forms.Label City24;
		private System.Windows.Forms.Label City25;
		private System.Windows.Forms.Label City26;
		private System.Windows.Forms.Label City27;
		private System.Windows.Forms.Label City28;
		private System.Windows.Forms.PictureBox GoldKey1;
		private System.Windows.Forms.PictureBox GoldKey2;
		private System.Windows.Forms.PictureBox GoldKey3;
		private System.Windows.Forms.PictureBox GoldKey4;
		private System.Windows.Forms.PictureBox GoldKey5;
		private System.Windows.Forms.PictureBox GoldKey6;
		private System.Windows.Forms.PictureBox GoldKey7;
		private System.Windows.Forms.PictureBox P_Start;
		private System.Windows.Forms.PictureBox P_Space;
		private System.Windows.Forms.PictureBox P_Island;
		private System.Windows.Forms.PictureBox P_Fund;
		private System.Windows.Forms.PictureBox P_FundPay;
		private System.Windows.Forms.Button Sell;
		private System.Windows.Forms.PictureBox Logo;
		private System.Windows.Forms.Label Player1Pic;
		private System.Windows.Forms.Label Player2Pic;
		private System.Windows.Forms.Label Player3Pic;
		private System.Windows.Forms.Label Player4Pic;

		private bool m_blnDirectSoundInitialised = false;

		// ������ WAV���� ������ ���� Player ��ü ����
		private MediaPlayerClass m_objSound1;
		private SoundPlayer m_objSound2;
		private SoundPlayer m_SoundSigh;
		private SoundPlayer m_SoundAbout;
		private SoundPlayer m_SoundIsland;
		private SoundPlayer m_SoundAmbulance;
		private SoundPlayer m_SoundLaugh;
		private SoundPlayer m_SoundP;

		private System.ComponentModel.Container components = null;

		// ���ӿ� �ʿ��� Object���� ����
		City[] cities = new City[40];
		Player[] players = new Player[4];
		GameData game = new GameData();
		Card[] cards = new Card[30];
		
		// ī�带 �������� �Ѱ� �� ����
		Card[] deck = new Card[30];

		private bool GameStartCheck;	// ������ ���۵Ǿ��°�?
		private bool CitySellCheck;		// ������ ���� �����Ҷ� ���ø� �ȼ��ֵ��� ����
		private int CardNumber;
		private System.Windows.Forms.PictureBox P_Avatar1;
		private System.Windows.Forms.PictureBox P_Avatar3;
		private System.Windows.Forms.PictureBox P_Avatar2;
		private System.Windows.Forms.PictureBox P_Avatar4;
		private System.Windows.Forms.Label L_CityInfo;
		private System.Windows.Forms.PictureBox CityPhoto;
		private System.Windows.Forms.MenuItem M_Option;
		private System.Windows.Forms.MenuItem M_MusicOn;
		private System.Windows.Forms.MenuItem M_MusicOff;
		private bool GoldKeyCheck;		// ���� Ȳ�ݿ��踦 �����ߴ°�?

		public Board()
		{
			//
			// Windows Form �����̳� ������ �ʿ��մϴ�.
			//
			InitializeComponent();
			// ���� ���� �ʱ�ȭ
			InitialiseSound(this.Handle.ToInt32());
			// ���� ������ �ʱ�ȭ
			DataInitialize();
			// ���� ���� ����
			SetCity();
			// Ȳ�ݿ��� ī�� ���� ����
			SetCard();
			// Ȳ�ݿ��� ī�� ����
			DeckMix();

			Logo.Visible = true;
			CityInfo.Visible = false;
			//
			// TODO: InitializeComponent�� ȣ���� ���� ������ �ڵ带 �߰��մϴ�.
			//
		}

		public void InitialiseSound(int intHandle)
		{
			try
			{
                m_objSound1 = new MediaPlayerClass();
                m_objSound1.FileName = "sound/bgm.wav";
                m_objSound1.Stop();
                m_objSound2 = new SoundPlayer("sound/effect_roll.wav");
				m_SoundLaugh = new SoundPlayer("sound/laugh.wav");
				m_SoundIsland = new SoundPlayer("sound/island.wav");
				m_SoundSigh = new SoundPlayer("sound/sigh.wav");
				m_SoundAmbulance = new SoundPlayer("sound/ambulance.wav");
				m_SoundP = new SoundPlayer("sound/p.wav");
				m_SoundAbout = new SoundPlayer("sound/about.wav");

				m_blnDirectSoundInitialised = true;
			}
			catch(Exception)
			{
				m_blnDirectSoundInitialised = false;

			}
		}

		// ������� ����
		private void PlaySound()
		{
			if(m_blnDirectSoundInitialised)
			{
                m_objSound1.Play();
			}
		}

		/// <summary>
		/// ��� ���� ��� ���ҽ��� �����մϴ�.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Board));
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.M_Game = new System.Windows.Forms.MenuItem();
			this.M_GameStart = new System.Windows.Forms.MenuItem();
			this.M_GameStop = new System.Windows.Forms.MenuItem();
			this.M_GameSet = new System.Windows.Forms.MenuItem();
			this.M_Exit = new System.Windows.Forms.MenuItem();
			this.M_Option = new System.Windows.Forms.MenuItem();
			this.M_MusicOn = new System.Windows.Forms.MenuItem();
			this.M_MusicOff = new System.Windows.Forms.MenuItem();
			this.M_Help = new System.Windows.Forms.MenuItem();
			this.M_About = new System.Windows.Forms.MenuItem();
			this.G_Player1 = new System.Windows.Forms.GroupBox();
			this.P_Avatar1 = new System.Windows.Forms.PictureBox();
			this.L_Player1 = new System.Windows.Forms.Label();
			this.G_Player2 = new System.Windows.Forms.GroupBox();
			this.P_Avatar2 = new System.Windows.Forms.PictureBox();
			this.L_Player2 = new System.Windows.Forms.Label();
			this.G_Player3 = new System.Windows.Forms.GroupBox();
			this.P_Avatar3 = new System.Windows.Forms.PictureBox();
			this.L_Player3 = new System.Windows.Forms.Label();
			this.G_Player4 = new System.Windows.Forms.GroupBox();
			this.P_Avatar4 = new System.Windows.Forms.PictureBox();
			this.L_Player4 = new System.Windows.Forms.Label();
			this.B_Roll = new System.Windows.Forms.Button();
			this.BoardPic = new System.Windows.Forms.PictureBox();
			this.CityInfo = new System.Windows.Forms.GroupBox();
			this.CityPhoto = new System.Windows.Forms.PictureBox();
			this.L_CityInfo = new System.Windows.Forms.Label();
			this.Buy = new System.Windows.Forms.Button();
			this.NextPlayer = new System.Windows.Forms.Button();
			this.City1 = new System.Windows.Forms.Label();
			this.City2 = new System.Windows.Forms.Label();
			this.City3 = new System.Windows.Forms.Label();
			this.City4 = new System.Windows.Forms.Label();
			this.City5 = new System.Windows.Forms.Label();
			this.City6 = new System.Windows.Forms.Label();
			this.City7 = new System.Windows.Forms.Label();
			this.City8 = new System.Windows.Forms.Label();
			this.City9 = new System.Windows.Forms.Label();
			this.City10 = new System.Windows.Forms.Label();
			this.City11 = new System.Windows.Forms.Label();
			this.City12 = new System.Windows.Forms.Label();
			this.City13 = new System.Windows.Forms.Label();
			this.City14 = new System.Windows.Forms.Label();
			this.City15 = new System.Windows.Forms.Label();
			this.City16 = new System.Windows.Forms.Label();
			this.City17 = new System.Windows.Forms.Label();
			this.City18 = new System.Windows.Forms.Label();
			this.City19 = new System.Windows.Forms.Label();
			this.City20 = new System.Windows.Forms.Label();
			this.City21 = new System.Windows.Forms.Label();
			this.City22 = new System.Windows.Forms.Label();
			this.City23 = new System.Windows.Forms.Label();
			this.Logo = new System.Windows.Forms.PictureBox();
			this.City24 = new System.Windows.Forms.Label();
			this.City25 = new System.Windows.Forms.Label();
			this.City26 = new System.Windows.Forms.Label();
			this.City27 = new System.Windows.Forms.Label();
			this.City28 = new System.Windows.Forms.Label();
			this.GoldKey1 = new System.Windows.Forms.PictureBox();
			this.GoldKey2 = new System.Windows.Forms.PictureBox();
			this.GoldKey3 = new System.Windows.Forms.PictureBox();
			this.GoldKey4 = new System.Windows.Forms.PictureBox();
			this.GoldKey5 = new System.Windows.Forms.PictureBox();
			this.GoldKey6 = new System.Windows.Forms.PictureBox();
			this.GoldKey7 = new System.Windows.Forms.PictureBox();
			this.P_Start = new System.Windows.Forms.PictureBox();
			this.P_Space = new System.Windows.Forms.PictureBox();
			this.P_Island = new System.Windows.Forms.PictureBox();
			this.P_Fund = new System.Windows.Forms.PictureBox();
			this.P_FundPay = new System.Windows.Forms.PictureBox();
			this.Sell = new System.Windows.Forms.Button();
			this.Player1Pic = new System.Windows.Forms.Label();
			this.Player2Pic = new System.Windows.Forms.Label();
			this.Player3Pic = new System.Windows.Forms.Label();
			this.Player4Pic = new System.Windows.Forms.Label();
			this.G_Player1.SuspendLayout();
			this.G_Player2.SuspendLayout();
			this.G_Player3.SuspendLayout();
			this.G_Player4.SuspendLayout();
			this.CityInfo.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.M_Game,
																					  this.M_Option,
																					  this.M_Help});
			// 
			// M_Game
			// 
			this.M_Game.Index = 0;
			this.M_Game.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.M_GameStart,
																				   this.M_GameStop,
																				   this.M_GameSet,
																				   this.M_Exit});
			this.M_Game.Text = "����";
			// 
			// M_GameStart
			// 
			this.M_GameStart.Index = 0;
			this.M_GameStart.Text = "���� ����";
			this.M_GameStart.Click += new System.EventHandler(this.M_GameStart_Click);
			// 
			// M_GameStop
			// 
			this.M_GameStop.Index = 1;
			this.M_GameStop.Text = "���� �ߴ�";
			this.M_GameStop.Click += new System.EventHandler(this.M_GameStop_Click);
			// 
			// M_GameSet
			// 
			this.M_GameSet.Index = 2;
			this.M_GameSet.Text = "���� ����";
			this.M_GameSet.Click += new System.EventHandler(this.M_GameSet_Click);
			// 
			// M_Exit
			// 
			this.M_Exit.Index = 3;
			this.M_Exit.Text = "��";
			this.M_Exit.Click += new System.EventHandler(this.M_Exit_Click);
			// 
			// M_Option
			// 
			this.M_Option.Index = 1;
			this.M_Option.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.M_MusicOn,
																					 this.M_MusicOff});
			this.M_Option.Text = "�ɼ�";
			// 
			// M_MusicOn
			// 
			this.M_MusicOn.Index = 0;
			this.M_MusicOn.Text = "���� On";
			this.M_MusicOn.Click += new System.EventHandler(this.M_MusicOn_Click);
			// 
			// M_MusicOff
			// 
			this.M_MusicOff.Index = 1;
			this.M_MusicOff.Text = "���� Off";
			this.M_MusicOff.Click += new System.EventHandler(this.M_MusicOff_Click);
			// 
			// M_Help
			// 
			this.M_Help.Index = 2;
			this.M_Help.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.M_About});
			this.M_Help.Text = "����";
			// 
			// M_About
			// 
			this.M_About.Index = 0;
			this.M_About.Text = "���Ͽ�...";
			this.M_About.Click += new System.EventHandler(this.M_About_Click);
			// 
			// G_Player1
			// 
			this.G_Player1.BackColor = System.Drawing.Color.Transparent;
			this.G_Player1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.P_Avatar1,
																					this.L_Player1});
			this.G_Player1.Font = new System.Drawing.Font("���� ���", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.G_Player1.ForeColor = System.Drawing.Color.White;
			this.G_Player1.Location = new System.Drawing.Point(8, 8);
			this.G_Player1.Name = "G_Player1";
			this.G_Player1.Size = new System.Drawing.Size(184, 328);
			this.G_Player1.TabIndex = 0;
			this.G_Player1.TabStop = false;
			this.G_Player1.Text = "�÷��̾� 1";
			// 
			// P_Avatar1
			// 
			this.P_Avatar1.Location = new System.Drawing.Point(32, 160);
			this.P_Avatar1.Name = "P_Avatar1";
			this.P_Avatar1.Size = new System.Drawing.Size(120, 152);
			this.P_Avatar1.TabIndex = 1;
			this.P_Avatar1.TabStop = false;
			// 
			// L_Player1
			// 
			this.L_Player1.Location = new System.Drawing.Point(8, 24);
			this.L_Player1.Name = "L_Player1";
			this.L_Player1.Size = new System.Drawing.Size(168, 127);
			this.L_Player1.TabIndex = 0;
			// 
			// G_Player2
			// 
			this.G_Player2.BackColor = System.Drawing.Color.Transparent;
			this.G_Player2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.P_Avatar2,
																					this.L_Player2});
			this.G_Player2.Font = new System.Drawing.Font("���� ���", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.G_Player2.ForeColor = System.Drawing.Color.White;
			this.G_Player2.Location = new System.Drawing.Point(824, 8);
			this.G_Player2.Name = "G_Player2";
			this.G_Player2.Size = new System.Drawing.Size(184, 328);
			this.G_Player2.TabIndex = 1;
			this.G_Player2.TabStop = false;
			this.G_Player2.Text = "�÷��̾� 2";
			// 
			// P_Avatar2
			// 
			this.P_Avatar2.Location = new System.Drawing.Point(32, 160);
			this.P_Avatar2.Name = "P_Avatar2";
			this.P_Avatar2.Size = new System.Drawing.Size(120, 152);
			this.P_Avatar2.TabIndex = 6;
			this.P_Avatar2.TabStop = false;
			// 
			// L_Player2
			// 
			this.L_Player2.Location = new System.Drawing.Point(8, 24);
			this.L_Player2.Name = "L_Player2";
			this.L_Player2.Size = new System.Drawing.Size(168, 127);
			this.L_Player2.TabIndex = 5;
			// 
			// G_Player3
			// 
			this.G_Player3.BackColor = System.Drawing.Color.Transparent;
			this.G_Player3.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.P_Avatar3,
																					this.L_Player3});
			this.G_Player3.Font = new System.Drawing.Font("���� ���", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.G_Player3.ForeColor = System.Drawing.Color.White;
			this.G_Player3.Location = new System.Drawing.Point(8, 352);
			this.G_Player3.Name = "G_Player3";
			this.G_Player3.Size = new System.Drawing.Size(184, 328);
			this.G_Player3.TabIndex = 2;
			this.G_Player3.TabStop = false;
			this.G_Player3.Text = "�÷��̾� 3";
			// 
			// P_Avatar3
			// 
			this.P_Avatar3.Location = new System.Drawing.Point(32, 160);
			this.P_Avatar3.Name = "P_Avatar3";
			this.P_Avatar3.Size = new System.Drawing.Size(120, 152);
			this.P_Avatar3.TabIndex = 6;
			this.P_Avatar3.TabStop = false;
			// 
			// L_Player3
			// 
			this.L_Player3.Location = new System.Drawing.Point(8, 24);
			this.L_Player3.Name = "L_Player3";
			this.L_Player3.Size = new System.Drawing.Size(168, 127);
			this.L_Player3.TabIndex = 5;
			// 
			// G_Player4
			// 
			this.G_Player4.BackColor = System.Drawing.Color.Transparent;
			this.G_Player4.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.P_Avatar4,
																					this.L_Player4});
			this.G_Player4.Font = new System.Drawing.Font("���� ���", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.G_Player4.ForeColor = System.Drawing.Color.White;
			this.G_Player4.Location = new System.Drawing.Point(824, 352);
			this.G_Player4.Name = "G_Player4";
			this.G_Player4.Size = new System.Drawing.Size(184, 328);
			this.G_Player4.TabIndex = 3;
			this.G_Player4.TabStop = false;
			this.G_Player4.Text = "�÷��̾� 4";
			// 
			// P_Avatar4
			// 
			this.P_Avatar4.Location = new System.Drawing.Point(32, 160);
			this.P_Avatar4.Name = "P_Avatar4";
			this.P_Avatar4.Size = new System.Drawing.Size(120, 152);
			this.P_Avatar4.TabIndex = 6;
			this.P_Avatar4.TabStop = false;
			// 
			// L_Player4
			// 
			this.L_Player4.Location = new System.Drawing.Point(8, 24);
			this.L_Player4.Name = "L_Player4";
			this.L_Player4.Size = new System.Drawing.Size(168, 127);
			this.L_Player4.TabIndex = 5;
			// 
			// B_Roll
			// 
			this.B_Roll.BackColor = System.Drawing.Color.Transparent;
			this.B_Roll.Font = new System.Drawing.Font("���� ���", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.B_Roll.ForeColor = System.Drawing.Color.White;
			this.B_Roll.Location = new System.Drawing.Point(200, 16);
			this.B_Roll.Name = "B_Roll";
			this.B_Roll.Size = new System.Drawing.Size(144, 32);
			this.B_Roll.TabIndex = 4;
			this.B_Roll.Text = "�ֻ��� ������";
			this.B_Roll.Click += new System.EventHandler(this.B_Roll_Click);
			// 
			// BoardPic
			// 
			this.BoardPic.BackColor = System.Drawing.Color.Transparent;
			this.BoardPic.Image = ((System.Drawing.Bitmap)(resources.GetObject("BoardPic.Image")));
			this.BoardPic.Location = new System.Drawing.Point(200, 56);
			this.BoardPic.Name = "BoardPic";
			this.BoardPic.Size = new System.Drawing.Size(616, 616);
			this.BoardPic.TabIndex = 5;
			this.BoardPic.TabStop = false;
			// 
			// CityInfo
			// 
			this.CityInfo.BackColor = System.Drawing.Color.Transparent;
			this.CityInfo.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.CityPhoto,
																				   this.L_CityInfo});
			this.CityInfo.Font = new System.Drawing.Font("���� ���", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.CityInfo.ForeColor = System.Drawing.Color.Lime;
			this.CityInfo.Location = new System.Drawing.Point(304, 160);
			this.CityInfo.Name = "CityInfo";
			this.CityInfo.Size = new System.Drawing.Size(408, 408);
			this.CityInfo.TabIndex = 6;
			this.CityInfo.TabStop = false;
			this.CityInfo.Text = "��������";
			this.CityInfo.Visible = false;
			// 
			// CityPhoto
			// 
			this.CityPhoto.Location = new System.Drawing.Point(112, 224);
			this.CityPhoto.Name = "CityPhoto";
			this.CityPhoto.Size = new System.Drawing.Size(280, 168);
			this.CityPhoto.TabIndex = 1;
			this.CityPhoto.TabStop = false;
			// 
			// L_CityInfo
			// 
			this.L_CityInfo.Location = new System.Drawing.Point(16, 32);
			this.L_CityInfo.Name = "L_CityInfo";
			this.L_CityInfo.Size = new System.Drawing.Size(376, 360);
			this.L_CityInfo.TabIndex = 0;
			// 
			// Buy
			// 
			this.Buy.BackColor = System.Drawing.Color.Transparent;
			this.Buy.Enabled = false;
			this.Buy.Font = new System.Drawing.Font("���� ���", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.Buy.Location = new System.Drawing.Point(360, 16);
			this.Buy.Name = "Buy";
			this.Buy.Size = new System.Drawing.Size(144, 32);
			this.Buy.TabIndex = 11;
			this.Buy.Text = "����/�ǹ� ����";
			this.Buy.Click += new System.EventHandler(this.Buy_Click);
			// 
			// NextPlayer
			// 
			this.NextPlayer.BackColor = System.Drawing.Color.Transparent;
			this.NextPlayer.Enabled = false;
			this.NextPlayer.Font = new System.Drawing.Font("���� ���", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.NextPlayer.Location = new System.Drawing.Point(672, 16);
			this.NextPlayer.Name = "NextPlayer";
			this.NextPlayer.Size = new System.Drawing.Size(144, 32);
			this.NextPlayer.TabIndex = 12;
			this.NextPlayer.Text = "���� �÷��̾�";
			this.NextPlayer.Click += new System.EventHandler(this.NextPlayer_Click);
			// 
			// City1
			// 
			this.City1.BackColor = System.Drawing.Color.White;
			this.City1.Font = new System.Drawing.Font("���� ���", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City1.ForeColor = System.Drawing.Color.Black;
			this.City1.Location = new System.Drawing.Point(680, 616);
			this.City1.Name = "City1";
			this.City1.Size = new System.Drawing.Size(40, 48);
			this.City1.TabIndex = 13;
			this.City1.Click += new System.EventHandler(this.City1_Click);
			// 
			// City2
			// 
			this.City2.Font = new System.Drawing.Font("���� ���", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City2.ForeColor = System.Drawing.Color.Black;
			this.City2.Location = new System.Drawing.Point(584, 616);
			this.City2.Name = "City2";
			this.City2.Size = new System.Drawing.Size(40, 48);
			this.City2.TabIndex = 15;
			this.City2.Click += new System.EventHandler(this.City2_Click);
			// 
			// City3
			// 
			this.City3.Font = new System.Drawing.Font("���� ���", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City3.ForeColor = System.Drawing.Color.Black;
			this.City3.Location = new System.Drawing.Point(536, 616);
			this.City3.Name = "City3";
			this.City3.Size = new System.Drawing.Size(40, 48);
			this.City3.TabIndex = 16;
			this.City3.Click += new System.EventHandler(this.City3_Click);
			// 
			// City4
			// 
			this.City4.Font = new System.Drawing.Font("���� ���", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City4.ForeColor = System.Drawing.Color.Black;
			this.City4.Location = new System.Drawing.Point(488, 616);
			this.City4.Name = "City4";
			this.City4.Size = new System.Drawing.Size(40, 48);
			this.City4.TabIndex = 18;
			this.City4.Click += new System.EventHandler(this.City4_Click);
			// 
			// City5
			// 
			this.City5.Font = new System.Drawing.Font("���� ���", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City5.ForeColor = System.Drawing.Color.Black;
			this.City5.Location = new System.Drawing.Point(440, 616);
			this.City5.Name = "City5";
			this.City5.Size = new System.Drawing.Size(40, 48);
			this.City5.TabIndex = 20;
			this.City5.Click += new System.EventHandler(this.City5_Click);
			// 
			// City6
			// 
			this.City6.Font = new System.Drawing.Font("���� ���", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City6.ForeColor = System.Drawing.Color.Black;
			this.City6.Location = new System.Drawing.Point(344, 616);
			this.City6.Name = "City6";
			this.City6.Size = new System.Drawing.Size(40, 48);
			this.City6.TabIndex = 21;
			this.City6.Click += new System.EventHandler(this.City6_Click);
			// 
			// City7
			// 
			this.City7.Font = new System.Drawing.Font("���� ���", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City7.ForeColor = System.Drawing.Color.Black;
			this.City7.Location = new System.Drawing.Point(296, 616);
			this.City7.Name = "City7";
			this.City7.Size = new System.Drawing.Size(40, 48);
			this.City7.TabIndex = 22;
			this.City7.Click += new System.EventHandler(this.City7_Click);
			// 
			// City8
			// 
			this.City8.Font = new System.Drawing.Font("���� ���", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City8.ForeColor = System.Drawing.Color.Black;
			this.City8.Location = new System.Drawing.Point(208, 536);
			this.City8.Name = "City8";
			this.City8.Size = new System.Drawing.Size(48, 40);
			this.City8.TabIndex = 24;
			this.City8.Click += new System.EventHandler(this.City8_Click);
			// 
			// City9
			// 
			this.City9.Font = new System.Drawing.Font("���� ���", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City9.ForeColor = System.Drawing.Color.Black;
			this.City9.Location = new System.Drawing.Point(208, 440);
			this.City9.Name = "City9";
			this.City9.Size = new System.Drawing.Size(48, 40);
			this.City9.TabIndex = 25;
			this.City9.Click += new System.EventHandler(this.City9_Click);
			// 
			// City10
			// 
			this.City10.Font = new System.Drawing.Font("���� ���", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City10.ForeColor = System.Drawing.Color.Black;
			this.City10.Location = new System.Drawing.Point(208, 392);
			this.City10.Name = "City10";
			this.City10.Size = new System.Drawing.Size(48, 40);
			this.City10.TabIndex = 27;
			this.City10.Click += new System.EventHandler(this.City10_Click);
			// 
			// City11
			// 
			this.City11.Font = new System.Drawing.Font("���� ���", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City11.ForeColor = System.Drawing.Color.Black;
			this.City11.Location = new System.Drawing.Point(208, 344);
			this.City11.Name = "City11";
			this.City11.Size = new System.Drawing.Size(80, 40);
			this.City11.TabIndex = 29;
			this.City11.Click += new System.EventHandler(this.City11_Click);
			// 
			// City12
			// 
			this.City12.Font = new System.Drawing.Font("���� ���", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City12.ForeColor = System.Drawing.Color.Black;
			this.City12.Location = new System.Drawing.Point(208, 296);
			this.City12.Name = "City12";
			this.City12.Size = new System.Drawing.Size(48, 40);
			this.City12.TabIndex = 30;
			this.City12.Click += new System.EventHandler(this.City12_Click);
			// 
			// City13
			// 
			this.City13.Font = new System.Drawing.Font("���� ���", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City13.ForeColor = System.Drawing.Color.Black;
			this.City13.Location = new System.Drawing.Point(208, 200);
			this.City13.Name = "City13";
			this.City13.Size = new System.Drawing.Size(48, 40);
			this.City13.TabIndex = 31;
			this.City13.Click += new System.EventHandler(this.City13_Click);
			// 
			// City14
			// 
			this.City14.Font = new System.Drawing.Font("���� ���", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City14.ForeColor = System.Drawing.Color.Black;
			this.City14.Location = new System.Drawing.Point(208, 152);
			this.City14.Name = "City14";
			this.City14.Size = new System.Drawing.Size(48, 40);
			this.City14.TabIndex = 33;
			this.City14.Click += new System.EventHandler(this.City14_Click);
			// 
			// City15
			// 
			this.City15.Font = new System.Drawing.Font("���� ���", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City15.ForeColor = System.Drawing.Color.Black;
			this.City15.Location = new System.Drawing.Point(296, 64);
			this.City15.Name = "City15";
			this.City15.Size = new System.Drawing.Size(40, 48);
			this.City15.TabIndex = 34;
			this.City15.Click += new System.EventHandler(this.City15_Click);
			// 
			// City16
			// 
			this.City16.Font = new System.Drawing.Font("���� ���", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City16.ForeColor = System.Drawing.Color.Black;
			this.City16.Location = new System.Drawing.Point(392, 64);
			this.City16.Name = "City16";
			this.City16.Size = new System.Drawing.Size(40, 48);
			this.City16.TabIndex = 36;
			this.City16.Click += new System.EventHandler(this.City16_Click);
			// 
			// City17
			// 
			this.City17.Font = new System.Drawing.Font("���� ���", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City17.ForeColor = System.Drawing.Color.Black;
			this.City17.Location = new System.Drawing.Point(440, 64);
			this.City17.Name = "City17";
			this.City17.Size = new System.Drawing.Size(40, 48);
			this.City17.TabIndex = 37;
			this.City17.Click += new System.EventHandler(this.City17_Click);
			// 
			// City18
			// 
			this.City18.Font = new System.Drawing.Font("���� ���", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City18.ForeColor = System.Drawing.Color.Black;
			this.City18.Location = new System.Drawing.Point(488, 64);
			this.City18.Name = "City18";
			this.City18.Size = new System.Drawing.Size(40, 48);
			this.City18.TabIndex = 39;
			this.City18.Click += new System.EventHandler(this.City18_Click);
			// 
			// City19
			// 
			this.City19.Font = new System.Drawing.Font("���� ���", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City19.ForeColor = System.Drawing.Color.Black;
			this.City19.Location = new System.Drawing.Point(536, 64);
			this.City19.Name = "City19";
			this.City19.Size = new System.Drawing.Size(40, 48);
			this.City19.TabIndex = 40;
			this.City19.Click += new System.EventHandler(this.City19_Click);
			// 
			// City20
			// 
			this.City20.Font = new System.Drawing.Font("���� ���", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City20.ForeColor = System.Drawing.Color.Black;
			this.City20.Location = new System.Drawing.Point(584, 64);
			this.City20.Name = "City20";
			this.City20.Size = new System.Drawing.Size(40, 48);
			this.City20.TabIndex = 42;
			this.City20.Click += new System.EventHandler(this.City20_Click);
			// 
			// City21
			// 
			this.City21.Font = new System.Drawing.Font("���� ���", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City21.ForeColor = System.Drawing.Color.Black;
			this.City21.Location = new System.Drawing.Point(680, 64);
			this.City21.Name = "City21";
			this.City21.Size = new System.Drawing.Size(40, 48);
			this.City21.TabIndex = 43;
			this.City21.Click += new System.EventHandler(this.City21_Click);
			// 
			// City22
			// 
			this.City22.Font = new System.Drawing.Font("���� ���", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City22.ForeColor = System.Drawing.Color.Black;
			this.City22.Location = new System.Drawing.Point(760, 152);
			this.City22.Name = "City22";
			this.City22.Size = new System.Drawing.Size(48, 40);
			this.City22.TabIndex = 45;
			this.City22.Click += new System.EventHandler(this.City22_Click);
			// 
			// City23
			// 
			this.City23.Font = new System.Drawing.Font("���� ���", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City23.ForeColor = System.Drawing.Color.Black;
			this.City23.Location = new System.Drawing.Point(728, 200);
			this.City23.Name = "City23";
			this.City23.Size = new System.Drawing.Size(80, 40);
			this.City23.TabIndex = 46;
			this.City23.Click += new System.EventHandler(this.City23_Click);
			// 
			// Logo
			// 
			this.Logo.Image = ((System.Drawing.Bitmap)(resources.GetObject("Logo.Image")));
			this.Logo.Location = new System.Drawing.Point(296, 152);
			this.Logo.Name = "Logo";
			this.Logo.Size = new System.Drawing.Size(424, 424);
			this.Logo.TabIndex = 47;
			this.Logo.TabStop = false;
			// 
			// City24
			// 
			this.City24.Font = new System.Drawing.Font("���� ���", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City24.ForeColor = System.Drawing.Color.Black;
			this.City24.Location = new System.Drawing.Point(760, 248);
			this.City24.Name = "City24";
			this.City24.Size = new System.Drawing.Size(48, 40);
			this.City24.TabIndex = 48;
			this.City24.Click += new System.EventHandler(this.City24_Click);
			// 
			// City25
			// 
			this.City25.Font = new System.Drawing.Font("���� ���", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City25.ForeColor = System.Drawing.Color.Black;
			this.City25.Location = new System.Drawing.Point(760, 296);
			this.City25.Name = "City25";
			this.City25.Size = new System.Drawing.Size(48, 40);
			this.City25.TabIndex = 49;
			this.City25.Click += new System.EventHandler(this.City25_Click);
			// 
			// City26
			// 
			this.City26.Font = new System.Drawing.Font("���� ���", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City26.ForeColor = System.Drawing.Color.Black;
			this.City26.Location = new System.Drawing.Point(760, 392);
			this.City26.Name = "City26";
			this.City26.Size = new System.Drawing.Size(48, 40);
			this.City26.TabIndex = 50;
			this.City26.Click += new System.EventHandler(this.City26_Click);
			// 
			// City27
			// 
			this.City27.Font = new System.Drawing.Font("���� ���", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City27.ForeColor = System.Drawing.Color.Black;
			this.City27.Location = new System.Drawing.Point(760, 440);
			this.City27.Name = "City27";
			this.City27.Size = new System.Drawing.Size(48, 40);
			this.City27.TabIndex = 51;
			this.City27.Click += new System.EventHandler(this.City27_Click);
			// 
			// City28
			// 
			this.City28.Font = new System.Drawing.Font("���� ���", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City28.ForeColor = System.Drawing.Color.Black;
			this.City28.Location = new System.Drawing.Point(760, 536);
			this.City28.Name = "City28";
			this.City28.Size = new System.Drawing.Size(48, 40);
			this.City28.TabIndex = 52;
			this.City28.Click += new System.EventHandler(this.City28_Click);
			// 
			// GoldKey1
			// 
			this.GoldKey1.Image = ((System.Drawing.Bitmap)(resources.GetObject("GoldKey1.Image")));
			this.GoldKey1.Location = new System.Drawing.Point(632, 584);
			this.GoldKey1.Name = "GoldKey1";
			this.GoldKey1.Size = new System.Drawing.Size(40, 80);
			this.GoldKey1.TabIndex = 53;
			this.GoldKey1.TabStop = false;
			this.GoldKey1.Click += new System.EventHandler(this.GoldKey1_Click);
			// 
			// GoldKey2
			// 
			this.GoldKey2.Image = ((System.Drawing.Bitmap)(resources.GetObject("GoldKey2.Image")));
			this.GoldKey2.Location = new System.Drawing.Point(392, 584);
			this.GoldKey2.Name = "GoldKey2";
			this.GoldKey2.Size = new System.Drawing.Size(40, 80);
			this.GoldKey2.TabIndex = 54;
			this.GoldKey2.TabStop = false;
			this.GoldKey2.Click += new System.EventHandler(this.GoldKey2_Click);
			// 
			// GoldKey3
			// 
			this.GoldKey3.Image = ((System.Drawing.Bitmap)(resources.GetObject("GoldKey3.Image")));
			this.GoldKey3.Location = new System.Drawing.Point(208, 488);
			this.GoldKey3.Name = "GoldKey3";
			this.GoldKey3.Size = new System.Drawing.Size(80, 40);
			this.GoldKey3.TabIndex = 55;
			this.GoldKey3.TabStop = false;
			this.GoldKey3.Click += new System.EventHandler(this.GoldKey3_Click);
			// 
			// GoldKey4
			// 
			this.GoldKey4.Image = ((System.Drawing.Bitmap)(resources.GetObject("GoldKey4.Image")));
			this.GoldKey4.Location = new System.Drawing.Point(208, 248);
			this.GoldKey4.Name = "GoldKey4";
			this.GoldKey4.Size = new System.Drawing.Size(80, 40);
			this.GoldKey4.TabIndex = 57;
			this.GoldKey4.TabStop = false;
			this.GoldKey4.Click += new System.EventHandler(this.GoldKey4_Click);
			// 
			// GoldKey5
			// 
			this.GoldKey5.Image = ((System.Drawing.Bitmap)(resources.GetObject("GoldKey5.Image")));
			this.GoldKey5.Location = new System.Drawing.Point(344, 64);
			this.GoldKey5.Name = "GoldKey5";
			this.GoldKey5.Size = new System.Drawing.Size(40, 80);
			this.GoldKey5.TabIndex = 58;
			this.GoldKey5.TabStop = false;
			this.GoldKey5.Click += new System.EventHandler(this.GoldKey5_Click);
			// 
			// GoldKey6
			// 
			this.GoldKey6.Image = ((System.Drawing.Bitmap)(resources.GetObject("GoldKey6.Image")));
			this.GoldKey6.Location = new System.Drawing.Point(632, 64);
			this.GoldKey6.Name = "GoldKey6";
			this.GoldKey6.Size = new System.Drawing.Size(40, 80);
			this.GoldKey6.TabIndex = 59;
			this.GoldKey6.TabStop = false;
			this.GoldKey6.Click += new System.EventHandler(this.GoldKey6_Click);
			// 
			// GoldKey7
			// 
			this.GoldKey7.Image = ((System.Drawing.Bitmap)(resources.GetObject("GoldKey7.Image")));
			this.GoldKey7.Location = new System.Drawing.Point(728, 344);
			this.GoldKey7.Name = "GoldKey7";
			this.GoldKey7.Size = new System.Drawing.Size(80, 40);
			this.GoldKey7.TabIndex = 60;
			this.GoldKey7.TabStop = false;
			this.GoldKey7.Click += new System.EventHandler(this.GoldKey7_Click);
			// 
			// P_Start
			// 
			this.P_Start.Image = ((System.Drawing.Bitmap)(resources.GetObject("P_Start.Image")));
			this.P_Start.Location = new System.Drawing.Point(728, 584);
			this.P_Start.Name = "P_Start";
			this.P_Start.Size = new System.Drawing.Size(80, 80);
			this.P_Start.TabIndex = 61;
			this.P_Start.TabStop = false;
			this.P_Start.Click += new System.EventHandler(this.P_Start_Click);
			// 
			// P_Space
			// 
			this.P_Space.Image = ((System.Drawing.Bitmap)(resources.GetObject("P_Space.Image")));
			this.P_Space.Location = new System.Drawing.Point(208, 584);
			this.P_Space.Name = "P_Space";
			this.P_Space.Size = new System.Drawing.Size(80, 80);
			this.P_Space.TabIndex = 62;
			this.P_Space.TabStop = false;
			this.P_Space.Click += new System.EventHandler(this.P_Space_Click);
			// 
			// P_Island
			// 
			this.P_Island.Image = ((System.Drawing.Bitmap)(resources.GetObject("P_Island.Image")));
			this.P_Island.Location = new System.Drawing.Point(208, 64);
			this.P_Island.Name = "P_Island";
			this.P_Island.Size = new System.Drawing.Size(80, 80);
			this.P_Island.TabIndex = 63;
			this.P_Island.TabStop = false;
			this.P_Island.Click += new System.EventHandler(this.P_Island_Click);
			// 
			// P_Fund
			// 
			this.P_Fund.Image = ((System.Drawing.Bitmap)(resources.GetObject("P_Fund.Image")));
			this.P_Fund.Location = new System.Drawing.Point(728, 64);
			this.P_Fund.Name = "P_Fund";
			this.P_Fund.Size = new System.Drawing.Size(80, 80);
			this.P_Fund.TabIndex = 64;
			this.P_Fund.TabStop = false;
			this.P_Fund.Click += new System.EventHandler(this.P_Fund_Click);
			// 
			// P_FundPay
			// 
			this.P_FundPay.Image = ((System.Drawing.Bitmap)(resources.GetObject("P_FundPay.Image")));
			this.P_FundPay.Location = new System.Drawing.Point(728, 488);
			this.P_FundPay.Name = "P_FundPay";
			this.P_FundPay.Size = new System.Drawing.Size(80, 40);
			this.P_FundPay.TabIndex = 65;
			this.P_FundPay.TabStop = false;
			this.P_FundPay.Click += new System.EventHandler(this.P_FundPay_Click);
			// 
			// Sell
			// 
			this.Sell.BackColor = System.Drawing.Color.Transparent;
			this.Sell.Enabled = false;
			this.Sell.Font = new System.Drawing.Font("���� ���", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.Sell.Location = new System.Drawing.Point(512, 16);
			this.Sell.Name = "Sell";
			this.Sell.Size = new System.Drawing.Size(144, 32);
			this.Sell.TabIndex = 66;
			this.Sell.Text = "���� �Ű�";
			this.Sell.Click += new System.EventHandler(this.Sell_Click);
			// 
			// Player1Pic
			// 
			this.Player1Pic.BackColor = System.Drawing.Color.Red;
			this.Player1Pic.Font = new System.Drawing.Font("���� ���", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.Player1Pic.Location = new System.Drawing.Point(752, 608);
			this.Player1Pic.Name = "Player1Pic";
			this.Player1Pic.Size = new System.Drawing.Size(16, 16);
			this.Player1Pic.TabIndex = 67;
			this.Player1Pic.Text = "1";
			this.Player1Pic.Visible = false;
			// 
			// Player2Pic
			// 
			this.Player2Pic.BackColor = System.Drawing.Color.Blue;
			this.Player2Pic.Font = new System.Drawing.Font("���� ���", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.Player2Pic.Location = new System.Drawing.Point(776, 608);
			this.Player2Pic.Name = "Player2Pic";
			this.Player2Pic.Size = new System.Drawing.Size(16, 16);
			this.Player2Pic.TabIndex = 68;
			this.Player2Pic.Text = "2";
			this.Player2Pic.Visible = false;
			// 
			// Player3Pic
			// 
			this.Player3Pic.BackColor = System.Drawing.Color.Yellow;
			this.Player3Pic.Font = new System.Drawing.Font("���� ���", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.Player3Pic.ForeColor = System.Drawing.Color.Black;
			this.Player3Pic.Location = new System.Drawing.Point(752, 632);
			this.Player3Pic.Name = "Player3Pic";
			this.Player3Pic.Size = new System.Drawing.Size(16, 16);
			this.Player3Pic.TabIndex = 69;
			this.Player3Pic.Text = "3";
			this.Player3Pic.Visible = false;
			// 
			// Player4Pic
			// 
			this.Player4Pic.BackColor = System.Drawing.Color.Green;
			this.Player4Pic.Font = new System.Drawing.Font("���� ���", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.Player4Pic.Location = new System.Drawing.Point(776, 632);
			this.Player4Pic.Name = "Player4Pic";
			this.Player4Pic.Size = new System.Drawing.Size(16, 16);
			this.Player4Pic.TabIndex = 70;
			this.Player4Pic.Text = "4";
			this.Player4Pic.Visible = false;
			// 
			// Board
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.White;
			this.BackgroundImage = ((System.Drawing.Bitmap)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(1018, 719);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.Player4Pic,
																		  this.Player3Pic,
																		  this.Player2Pic,
																		  this.Player1Pic,
																		  this.Sell,
																		  this.P_FundPay,
																		  this.P_Fund,
																		  this.P_Island,
																		  this.P_Space,
																		  this.P_Start,
																		  this.GoldKey7,
																		  this.GoldKey6,
																		  this.GoldKey5,
																		  this.GoldKey4,
																		  this.GoldKey3,
																		  this.GoldKey2,
																		  this.GoldKey1,
																		  this.City28,
																		  this.City27,
																		  this.City26,
																		  this.City25,
																		  this.City24,
																		  this.City23,
																		  this.City22,
																		  this.City21,
																		  this.City20,
																		  this.City19,
																		  this.City18,
																		  this.City17,
																		  this.City16,
																		  this.City15,
																		  this.City14,
																		  this.City13,
																		  this.City12,
																		  this.City11,
																		  this.City10,
																		  this.City9,
																		  this.City8,
																		  this.City7,
																		  this.City6,
																		  this.City5,
																		  this.City4,
																		  this.City3,
																		  this.City2,
																		  this.City1,
																		  this.NextPlayer,
																		  this.Buy,
																		  this.CityInfo,
																		  this.B_Roll,
																		  this.G_Player4,
																		  this.G_Player3,
																		  this.G_Player2,
																		  this.G_Player1,
																		  this.Logo,
																		  this.BoardPic});
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Menu = this.mainMenu1;
			this.Name = "Board";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "�η縶�� ü����";
			this.G_Player1.ResumeLayout(false);
			this.G_Player2.ResumeLayout(false);
			this.G_Player3.ResumeLayout(false);
			this.G_Player4.ResumeLayout(false);
			this.CityInfo.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// �ش� ���� ���α׷��� �� �������Դϴ�.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Board());
		}

		// ���� ������ �����ڸ� ����� ǥ��
		#region ViewCityHave
		private void ViewCityHave()
		{
		
			if(cities[1].CityHave == -1)
				City1.BackColor = Color.White;
			if(cities[1].CityHave == 0)
				City1.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(200)), ((System.Byte)(200)));
			if(cities[1].CityHave == 1)
				City1.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(200)), ((System.Byte)(255)));
			if(cities[1].CityHave == 2)
				City1.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[1].CityHave == 3)
				City1.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[3].CityHave == -1)
				City2.BackColor = Color.White;
			if(cities[3].CityHave == 0)
				City2.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(200)), ((System.Byte)(200)));
			if(cities[3].CityHave == 1)
				City2.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(200)), ((System.Byte)(255)));
			if(cities[3].CityHave == 2)
				City2.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[3].CityHave == 3)
				City2.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[4].CityHave == -1)
				City3.BackColor = Color.White;
			if(cities[4].CityHave == 0)
				City3.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(200)), ((System.Byte)(200)));
			if(cities[4].CityHave == 1)
				City3.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(200)), ((System.Byte)(255)));
			if(cities[4].CityHave == 2)
				City3.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[4].CityHave == 3)
				City3.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[5].CityHave == -1)
				City4.BackColor = Color.White;
			if(cities[5].CityHave == 0)
				City4.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(200)), ((System.Byte)(200)));
			if(cities[5].CityHave == 1)
				City4.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(200)), ((System.Byte)(255)));
			if(cities[5].CityHave == 2)
				City4.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[5].CityHave == 3)
				City4.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[6].CityHave == -1)
				City5.BackColor = Color.White;
			if(cities[6].CityHave == 0)
				City5.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(200)), ((System.Byte)(200)));
			if(cities[6].CityHave == 1)
				City5.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(200)), ((System.Byte)(255)));
			if(cities[6].CityHave == 2)
				City5.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[6].CityHave == 3)
				City5.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[8].CityHave == -1)
				City6.BackColor = Color.White;
			if(cities[8].CityHave == 0)
				City6.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(200)), ((System.Byte)(200)));
			if(cities[8].CityHave == 1)
				City6.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(200)), ((System.Byte)(255)));
			if(cities[8].CityHave == 2)
				City6.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[8].CityHave == 3)
				City6.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[9].CityHave == -1)
				City7.BackColor = Color.White;
			if(cities[9].CityHave == 0)
				City7.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(200)), ((System.Byte)(200)));
			if(cities[9].CityHave == 1)
				City7.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(200)), ((System.Byte)(255)));
			if(cities[9].CityHave == 2)
				City7.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[9].CityHave == 3)
				City7.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[11].CityHave == -1)
				City8.BackColor = Color.White;
			if(cities[11].CityHave == 0)
				City8.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(200)), ((System.Byte)(200)));
			if(cities[11].CityHave == 1)
				City8.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(200)), ((System.Byte)(255)));
			if(cities[11].CityHave == 2)
				City8.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[11].CityHave == 3)
				City8.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[13].CityHave == -1)
				City9.BackColor = Color.White;
			if(cities[13].CityHave == 0)
				City9.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(200)), ((System.Byte)(200)));
			if(cities[13].CityHave == 1)
				City9.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(200)), ((System.Byte)(255)));
			if(cities[13].CityHave == 2)
				City9.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[13].CityHave == 3)
				City9.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[14].CityHave == -1)
				City10.BackColor = Color.White;
			if(cities[14].CityHave == 0)
				City10.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(200)), ((System.Byte)(200)));
			if(cities[14].CityHave == 1)
				City10.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(200)), ((System.Byte)(255)));
			if(cities[14].CityHave == 2)
				City10.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[14].CityHave == 3)
				City10.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[15].CityHave == -1)
				City11.BackColor = Color.White;
			if(cities[15].CityHave == 0)
				City11.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(200)), ((System.Byte)(200)));
			if(cities[15].CityHave == 1)
				City11.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(200)), ((System.Byte)(255)));
			if(cities[15].CityHave == 2)
				City11.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[15].CityHave == 3)
				City11.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[16].CityHave == -1)
				City12.BackColor = Color.White;
			if(cities[16].CityHave == 0)
				City12.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(200)), ((System.Byte)(200)));
			if(cities[16].CityHave == 1)
				City12.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(200)), ((System.Byte)(255)));
			if(cities[16].CityHave == 2)
				City12.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[16].CityHave == 3)
				City12.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[18].CityHave == -1)
				City13.BackColor = Color.White;
			if(cities[18].CityHave == 0)
				City13.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(200)), ((System.Byte)(200)));
			if(cities[18].CityHave == 1)
				City13.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(200)), ((System.Byte)(255)));
			if(cities[18].CityHave == 2)
				City13.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[18].CityHave == 3)
				City13.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[19].CityHave == -1)
				City14.BackColor = Color.White;
			if(cities[19].CityHave == 0)
				City14.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(200)), ((System.Byte)(200)));
			if(cities[19].CityHave == 1)
				City14.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(200)), ((System.Byte)(255)));
			if(cities[19].CityHave == 2)
				City14.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[19].CityHave == 3)
				City14.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[21].CityHave == -1)
				City15.BackColor = Color.White;
			if(cities[21].CityHave == 0)
				City15.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(200)), ((System.Byte)(200)));
			if(cities[21].CityHave == 1)
				City15.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(200)), ((System.Byte)(255)));
			if(cities[21].CityHave == 2)
				City15.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[21].CityHave == 3)
				City15.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[23].CityHave == -1)
				City16.BackColor = Color.White;
			if(cities[23].CityHave == 0)
				City16.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(200)), ((System.Byte)(200)));
			if(cities[23].CityHave == 1)
				City16.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(200)), ((System.Byte)(255)));
			if(cities[23].CityHave == 2)
				City16.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[23].CityHave == 3)
				City16.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[24].CityHave == -1)
				City17.BackColor = Color.White;
			if(cities[24].CityHave == 0)
				City17.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(200)), ((System.Byte)(200)));
			if(cities[24].CityHave == 1)
				City17.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(200)), ((System.Byte)(255)));
			if(cities[24].CityHave == 2)
				City17.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[24].CityHave == 3)
				City17.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[25].CityHave == -1)
				City18.BackColor = Color.White;
			if(cities[25].CityHave == 0)
				City18.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(200)), ((System.Byte)(200)));
			if(cities[25].CityHave == 1)
				City18.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(200)), ((System.Byte)(255)));
			if(cities[25].CityHave == 2)
				City18.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[25].CityHave == 3)
				City18.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[26].CityHave == -1)
				City19.BackColor = Color.White;
			if(cities[26].CityHave == 0)
				City19.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(200)), ((System.Byte)(200)));
			if(cities[26].CityHave == 1)
				City19.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(200)), ((System.Byte)(255)));
			if(cities[26].CityHave == 2)
				City19.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[26].CityHave == 3)
				City19.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[27].CityHave == -1)
				City20.BackColor = Color.White;
			if(cities[27].CityHave == 0)
				City20.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(200)), ((System.Byte)(200)));
			if(cities[27].CityHave == 1)
				City20.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(200)), ((System.Byte)(255)));
			if(cities[27].CityHave == 2)
				City20.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[27].CityHave == 3)
				City20.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[29].CityHave == -1)
				City21.BackColor = Color.White;
			if(cities[29].CityHave == 0)
				City21.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(200)), ((System.Byte)(200)));
			if(cities[29].CityHave == 1)
				City21.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(200)), ((System.Byte)(255)));
			if(cities[29].CityHave == 2)
				City21.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[29].CityHave == 3)
				City21.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[31].CityHave == -1)
				City22.BackColor = Color.White;
			if(cities[31].CityHave == 0)
				City22.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(200)), ((System.Byte)(200)));
			if(cities[31].CityHave == 1)
				City22.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(200)), ((System.Byte)(255)));
			if(cities[31].CityHave == 2)
				City22.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[31].CityHave == 3)
				City22.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[32].CityHave == -1)
				City23.BackColor = Color.White;
			if(cities[32].CityHave == 0)
				City23.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(200)), ((System.Byte)(200)));
			if(cities[32].CityHave == 1)
				City23.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(200)), ((System.Byte)(255)));
			if(cities[32].CityHave == 2)
				City23.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[32].CityHave == 3)
				City23.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[33].CityHave == -1)
				City24.BackColor = Color.White;
			if(cities[33].CityHave == 0)
				City24.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(200)), ((System.Byte)(200)));
			if(cities[33].CityHave == 1)
				City24.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(200)), ((System.Byte)(255)));
			if(cities[33].CityHave == 2)
				City24.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[33].CityHave == 3)
				City24.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[34].CityHave == -1)
				City25.BackColor = Color.White;
			if(cities[34].CityHave == 0)
				City25.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(200)), ((System.Byte)(200)));
			if(cities[34].CityHave == 1)
				City25.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(200)), ((System.Byte)(255)));
			if(cities[34].CityHave == 2)
				City25.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[34].CityHave == 3)
				City25.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[36].CityHave == -1)
				City26.BackColor = Color.White;
			if(cities[36].CityHave == 0)
				City26.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(200)), ((System.Byte)(200)));
			if(cities[36].CityHave == 1)
				City26.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(200)), ((System.Byte)(255)));
			if(cities[36].CityHave == 2)
				City26.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[36].CityHave == 3)
				City26.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[37].CityHave == -1)
				City27.BackColor = Color.White;
			if(cities[37].CityHave == 0)
				City27.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(200)), ((System.Byte)(200)));
			if(cities[37].CityHave == 1)
				City27.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(200)), ((System.Byte)(255)));
			if(cities[37].CityHave == 2)
				City27.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[37].CityHave == 3)
				City27.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[39].CityHave == -1)
				City28.BackColor = Color.White;
			if(cities[39].CityHave == 0)
				City28.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(200)), ((System.Byte)(200)));
			if(cities[39].CityHave == 1)
				City28.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(200)), ((System.Byte)(255)));
			if(cities[39].CityHave == 2)
				City28.BackColor = 
					Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(200)));
			if(cities[39].CityHave == 3)
				City28.BackColor = 
					Color.FromArgb(((System.Byte)(200)), ((System.Byte)(255)), ((System.Byte)(200)));
		}
		#endregion

		// ���� �÷��̾��� ������ ȭ�鿡 ���
		private void RePrint()
		{	
			L_Player1.Text = "�̸� : " + players[0].PlayerName;
			if(players[0].PlayerIsDead == false)
				L_Player1.Text += "\n������ : " + (float)players[0].PlayerMoney/10000 + "����";
			else
				L_Player1.Text += "\n�Ļ�";
			L_Player1.Text += "\n������ġ : " + 
				cities[players[0].PlayerLocate].CityName;
			L_Player1.Text += "\n<< ������ >>";
			
			if(players[0].HaveItem1 > 0)
			{
				L_Player1.Text += "\n������ : " + players[0].HaveItem1;
			}
			if(players[0].HaveItem2 > 0)
			{
				L_Player1.Text += "\n���� : " + players[0].HaveItem2;
			}
			if(players[0].HaveItem1 == 0 && players[0].HaveItem2 == 0)
			{
				L_Player1.Text += "\n����";
			}

			P_Avatar1.Image = Image.FromFile("avatar/avatar"+players[0].PlayerAvatar+".gif");

			L_Player2.Text = "�̸� : " + players[1].PlayerName;
			if(players[1].PlayerIsDead == false)
				L_Player2.Text += "\n������ : " + (float)players[1].PlayerMoney/10000 + "����";
			else
				L_Player2.Text += "\n�Ļ�";
			L_Player2.Text += "\n������ġ : " + 
				cities[players[1].PlayerLocate].CityName;
			L_Player2.Text += "\n<< ������ >>";
			
			if(players[1].HaveItem1 > 0)
			{
				L_Player2.Text += "\n������ : " + players[1].HaveItem1;
			}
			if(players[1].HaveItem2 > 0)
			{
				L_Player2.Text += "\n���� : " + players[1].HaveItem2;
			}
			if(players[1].HaveItem1 == 0 && players[1].HaveItem2 == 0)
			{
				L_Player2.Text += "\n����";
			}

			P_Avatar2.Image = Image.FromFile("avatar/avatar"+players[1].PlayerAvatar+".gif");

			if(game.maxPlayer >= 3) 
			{
				L_Player3.Text = "�̸� : " + players[2].PlayerName;
				if(players[2].PlayerIsDead == false)
					L_Player3.Text += "\n������ : " + (float)players[2].PlayerMoney/10000 + "����";
				else
					L_Player3.Text += "\n�Ļ�";
				L_Player3.Text += "\n������ġ : " + 
					cities[players[2].PlayerLocate].CityName;
				L_Player3.Text += "\n<< ������ >>";
			
				if(players[2].HaveItem1 > 0)
				{
					L_Player3.Text += "\n������ : " + players[2].HaveItem1;
				}
				if(players[2].HaveItem2 > 0)
				{
					L_Player3.Text += "\n���� : " + players[2].HaveItem2;
				}
				if(players[2].HaveItem1 == 0 && players[2].HaveItem2 == 0)
				{
					L_Player3.Text += "\n����";
				}

				P_Avatar3.Image = Image.FromFile("avatar/avatar"+players[2].PlayerAvatar+".gif");
			}

			if(game.maxPlayer == 4)
			{
				L_Player4.Text = "�̸� : " + players[3].PlayerName;
				if(players[3].PlayerIsDead == false)
					L_Player4.Text += "\n������ : " + (float)players[3].PlayerMoney/10000 + "����";
				else
					L_Player4.Text += "\n�Ļ�";
				L_Player4.Text += "\n������ġ : " + 
					cities[players[3].PlayerLocate].CityName;
				L_Player4.Text += "\n<< ������ >>";
			
				if(players[3].HaveItem1 > 0)
				{
					L_Player4.Text += "\n������ : " + players[3].HaveItem1;
				}
				if(players[3].HaveItem2 > 0)
				{
					L_Player4.Text += "\n���� : " + players[3].HaveItem2;
				}
				if(players[3].HaveItem1 == 0 && players[3].HaveItem2 == 0)
				{
					L_Player4.Text += "\n����";
				}

				P_Avatar4.Image = Image.FromFile("avatar/avatar"+players[3].PlayerAvatar+".gif");
			}
		}

		// ī�� ����
		private void DeckMix()
		{
			int currentCard = 29;
			int val;
			Random CardNum = new Random();

			while(currentCard != -1)
			{
				val = CardNum.Next(0,100) % (currentCard + 1);
				deck[currentCard] = cards[val];
				cards[val] = cards[currentCard];
				currentCard--;
			}
		}

		// ���� �̵�(������� �̵�)
		private void LocMove(int current)
		{
			players[current].PlayerLocate++;

			// ��������� ����ϴ��� Ȯ��
			if(players[current].PlayerLocate >= 40) 
			{
				players[current].PlayerLocate -= 40;
			}

			if(current == 0)
			{
				game.loc_x = cities[players[current].PlayerLocate].CityLocate_X - 16;
				game.loc_y = cities[players[current].PlayerLocate].CityLocate_Y - 16;
				Player1Pic.Location = new Point(game.loc_x, game.loc_y);
			}
			if(current == 1)
			{
				game.loc_x = cities[players[current].PlayerLocate].CityLocate_X + 8;
				game.loc_y = cities[players[current].PlayerLocate].CityLocate_Y - 16;
				Player2Pic.Location = new Point(game.loc_x, game.loc_y);
			}
			if(current == 2)
			{
				game.loc_x = cities[players[current].PlayerLocate].CityLocate_X - 16;
				game.loc_y = cities[players[current].PlayerLocate].CityLocate_Y + 8;
				Player3Pic.Location = new Point(game.loc_x, game.loc_y);
			}
			if(current == 3)
			{
				game.loc_x = cities[players[current].PlayerLocate].CityLocate_X + 8;
				game.loc_y = cities[players[current].PlayerLocate].CityLocate_Y + 8;
				Player4Pic.Location = new Point(game.loc_x, game.loc_y);
			}

			// �������ָ� �Ҷ� ��ȸ���� ����� �޾ƿ�
			if(game.OneTurnCheck == true && players[current].PlayerLocate == 20)
			{
				if (game.SocietyFund != 0)
					m_SoundLaugh.Play();
				cities[players[current].PlayerLocate].SocietyFund(players[current]
					,game );
				game.BuyCheck = true;
			}

			if(players[current].PlayerLocate == 0 && players[current].NoPay == false) 
				GivePay(players[current]);		// �����ֱ�
		}

		// ���� �̵�(�ڷ� �̵�) => Ȳ�ݿ���ī�忡�� ���
		private void LocMoveBack(int current)
		{
			players[current].PlayerLocate--;

			// ��������� ����ϴ��� Ȯ��
			if(players[current].PlayerLocate < 0) 
			{
				players[current].PlayerLocate += 40;
			}

			if(current == 0)
			{
				game.loc_x = cities[players[current].PlayerLocate].CityLocate_X - 16;
				game.loc_y = cities[players[current].PlayerLocate].CityLocate_Y - 16;
				Player1Pic.Location = new Point(game.loc_x, game.loc_y);				
			}
			if(current == 1)
			{
				game.loc_x = cities[players[current].PlayerLocate].CityLocate_X + 8;
				game.loc_y = cities[players[current].PlayerLocate].CityLocate_Y - 16;
				Player2Pic.Location = new Point(game.loc_x, game.loc_y);
			}
			if(current == 2)
			{
				game.loc_x = cities[players[current].PlayerLocate].CityLocate_X - 16;
				game.loc_y = cities[players[current].PlayerLocate].CityLocate_Y + 8;
				Player3Pic.Location = new Point(game.loc_x, game.loc_y);
			}
			if(current == 3)
			{
				game.loc_x = cities[players[current].PlayerLocate].CityLocate_X + 8;
				game.loc_y = cities[players[current].PlayerLocate].CityLocate_Y + 8;
				Player4Pic.Location = new Point(game.loc_x, game.loc_y);
			}
		}

		// ���� ����� ȣ��
		private void GameOver()
		{
			int winner = 0;

			for(int i = 0; i < game.maxPlayer - 1; i++)		// ���� üũ
			{
				if(players[winner].PlayerMoney <= players[i+1].PlayerMoney)
					winner = i + 1;
			}
			
			m_SoundP.Play();

			UserBuffer.winner = players[winner].PlayerName;

			// �¸��� �÷��̾ ����ϴ� ��ȭ���ڸ� ����
			WinDialog windlg = new WinDialog();
			windlg.ShowDialog();

			UserBuffer.winner = null;

			DataInitialize();
			SetCity();
			SetCard();
			DeckMix();
			ViewCityHave();
			m_objSound1.Stop();
			CityInfo.Visible = false;
		}

		// �ֻ��� ������
		private int RollDice(Player temp)
		{
			Random DiceNum = new Random();
			int num1 = 0, num2 = 0, move = 0;
			
			num1 = DiceNum.Next(0,1000) % 6 + 1;
			num2 = DiceNum.Next(0,1000) % 6 + 1;
			DiceNums.dicenum1 = num1;
			DiceNums.dicenum2 = num2;

			// �ֻ��� �׸� ���
			RollDiceDlg roll = new RollDiceDlg();
			roll.ShowDialog();

			
			move = num1 + num2;

			// �� �ֻ����� �������� ��������(�����̶� Ī��)
			if(num1 == num2)
			{
				temp.DoubleDice = true;
			}
			else 
			{
				temp.DoubleDice = false;
			}

			if(temp.PlayerSleepTurn == 0)
				return move;
			else return 0;
		}

		// ���ü���
		#region SerCityData
		private void SetCity()
		{
			// ���� ��ǥ ����
			cities[0].CityLocate_X = 768;
			cities[0].CityLocate_Y = 624;
			cities[1].CityLocate_X = 696;
			cities[1].CityLocate_Y = 640;
			cities[2].CityLocate_X = 648;
			cities[2].CityLocate_Y = 640;
			cities[3].CityLocate_X = 600;
			cities[3].CityLocate_Y = 640;
			cities[4].CityLocate_X = 552;
			cities[4].CityLocate_Y = 640;
			cities[5].CityLocate_X = 504;
			cities[5].CityLocate_Y = 640;
			cities[6].CityLocate_X = 456;
			cities[6].CityLocate_Y = 640;
			cities[7].CityLocate_X = 408;
			cities[7].CityLocate_Y = 640;
			cities[8].CityLocate_X = 360;
			cities[8].CityLocate_Y = 640;
			cities[9].CityLocate_X = 312;
			cities[9].CityLocate_Y = 640;
			cities[10].CityLocate_X = 248;
			cities[10].CityLocate_Y = 624;
			cities[11].CityLocate_X = 224;
			cities[11].CityLocate_Y = 552;
			cities[12].CityLocate_X = 224;
			cities[12].CityLocate_Y = 504;
			cities[13].CityLocate_X = 224;
			cities[13].CityLocate_Y = 456;
			cities[14].CityLocate_X = 224;
			cities[14].CityLocate_Y = 408;
			cities[15].CityLocate_X = 224;
			cities[15].CityLocate_Y = 360;
			cities[16].CityLocate_X = 224;
			cities[16].CityLocate_Y = 312;
			cities[17].CityLocate_X = 224;
			cities[17].CityLocate_Y = 264;
			cities[18].CityLocate_X = 224;
			cities[18].CityLocate_Y = 216;
			cities[19].CityLocate_X = 224;
			cities[19].CityLocate_Y = 168;
			cities[20].CityLocate_X = 248;
			cities[20].CityLocate_Y = 104;
			cities[21].CityLocate_X = 312;
			cities[21].CityLocate_Y = 80;
			cities[22].CityLocate_X = 360;
			cities[22].CityLocate_Y = 80;
			cities[23].CityLocate_X = 408;
			cities[23].CityLocate_Y = 80;
			cities[24].CityLocate_X = 456;
			cities[24].CityLocate_Y = 80;
			cities[25].CityLocate_X = 504;
			cities[25].CityLocate_Y = 80;
			cities[26].CityLocate_X = 552;
			cities[26].CityLocate_Y = 80;
			cities[27].CityLocate_X = 600;
			cities[27].CityLocate_Y = 80;
			cities[28].CityLocate_X = 648;
			cities[28].CityLocate_Y = 80;
			cities[29].CityLocate_X = 696;
			cities[29].CityLocate_Y = 80;
			cities[30].CityLocate_X = 768;
			cities[30].CityLocate_Y = 96;
			cities[31].CityLocate_X = 784;
			cities[31].CityLocate_Y = 168;
			cities[32].CityLocate_X = 784;
			cities[32].CityLocate_Y = 216;
			cities[33].CityLocate_X = 784;
			cities[33].CityLocate_Y = 264;
			cities[34].CityLocate_X = 784;
			cities[34].CityLocate_Y = 312;
			cities[35].CityLocate_X = 784;
			cities[35].CityLocate_Y = 360;
			cities[36].CityLocate_X = 784;
			cities[36].CityLocate_Y = 408;
			cities[37].CityLocate_X = 784;
			cities[37].CityLocate_Y = 456;
			cities[38].CityLocate_X = 784;
			cities[38].CityLocate_Y = 504;
			cities[39].CityLocate_X = 784;
			cities[39].CityLocate_Y = 552;

			// ���� ���� ����
			cities[0].CityType = 6;
			cities[0].CityName = "���";
			cities[1].CityType = 0;
			cities[1].CityPriceLand  = 50000;
			cities[1].CityPriceUnit1 = 50000;
			cities[1].CityPriceUnit2 = 150000;
			cities[1].CityPriceUnit3 = 250000;
			cities[1].CityName = "Ÿ������";
			cities[1].CityNation = "�븸";
			cities[1].CityPayLand = 2000;
			cities[1].CityPayUnit1 = 10000;
			cities[1].CityPayUnit2 = 90000;
			cities[1].CityPayUnit3 = 250000;
			cities[2].CityType = 2;
			cities[2].CityName = "Ȳ�ݿ���";
			cities[3].CityType = 0;
			cities[3].CityPriceLand = 80000;
			cities[3].CityPriceUnit1 = 50000;
			cities[3].CityPriceUnit2 = 150000;
			cities[3].CityPriceUnit3 = 250000;
			cities[3].CityName = "ȫ��";
			cities[3].CityNation = "�߱�";
			cities[3].CityPayLand = 4000;
			cities[3].CityPayUnit1 = 20000;
			cities[3].CityPayUnit2 = 180000;
			cities[3].CityPayUnit3 = 450000;;
			cities[4].CityType = 0;
			cities[4].CityPriceLand = 80000;
			cities[4].CityPriceUnit1 = 50000;
			cities[4].CityPriceUnit2 = 150000;
			cities[4].CityPriceUnit3 = 250000;
			cities[4].CityName = "���Ҷ�";
			cities[4].CityNation = "�ʸ���";
			cities[4].CityPayLand = 4000;
			cities[4].CityPayUnit1 = 20000;
			cities[4].CityPayUnit2 = 180000;
			cities[4].CityPayUnit3 = 450000;
			cities[5].CityType = 1;
			cities[5].CityPriceLand = 200000;
			cities[5].CityName = "���ֵ�";
			cities[5].CityNation = "���ѹα�";
			cities[5].CityPayLand = 300000;
			cities[6].CityType = 0;
			cities[6].CityPriceLand = 100000;
			cities[6].CityPriceUnit1 = 50000;
			cities[6].CityPriceUnit2 = 150000;
			cities[6].CityPriceUnit3 = 250000;
			cities[6].CityName = "�̰�����";
			cities[6].CityNation = "�̰�����";
			cities[6].CityPayLand = 6000;
			cities[6].CityPayUnit1 = 30000;
			cities[6].CityPayUnit2 = 270000;
			cities[6].CityPayUnit3 = 550000;
			cities[7].CityType = 2;
			cities[7].CityName = "Ȳ�ݿ���";
			cities[8].CityType = 0;
			cities[8].CityPriceLand = 100000;
			cities[8].CityPriceUnit1 = 50000;
			cities[8].CityPriceUnit2 = 150000;
			cities[8].CityPriceUnit3 = 250000;
			cities[8].CityName = "ī�̷�";
			cities[8].CityNation = "����Ʈ";
			cities[8].CityPayLand = 6000;
			cities[8].CityPayUnit1 = 30000;
			cities[8].CityPayUnit2 = 270000;
			cities[8].CityPayUnit3 = 550000;
			cities[9].CityType = 0;
			cities[9].CityPriceLand = 120000;
			cities[9].CityPriceUnit1 = 50000;
			cities[9].CityPriceUnit2 = 150000;
			cities[9].CityPriceUnit3 = 250000;
			cities[9].CityName = "�̽�ź��";
			cities[9].CityNation = "��Ű";
			cities[9].CityPayLand = 8000;
			cities[9].CityPayUnit1 = 40000;
			cities[9].CityPayUnit2 = 300000;
			cities[9].CityPayUnit3 = 600000;
			cities[10].CityType = 3;
			cities[10].CityName = "���ε�";
			cities[11].CityType = 0;
			cities[11].CityPriceLand = 140000;
			cities[11].CityPriceUnit1 = 100000;
			cities[11].CityPriceUnit2 = 300000;
			cities[11].CityPriceUnit3 = 500000;
			cities[11].CityName = "���׳�";
			cities[11].CityNation = "�׸���";
			cities[11].CityPayLand = 10000;
			cities[11].CityPayUnit1 = 50000;
			cities[11].CityPayUnit2 = 450000;
			cities[11].CityPayUnit3 = 750000;
			cities[12].CityType = 2;
			cities[12].CityName = "Ȳ�ݿ���";
			cities[13].CityType = 0;
			cities[13].CityPriceLand = 160000;
			cities[13].CityPriceUnit1 = 100000;
			cities[13].CityPriceUnit2 = 300000;
			cities[13].CityPriceUnit3 = 500000;
			cities[13].CityName = "�����ϰ�";
			cities[13].CityNation = "����ũ";
			cities[13].CityPayLand = 12000;
			cities[13].CityPayUnit1 = 60000;
			cities[13].CityPayUnit2 = 500000;
			cities[13].CityPayUnit3 = 900000;
			cities[14].CityType = 0;
			cities[14].CityPriceLand = 160000;
			cities[14].CityPriceUnit1 = 100000;
			cities[14].CityPriceUnit2 = 300000;
			cities[14].CityPriceUnit3 = 500000;
			cities[14].CityName = "����Ȧ��";
			cities[14].CityNation = "������";
			cities[14].CityPayLand = 12000;
			cities[14].CityPayUnit1 = 60000;
			cities[14].CityPayUnit2 = 500000;
			cities[14].CityPayUnit3 = 900000;
			cities[15].CityType = 1;
			cities[15].CityPriceLand = 200000;
			cities[15].CityName = "���ڵ� ������";
			cities[15].CityNation = "������ ������";
			cities[15].CityPayLand = 300000;
			cities[16].CityType = 0;
			cities[16].CityPriceLand = 180000;
			cities[16].CityPriceUnit1 = 100000;
			cities[16].CityPriceUnit2 = 300000;
			cities[16].CityPriceUnit3 = 500000;
			cities[16].CityName = "�븮��";
			cities[16].CityNation = "������";
			cities[16].CityPayLand = 14000;
			cities[16].CityPayUnit1 = 70000;
			cities[16].CityPayUnit2 = 550000;
			cities[16].CityPayUnit3 = 950000;
			cities[17].CityType = 2;
			cities[17].CityName = "Ȳ�ݿ���";
			cities[18].CityType = 0;
			cities[18].CityPriceLand = 180000;
			cities[18].CityPriceUnit1 = 100000;
			cities[18].CityPriceUnit2 = 300000;
			cities[18].CityPriceUnit3 = 500000;
			cities[18].CityName = "������";
			cities[18].CityNation = "����";
			cities[18].CityPayLand = 14000;
			cities[18].CityPayUnit1 = 70000;
			cities[18].CityPayUnit2 = 550000;
			cities[18].CityPayUnit3 = 950000;
			cities[19].CityType = 0;
			cities[19].CityPriceLand = 200000;
			cities[19].CityPriceUnit1 = 100000;
			cities[19].CityPriceUnit2 = 300000;
			cities[19].CityPriceUnit3 = 500000;
			cities[19].CityName = "��Ʈ����";
			cities[19].CityNation = "ĳ����";
			cities[19].CityPayLand = 16000;
			cities[19].CityPayUnit1 = 80000;
			cities[19].CityPayUnit2 = 600000;
			cities[19].CityPayUnit3 = 1000000;
			cities[20].CityType = 5;
			cities[20].CityName = "��ȸ�������(����ó)";
			cities[21].CityType = 0;
			cities[21].CityPriceLand = 220000;
			cities[21].CityPriceUnit1 = 150000;
			cities[21].CityPriceUnit2 = 450000;
			cities[21].CityPriceUnit3 = 750000;
			cities[21].CityName = "�ο��뽺���̷���";
			cities[21].CityNation = "�Ƹ���Ƽ��";
			cities[21].CityPayLand = 18000;
			cities[21].CityPayUnit1 = 90000;
			cities[21].CityPayUnit2 = 700000;
			cities[21].CityPayUnit3 = 1050000;
			cities[22].CityType = 2;
			cities[22].CityName = "Ȳ�ݿ���";
			cities[23].CityType = 0;
			cities[23].CityPriceLand = 240000;
			cities[23].CityPriceUnit1 = 150000;
			cities[23].CityPriceUnit2 = 450000;
			cities[23].CityPriceUnit3 = 750000;
			cities[23].CityName = "���Ŀ��";
			cities[23].CityNation = "�����";
			cities[23].CityPayLand = 20000;
			cities[23].CityPayUnit1 = 100000;
			cities[23].CityPayUnit2 = 750000;
			cities[23].CityPayUnit3 = 1100000;
			cities[24].CityType = 0;
			cities[24].CityPriceLand = 240000;
			cities[24].CityPriceUnit1 = 150000;
			cities[24].CityPriceUnit2 = 450000;
			cities[24].CityPriceUnit3 = 750000;
			cities[24].CityName = "�õ��";
			cities[24].CityNation = "����Ʈ���ϸ���";
			cities[24].CityPayLand = 20000;
			cities[24].CityPayUnit1 = 100000;
			cities[24].CityPayUnit2 = 750000;
			cities[24].CityPayUnit3 = 1100000;
			cities[25].CityType = 1;
			cities[25].CityPriceLand = 500000;
			cities[25].CityName = "�λ�";
			cities[25].CityNation = "���ѹα�";
			cities[25].CityPayLand = 600000;
			cities[26].CityType = 0;
			cities[26].CityPriceLand = 260000;
			cities[26].CityPriceUnit1 = 150000;
			cities[26].CityPriceUnit2 = 450000;
			cities[26].CityPriceUnit3 = 750000;
			cities[26].CityName = "�Ͽ���";
			cities[26].CityNation = "����� ����";
			cities[26].CityPayLand = 22000;
			cities[26].CityPayUnit1 = 110000;
			cities[26].CityPayUnit2 = 800000;
			cities[26].CityPayUnit3 = 1150000;
			cities[27].CityType = 0;
			cities[27].CityPriceLand = 260000;
			cities[27].CityPriceUnit1 = 150000;
			cities[27].CityPriceUnit2 = 450000;
			cities[27].CityPriceUnit3 = 750000;
			cities[27].CityName = "������";
			cities[27].CityNation = "��������";
			cities[27].CityPayLand = 22000;
			cities[27].CityPayUnit1 = 110000;
			cities[27].CityPayUnit2 = 800000;
			cities[27].CityPayUnit3 = 1150000;
			cities[28].CityType = 2;
			cities[28].CityName = "Ȳ�ݿ���";
			cities[29].CityType = 0;
			cities[29].CityPriceLand = 280000;
			cities[29].CityPriceUnit1 = 150000;
			cities[29].CityPriceUnit2 = 450000;
			cities[29].CityPriceUnit3 = 750000;
			cities[29].CityName = "���帮��";
			cities[29].CityNation = "������";
			cities[29].CityPayLand = 24000;
			cities[29].CityPayUnit1 = 120000;
			cities[29].CityPayUnit2 = 850000;
			cities[29].CityPayUnit3 = 1200000;
			cities[30].CityType = 4;
			cities[30].CityName = "���ֿ���";
			cities[31].CityType = 0;
			cities[31].CityPriceLand = 300000;
			cities[31].CityPriceUnit1 = 200000;
			cities[31].CityPriceUnit2 = 600000;
			cities[31].CityPriceUnit3 = 1000000;
			cities[31].CityName = "����";
			cities[31].CityNation = "�Ϻ�";
			cities[31].CityPayLand = 26000;
			cities[31].CityPayUnit1 = 130000;
			cities[31].CityPayUnit2 = 900000;
			cities[31].CityPayUnit3 = 1270000;
			cities[32].CityType = 1;
			cities[32].CityPriceLand = 450000;
			cities[32].CityName = "�ݷҺ��ȣ";
			cities[32].CityNation = "���ֿպ���";
			cities[32].CityPayLand = 400000;
			cities[33].CityType = 0;
			cities[33].CityPriceLand = 320000;
			cities[33].CityPriceUnit1 = 200000;
			cities[33].CityPriceUnit2 = 600000;
			cities[33].CityPriceUnit3 = 1000000;
			cities[33].CityName = "�ĸ�";
			cities[33].CityNation = "������";
			cities[33].CityPayLand = 28000;
			cities[33].CityPayUnit1 = 150000;
			cities[33].CityPayUnit2 = 1000000;
			cities[33].CityPayUnit3 = 1400000;
			cities[34].CityType = 0;
			cities[34].CityPriceLand = 320000;
			cities[34].CityPriceUnit1 = 200000;
			cities[34].CityPriceUnit2 = 600000;
			cities[34].CityPriceUnit3 = 1000000;
			cities[34].CityName = "�θ�";
			cities[34].CityNation = "��Ż����";
			cities[34].CityPayLand = 28000;
			cities[34].CityPayUnit1 = 150000;
			cities[34].CityPayUnit2 = 1000000;
			cities[34].CityPayUnit3 = 1400000;
			cities[35].CityType = 2;
			cities[35].CityName = "Ȳ�ݿ���";
			cities[36].CityType = 0;
			cities[36].CityPriceLand = 350000;
			cities[36].CityPriceUnit1 = 200000;
			cities[36].CityPriceUnit2 = 600000;
			cities[36].CityPriceUnit3 = 1000000;
			cities[36].CityName = "����";
			cities[36].CityNation = "����";
			cities[36].CityPayLand = 35000;
			cities[36].CityPayUnit1 = 170000;
			cities[36].CityPayUnit2 = 1100000;
			cities[36].CityPayUnit3 = 1500000;
			cities[37].CityType = 0;
			cities[37].CityPriceLand = 350000;
			cities[37].CityPriceUnit1 = 200000;
			cities[37].CityPriceUnit2 = 600000;
			cities[37].CityPriceUnit3 = 1000000;
			cities[37].CityName = "����";
			cities[37].CityNation = "�̱�";
			cities[37].CityPayLand = 35000;
			cities[37].CityPayUnit1 = 170000;
			cities[37].CityPayUnit2 = 1100000;
			cities[37].CityPayUnit3 = 1500000;
			cities[38].CityType = 5;
			cities[38].CityName = "��ȸ�������";
			cities[39].CityType = 1;
			cities[39].CityPriceLand = 1000000;
			cities[39].CityName = "����";
			cities[39].CityNation = "���ѹα�";
			cities[39].CityPayLand = 2000000;
			City1.Text = cities[1].CityName + "\n" + cities[1].CityPriceLand/10000 + "����";
			City2.Text = cities[3].CityName + "\n" + cities[3].CityPriceLand/10000 + "����";
			City3.Text = cities[4].CityName + "\n" + cities[4].CityPriceLand/10000 + "����";
			City4.Text = cities[5].CityName + "\n" + cities[5].CityPriceLand/10000 + "����";
			City5.Text = cities[6].CityName + "\n" + cities[6].CityPriceLand/10000 + "����";
			City6.Text = cities[8].CityName + "\n" + cities[8].CityPriceLand/10000 + "����";
			City7.Text = cities[9].CityName + "\n" + cities[9].CityPriceLand/10000 + "����";
			City8.Text = cities[11].CityName + "\n" + cities[11].CityPriceLand/10000 + "����";
			City9.Text = cities[13].CityName + "\n" + cities[13].CityPriceLand/10000 + "����";
			City10.Text = cities[14].CityName + "\n" + cities[14].CityPriceLand/10000 + "����";
			City11.Text = cities[15].CityName + "\n" + cities[15].CityPriceLand/10000 + "����";
			City12.Text = cities[16].CityName + "\n" + cities[16].CityPriceLand/10000 + "����";
			City13.Text = cities[18].CityName + "\n" + cities[18].CityPriceLand/10000 + "����";
			City14.Text = cities[19].CityName + "\n" + cities[19].CityPriceLand/10000 + "����";
			City15.Text = cities[21].CityName + "\n" + cities[21].CityPriceLand/10000 + "����";
			City16.Text = cities[23].CityName + "\n" + cities[23].CityPriceLand/10000 + "����";
			City17.Text = cities[24].CityName + "\n" + cities[24].CityPriceLand/10000 + "����";
			City18.Text = cities[25].CityName + "\n" + cities[25].CityPriceLand/10000 + "����";
			City19.Text = cities[26].CityName + "\n" + cities[26].CityPriceLand/10000 + "����";
			City20.Text = cities[27].CityName + "\n" + cities[27].CityPriceLand/10000 + "����";
			City21.Text = cities[29].CityName + "\n" + cities[29].CityPriceLand/10000 + "����";
			City22.Text = cities[31].CityName + "\n" + cities[31].CityPriceLand/10000 + "����";
			City23.Text = cities[32].CityName + "\n" + cities[32].CityPriceLand/10000 + "����";
			City24.Text = cities[33].CityName + "\n" + cities[33].CityPriceLand/10000 + "����";
			City25.Text = cities[34].CityName + "\n" + cities[34].CityPriceLand/10000 + "����";
			City26.Text = cities[36].CityName + "\n" + cities[36].CityPriceLand/10000 + "����";
			City27.Text = cities[37].CityName + "\n" + cities[37].CityPriceLand/10000 + "����";
			City28.Text = cities[39].CityName + "\n" + cities[39].CityPriceLand/10000 + "����";
		}
		#endregion

		// Ȳ�ݿ��� ī�� ����
		#region SerCardData
		private void SetCard()
		{
			cards[0].CardName = "������ ����";
			cards[0].CardType = 1;
			cards[0].Money = 50000;
			cards[0].CardMessage = "�������� �ǰ������� �޾ҽ��ϴ�. ������ 5������ ���࿡ ���ÿ�.  ";
			cards[1].CardName = "���� ��÷";
			cards[1].CardType = 0;
			cards[1].Money = 200000;
			cards[1].CardMessage = "�����մϴ�. ���ǿ� ��÷�Ǿ����ϴ�.(2����)  ";
			cards[2].CardName = "Ư�� ������";
			cards[2].CardType = 3;
			cards[2].ItemType = 1;
			cards[2].CardMessage = "���ε��� ���������� ����� �� �ֽ��ϴ�.";
			cards[3].CardName = "���ε��� ���ÿ�";
			cards[3].CardType = 4;
			cards[3].CityNum = 10;
			cards[3].CardMessage = "��ǳ�� �������ϴ�. ���ε��� ���� ���õ� ������� �������� ������ ���� ���մϴ�.  ";
			cards[4].CardName = "��Ƽ �ʴ��";
			cards[4].CardType = 9;
			cards[4].CardMessage = "���� �տ��� ����ڶ��� �Ͻʽÿ�.  ";
			cards[5].CardName = "���� ����";
			cards[5].CardType = 4;
			cards[5].CityNum = 5;
			cards[5].CardMessage = "���ֵ��� ���ʽÿ�.  ";
			cards[6].CardName = "���� ���� ����";
			cards[6].CardType = 1;
			cards[6].Money = 50000;
			cards[6].CardMessage = "���� ������ �Ͽ����Ƿ� ���� 5������ ���ÿ�.  ";
			cards[7].CardName = "�ؿ� ����";
			cards[7].CardType = 1;
			cards[7].Money = 100000;
			cards[7].CardMessage = "�б� ��ϱ� 10������ ���ÿ�.  ";
			cards[8].CardName = "���� ����";
			cards[8].CardType = 0;
			cards[8].Money = 50000;
			cards[8].CardMessage = "���࿡�� ���Ŀ��� 5������ �����ÿ�.  ";
			cards[9].CardName = "�̻� ���ÿ�";
			cards[9].CardType = 5;
			cards[9].CityNum = 3;
			cards[9].CardMessage = "�ڷ� ��ĭ �ű�ÿ�.  ";
			cards[10].CardName = "��ӵ���";
			cards[10].CardType = 4;
			cards[10].CityNum = 0;
			cards[10].CardMessage = "��������� ��ٷ� ���ÿ�.  ";
			cards[11].CardName = "���";
			cards[11].CardType = 0;
			cards[11].Money = 100000;
			cards[11].CardMessage = "�ڵ��� ���ֿ��� è�ǿ��� �Ǿ����ϴ�  . ��� 100000��";
			cards[12].CardName = "����";
			cards[12].CardType = 3;
			cards[12].ItemType = 2;
			cards[12].CardMessage = "�� ������ ������ �ְ� �� ���, ������ ��Ҹ� ����� ���� �ӹ��� �� �ֽ��ϴ�.  ";
			cards[13].CardName = "�װ� ����";
			cards[13].CardType = 4;
			cards[13].CityNum = 1;
			cards[13].CardMessage = "���ڵ� �����⸦ Ÿ�ð� Ÿ�����̷� ���ÿ�.(���ڵ� ���Ƿ� ����)  ";
			cards[14].CardName = "�ǹ� ������ ����";
			cards[14].CardType = 2;
			cards[14].PayBuildUnit1 = 30000;
			cards[14].PayBuildUnit2 = 60000;
			cards[14].PayBuildUnit3 = 100000;
			cards[14].CardMessage = "ȣ�� : 10����  ���� : 6����  ���� : 3����  ";
			cards[15].CardName = "�����";
			cards[15].CardType = 2;
			cards[15].PayBuildUnit1 = 10000;
			cards[15].PayBuildUnit2 = 30000;
			cards[15].PayBuildUnit3 = 50000;
			cards[15].CardMessage = "ȣ�� : 5����  ���� : 3����  ���� : 1����  ";
			cards[16].CardName = "�������� �ʴ��";
			cards[16].CardType = 7;
			cards[16].CityNum = 40;
			cards[16].CardMessage = "�����մϴ�. ������ġ���� ���� �ѹ��� ���ƿ��ʽÿ�.  ";
			cards[17].CardName = "���� ����";
			cards[17].CardType = 4;
			cards[17].CityNum = 25;
			cards[17].CardMessage = "�λ����� ���ʽÿ�.  ";
			cards[18].CardName = "������ �����մϴ�";
			cards[18].CardType = 0;
			cards[18].Money = 10000;
			cards[18].CardMessage = "HAPPY BIRTHDAY TO YOU! ��ο��� �������ϸ� �����ÿ�.\n(���ϱ� : ����)  "; 
			cards[19].CardName = "���б� ����";
			cards[19].CardType = 0;
			cards[19].Money = 100000;
			cards[19].CardMessage = "���࿡�� ���б� 10������ �����ÿ�.  ";
			cards[20].CardName = "���� ���� �ҵ漼";
			cards[20].CardType = 2;
			cards[20].PayBuildUnit1 = 30000;
			cards[20].PayBuildUnit2 = 100000;
			cards[20].PayBuildUnit3 = 150000;
			cards[20].CardMessage = "ȣ�� : 15����  ���� : 10����  ���� : 3����  ";
			cards[21].CardName = "�뺧 ��ȭ�� ����";
			cards[21].CardType = 0;
			cards[21].Money = 300000;
			cards[21].CardMessage = "����� ������ȭ�� ���Ͽ� �����Ͽ����Ƿ� �������κ��� ��� 30������ ���޽��ϴ�.  ";
			cards[22].CardName = "���� ����";
			cards[22].CardType = 4;
			cards[22].CityNum = 39;
			cards[22].CardMessage = "88�ø��� �������� ����� ���ʽÿ�.  ";
			cards[23].CardName = "�ݾ� �����";
			cards[23].CardType = 6;
			cards[23].CardMessage = "����� ����߿��� ���� ��Ѱ��� �ݾ����� ���࿡ �Ľʽÿ�.  ";
			cards[24].CardName = "���ֿ��� ��û��";
			cards[24].CardType = 4;
			cards[24].CityNum = 30;
			cards[24].CardMessage = "�����װ������� ���ֿ��� ��û���� �Խ��ϴ�.  ";
			cards[25].CardName = "����";
			cards[25].CardType = 3;
			cards[25].ItemType = 2;
			cards[25].CardMessage = "�� ������ ������ �ְ� �� ���, ������ ��Ҹ� ����� ���� �ӹ��� �� �ֽ��ϴ�.  ";
			cards[26].CardName = "�������� �ʴ��";
			cards[26].CardType = 7;
			cards[26].CityNum = 40;
			cards[26].CardMessage = "�����մϴ�. ������ġ���� ���� �ѹ��� ���ƿ��ʽÿ�.  ";
			cards[27].CardName = "�̻� ���ÿ�";
			cards[27].CardType = 5;
			cards[27].CityNum = 3;
			cards[27].CardMessage = "�ڷ� ��ĭ �ű�ÿ�.  ";
			cards[28].CardName = "��ȸ������� ���";
			cards[28].CardType = 4;
			cards[28].CityNum = 20;
			cards[28].CardMessage = "��ȸ������� ����ó�� ���ÿ�.  ";
			cards[29].CardName = "�ݾ� �����";
			cards[29].CardType = 6;
			cards[29].CardMessage = "����� ����߿��� ���� ��Ѱ��� �ݾ����� ���࿡ �Ľʽÿ�.  ";
		}
		#endregion

		// ���� ����
		private void SetStart()
		{
			SetStart config = new SetStart();
			while(config.ShowDialog() == DialogResult.OK)
			{
				if(config.MaxPlayer == 4) 
				{
					if(config.PlayerName1 == "" || config.PlayerName2 == ""
						|| config.PlayerName3 == "" || config.PlayerName4 == "") 
					{
						MessageBox.Show("�̸��� �Է��ϼ���.  ","�̸� ���Է�",
							MessageBoxButtons.OK, MessageBoxIcon.Warning);
						continue;
					}
				}

				if(config.MaxPlayer == 3) 
				{
					if(config.PlayerName1 == "" || config.PlayerName2 == ""
						|| config.PlayerName3 == "") 
					{
						MessageBox.Show("�̸��� �Է��ϼ���.  ","�̸� ���Է�",
							MessageBoxButtons.OK, MessageBoxIcon.Warning);
						continue;
					}
				}

				if(config.MaxPlayer == 2) 
				{
					if(config.PlayerName1 == "" || config.PlayerName2 == "") 
					{
						MessageBox.Show("�̸��� �Է��ϼ���.  ","�̸� ���Է�",
							MessageBoxButtons.OK, MessageBoxIcon.Warning);
						continue;
					}
				}

				players[0].PlayerName = config.PlayerName1;
				players[1].PlayerName = config.PlayerName2;
				players[2].PlayerName = config.PlayerName3;
				players[3].PlayerName = config.PlayerName4;
				players[0].PlayerAvatar = config.Player1Avatar;
				players[1].PlayerAvatar = config.Player2Avatar;
				players[2].PlayerAvatar = config.Player3Avatar;
				players[3].PlayerAvatar = config.Player4Avatar;
				players[0].PlayerMoney = config.StartMoney;
				players[1].PlayerMoney = config.StartMoney;
				players[2].PlayerMoney = config.StartMoney;
				players[3].PlayerMoney = config.StartMoney;
				game.maxPlayer = config.MaxPlayer;
				game.LeftPlayer = game.maxPlayer;

				if(game.maxPlayer == 2)
				{
					Player1Pic.Visible = true;
					Player2Pic.Visible = true;
					players[2].PlayerIsDead = true;
					players[3].PlayerIsDead = true;
				}
				if(game.maxPlayer == 3)
				{	
					Player1Pic.Visible = true;
					Player2Pic.Visible = true;
					Player3Pic.Visible = true;
					players[3].PlayerIsDead = true;
				}
				if(game.maxPlayer == 4) 
				{
					Player1Pic.Visible = true;
					Player2Pic.Visible = true;
					Player3Pic.Visible = true;
					Player4Pic.Visible = true;
				}

				Player1Pic.Location = new Point(cities[0].CityLocate_X - 16
					, cities[0].CityLocate_Y - 16);
				Player2Pic.Location = new Point(cities[0].CityLocate_X + 8
					, cities[0].CityLocate_Y - 16);
				Player3Pic.Location = new Point(cities[0].CityLocate_X - 16
					, cities[0].CityLocate_Y + 8);
				Player4Pic.Location = new Point(cities[0].CityLocate_X + 8
					, cities[0].CityLocate_Y + 8);

				break;
			}
		}

		// Ȳ�ݿ��� ó��
		private void GoldenKey(City[] T_cities, Player temp, Player[] temp2)
		{
			switch(deck[CardNumber].CardType)
			{
				case 0:			// ���� ���� ī��
					m_SoundLaugh.Play();
					deck[CardNumber].GetMoney(temp, temp2);
					break;
				case 1:			// ���� ���� ī��
					m_SoundSigh.Play();
					deck[CardNumber].PayMoney(temp);
					break;
				case 2:			// �ǹ� ���� ���� ī��
					m_SoundSigh.Play();
					deck[CardNumber].BuildTax(T_cities,temp);
					break;
				case 3:			// ������
					deck[CardNumber].Item(temp);
					break;
				case 4:			// �̵�(������)
					game.DiceNum = deck[CardNumber].MoveLocation1(T_cities, temp, temp2);
					GameStart();
					temp.NoPay = false;
					break;
				case 5:			// �̵�(�ڷ�)
					deck[CardNumber].MoveLocation2(temp);
					for(int i = 0; i < deck[CardNumber].CityNum; i++)
					{
						LocMoveBack(game.Current);
					}
					game.DiceNum = -1;
					GameStart();
					game.DiceNum = 0;
					break;
				case 6:			// �ݾ״����
					deck[CardNumber].SellLand(T_cities,temp);
					break;
				case 7:			// ��������
					game.DiceNum = deck[CardNumber].OneTurn(temp);
					game.OneTurnCheck = true;
					GameStart();
					game.OneTurnCheck = false;
					break;
				case 8:			// ���ֿ��� ��û��
					players[game.Current].SpaceTourPay = true;
					game.DiceNum = deck[CardNumber].MoveLocation1(T_cities, temp, temp2);
					players[game.Current].DoubleDice = false;
					GameStart();
					players[game.Current].SpaceTourPay = false;
					break;
				case 9:			// ��Ÿ
					deck[CardNumber].Other();
					break;
				default:
					break;
			}

			// �������� ����ī�带 ���������� �Ѵ�.
			CardNumber++;

			if(CardNumber>=30)
			{
				for(int i = 0;i < 30;i++)
				{
					cards[i] = new Card();
					deck[i] = new Card();
				}
				SetCard();
				DeckMix();
				CardNumber = 0;
			}
		}

		// �����ֱ�
		private void GivePay(Player temp)
		{
			MessageBox.Show("������ �޽��ϴ�.  ","����");
			temp.PlayerMoney += 200000;
		}

		// ���� ������ �ʱ�ȭ �� ����
		private void DataInitialize()
		{
			// ���� ���ӿ� ����� �����͸� �ʱ�ȭ
			game.SocietyFund = 0;
			game.Current = -1;

			for(int i = 0;i < 40;i++)
			{
				cities[i] = new City();
			}

			for(int i=0;i<4;i++)
			{
				players[i] = new Player();
				players[i].PlayerNumber = i;
			}

			for(int i = 0;i < 30;i++)
			{
				cards[i] = new Card();
				deck[i] = new Card();
			}

			CardNumber = 0;

			L_Player1.Text = null;
			L_Player2.Text = null;
			L_Player3.Text = null;
			L_Player4.Text = null;
			P_Avatar1.Image = null;
			P_Avatar2.Image = null;
			P_Avatar3.Image = null;
			P_Avatar4.Image = null;

			NextPlayer.Enabled = false;
			B_Roll.Enabled = false;
			game.BuyCheck = false;
			Buy.Enabled = false;
			Sell.Enabled = false;

			Player1Pic.Location = new Point(cities[0].CityLocate_X - 16
				, cities[0].CityLocate_Y - 16);
			Player1Pic.Visible = false;
			Player2Pic.Location = new Point(cities[0].CityLocate_X + 8
				, cities[0].CityLocate_Y - 16);
			Player2Pic.Visible = false;
			Player3Pic.Location = new Point(cities[0].CityLocate_X - 16
				, cities[0].CityLocate_Y + 8);
			Player3Pic.Visible = false;
			Player4Pic.Location = new Point(cities[0].CityLocate_X + 8
				, cities[0].CityLocate_Y + 8);
			Player4Pic.Visible = false;

			G_Player1.ForeColor = System.Drawing.Color.White;
			G_Player2.ForeColor = System.Drawing.Color.White;
			G_Player3.ForeColor = System.Drawing.Color.White;
			G_Player4.ForeColor = System.Drawing.Color.White;

			GameStartCheck = false;
		}

		// ���Ͽ�..�� ����������
		private void M_About_Click(object sender, System.EventArgs e)
		{
            m_SoundAbout.Play();
			AboutDlg about = new AboutDlg();	// ���Ͽ�.. (��ȭâ)
			about.ShowDialog();
			m_SoundAbout.Stop();
		}

		// �������Ḧ ����������
		private void M_Exit_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
			// ���α׷� ����
		}

		// ���ӽ����� ����������
		private void M_GameStart_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck == false)
			{
				SetStart();
				RePrint();
				B_Roll.Enabled = true;
				GameStartCheck = true;
				PlaySound();
				ShowCurrentPlayer();
			}
			else
			{	
				// ���� ������ �������� ���¿��� ���ӽ����� ����������
				if(MessageBox.Show("���� �������� ������ �����ϰڽ��ϱ�?  ", "�����ߴ�",
					MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) 
				{
					DataInitialize();
					SetCity();
					SetCard();
					DeckMix();
					ViewCityHave();
					m_objSound1.Stop();
					CityInfo.Visible = false;

					SetStart();
					RePrint();
					GameStartCheck = true;
					B_Roll.Enabled = true;
					PlaySound();
					ShowCurrentPlayer();
				}
			}
		}

		// ���Ӽ����� Ŭ��������
		private void M_GameSet_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("ü���ǿ����� �������� �ʽ��ϴ�.  ", "���Ӽ���",	// ���Ӽ��� (��ȭâ)
				MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		// �����ߴ��� Ŭ��������
		private void M_GameStop_Click(object sender, System.EventArgs e)
		{
			if(MessageBox.Show("������ ������ �����ϰڽ��ϱ�?  ","�����ߴ�",
				MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
			{
				DataInitialize();
				SetCity();
				SetCard();
				DeckMix();
				ViewCityHave();
				m_objSound1.Stop();
				CityInfo.Visible = false;
			}
		}

		// ������ ����
		private void GameStart()
		{
			while(true)
			{
				if(players[game.Current].SpaceTourCheck == false && game.DiceNum == 0) // ��������
				{
					// �ֻ����� ���� �� ���� ����
					game.DiceNum = RollDice(players[game.Current]);
				}

				if(game.DiceNum != -1)
				{
					// �ֻ����� �������ŭ �̵�
					while(game.DiceNum !=0)
					{
						LocMove(game.Current);
						game.DiceNum--;
					}

				}

				// �ֻ��������⸦ Ŭ���ϰ��� ���̻� Ŭ���Ҽ� ������
				B_Roll.Enabled = false;

				// ������� ������Ʈ
				RePrint();

				// ���ε����� �޽������� �˻�
				if(players[game.Current].PlayerSleepTurn != 0) 
				{
					if(players[game.Current].DoubleDice) 
					{
						MessageBox.Show("���ε��� Ż���Ͽ����ϴ�.  ");
						players[game.Current].PlayerSleepTurn = 0;
						break;
					}
					else 
					{
						players[game.Current].PlayerSleepTurn--;
						if(players[game.Current].PlayerSleepTurn == 0)
						{
							MessageBox.Show("���ε��� Ż���Ͽ����ϴ�.  ");
						}
						break;
					}
				}

				// ���� ��ġ�� ���� ������ ������
				PrintCityInfo(players[game.Current].PlayerLocate);

				// ���� ��ġ�� ���� ���ó��
				switch(cities[players[game.Current].PlayerLocate].CityType) 
				{

					case 0:		// �Ϲݵ���
						if(cities[players[game.Current].PlayerLocate].CityHave == -1 || 
							cities[players[game.Current].PlayerLocate].CityHave == game.Current) 
						{
							Buy.Enabled = true;		// ���ü����ڰ� ���ų� �ڽ��� �����ϰ�� ���Թ�ư Ȱ��ȭ
							Sell.Enabled = false;
							if(cities[players[game.Current].PlayerLocate].CityHave == game.Current)
								Sell.Enabled = true;	// �ڽ��� ������ ��쿡�� �ȱ��ư Ȱ��ȭ
						}
						else 
						{
							cities[players[game.Current].PlayerLocate].NormalCity(players, game.Current, game);
							Buy.Enabled = false;
							Sell.Enabled = false;
						}

						break;

					case 1:		// Ư������
						if(cities[players[game.Current].PlayerLocate].CityHave == -1)
						{
							Buy.Enabled = true;
							Sell.Enabled = false;
						}
						else if(cities[players[game.Current].PlayerLocate].CityHave == game.Current) 
						{
							Buy.Enabled = false;
							Sell.Enabled = true;
						}
						else 
						{
							Buy.Enabled = false;
							Sell.Enabled = false;
							cities[players[game.Current].PlayerLocate].SpecialCity(players, game.Current, game);
						}
						break;

					case 2:		// Ȳ�ݿ���
						if(game.OneTurnCheck == false)
						{
							Buy.Enabled = false;
							Sell.Enabled = false;
							GoldKeyCheck = true;
							GoldenKey(cities, players[game.Current], players);
							GoldKeyCheck = false;
						}
						break;

					case 3:		// ���ε�
						players[game.Current].DoubleDice = false;	// ����� ���������� �ٽ� �ֻ����� ����������
						Buy.Enabled = false;
						Sell.Enabled = false;
						m_SoundIsland.Play();
						cities[players[game.Current].PlayerLocate].island(players[game.Current]);
						break;

					case 4:		// ���ֿ���
						Buy.Enabled = false;
						Sell.Enabled = false;
						if(cities[32].CityHave != -1 && cities[32].CityHave != game.Current 
							&& players[game.Current].SpaceTourPay == false)
						{
							// �ݷҺ��ȣ�� �����ڰ� �ְ� �ڽ��� ���� �ƴҶ�
							MessageBox.Show("�ݷҺ��ȣ�� 20������ �����մϴ�.  ", "����������");
							players[cities[32].CityHave].PlayerMoney += 200000;
							players[game.Current].PlayerMoney -= 200000;
						}
						MessageBox.Show("�����Ͽ� ���ϴ� ��ҷ� �̵��Ҽ� �ֽ��ϴ�.  ", "����������");
						players[game.Current].DoubleDice = false;
						break;

					case 5:		// ��ȸ�������
						if (game.SocietyFund != 0)
							m_SoundLaugh.Play();
						cities[players[game.Current].PlayerLocate].SocietyFund(players[game.Current]
							,game );
						Buy.Enabled = false;
						Sell.Enabled = false;
						break;
					
					case 6:		// �������
						Buy.Enabled = false;
						Sell.Enabled = false;
						break;

					default:
						break;
				}

				RePrint();
				
				// �Ļ꿩�� Ȯ��
				if(players[game.Current].PlayerMoney <= 0 && GoldKeyCheck == false) 
				{
					players[game.Current].DoubleDice = false;
					MessageBox.Show("���� �Ѿ������ ������ ���� �������� ������ �Ļ��Դϴ�.  \n(���� �����ϰ� �ִ� ���ø� �� �� �ֽ��ϴ�.)", "�Ļ� ����"
						,MessageBoxButtons.OK, MessageBoxIcon.Warning);
					CitySellCheck = true;
					NextPlayer.Text = "�Ļ� ����";
				}

				break;
			}	// while-loop ��������

			ViewCityHave();

			// ������ �������� �ٽ� �ֻ����� ������ ����
			if(players[game.Current].DoubleDice && GoldKeyCheck == false)
				MessageBox.Show("������ �������Ƿ� �ֻ����� �ѹ� �� ������ �ֽ��ϴ�.  ", "����"
					,MessageBoxButtons.OK, MessageBoxIcon.Information);

			// ������ ��������쿡 �����÷��̾�� ������ ���ѱ⵵�� ��(�ݵ�� ��������)
			if(players[game.Current].DoubleDice)
			{
				B_Roll.Enabled = true;
				game.BuyCheck = false;
				NextPlayer.Enabled = false;
			}
			else 
				NextPlayer.Enabled = true;
		}

		// �ֻ��� ������ ��ư�� Ŭ��������
		private void B_Roll_Click(object sender, System.EventArgs e)
		{
			m_objSound2.Play();
			GameStart();
		}

		// ����/�ǹ� ���� ��ư�� Ŭ��������
		private void Buy_Click(object sender, System.EventArgs e)
		{
			switch(cities[players[game.Current].PlayerLocate].CityType) 
			{
				case 0:		// �Ϲݵ���
					cities[players[game.Current].PlayerLocate].NormalCity(players, game.Current, game);
					break;

				case 1:		// Ư������
					cities[players[game.Current].PlayerLocate].SpecialCity(players, game.Current, game);
					break;
				default:
					break;
			}
			RePrint();
			ViewCityHave();

			// �ǹ��� �ѹ� ����� ���̻� �ٸ� ����� �Ҽ� ����
			if(game.BuyCheck == true) 
			{
				Buy.Enabled = false;
				Sell.Enabled = false;
			}
			else 
				game.BuyCheck = false;
		}

		// ���� �÷��̾� Ŭ��������
		private void NextPlayer_Click(object sender, System.EventArgs e)
		{
			CitySellCheck = false;
			// �Ļ꿩�� Ȯ��
			if(players[game.Current].PlayerMoney <= 0) 
			{
				m_SoundAmbulance.Play();
				players[game.Current].PlayerIsDead = true;
				MessageBox.Show("������ �ɷ��� ��� "
					+ players[game.Current].PlayerName + "���� �Ļ��ϼ̽��ϴ�.  ", "�Ļ�");
				if(players[game.Current].PlayerDebt)
					players[players[game.Current].DebtWho].PlayerMoney 
						+= players[game.Current].PlayerMoney;
				game.LeftPlayer--;

				// �Ļ��� ��� �� ����
				if(game.Current == 0)
				{
					Player1Pic.Visible = false;
				}
				if(game.Current == 1)
				{
					Player2Pic.Visible = false;
				}
				if(game.Current == 2)
				{
					Player3Pic.Visible = false;
				}
				if(game.Current == 3)
				{
					Player4Pic.Visible = false;
				}

				// �Ļ��� �÷��̾ �� ���� ��� ������ ����
				for(int i = 0; i < 40; i++)
				{
					if(cities[i].CityHave == game.Current)
					{
						cities[i].CityHave = -1;
						cities[i].BuildUnitNum1 = 0;
						cities[i].BuildUnitNum2 = 0;
						cities[i].BuildUnitNum3 = 0;
					}
				}
				RePrint();
				ViewCityHave();

				// �÷��̾ �Ļ��ϰ� �Ѹ� ��������
				if(game.LeftPlayer == 1)
				{
					GameOver();
					return;
				}
				NextPlayer.Text = "���� �÷��̾�";
			}

			players[game.Current].PlayerDebt = false;

			if(cities[players[game.Current].PlayerLocate].CityType == 4)
				players[game.Current].SpaceTourCheck = true;
			NextPlayer.Enabled = false;
			B_Roll.Enabled = true;
			game.BuyCheck = false;
			Sell.Enabled = false;
			Buy.Enabled = false;

			// ���� �÷��̾ ���� ����ó��
			ShowCurrentPlayer();
		}
		
		// ���� �÷��̾ �������
		private void ShowCurrentPlayer()
		{
			game.Current++;
			int temp;
			temp = game.Current % game.maxPlayer;

			while(true)
			{
				// �Ļ꿩�� �˻�
				if(players[temp].PlayerIsDead)
				{
					temp = (temp + 1) % game.maxPlayer;
					continue;
				}
				else  
				{
					MessageBox.Show(players[temp].PlayerName + "���� �����Դϴ�.  ","�����÷��̾�"
						,MessageBoxButtons.OK, MessageBoxIcon.Information);

					if(temp == 0) 
					{
						G_Player1.ForeColor = System.Drawing.Color.Aqua;
						G_Player2.ForeColor = System.Drawing.Color.White;
						G_Player3.ForeColor = System.Drawing.Color.White;
						G_Player4.ForeColor = System.Drawing.Color.White;
					}
					if(temp == 1) 
					{
						G_Player1.ForeColor = System.Drawing.Color.White;
						G_Player2.ForeColor = System.Drawing.Color.Aqua;
						G_Player3.ForeColor = System.Drawing.Color.White;
						G_Player4.ForeColor = System.Drawing.Color.White;
					}
					if(temp == 2) 
					{
						G_Player1.ForeColor = System.Drawing.Color.White;
						G_Player2.ForeColor = System.Drawing.Color.White;
						G_Player3.ForeColor = System.Drawing.Color.Aqua;
						G_Player4.ForeColor = System.Drawing.Color.White;
					}
					if(temp == 3) 
					{
						G_Player1.ForeColor = System.Drawing.Color.White;
						G_Player2.ForeColor = System.Drawing.Color.White;
						G_Player3.ForeColor = System.Drawing.Color.White;
						G_Player4.ForeColor = System.Drawing.Color.Aqua;
					}
					break;
				}
			}
			game.Current = temp;
			if(players[game.Current].SpaceTourCheck) // ���ֿ��࿡ �������� �����Ͽ� �̵�
			{
				B_Roll.Enabled = false;
				MessageBox.Show("�̵��ϱ� ���ϴ� ��Ҹ� �����ϼ���.  ", "���ֿ���", 
					MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		// ���� �Ű� ��ư�� Ŭ��������
		private void Sell_Click(object sender, System.EventArgs e)
		{
			// ���� �Ű� ��ȭ���� ���
			CityDialog3 CitySell = new CityDialog3();
			int ResultSell;

			if(CitySell.ShowDialog() == DialogResult.OK)
			{
				// �Ű��ϰԵǸ� �����ڰ� ���� ���÷� �� ����
				ResultSell = cities[players[game.Current].PlayerLocate].CityPriceLand;
				if(cities[players[game.Current].PlayerLocate].BuildUnitNum1 == 1)
					ResultSell += cities[players[game.Current].PlayerLocate].CityPriceUnit1;
				if(cities[players[game.Current].PlayerLocate].BuildUnitNum2 == 1)
					ResultSell += cities[players[game.Current].PlayerLocate].CityPriceUnit2;
				if(cities[players[game.Current].PlayerLocate].BuildUnitNum3 == 1)
					ResultSell += cities[players[game.Current].PlayerLocate].CityPriceUnit3;
				players[game.Current].PlayerMoney += (ResultSell / 4) * 3;
				cities[players[game.Current].PlayerLocate].BuildUnitNum1 = 0;
				cities[players[game.Current].PlayerLocate].BuildUnitNum2 = 0;
				cities[players[game.Current].PlayerLocate].BuildUnitNum3 = 0;
				cities[players[game.Current].PlayerLocate].CityHave = -1;
				Sell.Enabled = false;
				Buy.Enabled = false;
				RePrint();
				ViewCityHave();
			}
		}

		// ���ֿ��ൿ�� ���ϴ� ��Ҹ� Ŭ�������� ����
		private void MoveSpaceTour(int point, int D_num)
		{
			if(players[game.Current].SpaceTourCheck)
			{
				if(MessageBox.Show( cities[point].CityName + "(��)�� �̵��ϰڽ��ϱ�?  ", "���ֿ���", 
					MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
				{
					game.DiceNum = D_num;
					GameStart();
					if(GameStartCheck)
					{
						NextPlayer.Enabled = true;
						players[game.Current].SpaceTourCheck = false;
					}
				}
			}
		}

		// ������ �ɷ��� ������ �ڽ��� �����ϰ� �ִ� ���ø� �ȵ��� ��
		private void CitySell(int point)
		{
			if(cities[point].CityHave == players[game.Current].PlayerNumber)
			{
				string message;
				message = cities[point].CityName + "�� �Ű��ϰڽ��ϱ�?  ";
				message += "\n\n<�ǸŰ���>\n���� : " + cities[point].CityPriceLand/2 + "��";
				
				if(cities[point].BuildUnitNum1 == 1)
					message += "\n���� : " + cities[point].CityPriceUnit1/2 + "��";
				if(cities[point].BuildUnitNum2 == 1)
					message += "\n���� : " + cities[point].CityPriceUnit2/2 + "��";
				if(cities[point].BuildUnitNum3 == 1)
					message += "\nȣ�� : " + cities[point].CityPriceUnit3/2 + "��";

				if(MessageBox.Show( message, "���� �Ű�", 
					MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					int ResultSell;
					ResultSell = cities[point].CityPriceLand;
					if(cities[point].BuildUnitNum1 == 1)
						ResultSell += cities[point].CityPriceUnit1;
					if(cities[point].BuildUnitNum2 == 1)
						ResultSell += cities[point].CityPriceUnit2;
					if(cities[point].BuildUnitNum3 == 1)
						ResultSell += cities[point].CityPriceUnit3;
					players[game.Current].PlayerMoney += ResultSell / 2;
					cities[point].BuildUnitNum1 = 0;
					cities[point].BuildUnitNum2 = 0;
					cities[point].BuildUnitNum3 = 0;
					cities[point].CityHave = -1;

					RePrint();
					ViewCityHave();

					// �������� ��������� �����ϰ� ���� �ѱ⵵�� ��
					if(players[game.Current].PlayerMoney > 0)
					{
						CitySellCheck = false;
						NextPlayer.Text = "���� �÷��̾�";
					}
				}
			}
		}

		// ���⼭ ���ʹ� ���ϴ� ��Ҹ� Ŭ�������� �߻��ϴ� �̺�Ʈ
		private void P_Start_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(0,10);
			}
		}

		private void City1_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(1,11);
			}

			if(CitySellCheck)
			{
				CitySell(1);
			}
		}

		private void GoldKey1_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(2,12);
			}
		}

		private void City2_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(3,13);
			}

			if(CitySellCheck)
			{
				CitySell(3);
			}
		}

		private void City3_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(4,14);
			}

			if(CitySellCheck)
			{
				CitySell(4);
			}
		}

		private void City4_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(5,15);
			}

			if(CitySellCheck)
			{
				CitySell(5);
			}
		}

		private void City5_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(6,16);
			}

			if(CitySellCheck)
			{
				CitySell(6);
			}
		}

		private void GoldKey2_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(7,17);
			}
		}

		private void City6_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(8,18);
			}

			if(CitySellCheck)
			{
				CitySell(8);
			}
		}

		private void City7_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(9,19);
			}

			if(CitySellCheck)
			{
				CitySell(9);
			}
		}

		private void P_Space_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
		 		MoveSpaceTour(10,20);
			}
		}

		private void City8_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(11,21);
			}

			if(CitySellCheck)
			{
				CitySell(11);
			}
		}

		private void GoldKey3_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(12,22);
			}
		}

		private void City9_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(13,23);
			}

			if(CitySellCheck)
			{
				CitySell(13);
			}
		}

		private void City10_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(14,24);
			}

			if(CitySellCheck)
			{
				CitySell(14);
			}
		}

		private void City11_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(15,25);
			}

			if(CitySellCheck)
			{
				CitySell(15);
			}
		}

		private void City12_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(16,26);
			}

			if(CitySellCheck)
			{
				CitySell(16);
			}
		}

		private void GoldKey4_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(17,27);
			}
		}

		private void City13_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(18,28);
			}

			if(CitySellCheck)
			{
				CitySell(18);
			}
		}

		private void City14_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(19,29);
			}

			if(CitySellCheck)
			{
				CitySell(19);
			}
		}

		private void P_Island_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(20,30);
			}
		}

		private void City15_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(21,31);
			}

			if(CitySellCheck)
			{
				CitySell(21);
			}
		}

		private void GoldKey5_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(22,32);
			}
		}

		private void City16_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(23,33);
			}

			if(CitySellCheck)
			{
				CitySell(23);
			}
		}

		private void City17_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(24,34);
			}

			if(CitySellCheck)
			{
				CitySell(24);
			}
		}

		private void City18_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(25,35);
			}

			if(CitySellCheck)
			{
				CitySell(25);
			}
		}

		private void City19_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(26,36);
			}

			if(CitySellCheck)
			{
				CitySell(26);
			}
		}

		private void City20_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(27,37);
			}

			if(CitySellCheck)
			{
				CitySell(27);
			}
		}

		private void GoldKey6_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(28,38);
			}
		}

		private void City21_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(29,39);
			}

			if(CitySellCheck)
			{
				CitySell(29);
			}
		}

		private void P_Fund_Click(object sender, System.EventArgs e)
		{

		}

		private void City22_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(31,1);
			}

			if(CitySellCheck)
			{
				CitySell(31);
			}
		}

		private void City23_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(32,2);
			}

			if(CitySellCheck)
			{
				CitySell(32);
			}
		}

		private void City24_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(33,3);
			}

			if(CitySellCheck)
			{
				CitySell(33);
			}
		}

		private void City25_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(34,4);
			}

			if(CitySellCheck)
			{
				CitySell(34);
			}
		}

		private void GoldKey7_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(35,5);
			}
		}

		private void City26_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(36,6);
			}

			if(CitySellCheck)
			{
				CitySell(36);
			}
		}

		private void City27_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(37,7);
			}

			if(CitySellCheck)
			{
				CitySell(37);
			}
		}

		private void P_FundPay_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(38,8);
			}
		}

		private void City28_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck)
			{
				MoveSpaceTour(39,9);
			}

			if(CitySellCheck)
			{
				CitySell(39);
			}
		}

		// ���� ���� ���
		private void PrintCityInfo(int loc)
		{
			// ��������â�� ���̰� ��
			CityInfo.Visible = true;
			
			try {CityPhoto.Image = Image.FromFile("cityphoto/city" +loc+ ".gif");}
			catch {}

			L_CityInfo.Text = "";
			switch(loc)
			{
				case 0:
					CityInfo.Text = "���(Start Point)";
					L_CityInfo.Text += "������ �����Դϴ�.\n������ ������ ������ ����.\n����� �Ͼ�� �ɱ��? ^^";
					break;
				case 1:
					CityInfo.Text = "Ÿ������(Taipei, Taiwan)";
					L_CityInfo.Text += "Ÿ�̿�[��ؽ]�� ����. ������ ����[����]ȭ�걺, ������ ��Ŀ��[��Ϣ]����, ����/������ �߾ӻ������ �ѷ����� ������ �߽ɿ� ��ġ. �ð����� �������� �帣�� �ܼ��̰�[ӿ���]�� ���ʿ� ����. �ƿ������, ���(��Ѣ)�� ���� ���. �ѹ���(������)�� �̰����� �����ϱ� ������ ���� 17���� �������̸�, 18���� �ʿ��� �ܼ��̰� ���ȿ� ������ �����Ǿ���, ������� ������ ���� �ֿ� ���������� ��â�Ͽ���.";
					break;
				case 2:
					CityPhoto.Image = Image.FromFile("cityphoto/goldkey.gif");
					CityInfo.Text = "Ȳ�� ����(Golden Key)";
					L_CityInfo.Text = 
						"Ȳ�ݿ��踦 �տ� �� �����̴�\n ���� ������ �����ϰ�\n������ ������ ��� ����.\nȲ�� ���踦 ��������ν� \n���� ���ӿ� �̱�� ������ ������\n���� ���ڿ� ���� ������ \n�ڱ⵵ �𸣴� ���̿� ������ �뿹�� \n�Ǿ� ������.";
					break;
				case 3:
					CityInfo.Text = "ȫ��(Hongkong, China)";
					L_CityInfo.Text += "�߱� �������� Ư��������. ���� ��Ī�� '��ȭ�ιΰ�ȭ�� ȫ��Ư��������'. �ֵ�(�Դ)�� ȫ�ἶ�� ���丮�ƽ�(ȫ���). ���尭[��˰] �ϱ��� ���� ���ȿ� �ִ� ȫ�ἶ�� �ַ�ݵ�[��ף����] �� �� ���� ������ �����Ǿ� �ִ�. �� ��� ȫ�ἶ������Ŀ�ͼ��� �ַ�ݵ��� ����(�Ӯ)�� �ִ� �ַ��(�)�� ���� �����̰�, �ַ���� �Ĺ����� ����[��ͣ:New Territories]�� 230���� �μӵ����� ������(����)�̴�.";
					break;
				case 4:
					CityInfo.Text = "���Ҷ�(Manilla, Philiphine)";
					L_CityInfo.Text += "��ռ� �����ο� �ִ� �ʸ����� ����. ���迡�� ���� ���� �׸����� ���þ����� ���Ҷ�(ؽ)�� ���� �ױ����÷�, �ð����� �Ľñװ�(˰)�� ���� �� �������� ��������. ���ʿ� ����� �ߺ� ��� ��߸�, ���ʿ� ���� ����� ȭ�꼺 ������ ���� �ִ�. ";
					break;
				case 5:
					CityInfo.Text = "���ֵ�(Jeju Island, Korea)";
					L_CityInfo.Text += "�ѹݵ� ���� �ػ� �ִ� �ѱ� �ִ��� ���� ���ֵ���, �ֺ��� �����ϴ� ����� ����. �ѱ����߱� �Ϻ� �� �ص�(п��)������ �߾Ӻο� �־� �����������ε� �߿��ϴ�. ���ֵ��� ����, 8���� ���ε��� 55���� ���ε��� �̷������.";
					break;
				case 6:
					CityInfo.Text = "�̰�����(Singapore, Singapore)";
					L_CityInfo.Text += "�����ƽþƿ� �ִ� ������ �̷���� ���� ����.���� 646��. �α� 322�� 5000��(1999). �α��е� 4,991��/��(1999). ������ �̰������̸� ���� �߱���, ����, �����̾�, Ÿ�о� ���� ����Ѵ�. ���ĸ�Ī�� �̰����� ��ȭ��(Repubic of Singapore)�̴�. ���� ���� 137km ������ ������, ���������δ� �̰����� ��ȭ���� ������ ��ġ�Ѵ�. ";
					break;
				case 7:
					CityPhoto.Image = Image.FromFile("cityphoto/goldkey.gif");
					CityInfo.Text = "Ȳ�� ����(Golden Key)";
					L_CityInfo.Text = 
						"Ȳ�ݿ��踦 �տ� �� �����̴�\n ���� ������ �����ϰ�\n������ ������ ��� ����.\nȲ�� ���踦 ��������ν� \n���� ���ӿ� �̱�� ������ ������\n���� ���ڿ� ���� ������ \n�ڱ⵵ �𸣴� ���̿� ������ �뿹�� \n�Ǿ� ������.";
					break;
				case 8:
					CityInfo.Text = "ī�̷�(Cairo, Igypt)";
					L_CityInfo.Text += "����Ʈ�� ����. ���ϰ�(˰) �ﰢ���� ���ܿ��� �� 25km ���� ���ϰ� ��ȿ� �ִ�. �ð��� ���ߵ�(������)�� �����󼶿��� ���� �¾ȱ��� �������� �ƶ��ǰ� ������ī ������� ���� ū �����̴�. 1�� ��ձ�� 12.7��, 8�� ��ձ�� 27.7��, ����հ����� 25mm�̴�.";
					break;
				case 9:
					CityInfo.Text = "�̽�ź��(Istanbul, Turkey)";
					L_CityInfo.Text += "��Ű �ִ��� ����. �������罺 ������ ���� �Ա��� ��ġ�ϰ�, �ƽþƿ� ������ ���� �ִ�. 1923����� 1,600�� ���� �������� �̽�ź�ҿ��� �׸���/�θ��ô���� ������ �����ô뿡 �̸��� �ټ��� ������ �ִ�. �������罺 ����, ���ȥ, ����������(��)�� ���Ͽ� �����, �̽�ź��(��Ƽ��), �������ٸ��� 3������ �뺰�ȴ�. ����/������ �߽����μ� ������������ ����Ͽ� ����/�ܱ������� ����.";
					break;
				case 10:
					CityInfo.Text = "���ε�(Uninhabited Island)";
					L_CityInfo.Text += "�ƹ��� ã�ƿ��� �ʴ¼�.\n������ ���ø� ����\n�̷������� �� �� �ִٴ°�\nū �ູ�ΰ� ����.";
					break;
				case 11:
					CityInfo.Text = "���׳�(Athens, Greece)";
					L_CityInfo.Text += "�׸����� ����. �̸��� ��(�)�� ��ȣ�� ���׳� ���Ű� ���谡 �ִ�. ��Ƽī�ݵ� �߾� ��δ�ũ��(ؽ) ���ȿ� �ִµ� ������ �����佺��(ߣ), �ϵ����� ���ڸ��ܻ�, �ϼ����� �ĸ��Ͻ���, ������ ���̰��������꿡 �ѷ����� ��߰� ��δ�ũ������ ���� ������ �ڸ���� �ִ�. ��ũ���������� �ϵ��ΰ� ���� �߽ɺ��̸�, �ձá��ǻ�硤��û������ ���� �ִ�. ";
					break;
				case 12:
					CityPhoto.Image = Image.FromFile("cityphoto/goldkey.gif");
					CityInfo.Text = "Ȳ�� ����(Golden Key)";
					L_CityInfo.Text = 
						"Ȳ�ݿ��踦 �տ� �� �����̴�\n ���� ������ �����ϰ�\n������ ������ ��� ����.\nȲ�� ���踦 ��������ν� \n���� ���ӿ� �̱�� ������ ������\n���� ���ڿ� ���� ������ \n�ڱ⵵ �𸣴� ���̿� ������ �뿹�� \n�Ǿ� ������.";
					break;
				case 13:
					CityInfo.Text = "�����ϰ�(Copenhagen, Denmark)";
					L_CityInfo.Text += "����ũ�� ����. ����ũ��δ� �꺥�Ͽ�(Kubenhavn)�̶�� �Ѵ�. �ж����� �ϵ��ȿ� �ִ� ���������� ��ȿ� �ִ� �������� ���� ���̿��� ö���������� ������. �ó����� ������ ������ ���� ���� ����, ��ȸ ���� ���๰�� ���� ���������� �Ƹ��ٿ� ���÷� ������. �̼���, �ڹ����� ���� ���������� �����ִ� ��ȸ, ��������� ���ΰ� �ִ�. ����� �Ƹ��Ը������� �����ҿ� ö���� ���� ������, �������� Ȱ���ϴ�. ";
					break;
				case 14:
					CityInfo.Text = "����Ȧ��(Stockholm, Sweden)";
					L_CityInfo.Text += "�������� ����. ��Ʈ�طκ��� �� 30km �Ž��� �ö�� ���ȣ(��) ���ʿ� ������, �ð��� ���� �ݵ��� ���� �� ���� �ڸ���� �ִ�. ���� ����� ���� ������ ���� ���ϱ��� ����ġ�ơ���� �������� �Ҹ���. ����� 1���� ��1.6��, 7���� 16.6��, ���� ������ 555mm. ���� ������ ������ö ���������� �Ϻ�Ǿ� ������ �� ������ ��ġ ����ȭ ��������� �߽����̴�.";
					break;
				case 15:
					CityInfo.Text = "���ڵ� ������(Concord Airplane)";
					L_CityInfo.Text += "62�⿡ ������ ������ ��������.\n�뼭���� 3�ð����� ����������\n�����ӿ��� �ұ��ϰ�\n100������ ž���ο��� ���� ������ ����\n���ڸ� ������ϰ� ���� ������.";
					break;
				case 16:
					CityInfo.Text = "�븮��(Zurich, Switzerland)";
					L_CityInfo.Text += "������ �븮����(�)�� �ֵ�(�Դ).�α��� 34�� 3869��(1997). �븮��ȣ(��)�� �Ͼȿ��� �귯������ ����Ʈ��(˰)�� �� ������ ���� ���ȿ� ��ġ�Ѵ�. ������ ������ �����̸�, ���ο� ö���� �������� �ش��Ͽ� �� ������� ���뿭���� �����Ѵ�. �� ���ɿ��� 11km ���ʿ� �ִ� Ŭ���� �������� ������ �ִ��� �������� ���� ������ �̾��� �ִ�. ";
					break;
				case 17:
					CityPhoto.Image = Image.FromFile("cityphoto/goldkey.gif");
					CityInfo.Text = "Ȳ�� ����(Golden Key)";
					L_CityInfo.Text = 
						"Ȳ�ݿ��踦 �տ� �� �����̴�\n ���� ������ �����ϰ�\n������ ������ ��� ����.\nȲ�� ���踦 ��������ν� \n���� ���ӿ� �̱�� ������ ������\n���� ���ڿ� ���� ������ \n�ڱ⵵ �𸣴� ���̿� ������ �뿹�� \n�Ǿ� ������.";
					break;
				case 18:
					CityInfo.Text = "������(Berlin, Germany)";
					L_CityInfo.Text += "������ ����. ���� ����, �ٸ�����-������ �ְ�(���)�� ����(��)�� �ִ�. ���� ���� ���� ȣ���� �Ȱ� �־� ���� �̰��� �پ��, �������� ����Ʈ(�������� ����)����� �뷡�� �θ� ������ ���Ⱑ ����. �ܿ��� ���� ���, ������ �����ϴ�. 2�� ����������� ���� ���� �帧�� ������ ���̶� �ױ� ��Ȱ�� ������ �Ͽ���.";
					break;
				case 19:
					CityInfo.Text = "��Ʈ����(Montreal, Canada)";
					L_CityInfo.Text += "ĳ���� ������(�)�� �ִ� ����. ��������δ� �������̶�� �Ѵ�. ������ ����Ʈ�η�����(˰) ����� ��Ʈ���ü��� �ִ� ĳ���� �ִ��� �����̴�. 1535�� �������� J.ī��Ƽ���� �߰��Ͽ�����, 1642�� ��ô������ �����Ǿ���. �� �� ���Ǳ����� �߽��� �� ����Ž���� ������ �Ǿ�����, ����� ������ ĳ���� ������ �����ϴ� ������ �߰����̴�.";
					break;
				case 20:
					CityInfo.Text = "��ȸ������� ����ó(Public Society Fund)";
					L_CityInfo.Text += "������ �������ÿ�. ��.��;";
					break;
				case 21:
					CityInfo.Text = "�ο��뽺���̷���(Buenos Aires, Argentina)";
					L_CityInfo.Text += "�Ƹ���Ƽ���� ����. �������� �������̱⵵ �ϴ�. ��ȭ�� �������ǿ�, ������ ������ ��������� �������� ��� 19���� �Ĺݺ��� �޼��� �����Ͽ���. �ױ��� ���ö�Ÿ���� ������ �����߿���(��ź��)�� ������ �ڸ��Ͽ�, �����ʹ� �� ���� �� ���Ͽ� ���� �����ȴ�. ";
					break;
				case 22:
					CityPhoto.Image = Image.FromFile("cityphoto/goldkey.gif");
					CityInfo.Text = "Ȳ�� ����(Golden Key)";
					L_CityInfo.Text = 
						"Ȳ�ݿ��踦 �տ� �� �����̴�\n ���� ������ �����ϰ�\n������ ������ ��� ����.\nȲ�� ���踦 ��������ν� \n���� ���ӿ� �̱�� ������ ������\n���� ���ڿ� ���� ������ \n�ڱ⵵ �𸣴� ���̿� ������ �뿹�� \n�Ǿ� ������.";
					break;
				case 23:
					CityInfo.Text = "���Ŀ��(San Paulu, Brazil)";
					L_CityInfo.Text += "����� ���Ŀ����(�)�� �ֵ�(�Դ). ���쵥�ڳ��̷� ������ �� 500km ����, �ع߰� �� 800m�� ������뿡 ������, �α��� 20�� �� �������ø� �����Ͽ� �α� 900���� �Ѵ� ���Ƹ޸�ī �ִ��� �����̴�. ������ �����ϰ� ������ ���ķ� ����ձ�� 18.2��, �������� 1,247mm�̴�. ���� ��� ��ȭ�� ���� ���� Ư���̴�. ";
					break;
				case 24:
					CityInfo.Text = "�õ��(Sydney, Austrailia)";
					L_CityInfo.Text += "����Ʈ���ϸ��� ����콺���Ͻ���(�)�� �ֵ�(�Դ). �õ�� �뵵�ñ��� ���� �����, ���� ȣũ��������(˰), ���� ���ʹϸ�(ؽ)���� ���� ������, ���� �α��� �� 1/4�� ���� �ִ� �� ���� �ִ��� �����̴�. ���� �������� �ع߰� 1,000m ������ ������� �������� ���� �ִ�.";
					break;
				case 25:
					CityInfo.Text = "�λ�(Pusan, Korea)";
					L_CityInfo.Text += "��󳲵� �����ܿ� �ִ� ������. ������ �ٴٿ� ���ϰ�, ������ ���ؽ� ������� ���ؽ�, ������ ���� ���ݸ�� ���ؽ� �뵿��, ������ ��걤���� �����顤�¾�鿡 ���Ѵ�. �ѱ� ��2�� ��������, ��1�� �������̴�. ���������� ���� �Ϻ� �ø�뼼Ű[��μ]�� �� 250km ������ �ִ�. ";
					break;
				case 26:
					CityInfo.Text = "�Ͽ���(Hawaii, USA)";
					L_CityInfo.Text += "�������� �ִ� �̱��� ��.�ֵ�(�Դ)�� ȣ����. 50�� �� ��� ���� ���ʿ� ��ġ�Ѵ�. �Ͽ��� ������ ū 8�� ���� 100���� �Ѵ� ���� ������ �ϼ��ʿ��� ���������� �̾��� �ִ�. �ִ��� ���� �Ͽ��̼��̸� �ֹ��� ��κ��� �����ļ��� ��� �ִ�. ";
					break;
				case 27:
					CityInfo.Text = "������(Lisbon, Portugal)";
					L_CityInfo.Text += "���������� ����. ����������δ� ��������(Lisboa)��� �Ѵ�. ���ְ�(Ÿȣ��)�� �ﰢ �ϱ� ���(����)�� ��ġ�Ѵ�. �� ���� �ִ��� �����̸�, ������� �뼭�� ���� ������ ����(����)�̱⵵ �ϴ�.";
					break;
				case 28:
					CityPhoto.Image = Image.FromFile("cityphoto/goldkey.gif");
					CityInfo.Text = "Ȳ�� ����(Golden Key)";
					L_CityInfo.Text = 
						"Ȳ�ݿ��踦 �տ� �� �����̴�\n ���� ������ �����ϰ�\n������ ������ ��� ����.\nȲ�� ���踦 ��������ν� \n���� ���ӿ� �̱�� ������ ������\n���� ���ڿ� ���� ������ \n�ڱ⵵ �𸣴� ���̿� ������ �뿹�� \n�Ǿ� ������.";
					break;
				case 29:
					CityInfo.Text = "���帮��(Madrid, Spain)";
					L_CityInfo.Text += "�����ĳ��� ����. ������ ���� �� ���� ���� ���� ������, �������� 419mm�� �����ϴ�. ����� �ϱ����� ũ��. �ٷ����� ������÷μ��� �߿伺�� ũ��, ���� �������̱⵵ �ϴ�. �α������δ� ���� ��4�� �뵵���̴�.";
					break;
				case 30:
                    CityInfo.Text = "���ֿ���(Space-tour)";
					L_CityInfo.Text += "���Ǽ��迡���� ���� �Ұ����� ���ֿ����� �η縶�ҿ����� �����ϴ�.\n���Ӽӿ����� ���ֿ����� ����� ������ ������!";
					break;
				case 31:
					CityInfo.Text = "����(Tokyo, Japan)";
					L_CityInfo.Text += "�Ϻ��� ����. Ȳ��(����)�� �߽����� �� 23�� ��(ϡ)�� ����(ϡݻ), �� ������ 3�ٸ�����[߲��ؤ�ϡ] �� ��������[������]��������Ͷ�����[������]�� �����ϴ� 3�� �������� �뺰�ȴ�. ���ļ� ���쵵[����Դ]��� �Ѵ�. �׸��� ������ �α����� ���� ������ 1���̴�. ";
					break;
				case 32:
					CityInfo.Text = "�ݷҺ��ȣ";
					L_CityInfo.Text += "�̱����� 81�⿡ �߻�� ������ ���ֿպ���.\n �����ο� ���� ���� ž���ο� ����.\n������ũ�� ���� �� ���� ������\n�־�����, �ֱ� � ������ ���� ���ĵ�.";
					break;
				case 33:
					CityInfo.Text = "�ĸ�(Paris, France)";
					L_CityInfo.Text += "�������� ����. �������� ����(��)�� �ֵ�(�Դ)������ 1964����� �ĸ������� ���� ���� �Ǿ���. �������� ��ġ�����������롤�м�����ȭ�� �߽����� �Ӹ� �ƴ϶� ������ ��ȭ �߽�����, ������ ���á���� �Ҹ��� ������ ������� ������ ������ ���á���� �θ���. ";
					break;
				case 34:
					CityInfo.Text = "�θ�(Rome, Italy)";
					L_CityInfo.Text += "��Ż������ ����. �������뿡 �ڸ���� �ִ�. ���� �߽ɺ��� Ƽ�������� �α��� �׺����� �ϱ����� �� 25km ������ ���� �ִ�. �ù��� ���� ���� �������� �ȿ� �����ϰ� �����Ƿ� �ÿ��� �Ѿ ���ñ��� ������ ���� �� ���� ����. ";
					break;
				case 35:
					CityPhoto.Image = Image.FromFile("cityphoto/goldkey.gif");
					CityInfo.Text = "Ȳ�� ����(Golden Key)";
					L_CityInfo.Text = 
						"Ȳ�ݿ��踦 �տ� �� �����̴�\n ���� ������ �����ϰ�\n������ ������ ��� ����.\nȲ�� ���踦 ��������ν� \n���� ���ӿ� �̱�� ������ ������\n���� ���ڿ� ���� ������ \n�ڱ⵵ �𸣴� ���̿� ������ �뿹�� \n�Ǿ� ������.";
					break;
				case 36:
					CityInfo.Text = "����(London, England)";
					L_CityInfo.Text += "������ ����. ���� 3������ ��ǻ��� �߽ɵ����̸�, ����,������[߾��],����[����]�� ���Ҿ� ���� �ִ� ������ �ϳ��̴�. 1888�� ������(�)�� ��ġ�Ǿ���, 99�� ��Ƽ���귱���� ������ ������ 28���� �������� �����Ͽ� ���� ��û(���)�� �����Ͽ���. ";
					break;
				case 37:
					CityInfo.Text = "����(New York, USA)";
					L_CityInfo.Text += "�̱� ������(�)�� �ִ� �ִ��� �ױ�����. 1790�� �̷� �����μ��� ������ ���������, ��� �鿡�� �̱��� ������ �ϱ⿡ ����� ������ �ִ�. ���ܸ� ���� 1600���� �Ѵ� �α��� �����ϴ� �� �Ŵ뵵�ô� �̱� �������� �������� ���踦 �̷�� ��Ư�� �����̴�.";
					break;
				case 38:
					CityInfo.Text = "��ȸ�������(Public Society Fund)";
					L_CityInfo.Text += "��ȸ������ ���Ѱ��̴� �Ʊ��ٰ� �������� ���� ����!";
					break;
				case 39:
					CityInfo.Text = "����(Seoul, Korea)";
					L_CityInfo.Text += "�ѹݵ� �߾ӿ� ��ġ�ϸ�, �Ѱ��� ���̿� �ΰ� �������� �����Ǿ� �ִ�. 1394��(���� 3)���� �ѱ��� �߽����� �Ǿ� �Դ�. 1986�� �ƽþư���ȸ, 1988�� ���� �ø��Ȱ���ȸ�� ���ֵǴ� �� �������� �뵵���̴�.";
					break;
				default:
					break;
			}
		}

		// �޴����� ���� On Ŭ��
		private void M_MusicOn_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck == true)
				PlaySound();
		}

		// �޴����� ���� Off Ŭ��
		private void M_MusicOff_Click(object sender, System.EventArgs e)
		{
			m_objSound1.Stop();
		}
	}
}
