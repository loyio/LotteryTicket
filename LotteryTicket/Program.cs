/*

 Copyright (C) 2018 susmote.com All rights reserved
 Created by susmote on 06.07
 Github page  https://github.com/susmote/LotteryTicket
 
 */
using System;
using System.Drawing;

namespace LotteryTicket
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //初始化窗口
            Console.Clear();
            var initWindow = new InitWindow();
            initWindow.init_window();
            initWindow.welcome();
            
//            Console.SetCursorPosition(0, 2);
//            //生成红色球
//            var red_ball = new int[33];
//            for (var i = 1; i <= red_ball.Length; i++)
//            {
//                red_ball[i - 1] = i;
//            }
//            Console.ForegroundColor = ConsoleColor.Red;
//            foreach (var i in red_ball)
//            {
//                Console.Write("{0:D2}  ", red_ball[i-1]);
//            }
//            Console.WriteLine();
//            
//            //生成蓝色球
//            var blue_ball = new int[16];
//            for (var i = 1; i <= blue_ball.Length; i++)
//            {
//                blue_ball[i - 1] = i;
//            }
//            Console.ForegroundColor = ConsoleColor.Blue;
//            foreach (var i in blue_ball)
//            {
//                Console.Write("{0:D2}  ", blue_ball[i-1]);
//            }
            
            Console.SetCursorPosition(10, 20);
            var test_key = Console.ReadKey(true).Key;
            Console.Write(test_key);
            Console.Read();

        }
    }
}