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

            LuckFunc luckFunc = new LuckFunc();
            while (true)
            {
                var choose_func = Convert.ToInt32(Console.ReadLine());
                if (choose_func == 1)
                {
                    out_talk(1);
                    var input_ball = new string[7]; //存储所有输入的数字球
                    var right_ball = new string[7]; //存储开奖的数字球
                    var int_red_ball = new int[6];
                    var input_red_ball = new string[6];
                    var used_number = new bool[red_ball.Length];
                    for (var i = 1; i <= int_red_ball.Length; i++)
                    {
                        while (true)
                        {
                            int_red_ball[i - 1] = Convert.ToInt32(Console.ReadLine());
                            if (int_red_ball[i - 1] < 1 || int_red_ball[i - 1] > 33)
                            {
                                out_word("请检查你的输入，你输入的值不在范围之中，请重新输入");
                                out_line();
                                continue;
                            }
                            else if (used_number[int_red_ball[i - 1]])
                            {
                                out_word("这个号码已经选过了，不能重复选取");
                                out_line();
                                continue;
                            }
                            else 
                            {
                                break;
                            }
                        }
                        used_number[int_red_ball[i - 1]] = true;
                        var sig_redball = int_red_ball[i - 1].ToString("D2");
                        input_red_ball[i - 1] = sig_redball;
                    }
                    out_talk(2);
                    var int_blue_ball = 01;
                    while (true)
                    {
                        int_blue_ball = Convert.ToInt32(Console.ReadLine());
                        if (int_blue_ball < 1 || int_blue_ball > 16)
                        {
                            out_word("请检查你的输入，你输入的值不在范围之中，请重新输入");
                            out_line();
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    var input_blue_ball = int_blue_ball.ToString("D2");
                    for (var i = 0; i <= input_red_ball.Length-1; i++)
                    {
                        input_ball[i] = input_red_ball[i];
                    }
                    input_ball[input_ball.Length - 1] = input_blue_ball;
                    out_line();
                    out_word("你的选择如下");
                    out_line();
                    for (var i = 0; i <= input_ball.Length - 2; i++)
                    {
                        initWindow.input_redball();
                        out_word("\t");
                    }
                    initWindow.input_blueball();
                    out_line();
                    foreach (var ball in input_ball)
                    {
                        out_word(ball);
                        out_word("\t");
                    }
                    out_line();
                    out_word("按Enter键揭晓开奖号码");
                    out_line();
                    Console.ReadKey();
                    //输出中奖号码
                    out_talk(6);
                    var right_red_ball = luckFunc.get_rand_redball();
                    var right_blue_ball = luckFunc.get_rand_blueball();
                    for (var i = 0; i <= input_ball.Length - 2; i++)
                    {
                        initWindow.input_redball();
                        out_word("\t");
                    }
                    initWindow.input_blueball();
                    out_line();
                    for (var i = 0; i <= right_red_ball.Length - 1; i++)
                    {
                        right_ball[i] = right_red_ball[i];
                    }
                    right_ball[right_ball.Length - 1] = right_blue_ball;
                    foreach (var ball in right_ball)
                    {
                        out_word(ball);
                        out_word("\t");
                    }
                    out_line();
                    out_word("按Enter键计算获奖号码");
                    out_line();
                    Console.ReadKey();
                    var goal_ball = luckFunc.compare_right(input_ball, right_ball);
                    foreach (var ball in goal_ball)
                    {
                        Console.Write(ball);
                        out_word("\t");
                    }
                    for (int i = 0; i < goal_ball.Length; i++)
                    {
                        if (goal_ball[i] == true)
                        {
                            out_word(input_ball[i]);
                            out_word("\t");
                        }
                    }
                    Console.ReadKey();
                    break;
                }
                else if (choose_func == 2)
                {
                    Console.Clear();
                    out_talk(3);
                    Console.ReadKey();
                    out_line();
                    var input_ball = new string[7];
                    var input_red_ball = luckFunc.get_rand_redball();
                    var input_blue_ball = luckFunc.get_rand_blueball();
                    for (var i = 0; i <= input_ball.Length - 2; i++)
                    {
                        initWindow.input_redball();
                        out_word("\t");
                    }
                    initWindow.input_blueball();
                    out_line();
                    for (var i = 0; i <= input_red_ball.Length - 1; i++)
                    {
                        input_ball[i] = input_red_ball[i];
                    }
                    input_ball[input_ball.Length - 1] = input_blue_ball;
                    foreach (var ball in input_ball)
                    {
                        out_word(ball);
                        out_word("\t");
                    }
                    out_line();

                    //开奖号码
                    out_word("按Enter键揭晓开奖号码");
                    out_line();
                    Console.ReadKey();
                    LuckFunc new_luckfunc = new LuckFunc();
                    var right_ball = new string[7];
                    var right_red_ball = new_luckfunc.get_rand_redball();
                    var right_blue_ball = new_luckfunc.get_rand_blueball();
                    for (var i = 0; i <= right_ball.Length - 2; i++)
                    {
                        initWindow.input_redball();
                        out_word("\t");
                    }
                    initWindow.input_blueball();
                    out_line();
                    for (var i = 0; i <= right_red_ball.Length - 1; i++)
                    {
                        right_ball[i] = right_red_ball[i];
                    }
                    right_ball[right_ball.Length - 1] = right_blue_ball;
                    foreach (var ball in right_ball)
                    {
                        out_word(ball);
                        out_word("\t");
                    }
                    out_line();
                    out_word("按Enter键计算获奖号码");
                    out_line();
                    Console.ReadKey();
                    var goal_ball = new_luckfunc.compare_right(input_ball, right_ball);
                    foreach (var ball in goal_ball)
                    {
                        Console.Write(ball);
                        out_word("\t");
                    }
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
