/*
 
 Copyright (C) 2018 susmote.com All rights reserved
 Created by susmote on 06.07
 Github page  https://github.com/susmote/LotteryTicket
 
 */

using System;

namespace LotteryTicket_easy
{
    class Program
    {
        static void Main(string[] args)
        {
            //初始化窗口
            InitWindow initWindow = new InitWindow();

            //生成红色球
            const int init_left = 0;
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
                Console.Write("{0:D2}  ", red_ball[i - 1]);
            }
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
                Console.Write("{0:D2}  ", blue_ball[i - 1]);
            }
            out_line();
            out_word("请输入你需要进行的操作");
            out_word("1:手动选号\t 2:自动选号");
            out_line();
            while (true)
            {
                var choose_func = Convert.ToInt32(Console.ReadLine());
                if (choose_func == 1)
                {
                    out_talk(1);
                    var input_ball = new string[7]; //存储所有输入的数字球
                    var int_red_ball = new int[6];
                    var input_red_ball = new string[6];
                    for (var i = 1; i <= int_red_ball.Length; i++)
                    {
                        int_red_ball[i - 1] = Convert.ToInt32(Console.ReadLine());
                        var sig_redball = int_red_ball[i - 1].ToString("D2");
                        input_red_ball[i - 1] = sig_redball;
                    }
                    out_talk(2);
                    var int_blue_ball = Convert.ToInt32(Console.ReadLine());
                    var input_blue_ball = int_blue_ball.ToString("D2");
                    Console.ReadKey();
                    break;
                }
                else if (choose_func == 2)
                {
                    out_talk(3);
                    out_line();
                    Console.ReadKey();
                    Console.Clear();
                    LuckFunc luckFunc = new LuckFunc();
                    out_talk(4);
                    luckFunc.get_rand_redball();
                    out_talk(5);
                    luckFunc.get_rand_blueball();
                    Console.ReadKey();
                    break;
                }
                else
                {
                    out_word("请输入正确的操作数字");
                    out_line();
                    continue;
                }
            }
        }
        //指定位置输出字符串
        public static void out_word(string word, int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x, y);
            Console.Write(word);
        }

        public static void out_word(string word)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(word);
        }

        public static void out_talk(int choose)
        {
            InitWindow initWindow = new InitWindow();
            //手动选号红色
            if (choose == 1)
            {
                out_word("请从上面33个");
                initWindow.input_redball();
                out_word("选择6个");
                initWindow.input_redball();
                out_word(",按Enter键继续");
                out_line();
            }
            //手动选号蓝色
            else if (choose == 2)
            {
                out_word("请从上面16个");
                initWindow.input_blueball();
                out_word("选择1个");
                initWindow.input_blueball();
                out_word(",按Enter键继续");
                out_line();
            }
            //自动选号
            else if (choose == 3)
            {
                out_word("将要随机生成6个");
                initWindow.input_redball();
                out_word("和1个");
                initWindow.input_blueball();
                out_word(",按Enter键继续");
            }
            //生成红色球
            else if (choose == 4)
            {
                out_word("生成随机红色球");
                initWindow.input_redball();
                out_line();
            }
            //生成蓝色球
            else if (choose == 5)
            {
                out_word("生成随机蓝色球");
                initWindow.input_blueball();
                out_line();
            }
            //中奖号码
            else if (choose == 6)
            {
                out_word("当前开奖");
                initWindow.input_redball();
                out_word("和");
                initWindow.input_blueball();
                out_word("号码球如下:");
                out_line();
            }
        }

        //分行
        private static void out_line()
        {
            Console.WriteLine();
        }
    }
}
