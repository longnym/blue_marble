using System;
using System.Windows.Forms;
using Dialogs;

namespace BlueMarble
{
	// �ӽ� ������ ������ ���� ���Ƿ� ���� ����
	// �̵��� �̿��Ͽ� ���� â�� ��ȭ���� ������ ������ ��ȯ�� �Ͼ
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

	// ���ӿ� �ʿ��� ������ ����
	public class GameData
	{
		public int SocietyFund;		// ���� ��ȸ�������
		public int maxPlayer;		// �÷��̾� ��
		public int StartMoney;		// �����Ҷ� ������
		public int LeftPlayer;		// ���� �����ִ� �÷��̾�
		public int Current = -1;	// ���� �÷��̾�
		public int loc_x;			// �÷��̾� ���� ���� �̵���ġ�� ���ϱ� ����
		public int loc_y;
		public bool BuyCheck = false;	// �ǹ�/���ø� �����ߴ��� üũ
		public int DiceNum;				// �ֻ����� ���¼�
		public bool OneTurnCheck = false;	// �������� ������ üũ
	}

	// ���� ����
	public class City
	{
		public int CityType;		// ����
		public int CityPriceLand;	// ����(����)
		public int CityPriceUnit1;	// ����(����)
		public int CityPriceUnit2;	// ����(ȣ��)
		public int CityPriceUnit3;	// ����(����)
		public string CityName;		// �̸�
		public string CityInfo;		// ��������
		public string CityNation;	// ������ ����
		public int CityPicture;		// �̹���
		public int CityHave;		// ������
		public int BuildUnitNum1;	// �ǹ� ����(����)
		public int BuildUnitNum2;	// �ǹ� ����(ȣ��)
		public int BuildUnitNum3;	// �ǹ� ����(����)
		public int CityPayLand;		// �����(����)
		public int CityPayUnit1;	// �����(����)
		public int CityPayUnit2;	// �����(ȣ��)
		public int CityPayUnit3;	// �����(����)
		public int CityLocate_X;	// ��ġ(X��ǥ)
		public int CityLocate_Y;	// ��ġ(Y��ǥ)

		public City()
		{
			CityHave = -1;
		}

		// �Ϲݵ���
		public void NormalCity(Player[] temp, int now, GameData game)
		{
			// ���� ������ �� �ҷ��� ��ȭ���ڿ� ������ �ѱ�� ����
			UserBuffer.BufferStr1 = "���ø� : " + this.CityName 
				+ "\n���� : " + this.CityNation
				+"\n���� : " + this.CityPriceLand / 10000 + "����";
			UserBuffer.BufferInt2 = this.CityPriceUnit1;
			UserBuffer.BufferInt3 = this.CityPriceUnit2;
			UserBuffer.BufferInt4 = this.CityPriceUnit3;
			UserBuffer.BufferInt5 = temp[now].PlayerLocate;

			UserBuffer.BufferStr3 = "<< �Ǽ��� �ǹ� >>\n���� : " + BuildUnitNum1 + "ä" + "\n���� : " + BuildUnitNum2 + "ä" + "\nȣ�� : " 
				+ BuildUnitNum3 + "ä";
			UserBuffer.BufferStr3 += "\n\n<< ������ǥ >>\n������ : " + CityPayLand + "��";
			UserBuffer.BufferStr3 += "\n���� : " + CityPayUnit1 + "��" 
				+ "\n���� : " + CityPayUnit2 + "��"  + "\nȣ�� : " + CityPayUnit3 + "��";

			if(CityHave == temp[now].PlayerNumber)
			{
				CityDialog1 CityBuy1 = new CityDialog1();
	
				while(CityBuy1.ShowDialog() == DialogResult.OK)
				{
					if(CityBuy1.radioButton1.Checked == false && 
						CityBuy1.radioButton2.Checked == false &&
						CityBuy1.radioButton3.Checked == false) 
					{
						MessageBox.Show("�ǹ��� �������� �ʾҽ��ϴ�.  ","�ǹ��� �����ϼ���",
							MessageBoxButtons.OK,MessageBoxIcon.Warning);
						continue;
					}

					if(CityBuy1.radioButton1.Checked == true)
					{
						if(temp[now].PlayerMoney <= this.CityPriceUnit1)
						{
							MessageBox.Show("���� �����ϹǷ� �ǹ��� �Ǽ��� �� �����ϴ�.  ");
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
							MessageBox.Show("������ �̹� �Ǽ��Ǿ� �ֽ��ϴ�.  ");
							continue;
						}
					}
					if(CityBuy1.radioButton2.Checked == true)
					{
						if(temp[now].PlayerMoney <= this.CityPriceUnit2)
						{
							MessageBox.Show("���� �����ϹǷ� �ǹ��� �Ǽ��� �� �����ϴ�.  ");
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
							MessageBox.Show("������ �̹� �Ǽ��Ǿ� �ֽ��ϴ�.  ");
							continue;
						}
					}
					if(CityBuy1.radioButton3.Checked == true)
					{
						if(temp[now].PlayerMoney <= this.CityPriceUnit3)
						{
							MessageBox.Show("���� �����ϹǷ� �ǹ��� �Ǽ��� �� �����ϴ�.  ");
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
							MessageBox.Show("ȣ���� �̹� �Ǽ��Ǿ� �ֽ��ϴ�.  ");
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
						MessageBox.Show("���� �����ϹǷ� ���ø� ������ �� �����ϴ�.  ");
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

				UserBuffer.BufferStr2 = CityName + "�� ���� " + temp[CityHave].PlayerName
					+ "���� �����ϰ� �ֽ��ϴ�. �����  " + tempPay + "���� �����մϴ�.";

				CityDialog4 CityPay1 = new CityDialog4();

				while(CityPay1.ShowDialog() == DialogResult.Abort)
				{
					if(temp[now].HaveItem2 > 0) 
					{
						MessageBox.Show("������ ����Ͽ����ϴ�.  \n����Ḧ �������� �ʽ��ϴ�.  ");
						temp[now].HaveItem2--;
						game.BuyCheck = true;
						return;
					}
					else
						MessageBox.Show("������ �ִ� ������ �����ϴ�.  ");
				}

				temp[now].PlayerMoney -= tempPay;
				temp[CityHave].PlayerMoney += tempPay;

				if(temp[now].PlayerMoney < 0)
				{
					temp[now].DebtWho = CityHave;
					temp[now].PlayerDebt = true;
				}

				game.BuyCheck = true;		//����üũ
			}
		}

		// Ư������
		public void SpecialCity(Player[] temp, int now, GameData game)
		{
			UserBuffer.BufferStr1 = "���ø� : " + this.CityName 
				+ "\n���� : " + this.CityNation
				+"\n���� : " + this.CityPriceLand / 10000 + "����";
			UserBuffer.BufferInt5 = temp[now].PlayerLocate;

			UserBuffer.BufferStr3 = "<< �Ǽ��� �ǹ� >>\n�ǹ��� ���� �� �ִ� ���ð� �ƴմϴ�. ";
			UserBuffer.BufferStr3 += "\n\n<< ������ǥ >>\n������ : " + CityPayLand + "��";

			if(CityHave == temp[now].PlayerNumber)
			{
				//���� ������ �����ִ� ��ȭ���ڸ� ���(����)
			}

			else if(CityHave == -1)
			{
				CityDialog2 CityBuy2 = new CityDialog2();
				while(CityBuy2.ShowDialog() == DialogResult.OK)
				{
					if(temp[now].PlayerMoney <= this.CityPriceLand)
					{
						MessageBox.Show("���� �����ϹǷ� ���ø� ������ �� �����ϴ�.  ");
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
				UserBuffer.BufferStr2 = CityName + "�� ���� " + temp[CityHave].PlayerName
					+ "���� �����ϰ� �ֽ��ϴ�. �����  " + CityPayLand + "���� �����մϴ�.";

				CityDialog4 CityPay1 = new CityDialog4();

				while(CityPay1.ShowDialog() == DialogResult.Abort)
				{
					if(temp[now].HaveItem2 > 0) 
					{
						MessageBox.Show("������ ����Ͽ����ϴ�.  \n����Ḧ �������� �ʽ��ϴ�.  ");
						temp[now].HaveItem2--;
						game.BuyCheck = true;
						return;
					}
					else
						MessageBox.Show("������ �ִ� ������ �����ϴ�.  ");
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

		// ���ε�
		public void island(Player temp)
		{
			if(temp.HaveItem1 > 0)
			{
				if(MessageBox.Show("�����Ⱑ �ֽ��ϴ�.\n���ε��� Ż���ϰڽ��ϱ�?","���ε�",
					MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
				{
					MessageBox.Show("���ε��� Ż���߽��ϴ�.  ");
					temp.HaveItem1--;
					return;
				}
			}
			MessageBox.Show("���ε��Դϴ�. 3ȸ �޽�", "���ε�");
			temp.PlayerSleepTurn = 3;
		}

		// ��ȸ�������
		public void SocietyFund(Player temp,GameData game)
		{
			if(temp.PlayerLocate == 20) 
			{
				if(game.SocietyFund != 0) 
				{
					MessageBox.Show("��ȸ������� " + game.SocietyFund + "���� �޽��ϴ�.  ");
					temp.PlayerMoney += game.SocietyFund;
					game.SocietyFund = 0;
				}
				else
					MessageBox.Show("������ ��ȸ��������� �����ϴ�.  ");
			}
			else 
			{
				MessageBox.Show("��ȸ������� 150000���� ����ó�� ���ϴ�.  ");
				temp.PlayerMoney -= 150000;
				game.SocietyFund += 150000;
			}
		}
	}

	// �÷��̾� ����
	public class Player
	{
		// �÷��̾� ����(����� �����ݸ� ����)
		public void SetPlayer(int money)
		{
			this.PlayerMoney = money;
		}

		public string PlayerName;		// �̸�
		public int PlayerNumber;		// ��ȣ
		public int PlayerMoney;			// ������
		public int PlayerLocate;		// ��ġ
		public int PlayerItem;			// ���� ������
		public int PlayerCity;			// ���� ���� ����
		public int PlayerSleepTurn;		// �޽� Ƚ��
		public bool PlayerIsDead;		// �Ļ꿩��
		public bool DoubleDice;			// �ֻ����� �������� ��������
		public int HaveItem1;			// ������1 ����
		public int HaveItem2;			// ������2 ����	
		public bool SpaceTourCheck = false;		// ���ֿ���
		public bool SpaceTourPay = false;		// ���ֿ��� ��� ����
		public bool NoPay = false;		// ������ ������ �ִ��� ����
		public int DebtWho;				// �������� ����������
		public bool PlayerDebt;			// �÷��̾ �󸶸� ������ �ִ°�(���Ҵɷ� ������)

		public int PlayerAvatar;		// �÷��̾��� �ƹ�Ÿ��ȣ
	}

	// Ȳ�ݿ���
	public class Card
	{
		// ���Կ� ���� ī��
		public void GetMoney(Player temp, Player[] temp2)
		{
			MessageBox.Show(this.CardMessage,this.CardName);
			if(this.CardName=="������ �����մϴ�")
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
		
		// ���⿡ ���� ī��
		public void PayMoney(Player temp)
		{
			MessageBox.Show(this.CardMessage,this.CardName);
			temp.PlayerMoney -= this.Money;
		}

		// �ǹ� ���� �ΰ� ī��
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
				MessageBox.Show("������ �ִ� �ǹ��� �����ϴ�.\n����Ḧ �������� �ʽ��ϴ�.  ",this.CardName);
			else
				MessageBox.Show("���� : " + NumUnit1 + " ���� : " + NumUnit2 + " ȣ�� : " + NumUnit3 
					+ " �� " + PayMoney + "���� �����մϴ�.  ",this.CardName);

			temp.PlayerMoney -= PayMoney;
		}

		// ������ ī��
		public void Item(Player temp)
		{
			MessageBox.Show(this.CardMessage,this.CardName);
			if(this.ItemType == 1)
				temp.HaveItem1 += 1;		// Ư��������
			if(this.ItemType == 2)
				temp.HaveItem2 += 1;		// ����
		}

		// �̵� ī��(������)
		public int MoveLocation1(City[] T_City, Player temp, Player[] temp2)
		{
			MessageBox.Show(this.CardMessage,this.CardName);
			
			if(this.CardName=="�װ� ����")
			{
				if(T_City[15].CityHave != -1 && T_City[15].CityHave != temp.PlayerNumber)
				{
					MessageBox.Show("���ڵ� �������� ���Ƿ� " + T_City[15].CityPayLand + "���� �����մϴ�.  ",this.CardName);
					temp2[T_City[15].CityHave].PlayerMoney += T_City[15].CityPayLand;
					temp.PlayerMoney -= T_City[15].CityPayLand;
				}
			}

			if(this.CardName=="���ε��� ���ÿ�")
			{
				temp.NoPay = true;
			}

			if(this.CityNum - temp.PlayerLocate > 0)
				return this.CityNum - temp.PlayerLocate;
			else
				return this.CityNum - temp.PlayerLocate + 40;
		}

		// �̵� ī��(�ڷ�)
		public void MoveLocation2(Player temp)
		{
			MessageBox.Show(this.CardMessage,this.CardName);
		}

		// �ݾ״���� ī��
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
				MessageBox.Show("�����ϰ� �ִ� ���ð� �����ϴ�.  ",this.CardName);
				return;
			}

			MessageBox.Show(T_City[tempNum].CityName + "�� �ݾ׿� �˴ϴ�.  ",this.CardName);

			temp.PlayerMoney += (totaltemp / 2);
			T_City[tempNum].CityHave = -1;
			T_City[tempNum].BuildUnitNum1 = 0;
			T_City[tempNum].BuildUnitNum2 = 0;
			T_City[tempNum].BuildUnitNum3 = 0;
		}

		// ��������
		public int OneTurn(Player temp)
		{
			MessageBox.Show(this.CardMessage,this.CardName);
			return 40;
		}

		// ��Ÿ
		public void Other()
		{
			MessageBox.Show(this.CardMessage,this.CardName);
		}

		public string CardName;		// ī�� �̸�
		public int CardType;		// ī�� �Ӽ�
		public int ItemType;		// ������ ī���� �Ӽ�
		public int Money;			// ī�忡 ������ ��
		public int PayBuildUnit1;	// ���ռҵ漼�� ���� ����
		public int PayBuildUnit2;
		public int PayBuildUnit3;
		public int CityNum;			// �̵��� ���� ��ȣ
		public string CardMessage;	// ī���� �޼���
	}
}