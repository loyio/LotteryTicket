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

            const int init_left = 22;
            Console.SetCursorPosition(init_left, 2);
            //生成红色球
            var red_ball = new int[33];
            for (var i = 1; i <= red_ball.Length; i++)
            {
                red_ball[i - 1] = i;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var i in red_ball)
            {
                if (i % 6 == 1)
                {
                    Console.CursorTop++;
                    Console.CursorLeft = init_left;
                }
                Console.Write("{0:D2}  ", red_ball[i-1]);
            }

            out_line();
            Console.SetCursorPosition(init_left, 11);
            //生成蓝色球
            var blue_ball = new int[16];
            for (var i = 1; i <= blue_ball.Length; i++)
            {
                blue_ball[i - 1] = i;
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (var i in blue_ball)
            {
                if (i % 6 == 1)
                {
                    Console.CursorTop++;
                    Console.CursorLeft = init_left;
                }
                Console.Write("{0:D2}  ", blue_ball[i-1]);
            }
            
            out_word("请输入yes或y确定生成随机双色球",22,18);
            out_word("[    ]",25,20);
            Console.SetCursorPosition(26,20);
            var choose = Console.ReadLine();
            if (choose == "yes" || choose == "y")
            {
                
            }
        }
        //指定位置输出字符串
        public static void out_word(string word, int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(x, y);
            Console.Write(word);
        }
        
        //分行
        private static void out_line()
        {
            Console.WriteLine();
        }
    }
}