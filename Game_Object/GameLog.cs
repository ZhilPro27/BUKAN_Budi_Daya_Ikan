using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUKAN_Budi_Daya_Ikan_.Game_Object
{
    internal class GameLog
    {
        public string PlayerName { get; set; }
        public DateTime GameStartTime { get; set; }
        public DateTime GameEndTime { get; set; }
        public int FishPurchased { get; set; }
        public int EnemiesKilled { get; set; }
        public int MoneyEarned { get; set; }
        public int FinalScore { get; set; }

        public GameLog(string playerName)
        {
            PlayerName = playerName;
            GameStartTime = DateTime.Now;
            FishPurchased = 0;
            EnemiesKilled = 0;
            MoneyEarned = 0;
            FinalScore = 0;
        }
    }
}
