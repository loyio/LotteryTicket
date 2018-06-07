/*

 Copyright (C) 2018 susmote.com All rights reserved
 Created by susmote on 06.07
 Github page  https://github.com/susmote/LotteryTicket
 
 */
using System;

namespace LotteryTicket
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            InitWindow initWindow = new InitWindow();
            initWindow.init_window();
            Console.Clear();
            Console.WriteLine("hello world");
            Console.Read();
        }
    }
}