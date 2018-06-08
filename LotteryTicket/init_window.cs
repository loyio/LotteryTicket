/*
 
 Copyright (C) 2018 susmote.com All rights reserved
 Created by susmote on 06.07
 Github page  https://github.com/susmote/LotteryTicket
 
 */
using System;

namespace LotteryTicket
{
    public class InitWindow
    {
        public void init_window()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Title = "双色球彩票助手 by susmote";
            Console.WindowHeight = 25;
            Console.BufferHeight = 25;
            Console.WindowWidth = 74;
            Console.BufferWidth = 74;
            Console.WindowWidth = 74;
            Console.CursorVisible = false;
            
            //绘制边框
            for (var i = 0; i <= Console.WindowHeight; i++)
            {
                if (i == 0)
                {
                    Console.SetCursorPosition(0, i);
                    for (var j = 1; j <= Console.WindowWidth-1; j++)
                    {
                        if (j == 1)
                        {
                            Console.Write('╔');
                            continue;
                        }else if (j == Console.WindowWidth-1)
                        {
                            Console.Write("╗");
                            continue;
                        }
                        Console.Write("═");
                    }
                }
                else if (i == Console.WindowHeight - 2)
                {
                    Console.SetCursorPosition(0, i);
                    for (var j = 1; j <= Console.WindowWidth-1; j++)
                    {
                        if (j == 1)
                        {
                            Console.Write('╚');
                            continue;
                        }else if (j == Console.WindowWidth-1)
                        {
                            Console.Write("╝");
                            continue;
                        }
                        Console.Write("═");
                    }
                }
                else if (i == Console.WindowHeight || i == Console.WindowHeight - 1)
                {
                }
                else
                {
                    for (var j = 1; j <= Console.WindowWidth-1; j++)
                    {
                        if (j == 1)
                        {
                            Console.SetCursorPosition(j-1, i);
                            Console.Write('║');
                            continue;
                        }else if (j == Console.WindowWidth-1)
                        {
                            Console.SetCursorPosition(j-1, i);
                            Console.Write("║");
                            continue;
                        }
                    }
                }
            }
        }

        public void welcome()
        {
            Console.SetCursorPosition(12, 12);
            input_redball();
            input_title("双色球助手");
            input_blueball();
        }

        public void input_redball()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("●");
        }
        public void input_blueball()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("●");
        }

        public void input_title(string title)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(title);
        }
    }
}