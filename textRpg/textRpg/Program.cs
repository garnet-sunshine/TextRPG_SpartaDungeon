using System;
using System.ComponentModel.Design;
using System.Threading;
using textRpg;

namespace textRpg
{
    internal class Program
    {
        static Player player = new Player();
        public static List<Item> inventory = new List<Item>();

        static List<ShopItem> shopItems = new List<ShopItem>()
        {
            new ShopItem("수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", 5, "방어력", 1000),
            new ShopItem("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 9, "방어력", 1200),
            new ShopItem("스파르타의 갑옷", "스파르타 전사들이 사용한 전설의 갑옷입니다.", 15, "방어력", 3500),
            new ShopItem("낡은 검", "쉽게 볼 수 있는 낡은 검입니다.", 2, "공격력", 400),
            new ShopItem("청동 도끼", "어디선가 사용됐던거 같은 도끼입니다.", 5, "공격력", 1100),
            new ShopItem("스파르타의 창", "스파르타 전사들이 사용했던 전설의 창입니다.", 7, "공격력", 2200),
            new ShopItem("심연의 낫", "깊은 어둠속에서 깨어난 무기입니다.", 14, "공격력", 2300),
            new ShopItem("롱소드", "공격! 공격! 공격!", 30, "공격력", 5400),

        };


        static void Main(string[] args)
        {
            ShowTitle();
        }

        static void ShowTitle()
        {
            Console.WriteLine("+----------------------+");
            Console.WriteLine("|                      |");
            Console.WriteLine("|      Text RPG :      |");
            Console.WriteLine("|     스파르타던전     |");
            Console.WriteLine("|                      |");
            Console.WriteLine("+----------------------+\n");


            Thread.Sleep(1500);

            // 해커 타이핑
            string text1 = "스파르타가 당신을 기다리고 있습니다 ";
            foreach (char c in text1)
            {
                Console.Write(c);
                Thread.Sleep(50);
            }

            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(500);
                Console.Write(". ");
            }


            Console.WriteLine("\n");

            Thread.Sleep(1500);

            string text2 = "아무 키나 눌러 모험을 시작하세요 ";
            foreach (char c in text2)
            {
                Console.Write(c);
                Thread.Sleep(50);
            }

            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(500);
                Console.Write(". ");
            }

            Console.ReadKey(true);

            ShowMain();
        }

        static void ShowMain()
        {

            Console.Clear();

            Console.WriteLine("스파르타 마을에 오신 여러분, 환영합니다!");
            Console.WriteLine("던전에 들어가기전 이 곳에서 다양한 활동을 할 수 있습니다.\n");

            Console.ReadKey(true);

            Console.Write("1. ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("상태보기");
            Console.ResetColor();

            Console.Write("2. ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("인벤토리");
            Console.ResetColor();

            Console.Write("3. ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("상점");
            Console.ResetColor();

            Console.Write("4. ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("휴식하기");
            Console.ResetColor();

            Console.Write("5. ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("던전입장\n");
            Console.ResetColor();

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                ShowStatus();
                break;

                case "2":
                ShowInventory();
                break;

                case "3":
                ShowShop();
                break;

                case "4":
                ShowRest();
                break;

                case "5":
                ShowDungeon();
                break;

                case "0":
                Console.WriteLine("게임을 종료합니다.");
                break;

                default:
                Console.WriteLine("잘못된 입력입니다.");
                break;
            }
        }

        static void ShowStatus()
        {
            Console.Clear();

            Console.WriteLine("+----------------------+");
            Console.WriteLine("|       상태보기       |");
            Console.WriteLine("+----------------------+\n");

            Console.WriteLine("캐릭터의 상태가 표시됩니다.");
            Console.WriteLine();

            Console.Write($"Lv. ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{player.Level:D2}");
            Console.ResetColor();

            Console.Write($"{player.Name} ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"({player.Job})");
            Console.ResetColor();

            Console.Write($"공격력 : ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{player.TotalAtk}");
            Console.ResetColor();

            Console.Write($"방어력 : ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{player.TotalDef}");
            Console.ResetColor();

            Console.Write($"체  력 : ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{player.Hp}");
            Console.ResetColor();

            Console.Write($"Gold   : ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{player.Gold} G");
            Console.ResetColor();

            Console.WriteLine();

            Console.Write("0. ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("나가기");
            Console.ResetColor();
            Console.WriteLine();

            Console.Write("원하시는 행동을 입력해주세요.\n>> ");

            string input = Console.ReadLine();
            if (input == "0")
            {
                ShowMain();
            }
            else
            {
                ShowStatus();
            }
        }

        static void ShowInventory()
        {
            Console.Clear();

            Console.WriteLine("+----------------------+");
            Console.WriteLine("|       인벤토리       |");
            Console.WriteLine("+----------------------+\n");

            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();

            Console.WriteLine("[아이템 목록]");
            Console.WriteLine();

            if (inventory.Count == 0)
            {
                Console.WriteLine("보유중인 아이템이 없습니다.");
                Console.WriteLine();

                Console.Write("1. ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("장착관리");
                Console.ResetColor();

                Console.Write("0. ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("나가기\n");
                Console.ResetColor();
            }

            else
            {
                foreach (Item item in inventory)
                {
                    Console.Write("- ");

                    // [E]만 노란색
                    if (item.IsEquipped)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("[E] ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("   ");
                    }

                    Console.WriteLine($" {item.Name} | {item.Type} +{item.Power} | {item.Description}");
                }

                Console.WriteLine();

                Console.Write("1. ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("장착관리");
                Console.ResetColor();

                Console.Write("0. ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("나가기\n");
                Console.ResetColor();
            }

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            string input = Console.ReadLine();

            if (input == "1")
            {
                ShowEquip();
            }
            else if (input == "0")
            {
                ShowMain();
            }
            else
            {
                ShowInventory();
            }


        }

        static void ShowEquip()
        {
            Console.Clear();

            Console.WriteLine("+----------------------+");
            Console.WriteLine("|       인벤토리       |");
            Console.WriteLine("|      -장착관리-      |");
            Console.WriteLine("+----------------------+\n");

            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();

            Console.WriteLine("[아이템 목록]");
            Console.WriteLine();

            for (int i = 0; i < inventory.Count; i++)
            {
                Item item = inventory[i];
                Console.Write($"- {i + 1} ");

                if (item.IsEquipped)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("[E] ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("   ");
                }

                Console.WriteLine($"{item.Name} | {item.Type} +{item.Power} | {item.Description}");
            }

            Console.WriteLine();

            Console.Write("0. ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("나가기\n");
            Console.ResetColor();

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            string input = Console.ReadLine();

            if (input == "0")
            {
                ShowInventory();
                return;
            }

            if (int.TryParse(input, out int selected) && selected >= 1 && selected <= inventory.Count)
            {
                Item selectedItem = inventory[selected - 1];

                if (!selectedItem.IsEquipped)
                {
                    // 같은 타입의 아이템이 이미 장착되어 있다면 해제
                    foreach (Item item in inventory)
                    {
                        if (item.IsEquipped && item.Type == selectedItem.Type)
                        {
                            item.IsEquipped = false;
                        }
                    }

                    // 선택한 아이템 장착
                    selectedItem.IsEquipped = true;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"{selectedItem.Name}을(를) 장착했습니다!");
                }
                else
                {
                    // 이미 장착 중이라면 해제
                    selectedItem.IsEquipped = false;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"{selectedItem.Name}을(를) 장착 해제했습니다!");
                }
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("\n잘못된 입력입니다.");
            }

                Console.WriteLine("\n계속하려면 아무 키나 누르세요.");
                Console.ReadKey();
                ShowEquip();
        }

        static void ShowShop()
        {
            Console.Clear();
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");

            Console.WriteLine($"[보유 골드]");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"{player.Gold} ");
            Console.ResetColor();
            Console.WriteLine($"G");
            Console.WriteLine();

            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < shopItems.Count; i++)
            {
                var item = shopItems[i];
                string priceDisplay = item.IsPurchased ? "구매완료" : $"{item.Price} G";
                Console.WriteLine($"- {item.Name} | {item.Type} +{item.Power,-2} | {item.Description} |  {priceDisplay}");
            }

            Console.WriteLine();
            Console.Write("1. ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("아이템 구매");
            Console.ResetColor();

            Console.Write("2. ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("아이템 판매");
            Console.ResetColor();

            Console.Write("0. ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("나가기");
            Console.ResetColor();
            Console.WriteLine();

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            string input = Console.ReadLine();

            if (input == "0")
            {
                ShowMain();
            }
            else if (input == "1")
            {
                ShowPurchaseMenu();
            }
            else if (input == "2")
            {
                ShowSellMenu();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
                Console.ReadKey();
                ShowShop();
            }
        }

        static void ShowPurchaseMenu()
        {
            Console.WriteLine($"[보유 골드]");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"{player.Gold} G");
            Console.ResetColor();
            Console.WriteLine();

            Console.Clear();
            Console.WriteLine("[아이템 구매]");

            for (int i = 0; i < shopItems.Count; i++)
            {
                var item = shopItems[i];
                string status = item.IsPurchased ? "(구매완료)" : $"({item.Price} G)";
                Console.WriteLine($"{i + 1}. {item.Name} {status}");
            }

            Console.WriteLine();
            Console.Write("0. ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("나가기\n");
            Console.ResetColor();

            Console.WriteLine();
            Console.Write("구매할 아이템 번호를 입력하세요 >> ");
            string input = Console.ReadLine();

            if (input == "0")
            {
                ShowShop();
                return;
            }

            if (int.TryParse(input, out int selected) && selected >= 1 && selected <= shopItems.Count)
            {
                ShopItem item = shopItems[selected - 1];

                if (item.IsPurchased)
                {
                    Console.WriteLine("이미 구매한 아이템입니다.");
                }
                else if (player.Gold < item.Price)
                {
                    Console.WriteLine("골드가 부족합니다.");
                }
                else
                {
                    player.Gold -= item.Price;
                    item.IsPurchased = true;

                    // 인벤토리에 추가
                    inventory.Add(new Item(item.Name, item.Description, item.Power, item.Type, item.Price));

                    Console.WriteLine($"{item.Name}을(를) 구매했습니다!");
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }

            Console.WriteLine("\n계속하려면 아무 키나 누르세요...");
            Console.ReadKey();
            ShowPurchaseMenu();
        }

        static void ShowSellMenu()
        {
            Console.Clear();

            Console.Clear();
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");

            Console.WriteLine($"[보유 골드]");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"{player.Gold} ");
            Console.ResetColor();
            Console.WriteLine($"G");
            Console.WriteLine();

            if (inventory.Count == 0)
            {
                Console.WriteLine("판매할 아이템이 없습니다.\n");
                Console.WriteLine();
                Console.WriteLine();

                Console.Write("0. ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("나가기\n");
                Console.ResetColor();

                Console.Write("원하시는 행동을 입력해주세요.\n>> ");
                string exit = Console.ReadLine();
                if (exit == "0") ShowPurchaseMenu();
                return;
            }

            Console.WriteLine("[아이템 목록]");
            Console.WriteLine();

            for (int i = 0; i < inventory.Count; i++)
            {
                Item item = inventory[i];
                int sellPrice = (int)(item.Price * 0.85);
                Console.WriteLine($"- {i + 1}. {item.Name} | {item.Type} +{item.Power} | {item.Description} | {sellPrice} G");
            }

            Console.WriteLine();
            Console.Write("0. ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("나가기\n");
            Console.ResetColor();

            Console.Write("원하시는 행동을 입력해주세요.\n>> ");

            string input = Console.ReadLine();

            if (input == "0")
            {
                ShowPurchaseMenu();
                return;
            }

            if (int.TryParse(input, out int selected) && selected >= 1 && selected <= inventory.Count)
            {
                Item selectedItem = inventory[selected - 1];

                // 장착 중이면 해제
                if (selectedItem.IsEquipped)
                {
                    selectedItem.IsEquipped = false;
                }

                int sellPrice = (int)(selectedItem.Price * 0.85);
                player.Gold += sellPrice;
                inventory.RemoveAt(selected - 1);

                Console.Write($"\n{selectedItem.Name}을(를) ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"{sellPrice} ");
                Console.ResetColor();
                Console.WriteLine($"G에 판매하였습니다.");
            }
            else
            {
                Console.WriteLine("\n잘못된 입력입니다.");
            }

            Console.WriteLine("\n계속하려면 아무 키나 누르세요.");
            Console.ReadKey();
            ShowSellMenu();
        }

        static void ShowRest()
        {
            Console.Clear();

            Console.WriteLine("+----------------------+");
            Console.WriteLine("|       휴식하기       |");
            Console.WriteLine("+----------------------+\n");

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("500 ");
            Console.ResetColor();
            Console.WriteLine("G 를 내면 체력을 회복할 수 있습니다.");
            Console.WriteLine();

            Console.Write($"(보유 골드 : ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"{player.Gold} ");
            Console.ResetColor();
            Console.WriteLine($"G)");
            Console.WriteLine();

            Console.Write("1. ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("휴식하기");
            Console.ResetColor();

            Console.Write("0. ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("나가기");
            Console.ResetColor();

            Console.WriteLine();

            Console.Write("원하시는 행동을 입력해주세요.\n>> ");
            string input = Console.ReadLine();

            if (input == "1")
            {
                if (player.Gold >= 500)
                {
                    player.Gold -= 500;
                    player.Hp = 100;

                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("휴식을 완료했습니다. 체력이 회복되었습니다!");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Gold 가 부족합니다.");
                    Console.ResetColor();
                }

                Console.WriteLine();
                Console.WriteLine("계속하려면 아무 키나 누르세요.");
                Console.ReadKey();
                ShowMain();
            }
            else if (input == "0")
            {
                ShowMain();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("n잘못된 입력입니다.");
                Console.ReadKey();
                ShowRest();
            }
        }

        static void ShowDungeon()
        {
            Console.Clear();

            Console.WriteLine("+----------------------+");
            Console.WriteLine("|      던전 입장       |");
            Console.WriteLine("+----------------------+\n");

            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");

            Console.Write("1. ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("쉬운 던전");
            Console.ResetColor();
            Console.Write("     | 방어력 ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("5");
            Console.ResetColor();
            Console.WriteLine(" 이상 권장");

            Console.Write("2. ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("일반 던전");
            Console.ResetColor();
            Console.Write("     | 방어력 ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("11");
            Console.ResetColor();
            Console.WriteLine(" 이상 권장");

            Console.Write("3. ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("어려운 던전");
            Console.ResetColor();
            Console.Write("    | 방어력 ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("17");
            Console.ResetColor();
            Console.WriteLine(" 이상 권장");

            Console.WriteLine();
            Console.WriteLine("0. 나가기\n");

            Console.Write("원하시는 행동을 입력해주세요.\n>> ");
            string input = Console.ReadLine();

            if (input == "0")
            {
                ShowMain();
                return;
            }

            Dungeon dungeon = input switch
            {
                "1" => new Dungeon("쉬운 던전", 5, 1000),
                "2" => new Dungeon("일반 던전", 11, 1700),
                "3" => new Dungeon("어려운 던전", 17, 2500),
                _ => null
            };

            if (dungeon == null)
            {
                Console.WriteLine("잘못된 입력입니다.");
                Console.ReadKey();
                ShowDungeon();
                return;
            }

            EnterDungeon(dungeon);
        }

        static void EnterDungeon(Dungeon dungeon)
        {
            int oldHp = player.Hp;
            int oldGold = player.Gold;

            bool isSuccess = true;

            if (player.TotalDef < dungeon.RequiredDef)
            {
                Random rnd = new Random();
                int chance = rnd.Next(0, 100);
                if (chance < 40)
                {
                    isSuccess = false;
                }
            }

            if (!isSuccess)
            {
                player.Hp /= 2;

                Console.Clear();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("던전 실패...");
                Console.ResetColor();

                Console.WriteLine($"[탐험 결과]\n");
                Console.Write("체력 ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(oldHp);
                Console.ResetColor();
                Console.Write(" -> ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(player.Hp);
                Console.ResetColor();
            }
            else
            {
                int defDiff = dungeon.RequiredDef - player.TotalDef;
                defDiff = Math.Abs(defDiff);

                int min = 20 + defDiff;
                int max = 35 + defDiff;

                int hpLoss = new Random().Next(min, max + 1);
                player.Hp = Math.Max(0, player.Hp - hpLoss);

                int atkPercent = new Random().Next(player.TotalAtk, player.TotalAtk * 2 + 1);
                int reward = dungeon.BaseReward + (dungeon.BaseReward * atkPercent / 100);
                player.Gold += reward;

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("축하합니다!!");
                Console.ResetColor();
                Console.WriteLine($"{dungeon.Name}을 클리어 하였습니다.\n");

                Console.WriteLine("[탐험 결과]");

                Console.Write("체력 ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(oldHp);
                Console.ResetColor();
                Console.Write(" -> ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(player.Hp);
                Console.ResetColor();

                Console.Write("Gold ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(oldGold);
                Console.ResetColor();
                Console.Write(" G -> ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{player.Gold} G");
                Console.ResetColor();

                // 던전 클리어 횟수 증가
                player.ClearCount++;

                // 레벨업 조건 계산
                int requiredClear = 0;
                for (int i = 1; i < player.Level + 1; i++)
                {
                    requiredClear += i;
                }

                if (player.ClearCount >= requiredClear)
                {
                    player.Level++;
                    player.BasicAtk += 0.5f;
                    player.BasicDef += 1;

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"\n레벨업! Lv.{player.Level}이 되었습니다!");
                    Console.ResetColor();
                }

            }
            Console.Write("0. ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("나가기\n");
            Console.ResetColor();

            Console.Write(">> ");
            string back = Console.ReadLine();
            ShowMain();
        }


        
    }
}


class Player
{
    public int Level = 1;
    public string Name = "선샤인";
    public string Job = "전사";

    public float BasicAtk = 10f;
    public float BasicDef = 5f;
    public int Hp = 100;
    public int Gold = 1500;

    public int ClearCount = 0;
    
    public int TotalAtk
    {
        get
        {
            float extra = 0f;
            foreach (var item in Program.inventory)
            {
                if (item.IsEquipped && item.Type == "공격력")
                    extra += item.Power;
            }
            return (int)(BasicAtk + extra);
        }
    }

    public int TotalDef
    {
        get
        {
            float extra = 0;
            foreach (var item in Program.inventory)
            {
                if (item.IsEquipped && item.Type == "방어력")
                    extra += item.Power;
            }
            return (int)(BasicDef + extra);
        }
    }
}

public class Item
{
    public string Name;
    public string Description;
    public string Type;
    public int Power;
    public bool IsEquipped;
    public int Price;

    public Item(string name, string desc, int power, string type, int price)
    {
        Name = name;
        Description = desc;
        Power = power;
        Type = type;
        Price = price;
        IsEquipped = false;
    }
}

class ShopItem
{
    public string Name;
    public string Description;
    public int Power;
    public string Type;
    public int Price;
    public bool IsPurchased;

    public ShopItem(string name, string desc, int power, string type, int price)
    {
        Name = name;
        Description = desc;
        Power = power;
        Type = type;
        Price = price;
        IsPurchased = false;
    }
}

    class Dungeon
    {
        public string Name;
        public int RequiredDef;
        public int BaseReward;

        public Dungeon(string name, int def, int reward)
        {
            Name = name;
            RequiredDef = def;
            BaseReward = reward;
        }
    }


