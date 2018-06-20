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
            return res_red_ball;
        }
        //获取随机的蓝色号码球
        public string get_rand_blueball()
        {
            var tem_blue_ball = new int[16];
            var blue_ball = new string[16];
            for (var i = 1; i <= tem_blue_ball.Length; i++)
            {
                tem_blue_ball[i - 1] = i;
                var sig_blueball = tem_blue_ball[i - 1].ToString("D2");
                blue_ball[i - 1] = sig_blueball;
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            var random = new Random();
            var index = random.Next(blue_ball.Length);
            var res_blue_ball = blue_ball[index];
            return res_blue_ball;
        }

        //判断最后输入的值是否中奖
        public bool[] compare_right(string[] input_ball, string[] right_choose)
        {
            var right_ball = new bool[7];

            //判断蓝色球是否正确
            if (input_ball[6] == right_choose[6])
            {
                right_ball[6] = true;
            }
            else 
            {
                right_ball[6] = false;
            }
            for (var i = 0; i < input_ball.Length - 1; i++)
            {
                for (var j = 0; j < right_choose.Length - 1; j++)
                {
                    if (input_ball[i] == right_choose[j])
                    {
                        right_ball[i] = true;
                        break;
                    }
                    else
                    {
                        right_ball[i] = false;
                    }
                }
            }
            return right_ball;
        }

        //判断获取几等奖,根据网上规则
        public string judge_goal(bool[] input_goal)
        {
            var red_count = 0;
            var blue_count = 0; 
            for (var i = 0; i < input_goal.Length - 1; i++)
            {
                if (input_goal[i])
                {
                    red_count++;
                }
            }
            if (input_goal[input_goal.Length - 1])
            {
                blue_count = 1;
            }
            switch (red_count)
            {
                case 1:
                    return "六等奖";
                case 2:
                    return "六等奖";
                case 3:
                    if (blue_count == 1)
                    {
                        return "五等奖";
                    }
                    else 
                    {
                        return "未获奖";
                    }
                case 4:
                    if (blue_count == 1)
                    {
                        return "四等奖";
                    }
                    else
                    {
                        return "五等奖";
                    }
                case 5:
                    if (blue_count == 1)
                    {
                        return "三等奖";
                    }
                    else
                    {
                        return "四等奖";
                    }
                case 6:
                    if (blue_count == 1)
                    {
                        return "一等奖";
                    }
                    else
                    {
                        return "二等奖";
                    }
                default:
                    return "未获奖";
            }
        }
    }
}