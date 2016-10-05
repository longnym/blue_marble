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

		// 각각의 WAV파일 설정을 위한 Player 객체 선언
		private MediaPlayerClass m_objSound1;
		private SoundPlayer m_objSound2;
		private SoundPlayer m_SoundSigh;
		private SoundPlayer m_SoundAbout;
		private SoundPlayer m_SoundIsland;
		private SoundPlayer m_SoundAmbulance;
		private SoundPlayer m_SoundLaugh;
		private SoundPlayer m_SoundP;

		private System.ComponentModel.Container components = null;

		// 게임에 필요한 Object들을 생성
		City[] cities = new City[40];
		Player[] players = new Player[4];
		GameData game = new GameData();
		Card[] cards = new Card[30];
		
		// 카드를 섞기위해 한개 더 생성
		Card[] deck = new Card[30];

		private bool GameStartCheck;	// 게임이 시작되었는가?
		private bool CitySellCheck;		// 지불할 돈이 부족할때 도시를 팔수있도록 설정
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
		private bool GoldKeyCheck;		// 현재 황금열쇠를 실행했는가?

		public Board()
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();
			// 사운드 설정 초기화
			InitialiseSound(this.Handle.ToInt32());
			// 게임 데이터 초기화
			DataInitialize();
			// 도시 정보 설정
			SetCity();
			// 황금열쇠 카드 정보 설정
			SetCard();
			// 황금열쇠 카드 섞기
			DeckMix();

			Logo.Visible = true;
			CityInfo.Visible = false;
			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
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

		// 배경음악 연주
		private void PlaySound()
		{
			if(m_blnDirectSoundInitialised)
			{
                m_objSound1.Play();
			}
		}

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
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
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
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
			this.M_Game.Text = "게임";
			// 
			// M_GameStart
			// 
			this.M_GameStart.Index = 0;
			this.M_GameStart.Text = "게임 시작";
			this.M_GameStart.Click += new System.EventHandler(this.M_GameStart_Click);
			// 
			// M_GameStop
			// 
			this.M_GameStop.Index = 1;
			this.M_GameStop.Text = "게임 중단";
			this.M_GameStop.Click += new System.EventHandler(this.M_GameStop_Click);
			// 
			// M_GameSet
			// 
			this.M_GameSet.Index = 2;
			this.M_GameSet.Text = "게임 설정";
			this.M_GameSet.Click += new System.EventHandler(this.M_GameSet_Click);
			// 
			// M_Exit
			// 
			this.M_Exit.Index = 3;
			this.M_Exit.Text = "끝";
			this.M_Exit.Click += new System.EventHandler(this.M_Exit_Click);
			// 
			// M_Option
			// 
			this.M_Option.Index = 1;
			this.M_Option.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.M_MusicOn,
																					 this.M_MusicOff});
			this.M_Option.Text = "옵션";
			// 
			// M_MusicOn
			// 
			this.M_MusicOn.Index = 0;
			this.M_MusicOn.Text = "음악 On";
			this.M_MusicOn.Click += new System.EventHandler(this.M_MusicOn_Click);
			// 
			// M_MusicOff
			// 
			this.M_MusicOff.Index = 1;
			this.M_MusicOff.Text = "음악 Off";
			this.M_MusicOff.Click += new System.EventHandler(this.M_MusicOff_Click);
			// 
			// M_Help
			// 
			this.M_Help.Index = 2;
			this.M_Help.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.M_About});
			this.M_Help.Text = "도움말";
			// 
			// M_About
			// 
			this.M_About.Index = 0;
			this.M_About.Text = "대하여...";
			this.M_About.Click += new System.EventHandler(this.M_About_Click);
			// 
			// G_Player1
			// 
			this.G_Player1.BackColor = System.Drawing.Color.Transparent;
			this.G_Player1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.P_Avatar1,
																					this.L_Player1});
			this.G_Player1.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.G_Player1.ForeColor = System.Drawing.Color.White;
			this.G_Player1.Location = new System.Drawing.Point(8, 8);
			this.G_Player1.Name = "G_Player1";
			this.G_Player1.Size = new System.Drawing.Size(184, 328);
			this.G_Player1.TabIndex = 0;
			this.G_Player1.TabStop = false;
			this.G_Player1.Text = "플레이어 1";
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
			this.G_Player2.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.G_Player2.ForeColor = System.Drawing.Color.White;
			this.G_Player2.Location = new System.Drawing.Point(824, 8);
			this.G_Player2.Name = "G_Player2";
			this.G_Player2.Size = new System.Drawing.Size(184, 328);
			this.G_Player2.TabIndex = 1;
			this.G_Player2.TabStop = false;
			this.G_Player2.Text = "플레이어 2";
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
			this.G_Player3.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.G_Player3.ForeColor = System.Drawing.Color.White;
			this.G_Player3.Location = new System.Drawing.Point(8, 352);
			this.G_Player3.Name = "G_Player3";
			this.G_Player3.Size = new System.Drawing.Size(184, 328);
			this.G_Player3.TabIndex = 2;
			this.G_Player3.TabStop = false;
			this.G_Player3.Text = "플레이어 3";
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
			this.G_Player4.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.G_Player4.ForeColor = System.Drawing.Color.White;
			this.G_Player4.Location = new System.Drawing.Point(824, 352);
			this.G_Player4.Name = "G_Player4";
			this.G_Player4.Size = new System.Drawing.Size(184, 328);
			this.G_Player4.TabIndex = 3;
			this.G_Player4.TabStop = false;
			this.G_Player4.Text = "플레이어 4";
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
			this.B_Roll.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.B_Roll.ForeColor = System.Drawing.Color.White;
			this.B_Roll.Location = new System.Drawing.Point(200, 16);
			this.B_Roll.Name = "B_Roll";
			this.B_Roll.Size = new System.Drawing.Size(144, 32);
			this.B_Roll.TabIndex = 4;
			this.B_Roll.Text = "주사위 던지기";
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
			this.CityInfo.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.CityInfo.ForeColor = System.Drawing.Color.Lime;
			this.CityInfo.Location = new System.Drawing.Point(304, 160);
			this.CityInfo.Name = "CityInfo";
			this.CityInfo.Size = new System.Drawing.Size(408, 408);
			this.CityInfo.TabIndex = 6;
			this.CityInfo.TabStop = false;
			this.CityInfo.Text = "도시정보";
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
			this.Buy.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.Buy.Location = new System.Drawing.Point(360, 16);
			this.Buy.Name = "Buy";
			this.Buy.Size = new System.Drawing.Size(144, 32);
			this.Buy.TabIndex = 11;
			this.Buy.Text = "도시/건물 구입";
			this.Buy.Click += new System.EventHandler(this.Buy_Click);
			// 
			// NextPlayer
			// 
			this.NextPlayer.BackColor = System.Drawing.Color.Transparent;
			this.NextPlayer.Enabled = false;
			this.NextPlayer.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.NextPlayer.Location = new System.Drawing.Point(672, 16);
			this.NextPlayer.Name = "NextPlayer";
			this.NextPlayer.Size = new System.Drawing.Size(144, 32);
			this.NextPlayer.TabIndex = 12;
			this.NextPlayer.Text = "다음 플레이어";
			this.NextPlayer.Click += new System.EventHandler(this.NextPlayer_Click);
			// 
			// City1
			// 
			this.City1.BackColor = System.Drawing.Color.White;
			this.City1.Font = new System.Drawing.Font("맑은 고딕", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City1.ForeColor = System.Drawing.Color.Black;
			this.City1.Location = new System.Drawing.Point(680, 616);
			this.City1.Name = "City1";
			this.City1.Size = new System.Drawing.Size(40, 48);
			this.City1.TabIndex = 13;
			this.City1.Click += new System.EventHandler(this.City1_Click);
			// 
			// City2
			// 
			this.City2.Font = new System.Drawing.Font("맑은 고딕", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City2.ForeColor = System.Drawing.Color.Black;
			this.City2.Location = new System.Drawing.Point(584, 616);
			this.City2.Name = "City2";
			this.City2.Size = new System.Drawing.Size(40, 48);
			this.City2.TabIndex = 15;
			this.City2.Click += new System.EventHandler(this.City2_Click);
			// 
			// City3
			// 
			this.City3.Font = new System.Drawing.Font("맑은 고딕", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City3.ForeColor = System.Drawing.Color.Black;
			this.City3.Location = new System.Drawing.Point(536, 616);
			this.City3.Name = "City3";
			this.City3.Size = new System.Drawing.Size(40, 48);
			this.City3.TabIndex = 16;
			this.City3.Click += new System.EventHandler(this.City3_Click);
			// 
			// City4
			// 
			this.City4.Font = new System.Drawing.Font("맑은 고딕", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City4.ForeColor = System.Drawing.Color.Black;
			this.City4.Location = new System.Drawing.Point(488, 616);
			this.City4.Name = "City4";
			this.City4.Size = new System.Drawing.Size(40, 48);
			this.City4.TabIndex = 18;
			this.City4.Click += new System.EventHandler(this.City4_Click);
			// 
			// City5
			// 
			this.City5.Font = new System.Drawing.Font("맑은 고딕", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City5.ForeColor = System.Drawing.Color.Black;
			this.City5.Location = new System.Drawing.Point(440, 616);
			this.City5.Name = "City5";
			this.City5.Size = new System.Drawing.Size(40, 48);
			this.City5.TabIndex = 20;
			this.City5.Click += new System.EventHandler(this.City5_Click);
			// 
			// City6
			// 
			this.City6.Font = new System.Drawing.Font("맑은 고딕", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City6.ForeColor = System.Drawing.Color.Black;
			this.City6.Location = new System.Drawing.Point(344, 616);
			this.City6.Name = "City6";
			this.City6.Size = new System.Drawing.Size(40, 48);
			this.City6.TabIndex = 21;
			this.City6.Click += new System.EventHandler(this.City6_Click);
			// 
			// City7
			// 
			this.City7.Font = new System.Drawing.Font("맑은 고딕", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City7.ForeColor = System.Drawing.Color.Black;
			this.City7.Location = new System.Drawing.Point(296, 616);
			this.City7.Name = "City7";
			this.City7.Size = new System.Drawing.Size(40, 48);
			this.City7.TabIndex = 22;
			this.City7.Click += new System.EventHandler(this.City7_Click);
			// 
			// City8
			// 
			this.City8.Font = new System.Drawing.Font("맑은 고딕", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City8.ForeColor = System.Drawing.Color.Black;
			this.City8.Location = new System.Drawing.Point(208, 536);
			this.City8.Name = "City8";
			this.City8.Size = new System.Drawing.Size(48, 40);
			this.City8.TabIndex = 24;
			this.City8.Click += new System.EventHandler(this.City8_Click);
			// 
			// City9
			// 
			this.City9.Font = new System.Drawing.Font("맑은 고딕", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City9.ForeColor = System.Drawing.Color.Black;
			this.City9.Location = new System.Drawing.Point(208, 440);
			this.City9.Name = "City9";
			this.City9.Size = new System.Drawing.Size(48, 40);
			this.City9.TabIndex = 25;
			this.City9.Click += new System.EventHandler(this.City9_Click);
			// 
			// City10
			// 
			this.City10.Font = new System.Drawing.Font("맑은 고딕", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City10.ForeColor = System.Drawing.Color.Black;
			this.City10.Location = new System.Drawing.Point(208, 392);
			this.City10.Name = "City10";
			this.City10.Size = new System.Drawing.Size(48, 40);
			this.City10.TabIndex = 27;
			this.City10.Click += new System.EventHandler(this.City10_Click);
			// 
			// City11
			// 
			this.City11.Font = new System.Drawing.Font("맑은 고딕", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City11.ForeColor = System.Drawing.Color.Black;
			this.City11.Location = new System.Drawing.Point(208, 344);
			this.City11.Name = "City11";
			this.City11.Size = new System.Drawing.Size(80, 40);
			this.City11.TabIndex = 29;
			this.City11.Click += new System.EventHandler(this.City11_Click);
			// 
			// City12
			// 
			this.City12.Font = new System.Drawing.Font("맑은 고딕", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City12.ForeColor = System.Drawing.Color.Black;
			this.City12.Location = new System.Drawing.Point(208, 296);
			this.City12.Name = "City12";
			this.City12.Size = new System.Drawing.Size(48, 40);
			this.City12.TabIndex = 30;
			this.City12.Click += new System.EventHandler(this.City12_Click);
			// 
			// City13
			// 
			this.City13.Font = new System.Drawing.Font("맑은 고딕", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City13.ForeColor = System.Drawing.Color.Black;
			this.City13.Location = new System.Drawing.Point(208, 200);
			this.City13.Name = "City13";
			this.City13.Size = new System.Drawing.Size(48, 40);
			this.City13.TabIndex = 31;
			this.City13.Click += new System.EventHandler(this.City13_Click);
			// 
			// City14
			// 
			this.City14.Font = new System.Drawing.Font("맑은 고딕", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City14.ForeColor = System.Drawing.Color.Black;
			this.City14.Location = new System.Drawing.Point(208, 152);
			this.City14.Name = "City14";
			this.City14.Size = new System.Drawing.Size(48, 40);
			this.City14.TabIndex = 33;
			this.City14.Click += new System.EventHandler(this.City14_Click);
			// 
			// City15
			// 
			this.City15.Font = new System.Drawing.Font("맑은 고딕", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City15.ForeColor = System.Drawing.Color.Black;
			this.City15.Location = new System.Drawing.Point(296, 64);
			this.City15.Name = "City15";
			this.City15.Size = new System.Drawing.Size(40, 48);
			this.City15.TabIndex = 34;
			this.City15.Click += new System.EventHandler(this.City15_Click);
			// 
			// City16
			// 
			this.City16.Font = new System.Drawing.Font("맑은 고딕", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City16.ForeColor = System.Drawing.Color.Black;
			this.City16.Location = new System.Drawing.Point(392, 64);
			this.City16.Name = "City16";
			this.City16.Size = new System.Drawing.Size(40, 48);
			this.City16.TabIndex = 36;
			this.City16.Click += new System.EventHandler(this.City16_Click);
			// 
			// City17
			// 
			this.City17.Font = new System.Drawing.Font("맑은 고딕", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City17.ForeColor = System.Drawing.Color.Black;
			this.City17.Location = new System.Drawing.Point(440, 64);
			this.City17.Name = "City17";
			this.City17.Size = new System.Drawing.Size(40, 48);
			this.City17.TabIndex = 37;
			this.City17.Click += new System.EventHandler(this.City17_Click);
			// 
			// City18
			// 
			this.City18.Font = new System.Drawing.Font("맑은 고딕", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City18.ForeColor = System.Drawing.Color.Black;
			this.City18.Location = new System.Drawing.Point(488, 64);
			this.City18.Name = "City18";
			this.City18.Size = new System.Drawing.Size(40, 48);
			this.City18.TabIndex = 39;
			this.City18.Click += new System.EventHandler(this.City18_Click);
			// 
			// City19
			// 
			this.City19.Font = new System.Drawing.Font("맑은 고딕", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City19.ForeColor = System.Drawing.Color.Black;
			this.City19.Location = new System.Drawing.Point(536, 64);
			this.City19.Name = "City19";
			this.City19.Size = new System.Drawing.Size(40, 48);
			this.City19.TabIndex = 40;
			this.City19.Click += new System.EventHandler(this.City19_Click);
			// 
			// City20
			// 
			this.City20.Font = new System.Drawing.Font("맑은 고딕", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City20.ForeColor = System.Drawing.Color.Black;
			this.City20.Location = new System.Drawing.Point(584, 64);
			this.City20.Name = "City20";
			this.City20.Size = new System.Drawing.Size(40, 48);
			this.City20.TabIndex = 42;
			this.City20.Click += new System.EventHandler(this.City20_Click);
			// 
			// City21
			// 
			this.City21.Font = new System.Drawing.Font("맑은 고딕", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City21.ForeColor = System.Drawing.Color.Black;
			this.City21.Location = new System.Drawing.Point(680, 64);
			this.City21.Name = "City21";
			this.City21.Size = new System.Drawing.Size(40, 48);
			this.City21.TabIndex = 43;
			this.City21.Click += new System.EventHandler(this.City21_Click);
			// 
			// City22
			// 
			this.City22.Font = new System.Drawing.Font("맑은 고딕", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City22.ForeColor = System.Drawing.Color.Black;
			this.City22.Location = new System.Drawing.Point(760, 152);
			this.City22.Name = "City22";
			this.City22.Size = new System.Drawing.Size(48, 40);
			this.City22.TabIndex = 45;
			this.City22.Click += new System.EventHandler(this.City22_Click);
			// 
			// City23
			// 
			this.City23.Font = new System.Drawing.Font("맑은 고딕", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
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
			this.City24.Font = new System.Drawing.Font("맑은 고딕", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City24.ForeColor = System.Drawing.Color.Black;
			this.City24.Location = new System.Drawing.Point(760, 248);
			this.City24.Name = "City24";
			this.City24.Size = new System.Drawing.Size(48, 40);
			this.City24.TabIndex = 48;
			this.City24.Click += new System.EventHandler(this.City24_Click);
			// 
			// City25
			// 
			this.City25.Font = new System.Drawing.Font("맑은 고딕", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City25.ForeColor = System.Drawing.Color.Black;
			this.City25.Location = new System.Drawing.Point(760, 296);
			this.City25.Name = "City25";
			this.City25.Size = new System.Drawing.Size(48, 40);
			this.City25.TabIndex = 49;
			this.City25.Click += new System.EventHandler(this.City25_Click);
			// 
			// City26
			// 
			this.City26.Font = new System.Drawing.Font("맑은 고딕", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City26.ForeColor = System.Drawing.Color.Black;
			this.City26.Location = new System.Drawing.Point(760, 392);
			this.City26.Name = "City26";
			this.City26.Size = new System.Drawing.Size(48, 40);
			this.City26.TabIndex = 50;
			this.City26.Click += new System.EventHandler(this.City26_Click);
			// 
			// City27
			// 
			this.City27.Font = new System.Drawing.Font("맑은 고딕", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.City27.ForeColor = System.Drawing.Color.Black;
			this.City27.Location = new System.Drawing.Point(760, 440);
			this.City27.Name = "City27";
			this.City27.Size = new System.Drawing.Size(48, 40);
			this.City27.TabIndex = 51;
			this.City27.Click += new System.EventHandler(this.City27_Click);
			// 
			// City28
			// 
			this.City28.Font = new System.Drawing.Font("맑은 고딕", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
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
			this.Sell.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.Sell.Location = new System.Drawing.Point(512, 16);
			this.Sell.Name = "Sell";
			this.Sell.Size = new System.Drawing.Size(144, 32);
			this.Sell.TabIndex = 66;
			this.Sell.Text = "도시 매각";
			this.Sell.Click += new System.EventHandler(this.Sell_Click);
			// 
			// Player1Pic
			// 
			this.Player1Pic.BackColor = System.Drawing.Color.Red;
			this.Player1Pic.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
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
			this.Player2Pic.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
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
			this.Player3Pic.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
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
			this.Player4Pic.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
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
			this.Text = "부루마불 체험판";
			this.G_Player1.ResumeLayout(false);
			this.G_Player2.ResumeLayout(false);
			this.G_Player3.ResumeLayout(false);
			this.G_Player4.ResumeLayout(false);
			this.CityInfo.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 해당 응용 프로그램의 주 진입점입니다.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Board());
		}

		// 현재 도시의 소유자를 색깔로 표시
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

		// 현재 플레이어의 정보를 화면에 출력
		private void RePrint()
		{	
			L_Player1.Text = "이름 : " + players[0].PlayerName;
			if(players[0].PlayerIsDead == false)
				L_Player1.Text += "\n소지금 : " + (float)players[0].PlayerMoney/10000 + "만원";
			else
				L_Player1.Text += "\n파산";
			L_Player1.Text += "\n현재위치 : " + 
				cities[players[0].PlayerLocate].CityName;
			L_Player1.Text += "\n<< 아이템 >>";
			
			if(players[0].HaveItem1 > 0)
			{
				L_Player1.Text += "\n무전기 : " + players[0].HaveItem1;
			}
			if(players[0].HaveItem2 > 0)
			{
				L_Player1.Text += "\n우대권 : " + players[0].HaveItem2;
			}
			if(players[0].HaveItem1 == 0 && players[0].HaveItem2 == 0)
			{
				L_Player1.Text += "\n없음";
			}

			P_Avatar1.Image = Image.FromFile("avatar/avatar"+players[0].PlayerAvatar+".gif");

			L_Player2.Text = "이름 : " + players[1].PlayerName;
			if(players[1].PlayerIsDead == false)
				L_Player2.Text += "\n소지금 : " + (float)players[1].PlayerMoney/10000 + "만원";
			else
				L_Player2.Text += "\n파산";
			L_Player2.Text += "\n현재위치 : " + 
				cities[players[1].PlayerLocate].CityName;
			L_Player2.Text += "\n<< 아이템 >>";
			
			if(players[1].HaveItem1 > 0)
			{
				L_Player2.Text += "\n무전기 : " + players[1].HaveItem1;
			}
			if(players[1].HaveItem2 > 0)
			{
				L_Player2.Text += "\n우대권 : " + players[1].HaveItem2;
			}
			if(players[1].HaveItem1 == 0 && players[1].HaveItem2 == 0)
			{
				L_Player2.Text += "\n없음";
			}

			P_Avatar2.Image = Image.FromFile("avatar/avatar"+players[1].PlayerAvatar+".gif");

			if(game.maxPlayer >= 3) 
			{
				L_Player3.Text = "이름 : " + players[2].PlayerName;
				if(players[2].PlayerIsDead == false)
					L_Player3.Text += "\n소지금 : " + (float)players[2].PlayerMoney/10000 + "만원";
				else
					L_Player3.Text += "\n파산";
				L_Player3.Text += "\n현재위치 : " + 
					cities[players[2].PlayerLocate].CityName;
				L_Player3.Text += "\n<< 아이템 >>";
			
				if(players[2].HaveItem1 > 0)
				{
					L_Player3.Text += "\n무전기 : " + players[2].HaveItem1;
				}
				if(players[2].HaveItem2 > 0)
				{
					L_Player3.Text += "\n우대권 : " + players[2].HaveItem2;
				}
				if(players[2].HaveItem1 == 0 && players[2].HaveItem2 == 0)
				{
					L_Player3.Text += "\n없음";
				}

				P_Avatar3.Image = Image.FromFile("avatar/avatar"+players[2].PlayerAvatar+".gif");
			}

			if(game.maxPlayer == 4)
			{
				L_Player4.Text = "이름 : " + players[3].PlayerName;
				if(players[3].PlayerIsDead == false)
					L_Player4.Text += "\n소지금 : " + (float)players[3].PlayerMoney/10000 + "만원";
				else
					L_Player4.Text += "\n파산";
				L_Player4.Text += "\n현재위치 : " + 
					cities[players[3].PlayerLocate].CityName;
				L_Player4.Text += "\n<< 아이템 >>";
			
				if(players[3].HaveItem1 > 0)
				{
					L_Player4.Text += "\n무전기 : " + players[3].HaveItem1;
				}
				if(players[3].HaveItem2 > 0)
				{
					L_Player4.Text += "\n우대권 : " + players[3].HaveItem2;
				}
				if(players[3].HaveItem1 == 0 && players[3].HaveItem2 == 0)
				{
					L_Player4.Text += "\n없음";
				}

				P_Avatar4.Image = Image.FromFile("avatar/avatar"+players[3].PlayerAvatar+".gif");
			}
		}

		// 카드 섞기
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

		// 말판 이동(통상적인 이동)
		private void LocMove(int current)
		{
			players[current].PlayerLocate++;

			// 출발지점을 통과하는지 확인
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

			// 세계일주를 할때 사회복지 기금을 받아옴
			if(game.OneTurnCheck == true && players[current].PlayerLocate == 20)
			{
				if (game.SocietyFund != 0)
					m_SoundLaugh.Play();
				cities[players[current].PlayerLocate].SocietyFund(players[current]
					,game );
				game.BuyCheck = true;
			}

			if(players[current].PlayerLocate == 0 && players[current].NoPay == false) 
				GivePay(players[current]);		// 월급주기
		}

		// 말판 이동(뒤로 이동) => 황금열쇠카드에서 사용
		private void LocMoveBack(int current)
		{
			players[current].PlayerLocate--;

			// 출발지점을 통과하는지 확인
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

		// 게임 종료시 호출
		private void GameOver()
		{
			int winner = 0;

			for(int i = 0; i < game.maxPlayer - 1; i++)		// 버그 체크
			{
				if(players[winner].PlayerMoney <= players[i+1].PlayerMoney)
					winner = i + 1;
			}
			
			m_SoundP.Play();

			UserBuffer.winner = players[winner].PlayerName;

			// 승리한 플레이어를 출력하는 대화상자를 실행
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

		// 주사위 굴리기
		private int RollDice(Player temp)
		{
			Random DiceNum = new Random();
			int num1 = 0, num2 = 0, move = 0;
			
			num1 = DiceNum.Next(0,1000) % 6 + 1;
			num2 = DiceNum.Next(0,1000) % 6 + 1;
			DiceNums.dicenum1 = num1;
			DiceNums.dicenum2 = num2;

			// 주사위 그림 출력
			RollDiceDlg roll = new RollDiceDlg();
			roll.ShowDialog();

			
			move = num1 + num2;

			// 두 주사위가 같은수가 나왔을때(더블이라 칭함)
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

		// 도시설정
		#region SerCityData
		private void SetCity()
		{
			// 도시 좌표 설정
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

			// 도시 정보 설정
			cities[0].CityType = 6;
			cities[0].CityName = "출발";
			cities[1].CityType = 0;
			cities[1].CityPriceLand  = 50000;
			cities[1].CityPriceUnit1 = 50000;
			cities[1].CityPriceUnit2 = 150000;
			cities[1].CityPriceUnit3 = 250000;
			cities[1].CityName = "타이페이";
			cities[1].CityNation = "대만";
			cities[1].CityPayLand = 2000;
			cities[1].CityPayUnit1 = 10000;
			cities[1].CityPayUnit2 = 90000;
			cities[1].CityPayUnit3 = 250000;
			cities[2].CityType = 2;
			cities[2].CityName = "황금열쇠";
			cities[3].CityType = 0;
			cities[3].CityPriceLand = 80000;
			cities[3].CityPriceUnit1 = 50000;
			cities[3].CityPriceUnit2 = 150000;
			cities[3].CityPriceUnit3 = 250000;
			cities[3].CityName = "홍콩";
			cities[3].CityNation = "중국";
			cities[3].CityPayLand = 4000;
			cities[3].CityPayUnit1 = 20000;
			cities[3].CityPayUnit2 = 180000;
			cities[3].CityPayUnit3 = 450000;;
			cities[4].CityType = 0;
			cities[4].CityPriceLand = 80000;
			cities[4].CityPriceUnit1 = 50000;
			cities[4].CityPriceUnit2 = 150000;
			cities[4].CityPriceUnit3 = 250000;
			cities[4].CityName = "마닐라";
			cities[4].CityNation = "필리핀";
			cities[4].CityPayLand = 4000;
			cities[4].CityPayUnit1 = 20000;
			cities[4].CityPayUnit2 = 180000;
			cities[4].CityPayUnit3 = 450000;
			cities[5].CityType = 1;
			cities[5].CityPriceLand = 200000;
			cities[5].CityName = "제주도";
			cities[5].CityNation = "대한민국";
			cities[5].CityPayLand = 300000;
			cities[6].CityType = 0;
			cities[6].CityPriceLand = 100000;
			cities[6].CityPriceUnit1 = 50000;
			cities[6].CityPriceUnit2 = 150000;
			cities[6].CityPriceUnit3 = 250000;
			cities[6].CityName = "싱가포르";
			cities[6].CityNation = "싱가포르";
			cities[6].CityPayLand = 6000;
			cities[6].CityPayUnit1 = 30000;
			cities[6].CityPayUnit2 = 270000;
			cities[6].CityPayUnit3 = 550000;
			cities[7].CityType = 2;
			cities[7].CityName = "황금열쇠";
			cities[8].CityType = 0;
			cities[8].CityPriceLand = 100000;
			cities[8].CityPriceUnit1 = 50000;
			cities[8].CityPriceUnit2 = 150000;
			cities[8].CityPriceUnit3 = 250000;
			cities[8].CityName = "카이로";
			cities[8].CityNation = "이집트";
			cities[8].CityPayLand = 6000;
			cities[8].CityPayUnit1 = 30000;
			cities[8].CityPayUnit2 = 270000;
			cities[8].CityPayUnit3 = 550000;
			cities[9].CityType = 0;
			cities[9].CityPriceLand = 120000;
			cities[9].CityPriceUnit1 = 50000;
			cities[9].CityPriceUnit2 = 150000;
			cities[9].CityPriceUnit3 = 250000;
			cities[9].CityName = "이스탄불";
			cities[9].CityNation = "터키";
			cities[9].CityPayLand = 8000;
			cities[9].CityPayUnit1 = 40000;
			cities[9].CityPayUnit2 = 300000;
			cities[9].CityPayUnit3 = 600000;
			cities[10].CityType = 3;
			cities[10].CityName = "무인도";
			cities[11].CityType = 0;
			cities[11].CityPriceLand = 140000;
			cities[11].CityPriceUnit1 = 100000;
			cities[11].CityPriceUnit2 = 300000;
			cities[11].CityPriceUnit3 = 500000;
			cities[11].CityName = "아테네";
			cities[11].CityNation = "그리스";
			cities[11].CityPayLand = 10000;
			cities[11].CityPayUnit1 = 50000;
			cities[11].CityPayUnit2 = 450000;
			cities[11].CityPayUnit3 = 750000;
			cities[12].CityType = 2;
			cities[12].CityName = "황금열쇠";
			cities[13].CityType = 0;
			cities[13].CityPriceLand = 160000;
			cities[13].CityPriceUnit1 = 100000;
			cities[13].CityPriceUnit2 = 300000;
			cities[13].CityPriceUnit3 = 500000;
			cities[13].CityName = "코펜하겐";
			cities[13].CityNation = "덴마크";
			cities[13].CityPayLand = 12000;
			cities[13].CityPayUnit1 = 60000;
			cities[13].CityPayUnit2 = 500000;
			cities[13].CityPayUnit3 = 900000;
			cities[14].CityType = 0;
			cities[14].CityPriceLand = 160000;
			cities[14].CityPriceUnit1 = 100000;
			cities[14].CityPriceUnit2 = 300000;
			cities[14].CityPriceUnit3 = 500000;
			cities[14].CityName = "스톡홀롬";
			cities[14].CityNation = "스웨덴";
			cities[14].CityPayLand = 12000;
			cities[14].CityPayUnit1 = 60000;
			cities[14].CityPayUnit2 = 500000;
			cities[14].CityPayUnit3 = 900000;
			cities[15].CityType = 1;
			cities[15].CityPriceLand = 200000;
			cities[15].CityName = "콩코드 여객기";
			cities[15].CityNation = "초음속 여객기";
			cities[15].CityPayLand = 300000;
			cities[16].CityType = 0;
			cities[16].CityPriceLand = 180000;
			cities[16].CityPriceUnit1 = 100000;
			cities[16].CityPriceUnit2 = 300000;
			cities[16].CityPriceUnit3 = 500000;
			cities[16].CityName = "취리히";
			cities[16].CityNation = "스위스";
			cities[16].CityPayLand = 14000;
			cities[16].CityPayUnit1 = 70000;
			cities[16].CityPayUnit2 = 550000;
			cities[16].CityPayUnit3 = 950000;
			cities[17].CityType = 2;
			cities[17].CityName = "황금열쇠";
			cities[18].CityType = 0;
			cities[18].CityPriceLand = 180000;
			cities[18].CityPriceUnit1 = 100000;
			cities[18].CityPriceUnit2 = 300000;
			cities[18].CityPriceUnit3 = 500000;
			cities[18].CityName = "베를린";
			cities[18].CityNation = "독일";
			cities[18].CityPayLand = 14000;
			cities[18].CityPayUnit1 = 70000;
			cities[18].CityPayUnit2 = 550000;
			cities[18].CityPayUnit3 = 950000;
			cities[19].CityType = 0;
			cities[19].CityPriceLand = 200000;
			cities[19].CityPriceUnit1 = 100000;
			cities[19].CityPriceUnit2 = 300000;
			cities[19].CityPriceUnit3 = 500000;
			cities[19].CityName = "몬트리올";
			cities[19].CityNation = "캐나다";
			cities[19].CityPayLand = 16000;
			cities[19].CityPayUnit1 = 80000;
			cities[19].CityPayUnit2 = 600000;
			cities[19].CityPayUnit3 = 1000000;
			cities[20].CityType = 5;
			cities[20].CityName = "사회복지기금(접수처)";
			cities[21].CityType = 0;
			cities[21].CityPriceLand = 220000;
			cities[21].CityPriceUnit1 = 150000;
			cities[21].CityPriceUnit2 = 450000;
			cities[21].CityPriceUnit3 = 750000;
			cities[21].CityName = "부에노스아이레스";
			cities[21].CityNation = "아르헨티나";
			cities[21].CityPayLand = 18000;
			cities[21].CityPayUnit1 = 90000;
			cities[21].CityPayUnit2 = 700000;
			cities[21].CityPayUnit3 = 1050000;
			cities[22].CityType = 2;
			cities[22].CityName = "황금열쇠";
			cities[23].CityType = 0;
			cities[23].CityPriceLand = 240000;
			cities[23].CityPriceUnit1 = 150000;
			cities[23].CityPriceUnit2 = 450000;
			cities[23].CityPriceUnit3 = 750000;
			cities[23].CityName = "상파울로";
			cities[23].CityNation = "브라질";
			cities[23].CityPayLand = 20000;
			cities[23].CityPayUnit1 = 100000;
			cities[23].CityPayUnit2 = 750000;
			cities[23].CityPayUnit3 = 1100000;
			cities[24].CityType = 0;
			cities[24].CityPriceLand = 240000;
			cities[24].CityPriceUnit1 = 150000;
			cities[24].CityPriceUnit2 = 450000;
			cities[24].CityPriceUnit3 = 750000;
			cities[24].CityName = "시드니";
			cities[24].CityNation = "오스트레일리아";
			cities[24].CityPayLand = 20000;
			cities[24].CityPayUnit1 = 100000;
			cities[24].CityPayUnit2 = 750000;
			cities[24].CityPayUnit3 = 1100000;
			cities[25].CityType = 1;
			cities[25].CityPriceLand = 500000;
			cities[25].CityName = "부산";
			cities[25].CityNation = "대한민국";
			cities[25].CityPayLand = 600000;
			cities[26].CityType = 0;
			cities[26].CityPriceLand = 260000;
			cities[26].CityPriceUnit1 = 150000;
			cities[26].CityPriceUnit2 = 450000;
			cities[26].CityPriceUnit3 = 750000;
			cities[26].CityName = "하와이";
			cities[26].CityNation = "태평양 군도";
			cities[26].CityPayLand = 22000;
			cities[26].CityPayUnit1 = 110000;
			cities[26].CityPayUnit2 = 800000;
			cities[26].CityPayUnit3 = 1150000;
			cities[27].CityType = 0;
			cities[27].CityPriceLand = 260000;
			cities[27].CityPriceUnit1 = 150000;
			cities[27].CityPriceUnit2 = 450000;
			cities[27].CityPriceUnit3 = 750000;
			cities[27].CityName = "리스본";
			cities[27].CityNation = "포르투갈";
			cities[27].CityPayLand = 22000;
			cities[27].CityPayUnit1 = 110000;
			cities[27].CityPayUnit2 = 800000;
			cities[27].CityPayUnit3 = 1150000;
			cities[28].CityType = 2;
			cities[28].CityName = "황금열쇠";
			cities[29].CityType = 0;
			cities[29].CityPriceLand = 280000;
			cities[29].CityPriceUnit1 = 150000;
			cities[29].CityPriceUnit2 = 450000;
			cities[29].CityPriceUnit3 = 750000;
			cities[29].CityName = "마드리드";
			cities[29].CityNation = "스페인";
			cities[29].CityPayLand = 24000;
			cities[29].CityPayUnit1 = 120000;
			cities[29].CityPayUnit2 = 850000;
			cities[29].CityPayUnit3 = 1200000;
			cities[30].CityType = 4;
			cities[30].CityName = "우주여행";
			cities[31].CityType = 0;
			cities[31].CityPriceLand = 300000;
			cities[31].CityPriceUnit1 = 200000;
			cities[31].CityPriceUnit2 = 600000;
			cities[31].CityPriceUnit3 = 1000000;
			cities[31].CityName = "도쿄";
			cities[31].CityNation = "일본";
			cities[31].CityPayLand = 26000;
			cities[31].CityPayUnit1 = 130000;
			cities[31].CityPayUnit2 = 900000;
			cities[31].CityPayUnit3 = 1270000;
			cities[32].CityType = 1;
			cities[32].CityPriceLand = 450000;
			cities[32].CityName = "콜롬비아호";
			cities[32].CityNation = "우주왕복선";
			cities[32].CityPayLand = 400000;
			cities[33].CityType = 0;
			cities[33].CityPriceLand = 320000;
			cities[33].CityPriceUnit1 = 200000;
			cities[33].CityPriceUnit2 = 600000;
			cities[33].CityPriceUnit3 = 1000000;
			cities[33].CityName = "파리";
			cities[33].CityNation = "프랑스";
			cities[33].CityPayLand = 28000;
			cities[33].CityPayUnit1 = 150000;
			cities[33].CityPayUnit2 = 1000000;
			cities[33].CityPayUnit3 = 1400000;
			cities[34].CityType = 0;
			cities[34].CityPriceLand = 320000;
			cities[34].CityPriceUnit1 = 200000;
			cities[34].CityPriceUnit2 = 600000;
			cities[34].CityPriceUnit3 = 1000000;
			cities[34].CityName = "로마";
			cities[34].CityNation = "이탈리아";
			cities[34].CityPayLand = 28000;
			cities[34].CityPayUnit1 = 150000;
			cities[34].CityPayUnit2 = 1000000;
			cities[34].CityPayUnit3 = 1400000;
			cities[35].CityType = 2;
			cities[35].CityName = "황금열쇠";
			cities[36].CityType = 0;
			cities[36].CityPriceLand = 350000;
			cities[36].CityPriceUnit1 = 200000;
			cities[36].CityPriceUnit2 = 600000;
			cities[36].CityPriceUnit3 = 1000000;
			cities[36].CityName = "런던";
			cities[36].CityNation = "영국";
			cities[36].CityPayLand = 35000;
			cities[36].CityPayUnit1 = 170000;
			cities[36].CityPayUnit2 = 1100000;
			cities[36].CityPayUnit3 = 1500000;
			cities[37].CityType = 0;
			cities[37].CityPriceLand = 350000;
			cities[37].CityPriceUnit1 = 200000;
			cities[37].CityPriceUnit2 = 600000;
			cities[37].CityPriceUnit3 = 1000000;
			cities[37].CityName = "뉴욕";
			cities[37].CityNation = "미국";
			cities[37].CityPayLand = 35000;
			cities[37].CityPayUnit1 = 170000;
			cities[37].CityPayUnit2 = 1100000;
			cities[37].CityPayUnit3 = 1500000;
			cities[38].CityType = 5;
			cities[38].CityName = "사회복지기금";
			cities[39].CityType = 1;
			cities[39].CityPriceLand = 1000000;
			cities[39].CityName = "서울";
			cities[39].CityNation = "대한민국";
			cities[39].CityPayLand = 2000000;
			City1.Text = cities[1].CityName + "\n" + cities[1].CityPriceLand/10000 + "만원";
			City2.Text = cities[3].CityName + "\n" + cities[3].CityPriceLand/10000 + "만원";
			City3.Text = cities[4].CityName + "\n" + cities[4].CityPriceLand/10000 + "만원";
			City4.Text = cities[5].CityName + "\n" + cities[5].CityPriceLand/10000 + "만원";
			City5.Text = cities[6].CityName + "\n" + cities[6].CityPriceLand/10000 + "만원";
			City6.Text = cities[8].CityName + "\n" + cities[8].CityPriceLand/10000 + "만원";
			City7.Text = cities[9].CityName + "\n" + cities[9].CityPriceLand/10000 + "만원";
			City8.Text = cities[11].CityName + "\n" + cities[11].CityPriceLand/10000 + "만원";
			City9.Text = cities[13].CityName + "\n" + cities[13].CityPriceLand/10000 + "만원";
			City10.Text = cities[14].CityName + "\n" + cities[14].CityPriceLand/10000 + "만원";
			City11.Text = cities[15].CityName + "\n" + cities[15].CityPriceLand/10000 + "만원";
			City12.Text = cities[16].CityName + "\n" + cities[16].CityPriceLand/10000 + "만원";
			City13.Text = cities[18].CityName + "\n" + cities[18].CityPriceLand/10000 + "만원";
			City14.Text = cities[19].CityName + "\n" + cities[19].CityPriceLand/10000 + "만원";
			City15.Text = cities[21].CityName + "\n" + cities[21].CityPriceLand/10000 + "만원";
			City16.Text = cities[23].CityName + "\n" + cities[23].CityPriceLand/10000 + "만원";
			City17.Text = cities[24].CityName + "\n" + cities[24].CityPriceLand/10000 + "만원";
			City18.Text = cities[25].CityName + "\n" + cities[25].CityPriceLand/10000 + "만원";
			City19.Text = cities[26].CityName + "\n" + cities[26].CityPriceLand/10000 + "만원";
			City20.Text = cities[27].CityName + "\n" + cities[27].CityPriceLand/10000 + "만원";
			City21.Text = cities[29].CityName + "\n" + cities[29].CityPriceLand/10000 + "만원";
			City22.Text = cities[31].CityName + "\n" + cities[31].CityPriceLand/10000 + "만원";
			City23.Text = cities[32].CityName + "\n" + cities[32].CityPriceLand/10000 + "만원";
			City24.Text = cities[33].CityName + "\n" + cities[33].CityPriceLand/10000 + "만원";
			City25.Text = cities[34].CityName + "\n" + cities[34].CityPriceLand/10000 + "만원";
			City26.Text = cities[36].CityName + "\n" + cities[36].CityPriceLand/10000 + "만원";
			City27.Text = cities[37].CityName + "\n" + cities[37].CityPriceLand/10000 + "만원";
			City28.Text = cities[39].CityName + "\n" + cities[39].CityPriceLand/10000 + "만원";
		}
		#endregion

		// 황금열쇠 카드 설정
		#region SerCardData
		private void SetCard()
		{
			cards[0].CardName = "병원비 지불";
			cards[0].CardType = 1;
			cards[0].Money = 50000;
			cards[0].CardMessage = "병원에서 건강진단을 받았습니다. 병원비 5만원을 은행에 내시오.  ";
			cards[1].CardName = "복권 당첨";
			cards[1].CardType = 0;
			cards[1].Money = 200000;
			cards[1].CardMessage = "축하합니다. 복권에 당첨되었습니다.(2만원)  ";
			cards[2].CardName = "특수 무전기";
			cards[2].CardType = 3;
			cards[2].ItemType = 1;
			cards[2].CardMessage = "무인도에 갇혀있을때 사용할 수 있습니다.";
			cards[3].CardName = "무인도로 가시오";
			cards[3].CardType = 4;
			cards[3].CityNum = 10;
			cards[3].CardMessage = "폭풍을 만났습니다. 무인도로 곧장 가시되 출발지를 지날때도 월급을 받지 못합니다.  ";
			cards[4].CardName = "파티 초대권";
			cards[4].CardType = 9;
			cards[4].CardMessage = "대중 앞에서 장기자랑을 하십시오.  ";
			cards[5].CardName = "관광 여행";
			cards[5].CardType = 4;
			cards[5].CityNum = 5;
			cards[5].CardMessage = "제주도로 가십시오.  ";
			cards[6].CardName = "과속 운전 벌금";
			cards[6].CardType = 1;
			cards[6].Money = 50000;
			cards[6].CardMessage = "과속 운전을 하였으므로 벌금 5만원을 내시오.  ";
			cards[7].CardName = "해외 유학";
			cards[7].CardType = 1;
			cards[7].Money = 100000;
			cards[7].CardMessage = "학교 등록금 10만원을 내시오.  ";
			cards[8].CardName = "연금 혜택";
			cards[8].CardType = 0;
			cards[8].Money = 50000;
			cards[8].CardMessage = "은행에서 노후연금 5만원을 받으시오.  ";
			cards[9].CardName = "이사 가시오";
			cards[9].CardType = 5;
			cards[9].CityNum = 3;
			cards[9].CardMessage = "뒤로 세칸 옮기시오.  ";
			cards[10].CardName = "고속도로";
			cards[10].CardType = 4;
			cards[10].CityNum = 0;
			cards[10].CardMessage = "출발지까지 곧바로 가시오.  ";
			cards[11].CardName = "우승";
			cards[11].CardType = 0;
			cards[11].Money = 100000;
			cards[11].CardMessage = "자동차 경주에서 챔피온이 되었습니다  . 상금 100000원";
			cards[12].CardName = "우대권";
			cards[12].CardType = 3;
			cards[12].ItemType = 2;
			cards[12].CardMessage = "이 우대권을 가지고 있게 될 경우, 상대방의 장소를 통행료 없이 머무를 수 있습니다.  ";
			cards[13].CardName = "항공 여행";
			cards[13].CardType = 4;
			cards[13].CityNum = 1;
			cards[13].CardMessage = "콩코드 여객기를 타시고 타이페이로 가시오.(콩코드 객실료 지불)  ";
			cards[14].CardName = "건물 수리비 지불";
			cards[14].CardType = 2;
			cards[14].PayBuildUnit1 = 30000;
			cards[14].PayBuildUnit2 = 60000;
			cards[14].PayBuildUnit3 = 100000;
			cards[14].CardMessage = "호텔 : 10만원  빌딩 : 6만원  별장 : 3만원  ";
			cards[15].CardName = "방범비";
			cards[15].CardType = 2;
			cards[15].PayBuildUnit1 = 10000;
			cards[15].PayBuildUnit2 = 30000;
			cards[15].PayBuildUnit3 = 50000;
			cards[15].CardMessage = "호텔 : 5만원  빌딩 : 3만원  별장 : 1만원  ";
			cards[16].CardName = "세계일주 초대권";
			cards[16].CardType = 7;
			cards[16].CityNum = 40;
			cards[16].CardMessage = "축하합니다. 현재위치에서 부터 한바퀴 돌아오십시오.  ";
			cards[17].CardName = "관광 여행";
			cards[17].CardType = 4;
			cards[17].CityNum = 25;
			cards[17].CardMessage = "부산으로 가십시오.  ";
			cards[18].CardName = "생일을 축하합니다";
			cards[18].CardType = 0;
			cards[18].Money = 10000;
			cards[18].CardMessage = "HAPPY BIRTHDAY TO YOU! 모두에게 생일축하를 받으시오.\n(축하금 : 만원)  "; 
			cards[19].CardName = "장학금 혜택";
			cards[19].CardType = 0;
			cards[19].Money = 100000;
			cards[19].CardMessage = "은행에서 장학금 10만원을 받으시오.  ";
			cards[20].CardName = "정기 종합 소득세";
			cards[20].CardType = 2;
			cards[20].PayBuildUnit1 = 30000;
			cards[20].PayBuildUnit2 = 100000;
			cards[20].PayBuildUnit3 = 150000;
			cards[20].CardMessage = "호텔 : 15만원  빌딩 : 10만원  별장 : 3만원  ";
			cards[21].CardName = "노벨 평화상 수상";
			cards[21].CardType = 0;
			cards[21].Money = 300000;
			cards[21].CardMessage = "당신은 세계평화를 위하여 공헌하였으므로 은행으로부터 상금 30만원을 배당받습니다.  ";
			cards[22].CardName = "관광 여행";
			cards[22].CardType = 4;
			cards[22].CityNum = 39;
			cards[22].CardMessage = "88올림픽 개최지인 서울로 가십시오.  ";
			cards[23].CardName = "반액 대매출";
			cards[23].CardType = 6;
			cards[23].CardMessage = "당신의 재산중에서 제일 비싼곳을 반액으로 은행에 파십시오.  ";
			cards[24].CardName = "우주여행 초청장";
			cards[24].CardType = 4;
			cards[24].CityNum = 30;
			cards[24].CardMessage = "우주항공국에서 우주여행 초청장이 왔습니다.  ";
			cards[25].CardName = "우대권";
			cards[25].CardType = 3;
			cards[25].ItemType = 2;
			cards[25].CardMessage = "이 우대권을 가지고 있게 될 경우, 상대방의 장소를 통행료 없이 머무를 수 있습니다.  ";
			cards[26].CardName = "세계일주 초대권";
			cards[26].CardType = 7;
			cards[26].CityNum = 40;
			cards[26].CardMessage = "축하합니다. 현재위치에서 부터 한바퀴 돌아오십시오.  ";
			cards[27].CardName = "이사 가시오";
			cards[27].CardType = 5;
			cards[27].CityNum = 3;
			cards[27].CardMessage = "뒤로 세칸 옮기시오.  ";
			cards[28].CardName = "사회복지기금 배당";
			cards[28].CardType = 4;
			cards[28].CityNum = 20;
			cards[28].CardMessage = "사회복지기금 접수처로 가시오.  ";
			cards[29].CardName = "반액 대매출";
			cards[29].CardType = 6;
			cards[29].CardMessage = "당신의 재산중에서 제일 비싼곳을 반액으로 은행에 파십시오.  ";
		}
		#endregion

		// 시작 설정
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
						MessageBox.Show("이름을 입력하세요.  ","이름 미입력",
							MessageBoxButtons.OK, MessageBoxIcon.Warning);
						continue;
					}
				}

				if(config.MaxPlayer == 3) 
				{
					if(config.PlayerName1 == "" || config.PlayerName2 == ""
						|| config.PlayerName3 == "") 
					{
						MessageBox.Show("이름을 입력하세요.  ","이름 미입력",
							MessageBoxButtons.OK, MessageBoxIcon.Warning);
						continue;
					}
				}

				if(config.MaxPlayer == 2) 
				{
					if(config.PlayerName1 == "" || config.PlayerName2 == "") 
					{
						MessageBox.Show("이름을 입력하세요.  ","이름 미입력",
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

		// 황금열쇠 처리
		private void GoldenKey(City[] T_cities, Player temp, Player[] temp2)
		{
			switch(deck[CardNumber].CardType)
			{
				case 0:			// 수입 관련 카드
					m_SoundLaugh.Play();
					deck[CardNumber].GetMoney(temp, temp2);
					break;
				case 1:			// 지출 관련 카드
					m_SoundSigh.Play();
					deck[CardNumber].PayMoney(temp);
					break;
				case 2:			// 건물 세금 관련 카드
					m_SoundSigh.Play();
					deck[CardNumber].BuildTax(T_cities,temp);
					break;
				case 3:			// 아이템
					deck[CardNumber].Item(temp);
					break;
				case 4:			// 이동(앞으로)
					game.DiceNum = deck[CardNumber].MoveLocation1(T_cities, temp, temp2);
					GameStart();
					temp.NoPay = false;
					break;
				case 5:			// 이동(뒤로)
					deck[CardNumber].MoveLocation2(temp);
					for(int i = 0; i < deck[CardNumber].CityNum; i++)
					{
						LocMoveBack(game.Current);
					}
					game.DiceNum = -1;
					GameStart();
					game.DiceNum = 0;
					break;
				case 6:			// 반액대매출
					deck[CardNumber].SellLand(T_cities,temp);
					break;
				case 7:			// 세계일주
					game.DiceNum = deck[CardNumber].OneTurn(temp);
					game.OneTurnCheck = true;
					GameStart();
					game.OneTurnCheck = false;
					break;
				case 8:			// 우주여행 초청장
					players[game.Current].SpaceTourPay = true;
					game.DiceNum = deck[CardNumber].MoveLocation1(T_cities, temp, temp2);
					players[game.Current].DoubleDice = false;
					GameStart();
					players[game.Current].SpaceTourPay = false;
					break;
				case 9:			// 기타
					deck[CardNumber].Other();
					break;
				default:
					break;
			}

			// 다음번엔 다음카드를 가져오도록 한다.
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

		// 월급주기
		private void GivePay(Player temp)
		{
			MessageBox.Show("월급을 받습니다.  ","월급");
			temp.PlayerMoney += 200000;
		}

		// 게임 데이터 초기화 및 설정
		private void DataInitialize()
		{
			// 이전 게임에 저장된 데이터를 초기화
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

		// 대하여..를 선택했을때
		private void M_About_Click(object sender, System.EventArgs e)
		{
            m_SoundAbout.Play();
			AboutDlg about = new AboutDlg();	// 대하여.. (대화창)
			about.ShowDialog();
			m_SoundAbout.Stop();
		}

		// 게임종료를 선택했을때
		private void M_Exit_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
			// 프로그램 종료
		}

		// 게임시작을 선택했을때
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
				// 현재 게임이 진행중인 상태에서 게임시작을 선택했을때
				if(MessageBox.Show("현재 진행중인 게임을 종료하겠습니까?  ", "게임중단",
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

		// 게임설정을 클릭했을때
		private void M_GameSet_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("체험판에서는 지원하지 않습니다.  ", "게임설정",	// 게임설정 (대화창)
				MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		// 게임중단을 클릭했을때
		private void M_GameStop_Click(object sender, System.EventArgs e)
		{
			if(MessageBox.Show("정말로 게임을 종료하겠습니까?  ","게임중단",
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

		// 게임을 시작
		private void GameStart()
		{
			while(true)
			{
				if(players[game.Current].SpaceTourCheck == false && game.DiceNum == 0) // 버그주의
				{
					// 주사위를 굴려 그 값을 저장
					game.DiceNum = RollDice(players[game.Current]);
				}

				if(game.DiceNum != -1)
				{
					// 주사위의 결과값만큼 이동
					while(game.DiceNum !=0)
					{
						LocMove(game.Current);
						game.DiceNum--;
					}

				}

				// 주사위굴리기를 클릭하고난뒤 더이상 클릭할수 없게함
				B_Roll.Enabled = false;

				// 현재상태 업데이트
				RePrint();

				// 무인도에서 휴식중인지 검사
				if(players[game.Current].PlayerSleepTurn != 0) 
				{
					if(players[game.Current].DoubleDice) 
					{
						MessageBox.Show("무인도를 탈출하였습니다.  ");
						players[game.Current].PlayerSleepTurn = 0;
						break;
					}
					else 
					{
						players[game.Current].PlayerSleepTurn--;
						if(players[game.Current].PlayerSleepTurn == 0)
						{
							MessageBox.Show("무인도를 탈출하였습니다.  ");
						}
						break;
					}
				}

				// 현재 위치의 도시 정보를 보여줌
				PrintCityInfo(players[game.Current].PlayerLocate);

				// 현재 위치에 따른 명령처리
				switch(cities[players[game.Current].PlayerLocate].CityType) 
				{

					case 0:		// 일반도시
						if(cities[players[game.Current].PlayerLocate].CityHave == -1 || 
							cities[players[game.Current].PlayerLocate].CityHave == game.Current) 
						{
							Buy.Enabled = true;		// 도시소유자가 없거나 자신의 도시일경우 구입버튼 활성화
							Sell.Enabled = false;
							if(cities[players[game.Current].PlayerLocate].CityHave == game.Current)
								Sell.Enabled = true;	// 자신의 도시일 경우에만 팔기버튼 활성화
						}
						else 
						{
							cities[players[game.Current].PlayerLocate].NormalCity(players, game.Current, game);
							Buy.Enabled = false;
							Sell.Enabled = false;
						}

						break;

					case 1:		// 특수도시
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

					case 2:		// 황금열쇠
						if(game.OneTurnCheck == false)
						{
							Buy.Enabled = false;
							Sell.Enabled = false;
							GoldKeyCheck = true;
							GoldenKey(cities, players[game.Current], players);
							GoldKeyCheck = false;
						}
						break;

					case 3:		// 무인도
						players[game.Current].DoubleDice = false;	// 더블로 도착했을때 다시 주사위를 못굴리게함
						Buy.Enabled = false;
						Sell.Enabled = false;
						m_SoundIsland.Play();
						cities[players[game.Current].PlayerLocate].island(players[game.Current]);
						break;

					case 4:		// 우주여행
						Buy.Enabled = false;
						Sell.Enabled = false;
						if(cities[32].CityHave != -1 && cities[32].CityHave != game.Current 
							&& players[game.Current].SpaceTourPay == false)
						{
							// 콜롬비아호의 소유자가 있고 자신의 땅이 아닐때
							MessageBox.Show("콜롬비아호에 20만원을 지불합니다.  ", "우주정거장");
							players[cities[32].CityHave].PlayerMoney += 200000;
							players[game.Current].PlayerMoney -= 200000;
						}
						MessageBox.Show("다음턴에 원하는 장소로 이동할수 있습니다.  ", "우주정거장");
						players[game.Current].DoubleDice = false;
						break;

					case 5:		// 사회복지기금
						if (game.SocietyFund != 0)
							m_SoundLaugh.Play();
						cities[players[game.Current].PlayerLocate].SocietyFund(players[game.Current]
							,game );
						Buy.Enabled = false;
						Sell.Enabled = false;
						break;
					
					case 6:		// 출발지점
						Buy.Enabled = false;
						Sell.Enabled = false;
						break;

					default:
						break;
				}

				RePrint();
				
				// 파산여부 확인
				if(players[game.Current].PlayerMoney <= 0 && GoldKeyCheck == false) 
				{
					players[game.Current].DoubleDice = false;
					MessageBox.Show("턴이 넘어가기전에 지불할 돈을 마련하지 않으면 파산입니다.  \n(현재 소유하고 있는 도시를 팔 수 있습니다.)", "파산 위기"
						,MessageBoxButtons.OK, MessageBoxIcon.Warning);
					CitySellCheck = true;
					NextPlayer.Text = "파산 선언";
				}

				break;
			}	// while-loop 빠져나옴

			ViewCityHave();

			// 더블이 나왔을떄 다시 주사위를 굴릴수 있음
			if(players[game.Current].DoubleDice && GoldKeyCheck == false)
				MessageBox.Show("더블이 나왔으므로 주사위를 한번 더 던질수 있습니다.  ", "더블"
					,MessageBoxButtons.OK, MessageBoxIcon.Information);

			// 더블이 나왔을경우에 다음플레이어로 순서를 못넘기도록 함(반드시 굴려야함)
			if(players[game.Current].DoubleDice)
			{
				B_Roll.Enabled = true;
				game.BuyCheck = false;
				NextPlayer.Enabled = false;
			}
			else 
				NextPlayer.Enabled = true;
		}

		// 주사위 던지기 버튼을 클릭했을때
		private void B_Roll_Click(object sender, System.EventArgs e)
		{
			m_objSound2.Play();
			GameStart();
		}

		// 도시/건물 구입 버튼을 클릭했을때
		private void Buy_Click(object sender, System.EventArgs e)
		{
			switch(cities[players[game.Current].PlayerLocate].CityType) 
			{
				case 0:		// 일반도시
					cities[players[game.Current].PlayerLocate].NormalCity(players, game.Current, game);
					break;

				case 1:		// 특수도시
					cities[players[game.Current].PlayerLocate].SpecialCity(players, game.Current, game);
					break;
				default:
					break;
			}
			RePrint();
			ViewCityHave();

			// 건물을 한번 사고나면 더이상 다른 명령을 할수 없음
			if(game.BuyCheck == true) 
			{
				Buy.Enabled = false;
				Sell.Enabled = false;
			}
			else 
				game.BuyCheck = false;
		}

		// 다음 플레이어 클릭했을때
		private void NextPlayer_Click(object sender, System.EventArgs e)
		{
			CitySellCheck = false;
			// 파산여부 확인
			if(players[game.Current].PlayerMoney <= 0) 
			{
				m_SoundAmbulance.Play();
				players[game.Current].PlayerIsDead = true;
				MessageBox.Show("지불할 능력이 없어서 "
					+ players[game.Current].PlayerName + "님은 파산하셨습니다.  ", "파산");
				if(players[game.Current].PlayerDebt)
					players[players[game.Current].DebtWho].PlayerMoney 
						+= players[game.Current].PlayerMoney;
				game.LeftPlayer--;

				// 파산한 사람 말 삭제
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

				// 파산한 플레이어가 산 땅을 모두 빈땅으로 만듬
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

				// 플레이어가 파산하고 한명만 남았을때
				if(game.LeftPlayer == 1)
				{
					GameOver();
					return;
				}
				NextPlayer.Text = "다음 플레이어";
			}

			players[game.Current].PlayerDebt = false;

			if(cities[players[game.Current].PlayerLocate].CityType == 4)
				players[game.Current].SpaceTourCheck = true;
			NextPlayer.Enabled = false;
			B_Roll.Enabled = true;
			game.BuyCheck = false;
			Sell.Enabled = false;
			Buy.Enabled = false;

			// 다음 플레이어에 대한 정보처리
			ShowCurrentPlayer();
		}
		
		// 현재 플레이어를 출력해줌
		private void ShowCurrentPlayer()
		{
			game.Current++;
			int temp;
			temp = game.Current % game.maxPlayer;

			while(true)
			{
				// 파산여부 검사
				if(players[temp].PlayerIsDead)
				{
					temp = (temp + 1) % game.maxPlayer;
					continue;
				}
				else  
				{
					MessageBox.Show(players[temp].PlayerName + "님의 차례입니다.  ","현재플레이어"
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
			if(players[game.Current].SpaceTourCheck) // 우주여행에 도착한후 다음턴에 이동
			{
				B_Roll.Enabled = false;
				MessageBox.Show("이동하길 원하는 장소를 선택하세요.  ", "우주여행", 
					MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		// 도시 매각 버튼을 클릭했을때
		private void Sell_Click(object sender, System.EventArgs e)
		{
			// 도시 매각 대화상자 출력
			CityDialog3 CitySell = new CityDialog3();
			int ResultSell;

			if(CitySell.ShowDialog() == DialogResult.OK)
			{
				// 매각하게되면 소유자가 없는 도시로 재 설정
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

		// 우주여행동안 원하는 장소를 클릭했을때 실행
		private void MoveSpaceTour(int point, int D_num)
		{
			if(players[game.Current].SpaceTourCheck)
			{
				if(MessageBox.Show( cities[point].CityName + "(으)로 이동하겠습니까?  ", "우주여행", 
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

		// 지불할 능력이 없을때 자신이 소유하고 있는 도시를 팔도록 함
		private void CitySell(int point)
		{
			if(cities[point].CityHave == players[game.Current].PlayerNumber)
			{
				string message;
				message = cities[point].CityName + "을 매각하겠습니까?  ";
				message += "\n\n<판매가격>\n도시 : " + cities[point].CityPriceLand/2 + "원";
				
				if(cities[point].BuildUnitNum1 == 1)
					message += "\n별장 : " + cities[point].CityPriceUnit1/2 + "원";
				if(cities[point].BuildUnitNum2 == 1)
					message += "\n빌딩 : " + cities[point].CityPriceUnit2/2 + "원";
				if(cities[point].BuildUnitNum3 == 1)
					message += "\n호텔 : " + cities[point].CityPriceUnit3/2 + "원";

				if(MessageBox.Show( message, "도시 매각", 
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

					// 소지금이 충분해지면 종료하고 턴을 넘기도록 함
					if(players[game.Current].PlayerMoney > 0)
					{
						CitySellCheck = false;
						NextPlayer.Text = "다음 플레이어";
					}
				}
			}
		}

		// 여기서 부터는 원하는 장소를 클릭했을때 발생하는 이벤트
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

		// 도시 정보 출력
		private void PrintCityInfo(int loc)
		{
			// 도시정보창을 보이게 함
			CityInfo.Visible = true;
			
			try {CityPhoto.Image = Image.FromFile("cityphoto/city" +loc+ ".gif");}
			catch {}

			L_CityInfo.Text = "";
			switch(loc)
			{
				case 0:
					CityInfo.Text = "출발(Start Point)";
					L_CityInfo.Text += "모든것의 시작입니다.\n언제나 설레는 여행의 시작.\n어떤일이 일어나게 될까요? ^^";
					break;
				case 1:
					CityInfo.Text = "타이페이(Taipei, Taiwan)";
					L_CityInfo.Text += "타이완[臺灣]의 수도. 북쪽은 다툰[大屯]화산군, 서쪽은 린커우[林口]분지, 동쪽/남쪽은 중앙산맥으로 둘러싸인 분지의 중심에 위치. 시가지는 북쪽으로 흐르는 단수이강[淡水河]의 동쪽에 있음. 아열대기후, 우기(雨期)가 비교적 길다. 한민족(漢民族)이 이곳으로 이주하기 시작한 것은 17세기 말부터이며, 18세기 초에는 단수이강 연안에 마을이 형성되었고, 대륙과의 교역을 위한 주요 무역항으로 번창하였다.";
					break;
				case 2:
					CityPhoto.Image = Image.FromFile("cityphoto/goldkey.gif");
					CityInfo.Text = "황금 열쇠(Golden Key)";
					L_CityInfo.Text = 
						"황금열쇠를 손에 쥔 젊은이는\n 드디어 배팅을 시작하고\n위험한 갬블러의 길로 들어선다.\n황금 열쇠를 사용함으로써 \n쉽게 게임에 이기기 시작한 갬블러는\n점점 도박에 흥이 오르고 \n자기도 모르는 사이에 도박의 노예가 \n되어 버린다.";
					break;
				case 3:
					CityInfo.Text = "홍콩(Hongkong, China)";
					L_CityInfo.Text += "중국 남동부의 특별행정구. 정식 명칭은 '중화인민공화국 홍콩특별행정구'. 주도(主都)는 홍콩섬의 빅토리아시(홍콩市). 주장강[珠江] 하구의 동쪽 연안에 있는 홍콩섬과 주룽반도[九龍半島] 및 그 밖의 섬으로 구성되어 있다. 그 가운데 홍콩섬·스톤커터섬과 주룽반도의 선단(先端)에 있는 주룽시(市)는 영국 영토이고, 주룽시의 후배지인 신제[新界:New Territories]와 230개의 부속도서는 조차지(租借地)이다.";
					break;
				case 4:
					CityInfo.Text = "마닐라(Manilla, Philiphine)";
					L_CityInfo.Text += "루손섬 남서부에 있는 필리핀의 수도. 세계에서 가장 좋은 항만으로 일컬어지는 마닐라만(灣)에 임한 항구도시로, 시가지는 파시그강(江)을 끼고 그 남북으로 펼쳐진다. 북쪽에 비옥한 중부 루손 평야를, 남쪽에 남부 루손의 화산성 저지를 끼고 있다. ";
					break;
				case 5:
					CityInfo.Text = "제주도(Jeju Island, Korea)";
					L_CityInfo.Text += "한반도 남서 해상에 있는 한국 최대의 섬인 제주도와, 주변에 산재하는 섬들로 구성. 한국·중국 일본 등 극동(極東)지역의 중앙부에 있어 지정학적으로도 중요하다. 제주도를 포함, 8개의 유인도와 55개의 무인도로 이루어졌다.";
					break;
				case 6:
					CityInfo.Text = "싱가포르(Singapore, Singapore)";
					L_CityInfo.Text += "동남아시아에 있는 섬으로 이루어진 도시 국가.면적 646㎢. 인구 322만 5000명(1999). 인구밀도 4,991명/㎢(1999). 수도는 싱가포르이며 언어는 중국어, 영어, 말레이어, 타밀어 등을 사용한다. 정식명칭은 싱가포르 공화국(Repubic of Singapore)이다. 적도 북쪽 137km 지점에 있으며, 행정적으로는 싱가포르 공화국과 수도가 일치한다. ";
					break;
				case 7:
					CityPhoto.Image = Image.FromFile("cityphoto/goldkey.gif");
					CityInfo.Text = "황금 열쇠(Golden Key)";
					L_CityInfo.Text = 
						"황금열쇠를 손에 쥔 젊은이는\n 드디어 배팅을 시작하고\n위험한 갬블러의 길로 들어선다.\n황금 열쇠를 사용함으로써 \n쉽게 게임에 이기기 시작한 갬블러는\n점점 도박에 흥이 오르고 \n자기도 모르는 사이에 도박의 노예가 \n되어 버린다.";
					break;
				case 8:
					CityInfo.Text = "카이로(Cairo, Igypt)";
					L_CityInfo.Text += "이집트의 수도. 나일강(江) 삼각주의 남단에서 약 25km 남쪽 나일강 우안에 있다. 시가는 하중도(河中島)인 게지라섬에서 강의 좌안까지 펼쳐지며 아랍권과 아프리카 대륙에서 가장 큰 도시이다. 1월 평균기온 12.7℃, 8월 평균기온 27.7℃, 연평균강수량 25mm이다.";
					break;
				case 9:
					CityInfo.Text = "이스탄불(Istanbul, Turkey)";
					L_CityInfo.Text += "터키 최대의 도시. 보스포루스 해협의 남쪽 입구에 위치하고, 아시아와 유럽에 걸쳐 있다. 1923년까지 1,600년 동안 수도였던 이스탄불에는 그리스/로마시대부터 오스만 제국시대에 이르는 다수의 사적이 있다. 보스포루스 해협, 골든혼, 마르마라해(海)에 의하여 베욜루, 이스탄불(파티프), 위스퀴다르의 3지구로 대별된다. 금융/무역의 중심지로서 오스만은행을 비롯하여 국립/외국은행이 많다.";
					break;
				case 10:
					CityInfo.Text = "무인도(Uninhabited Island)";
					L_CityInfo.Text += "아무도 찾아오지 않는섬.\n가끔은 도시를 떠나\n이런곳에서 쉴 수 있다는게\n큰 행복인거 같다.";
					break;
				case 11:
					CityInfo.Text = "아테네(Athens, Greece)";
					L_CityInfo.Text += "그리스의 수도. 이름은 시(市)의 수호신 아테나 여신과 관계가 있다. 아티카반도 중앙 사로니크만(灣) 연안에 있는데 동쪽은 히메토스산(山), 북동쪽은 펜텔리콘산, 북서쪽은 파르니스산, 서쪽은 아이갈레오스산에 둘러싸인 평야가 사로니크만으로 기우는 지점에 자리잡고 있다. 아크로폴리스의 북동부가 시의 중심부이며, 왕궁·의사당·관청·대학 등이 있다. ";
					break;
				case 12:
					CityPhoto.Image = Image.FromFile("cityphoto/goldkey.gif");
					CityInfo.Text = "황금 열쇠(Golden Key)";
					L_CityInfo.Text = 
						"황금열쇠를 손에 쥔 젊은이는\n 드디어 배팅을 시작하고\n위험한 갬블러의 길로 들어선다.\n황금 열쇠를 사용함으로써 \n쉽게 게임에 이기기 시작한 갬블러는\n점점 도박에 흥이 오르고 \n자기도 모르는 사이에 도박의 노예가 \n되어 버린다.";
					break;
				case 13:
					CityInfo.Text = "코펜하겐(Copenhagen, Denmark)";
					L_CityInfo.Text += "덴마크의 수도. 덴마크어로는 쾨벤하운(Kubenhavn)이라고 한다. 셸란섬의 북동안에 있는 무역항으로 대안에 있는 스웨덴의 말뫼 사이에는 철도연락선이 오간다. 시내에는 녹지가 많으며 유서 깊은 궁전, 교회 등의 건축물이 많아 유럽에서도 아름다운 도시로 꼽힌다. 미술관, 박물관이 많고 세계적으로 권위있는 학회, 연구기관의 본부가 있다. 대안의 아마게르섬에는 조선소와 철공장 등이 있으며, 제조업이 활발하다. ";
					break;
				case 14:
					CityInfo.Text = "스톡홀름(Stockholm, Sweden)";
					L_CityInfo.Text += "스웨덴의 수도. 발트해로부터 약 30km 거슬러 올라온 멜라렌호(湖) 동쪽에 있으며, 시가는 많은 반도와 작은 섬 위에 자리잡고 있다. 넓은 수면과 운하 때문에 흔히 ‘북구의 베네치아’라는 별명으로 불린다. 기온은 1월이 －1.6℃, 7월이 16.6℃, 연간 강수량 555mm. 해항 ·공항 ·지하철 ·버스망이 완비되어 있으며 이 나라의 정치 ·문화 ·상공업의 중심지이다.";
					break;
				case 15:
					CityInfo.Text = "콩코드 여객기(Concord Airplane)";
					L_CityInfo.Text += "62년에 영국과 프랑스 공동개발.\n대서양을 3시간만에 가로지르는\n초음속에도 불구하고\n100명정도 탑승인원과 심한 소음에 의해\n적자를 감당못하고 현재 휴항중.";
					break;
				case 16:
					CityInfo.Text = "취리히(Zurich, Switzerland)";
					L_CityInfo.Text += "스위스 취리히주(州)의 주도(州都).인구는 34만 3869명(1997). 취리히호(湖)의 북안에서 흘러나오는 리마트강(江)과 그 지류인 질강 연안에 위치한다. 스위스 제일의 도시이며, 도로와 철도의 결절점에 해당하여 각 방면으로 직통열차가 발착한다. 또 도심에서 11km 북쪽에 있는 클로텐 비행장은 스위스 최대의 공항으로 세계 각지와 이어져 있다. ";
					break;
				case 17:
					CityPhoto.Image = Image.FromFile("cityphoto/goldkey.gif");
					CityInfo.Text = "황금 열쇠(Golden Key)";
					L_CityInfo.Text = 
						"황금열쇠를 손에 쥔 젊은이는\n 드디어 배팅을 시작하고\n위험한 갬블러의 길로 들어선다.\n황금 열쇠를 사용함으로써 \n쉽게 게임에 이기기 시작한 갬블러는\n점점 도박에 흥이 오르고 \n자기도 모르는 사이에 도박의 노예가 \n되어 버린다.";
					break;
				case 18:
					CityInfo.Text = "베를린(Berlin, Germany)";
					L_CityInfo.Text += "독일의 수도. 독일 동부, 바르샤바-베를린 주곡(主谷)의 저지(低地)에 있다. 넓은 숲과 많은 호수를 안고 있어 도시 미관이 뛰어나고, 베를리너 루프트(베를린의 공기)’라고 노래로 부를 정도로 공기가 맑다. 겨울은 몹시 춥고, 여름도 서늘하다. 2차 세계대전때는 여러 강의 흐름이 만나는 곳이라 항구 역활을 톡톡히 하였다.";
					break;
				case 19:
					CityInfo.Text = "몬트리올(Montreal, Canada)";
					L_CityInfo.Text += "캐나다 퀘벡주(州)에 있는 도시. 프랑스어로는 몽레알이라고 한다. 남부의 세인트로렌스강(江) 어귀의 몬트리올섬에 있는 캐나다 최대의 도시이다. 1535년 프랑스인 J.카르티에가 발견하였으며, 1642년 개척마을이 형성되었다. 그 후 모피교역의 중심지 및 내륙탐험의 기지가 되었으며, 현재는 유럽과 캐나다 각지를 연결하는 교통의 중계지이다.";
					break;
				case 20:
					CityInfo.Text = "사회복지기금 접수처(Public Society Fund)";
					L_CityInfo.Text += "있으면 가져가시오. ㅡ.ㅡ;";
					break;
				case 21:
					CityInfo.Text = "부에노스아이레스(Buenos Aires, Argentina)";
					L_CityInfo.Text += "아르헨티나의 수도. 세계적인 무역항이기도 하다. 온화한 기후조건에, 광대한 팜파의 농목지역을 배후지로 삼고 19세기 후반부터 급속히 발전하였다. 항구는 라플라타강의 지류인 리아추엘로(마탄사)강 연변에 자리하여, 본류와는 남 ·북 두 운하에 의해 연락된다. ";
					break;
				case 22:
					CityPhoto.Image = Image.FromFile("cityphoto/goldkey.gif");
					CityInfo.Text = "황금 열쇠(Golden Key)";
					L_CityInfo.Text = 
						"황금열쇠를 손에 쥔 젊은이는\n 드디어 배팅을 시작하고\n위험한 갬블러의 길로 들어선다.\n황금 열쇠를 사용함으로써 \n쉽게 게임에 이기기 시작한 갬블러는\n점점 도박에 흥이 오르고 \n자기도 모르는 사이에 도박의 노예가 \n되어 버린다.";
					break;
				case 23:
					CityInfo.Text = "상파울로(San Paulu, Brazil)";
					L_CityInfo.Text += "브라질 상파울루주(州)의 주도(州都). 리우데자네이루 남서쪽 약 500km 지점, 해발고도 약 800m의 고원지대에 있으며, 부근의 20여 개 위성도시를 포함하여 인구 900만이 넘는 남아메리카 최대의 도시이다. 여름은 서늘하고 쾌적한 기후로 연평균기온 18.2℃, 연강수량 1,247mm이다. 연중 기온 변화가 적은 것이 특색이다. ";
					break;
				case 24:
					CityInfo.Text = "시드니(Sydney, Austrailia)";
					L_CityInfo.Text += "오스트레일리아 뉴사우스웨일스주(州)의 주도(州都). 시드니 대도시권은 서쪽 블루산맥, 북쪽 호크스베리강(江), 남쪽 보터니만(灣)까지 뻗어 있으며, 전국 인구의 약 1/4이 몰려 있는 이 나라 최대의 도시이다. 서쪽 내륙에는 해발고도 1,000m 전후의 블루산맥이 남북으로 뻗어 있다.";
					break;
				case 25:
					CityInfo.Text = "부산(Pusan, Korea)";
					L_CityInfo.Text += "경상남도 남동단에 있는 광역시. 남쪽은 바다에 면하고, 서쪽은 김해시 장유면과 진해시, 북쪽은 양산시 물금면과 김해시 대동면, 동쪽은 울산광역시 서생면·온양면에 접한다. 한국 제2의 도시이자, 제1의 무역항이다. 대한해협을 끼고 일본 시모노세키[下關]와 약 250km 떨어져 있다. ";
					break;
				case 26:
					CityInfo.Text = "하와이(Hawaii, USA)";
					L_CityInfo.Text += "북태평양상에 있는 미국의 주.주도(州都)는 호놀룰루. 50개 주 가운데 가장 남쪽에 위치한다. 하와이 제도는 큰 8개 섬과 100개가 넘는 작은 섬들이 북서쪽에서 남동쪽으로 이어져 있다. 최대의 섬은 하와이섬이며 주민의 대부분은 오아후섬에 살고 있다. ";
					break;
				case 27:
					CityInfo.Text = "리스본(Lisbon, Portugal)";
					L_CityInfo.Text += "포르투갈의 수도. 포르투갈어로는 리스보아(Lisboa)라고 한다. 테주강(타호강)의 삼각 하구 우안(右岸)에 위치한다. 이 나라 최대의 도시이며, 유럽대륙 대서양 연안 굴지의 양항(良港)이기도 하다.";
					break;
				case 28:
					CityPhoto.Image = Image.FromFile("cityphoto/goldkey.gif");
					CityInfo.Text = "황금 열쇠(Golden Key)";
					L_CityInfo.Text = 
						"황금열쇠를 손에 쥔 젊은이는\n 드디어 배팅을 시작하고\n위험한 갬블러의 길로 들어선다.\n황금 열쇠를 사용함으로써 \n쉽게 게임에 이기기 시작한 갬블러는\n점점 도박에 흥이 오르고 \n자기도 모르는 사이에 도박의 노예가 \n되어 버린다.";
					break;
				case 29:
					CityInfo.Text = "마드리드(Madrid, Spain)";
					L_CityInfo.Text += "에스파냐의 수도. 유럽의 수도 중 가장 높은 곳에 있으며, 연강수량 419mm로 건조하다. 기온의 일교차가 크다. 근래에는 산업도시로서의 중요성도 크며, 교통 요충지이기도 하다. 인구상으로는 유럽 제4의 대도시이다.";
					break;
				case 30:
                    CityInfo.Text = "우주여행(Space-tour)";
					L_CityInfo.Text += "현실세계에서는 아직 불가능한 우주여행이 부루마불에서는 가능하다.\n게임속에서라도 우주여행의 기쁨을 마음껏 누려라!";
					break;
				case 31:
					CityInfo.Text = "도쿄(Tokyo, Japan)";
					L_CityInfo.Text += "일본의 수도. 황궁(皇宮)을 중심으로 한 23개 구(區)의 구부(區部), 그 서쪽의 3다마지구[三多摩地區] 및 이즈제도[伊豆諸島]·오가사와라제도[小笠原諸島]를 포함하는 3개 지역으로 대별된다. 합쳐서 도쿄도[東京都]라고 한다. 그리고 도쿄의 인구수는 세계 도시중 1위이다. ";
					break;
				case 32:
					CityInfo.Text = "콜롬비아호";
					L_CityInfo.Text += "미국에서 81년에 발사된 최초의 우주왕복선.\n 아폴로에 비해 많은 탑승인원 수용.\n연료탱크의 재사용 등 많은 장점이\n있었으나, 최근 어떤 이유에 의해 폭파됨.";
					break;
				case 33:
					CityInfo.Text = "파리(Paris, France)";
					L_CityInfo.Text += "프랑스의 수도. 오랫동안 센현(縣)의 주도(主都)였으나 1964년부터 파리만으로 독립 현이 되었다. 프랑스의 정치·경제·교통·학술·문화의 중심지일 뿐만 아니라 세계의 문화 중심지로, ‘꽃의 도시’라고 불리며 프랑스 사람들은 스스로 ‘빛의 도시’라고 부른다. ";
					break;
				case 34:
					CityInfo.Text = "로마(Rome, Italy)";
					L_CityInfo.Text += "이탈리아의 수도. 구릉지대에 자리잡고 있다. 시의 중심부인 티베리나섬 부근은 테베레강 하구에서 약 25km 떨어진 곳에 있다. 시민은 거의 시의 행정영역 안에 거주하고 있으므로 시역을 넘어선 도시권의 발전은 별로 볼 수가 없다. ";
					break;
				case 35:
					CityPhoto.Image = Image.FromFile("cityphoto/goldkey.gif");
					CityInfo.Text = "황금 열쇠(Golden Key)";
					L_CityInfo.Text = 
						"황금열쇠를 손에 쥔 젊은이는\n 드디어 배팅을 시작하고\n위험한 갬블러의 길로 들어선다.\n황금 열쇠를 사용함으로써 \n쉽게 게임에 이기기 시작한 갬블러는\n점점 도박에 흥이 오르고 \n자기도 모르는 사이에 도박의 노예가 \n되어 버린다.";
					break;
				case 36:
					CityInfo.Text = "런던(London, England)";
					L_CityInfo.Text += "영국의 수도. 영국 3연방의 사실상의 중심도시이며, 뉴욕,상하이[上海],도쿄[東京]와 더불어 세계 최대 도시의 하나이다. 1888년 런던주(州)가 설치되었고, 99년 시티오브런던을 제외한 지역을 28개의 행정구로 구분하여 런던 주청(州廳)이 통할하였다. ";
					break;
				case 37:
					CityInfo.Text = "뉴욕(New York, USA)";
					L_CityInfo.Text += "미국 뉴욕주(州)에 있는 최대의 항구도시. 1790년 이래 수도로서의 지위는 상실했으나, 모든 면에서 미국의 수도라 하기에 충분한 지위에 있다. 교외를 포함 1600만이 넘는 인구를 수용하는 이 거대도시는 미국 내에서도 독자적인 세계를 이루는 독특한 도시이다.";
					break;
				case 38:
					CityInfo.Text = "사회복지기금(Public Society Fund)";
					L_CityInfo.Text += "사회복지를 위한것이니 아깝다고 생각하지 말고 내자!";
					break;
				case 39:
					CityInfo.Text = "서울(Seoul, Korea)";
					L_CityInfo.Text += "한반도 중앙에 위치하며, 한강을 사이에 두고 남북으로 전개되어 있다. 1394년(태조 3)부터 한국의 중심지가 되어 왔다. 1986년 아시아경기대회, 1988년 서울 올림픽경기대회가 개최되는 등 국제적인 대도시이다.";
					break;
				default:
					break;
			}
		}

		// 메뉴에서 음악 On 클릭
		private void M_MusicOn_Click(object sender, System.EventArgs e)
		{
			if(GameStartCheck == true)
				PlaySound();
		}

		// 메뉴에서 음악 Off 클릭
		private void M_MusicOff_Click(object sender, System.EventArgs e)
		{
			m_objSound1.Stop();
		}
	}
}
