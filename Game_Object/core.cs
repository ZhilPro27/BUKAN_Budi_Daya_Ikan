﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUKAN_Budi_Daya_Ikan_.Game_Object
{
    public static class core
    {
        public static List<Food> Foodlist = new List<Food>();
        public static List<Fish> Fishlist = new List<Fish>();
        public static List<Enemy> Enemylist = new List<Enemy>();
        public static Random random = new Random();
        public static int score = 0;
        public static int money = 10;
        public static string playerName = "";
        public static void AddScore()
        {
            core.score += 1;
        }

        public static void AddMoney()
        {
            core.money += 20;
        }
    }
}
