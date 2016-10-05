using System;
using System.Windows.Forms;
using Dialogs;

namespace BlueMarble
{
	// 임시 데이터 저장을 위해 임의로 만든 버퍼
	// 이들을 이용하여 메인 창과 대화상자 사이의 데이터 교환이 일어남
	public class UserBuffer
	{
		static public string BufferStr1;
		static public string BufferStr2;
		static public string BufferStr3;
		static public string winner;
		static public int BufferInt1;
		static public int BufferInt2;
		static public int BufferInt3;
		static public int BufferInt4;
		static public int BufferInt5;
	}

	// 게임에 필요한 데이터 모음
	public class GameData
	{
		public int SocietyFund;		// 현재 사회복지기금
		public int maxPlayer;		// 플레이어 수
		public int StartMoney;		// 시작할때 소지금
		public int LeftPlayer;		// 현재 남아있는 플레이어
		public int Current = -1;	// 현재 플레이어
		public int loc_x;			// 플레이어 말의 다음 이동위치를 정하기 위함
		public int loc_y;
		public bool BuyCheck = false;	// 건물/도시를 구입했는지 체크
		public int DiceNum;				// 주사위가 나온수
		public bool OneTurnCheck = false;	// 세계일주 중인지 체크
	}

	// 도시 정보
	public class City
	{
		public int CityType;		// 유형
		public int CityPriceLand;	// 가격(지대)
		public int CityPriceUnit1;	// 가격(별장)
		public int CityPriceUnit2;	// 가격(호텔)
		public int CityPriceUnit3;	// 가격(빌딩)
		public string CityName;		// 이름
		public string CityInfo;		// 도시정보
		public string CityNation;	// 도시의 국적
		public int CityPicture;		// 이미지
		public int CityHave;		// 소유자
		public int BuildUnitNum1;	// 건물 갯수(별장)
		public int BuildUnitNum2;	// 건물 갯수(호텔)
		public int BuildUnitNum3;	// 건물 갯수(빌딩)
		public int CityPayLand;		// 통행료(지대)
		public int CityPayUnit1;	// 통행료(별장)
		public int CityPayUnit2;	// 통행료(호텔)
		public int CityPayUnit3;	// 통행료(빌딩)
		public int CityLocate_X;	// 위치(X좌표)
		public int CityLocate_Y;	// 위치(Y좌표)

		public City()
		{
			CityHave = -1;
		}

		// 일반도시
		public void NormalCity(Player[] temp, int now, GameData game)
		{
			// 현재 내용을 곧 불러울 대화상자에 정보를 넘기기 위함
			UserBuffer.BufferStr1 = "도시명 : " + this.CityName 
				+ "\n국적 : " + this.CityNation
				+"\n가격 : " + this.CityPriceLand / 10000 + "만원";
			UserBuffer.BufferInt2 = this.CityPriceUnit1;
			UserBuffer.BufferInt3 = this.CityPriceUnit2;
			UserBuffer.BufferInt4 = this.CityPriceUnit3;
			UserBuffer.BufferInt5 = temp[now].PlayerLocate;

			UserBuffer.BufferStr3 = "<< 건설된 건물 >>\n별장 : " + BuildUnitNum1 + "채" + "\n빌딩 : " + BuildUnitNum2 + "채" + "\n호텔 : " 
				+ BuildUnitNum3 + "채";
			UserBuffer.BufferStr3 += "\n\n<< 통행요금표 >>\n대지료 : " + CityPayLand + "원";
			UserBuffer.BufferStr3 += "\n별장 : " + CityPayUnit1 + "원" 
				+ "\n빌딩 : " + CityPayUnit2 + "원"  + "\n호텔 : " + CityPayUnit3 + "원";

			if(CityHave == temp[now].PlayerNumber)
			{
				CityDialog1 CityBuy1 = new CityDialog1();
	
				while(CityBuy1.ShowDialog() == DialogResult.OK)
				{
					if(CityBuy1.radioButton1.Checked == false && 
						CityBuy1.radioButton2.Checked == false &&
						CityBuy1.radioButton3.Checked == false) 
					{
						MessageBox.Show("건물을 선택하지 않았습니다.  ","건물을 선택하세요",
							MessageBoxButtons.OK,MessageBoxIcon.Warning);
						continue;
					}

					if(CityBuy1.radioButton1.Checked == true)
					{
						if(temp[now].PlayerMoney <= this.CityPriceUnit1)
						{
							MessageBox.Show("돈이 부족하므로 건물을 건설할 수 없습니다.  ");
							continue;
						}

						if(BuildUnitNum1 == 0) 
						{
							this.BuildUnitNum1 = 1;
							temp[now].PlayerMoney -= this.CityPriceUnit1;
							game.BuyCheck = true;
							break;
						}
						else 
						{
							MessageBox.Show("별장은 이미 건설되어 있습니다.  ");
							continue;
						}
					}
					if(CityBuy1.radioButton2.Checked == true)
					{
						if(temp[now].PlayerMoney <= this.CityPriceUnit2)
						{
							MessageBox.Show("돈이 부족하므로 건물을 건설할 수 없습니다.  ");
							continue;
						}

						if(BuildUnitNum2 == 0) 
						{
							this.BuildUnitNum2 = 1;
							temp[now].PlayerMoney -= this.CityPriceUnit2;
							game.BuyCheck = true;
							break;
						}
						else 
						{
							MessageBox.Show("빌딩은 이미 건설되어 있습니다.  ");
							continue;
						}
					}
					if(CityBuy1.radioButton3.Checked == true)
					{
						if(temp[now].PlayerMoney <= this.CityPriceUnit3)
						{
							MessageBox.Show("돈이 부족하므로 건물을 건설할 수 없습니다.  ");
							continue;
						}

						if(BuildUnitNum3 == 0) 
						{
							this.BuildUnitNum3 = 1;
							temp[now].PlayerMoney -= this.CityPriceUnit3;
							game.BuyCheck = true;
							break;
						}
						else 
						{
							MessageBox.Show("호텔은 이미 건설되어 있습니다.  ");
							continue;
						}
					}
				}
			}
			
			else if(CityHave == -1)
			{
				CityDialog2 CityBuy2 = new CityDialog2();

				while(CityBuy2.ShowDialog() == DialogResult.OK)
				{
					if(temp[now].PlayerMoney <= this.CityPriceLand)
					{
						MessageBox.Show("돈이 부족하므로 도시를 구입할 수 없습니다.  ");
						continue;
					}

					this.CityHave = temp[now].PlayerNumber;
					temp[now].PlayerMoney -= this.CityPriceLand;
					game.BuyCheck = true;
					break;
				}
			}

			else
			{
				int tempPay;

				tempPay = 0;
				if (BuildUnitNum1 == 1) 
					tempPay += CityPayUnit1;
				if (BuildUnitNum2 == 1)
					tempPay += CityPayUnit2;
				if (BuildUnitNum3 == 1)
					tempPay += CityPayUnit3;
				if (BuildUnitNum1 == 0 && BuildUnitNum2 == 0 && BuildUnitNum3 == 0)
					tempPay += CityPayLand;

				UserBuffer.BufferStr2 = CityName + "은 현재 " + temp[CityHave].PlayerName
					+ "님이 소유하고 있습니다. 통행료  " + tempPay + "원을 지불합니다.";

				CityDialog4 CityPay1 = new CityDialog4();

				while(CityPay1.ShowDialog() == DialogResult.Abort)
				{
					if(temp[now].HaveItem2 > 0) 
					{
						MessageBox.Show("우대권을 사용하였습니다.  \n통행료를 지불하지 않습니다.  ");
						temp[now].HaveItem2--;
						game.BuyCheck = true;
						return;
					}
					else
						MessageBox.Show("가지고 있는 우대권이 없습니다.  ");
				}

				temp[now].PlayerMoney -= tempPay;
				temp[CityHave].PlayerMoney += tempPay;

				if(temp[now].PlayerMoney < 0)
				{
					temp[now].DebtWho = CityHave;
					temp[now].PlayerDebt = true;
				}

				game.BuyCheck = true;		//버그체크
			}
		}

		// 특수도시
		public void SpecialCity(Player[] temp, int now, GameData game)
		{
			UserBuffer.BufferStr1 = "도시명 : " + this.CityName 
				+ "\n국적 : " + this.CityNation
				+"\n가격 : " + this.CityPriceLand / 10000 + "만원";
			UserBuffer.BufferInt5 = temp[now].PlayerLocate;

			UserBuffer.BufferStr3 = "<< 건설된 건물 >>\n건물을 지을 수 있는 도시가 아닙니다. ";
			UserBuffer.BufferStr3 += "\n\n<< 통행요금표 >>\n대지료 : " + CityPayLand + "원";

			if(CityHave == temp[now].PlayerNumber)
			{
				//도시 정보를 보여주는 대화상자를 띄움(예정)
			}

			else if(CityHave == -1)
			{
				CityDialog2 CityBuy2 = new CityDialog2();
				while(CityBuy2.ShowDialog() == DialogResult.OK)
				{
					if(temp[now].PlayerMoney <= this.CityPriceLand)
					{
						MessageBox.Show("돈이 부족하므로 도시를 구입할 수 없습니다.  ");
						continue;
					}

					this.CityHave = temp[now].PlayerNumber;
					temp[now].PlayerMoney -= this.CityPriceLand;
					game.BuyCheck = true;
					break;
				}
			}

			else
			{
				UserBuffer.BufferStr2 = CityName + "은 현재 " + temp[CityHave].PlayerName
					+ "님이 소유하고 있습니다. 통행료  " + CityPayLand + "원을 지불합니다.";

				CityDialog4 CityPay1 = new CityDialog4();

				while(CityPay1.ShowDialog() == DialogResult.Abort)
				{
					if(temp[now].HaveItem2 > 0) 
					{
						MessageBox.Show("우대권을 사용하였습니다.  \n통행료를 지불하지 않습니다.  ");
						temp[now].HaveItem2--;
						game.BuyCheck = true;
						return;
					}
					else
						MessageBox.Show("가지고 있는 우대권이 없습니다.  ");
				}

				temp[now].PlayerMoney -= CityPayLand;
				temp[CityHave].PlayerMoney += CityPayLand;

				if(temp[now].PlayerMoney < 0)
				{
					temp[now].DebtWho = CityHave;
					temp[now].PlayerDebt = true;
				}

				game.BuyCheck = true;
			}
		}

		// 무인도
		public void island(Player temp)
		{
			if(temp.HaveItem1 > 0)
			{
				if(MessageBox.Show("무전기가 있습니다.\n무인도를 탈출하겠습니까?","무인도",
					MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
				{
					MessageBox.Show("무인도를 탈출했습니다.  ");
					temp.HaveItem1--;
					return;
				}
			}
			MessageBox.Show("무인도입니다. 3회 휴식", "무인도");
			temp.PlayerSleepTurn = 3;
		}

		// 사회복지기금
		public void SocietyFund(Player temp,GameData game)
		{
			if(temp.PlayerLocate == 20) 
			{
				if(game.SocietyFund != 0) 
				{
					MessageBox.Show("사회복지기금 " + game.SocietyFund + "원을 받습니다.  ");
					temp.PlayerMoney += game.SocietyFund;
					game.SocietyFund = 0;
				}
				else
					MessageBox.Show("접수된 사회복지기금이 없습니다.  ");
			}
			else 
			{
				MessageBox.Show("사회복지기금 150000원을 접수처에 냅니다.  ");
				temp.PlayerMoney -= 150000;
				game.SocietyFund += 150000;
			}
		}
	}

	// 플레이어 정보
	public class Player
	{
		// 플레이어 설정(현재는 소지금만 설정)
		public void SetPlayer(int money)
		{
			this.PlayerMoney = money;
		}

		public string PlayerName;		// 이름
		public int PlayerNumber;		// 번호
		public int PlayerMoney;			// 소지금
		public int PlayerLocate;		// 위치
		public int PlayerItem;			// 소유 아이템
		public int PlayerCity;			// 소유 도시 갯수
		public int PlayerSleepTurn;		// 휴식 횟수
		public bool PlayerIsDead;		// 파산여부
		public bool DoubleDice;			// 주사위가 같은수가 나왔을때
		public int HaveItem1;			// 아이템1 소유
		public int HaveItem2;			// 아이템2 소유	
		public bool SpaceTourCheck = false;		// 우주여행
		public bool SpaceTourPay = false;		// 우주여행 비용 지불
		public bool NoPay = false;		// 월급을 받을수 있는지 여부
		public int DebtWho;				// 누구에게 빚을졌는지
		public bool PlayerDebt;			// 플레이어가 얼마를 빚지고 있는가(지불능력 부족시)

		public int PlayerAvatar;		// 플레이어의 아바타번호
	}

	// 황금열쇠
	public class Card
	{
		// 수입에 관한 카드
		public void GetMoney(Player temp, Player[] temp2)
		{
			MessageBox.Show(this.CardMessage,this.CardName);
			if(this.CardName=="생일을 축하합니다")
			{
				int present = 0;

				for(int i = 0; i < 4; i++)
				{
					if(temp2[i].PlayerIsDead == false)
					{
						present += this.Money;
						temp2[i].PlayerMoney -= this.Money;
					};
				}
				temp.PlayerMoney += present;
			}
			else 
				temp.PlayerMoney += this.Money;
		}
		
		// 지출에 관한 카드
		public void PayMoney(Player temp)
		{
			MessageBox.Show(this.CardMessage,this.CardName);
			temp.PlayerMoney -= this.Money;
		}

		// 건물 세금 부과 카드
		public void BuildTax(City[] T_City, Player temp)
		{
			MessageBox.Show(this.CardMessage,this.CardName);

			int NumUnit1 = 0;
			int NumUnit2 = 0;
			int NumUnit3 = 0;
			int PayMoney = 0;

			for(int i=0;i<40;i++)
			{
				if(T_City[i].CityHave == temp.PlayerNumber)
				{
					if(T_City[i].BuildUnitNum1 == 1)
						NumUnit1++;
					if(T_City[i].BuildUnitNum2 == 1)
						NumUnit2++;
					if(T_City[i].BuildUnitNum3 == 1)
						NumUnit3++;
				}
			}

			PayMoney = (NumUnit1 * this.PayBuildUnit1) + (NumUnit2 * this.PayBuildUnit2)
				+ (NumUnit3 * this.PayBuildUnit3);

			if(PayMoney == 0)
				MessageBox.Show("가지고 있는 건물이 없습니다.\n통행료를 지불하지 않습니다.  ",this.CardName);
			else
				MessageBox.Show("주택 : " + NumUnit1 + " 빌딩 : " + NumUnit2 + " 호텔 : " + NumUnit3 
					+ " 총 " + PayMoney + "원을 지불합니다.  ",this.CardName);

			temp.PlayerMoney -= PayMoney;
		}

		// 아이템 카드
		public void Item(Player temp)
		{
			MessageBox.Show(this.CardMessage,this.CardName);
			if(this.ItemType == 1)
				temp.HaveItem1 += 1;		// 특수무전기
			if(this.ItemType == 2)
				temp.HaveItem2 += 1;		// 우대권
		}

		// 이동 카드(앞으로)
		public int MoveLocation1(City[] T_City, Player temp, Player[] temp2)
		{
			MessageBox.Show(this.CardMessage,this.CardName);
			
			if(this.CardName=="항공 여행")
			{
				if(T_City[15].CityHave != -1 && T_City[15].CityHave != temp.PlayerNumber)
				{
					MessageBox.Show("콩코드 여객기의 객실료 " + T_City[15].CityPayLand + "원을 지불합니다.  ",this.CardName);
					temp2[T_City[15].CityHave].PlayerMoney += T_City[15].CityPayLand;
					temp.PlayerMoney -= T_City[15].CityPayLand;
				}
			}

			if(this.CardName=="무인도로 가시오")
			{
				temp.NoPay = true;
			}

			if(this.CityNum - temp.PlayerLocate > 0)
				return this.CityNum - temp.PlayerLocate;
			else
				return this.CityNum - temp.PlayerLocate + 40;
		}

		// 이동 카드(뒤로)
		public void MoveLocation2(Player temp)
		{
			MessageBox.Show(this.CardMessage,this.CardName);
		}

		// 반액대매출 카드
		public void SellLand(City[] T_City, Player temp)
		{
			MessageBox.Show(this.CardMessage,this.CardName);

			int tempNum = 0;
			int total = 0;
			int totaltemp = 0;
			int counter = 0;
			int i;

			for(i=0;i<40;i++)
			{
				if(T_City[i].CityHave == temp.PlayerNumber)
				{
					total = T_City[i].CityPriceLand 
						+ (T_City[i].CityPriceUnit1 * T_City[i].BuildUnitNum1)
						+ (T_City[i].CityPriceUnit2 * T_City[i].BuildUnitNum2)
						+ (T_City[i].CityPriceUnit3 * T_City[i].BuildUnitNum3);
					
					if(total>=totaltemp)
					{
						tempNum = i;
						totaltemp = total;
					}
					counter++;
				}
			}

			if(counter==0) 
			{
				MessageBox.Show("소유하고 있는 도시가 없습니다.  ",this.CardName);
				return;
			}

			MessageBox.Show(T_City[tempNum].CityName + "을 반액에 팝니다.  ",this.CardName);

			temp.PlayerMoney += (totaltemp / 2);
			T_City[tempNum].CityHave = -1;
			T_City[tempNum].BuildUnitNum1 = 0;
			T_City[tempNum].BuildUnitNum2 = 0;
			T_City[tempNum].BuildUnitNum3 = 0;
		}

		// 세계일주
		public int OneTurn(Player temp)
		{
			MessageBox.Show(this.CardMessage,this.CardName);
			return 40;
		}

		// 기타
		public void Other()
		{
			MessageBox.Show(this.CardMessage,this.CardName);
		}

		public string CardName;		// 카드 이름
		public int CardType;		// 카드 속성
		public int ItemType;		// 아이템 카드의 속성
		public int Money;			// 카드에 설정된 돈
		public int PayBuildUnit1;	// 종합소득세를 위한 설정
		public int PayBuildUnit2;
		public int PayBuildUnit3;
		public int CityNum;			// 이동할 도시 번호
		public string CardMessage;	// 카드의 메세지
	}
}