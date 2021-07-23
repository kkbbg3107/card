using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WORK
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] poker = new int[52];//一副牌
            List<int> card = sufflecard(poker);
            Console.WriteLine("請輸入人數");
            var input = int.Parse(Console.ReadLine());
            GetCard(card,input);
            Console.WriteLine("要繼續玩嗎 要的話按1\n");

            var check = Console.ReadLine();
            if (check == "1")
            {
                Console.WriteLine("重洗&發牌後");
                while (check == "1")
                {
                    List<int> s = sufflecard(poker);
                    Console.WriteLine("請輸入人數");
                    var person = int.Parse(Console.ReadLine());
                    GetCard(s,person);
                    Console.WriteLine("要繼續玩嗎 要的話按1");
                }
            }
            
            Console.ReadLine();
        }

        
        
        public static List<int> sufflecard(int[] poker) // 洗牌
        {
            
            List<int> record = new List<int>();
            for (int i = 0; i < poker.Length; i++)
            {
                poker[i] = i + 1;
            }

            int rand = 0;
            int tmp = 0;
            Random r = new Random();
            for (int i = 0; i < poker.Length; i++) // 暫存變數使用
            {
                rand = r.Next(0, 52);
                tmp = poker[i];
                poker[i] = poker[rand];
                poker[rand] = tmp;
            }

            for (int i =0; i < poker.Length; i++)
            {
                record.Add(poker[i]);
            }

            return record;
        }

        /// <summary>
        /// 每個人得到的卡片
        /// </summary>
        /// <returns></returns>
        public static void GetCard(List<int> poker, int peopleCount)
        {
            
            int card = 52 / peopleCount;
            int tmp = 0;
            //List<int> personList = new List<int>();
            Console.WriteLine("請輸入人員數量");
            for (int people = 1; people <= peopleCount; people++)
            {
                Console.WriteLine($"第{people}位玩家");
                int r = 0;
       

                string s = string.Empty;
                for (card = 0; card < 52 / peopleCount; card++) // 他能得到幾張牌
                {

                    s += poker[tmp] + ",";
                    tmp++;
                }
                Console.WriteLine($"第{people}個人,拿到這些牌{s}");
            }

            string leaveCard = string.Empty;
            for (int i = tmp; i < 52; i++)
            {
                leaveCard += poker[i].ToString() + ",";
            }
            Console.WriteLine("發剩的牌" + leaveCard);
        }
    }
}
