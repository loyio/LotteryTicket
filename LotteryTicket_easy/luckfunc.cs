/*
 
 Copyright (C) 2018 susmote.com All rights reserved
 Created by susmote on 06.07
 Github page  https://github.com/susmote/LotteryTicket
 
 */
using System;

namespace LotteryTicket_easy
{
    public class LuckFunc
    {
        //获取随机的红色号码球
        public string[] get_rand_redball()
        {
            var tem_red_ball = new int[33];
            var red_ball = new string[33];
            var res_red_ball = new string[6];
            for (var i = 1; i <= tem_red_ball.Length; i++)
            {
                tem_red_ball[i - 1] = i;
                var sig_redball = tem_red_ball[i - 1].ToString("D2");
                red_ball[i - 1] = sig_redball;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            var length = 0;
            var used_number = new bool[red_ball.Length];
            var random = new Random();
            while (true)
            {
                var index = random.Next(red_ball.Length);
                if (used_number[index])
                    continue;
                res_red_ball[length++] = red_ball[index];
                used_number[index] = true;
                if (length == res_red_ball.Length)
                    break;
            }
            foreach (var ball in res_red_ball)
            {
                Console.WriteLine(ball);
            }
            return res_red_ball;
        }
        //获取随机的蓝色号码球
        public string get_rand_blueball()
        {
            var tem_blue_ball = new int[16];
            var blue_ball = new string[16];
            var res_blue_ball = "01";
            for (var i = 1; i <= tem_blue_ball.Length; i++)
            {
                tem_blue_ball[i - 1] = i;
                var sig_blueball = tem_blue_ball[i - 1].ToString("D2");
                blue_ball[i - 1] = sig_blueball;
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            var random = new Random();
            var index = random.Next(blue_ball.Length);
            res_blue_ball = blue_ball[index];
            Console.WriteLine(res_blue_ball);
            return res_blue_ball;
        }

        //判断最后输入的值是否中奖
        public bool[] compare_right(string[] input_ball, string[] right_choose)
        {
            var right_ball = new bool[7];
            return right_ball;
        }
    }
}