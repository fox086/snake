using System;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    class GameOver
    {
        public static void WriteGameOver()
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset + 1, yOffset++);
            yOffset++;
            WriteText("  Автор: Сергеев Кирилл", xOffset + 2, yOffset++);
            WriteText("     Для выхода - ENTER", xOffset + 1, yOffset++);
            WriteText("============================", xOffset, yOffset++);
        }

        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }

        public static void StartGame()
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            WriteText("   ЗМЕЯ В ПОИСКАХ БАБЛА!    ", xOffset + 1, yOffset++);
            yOffset++;
            WriteText("    Для старта нажмите      ", xOffset + 2, yOffset++);
            WriteText("   *******ENTER*******      ", xOffset + 1, yOffset++);
            WriteText("============================", xOffset, yOffset++);

            Console.ReadLine();

            int qxOffset = 25;
            int qyOffset = 8;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(qxOffset, qyOffset++);
            WriteText("                            ", qxOffset, qyOffset++);
            WriteText("                            ", qxOffset + 1, qyOffset++);
            qyOffset++;
            WriteText("                            ", qxOffset + 2, qyOffset++);
            WriteText("                            ", qxOffset + 1, qyOffset++);
            WriteText("                            ", qxOffset, qyOffset++);

        }

        public void RestartKey(ConsoleKey rkey)
        {
            if (rkey == ConsoleKey.S)
            {
                Process.Start(Assembly.GetExecutingAssembly().Location);
                Environment.Exit(0);
            }
            else if (rkey == ConsoleKey.Enter)
            {
                return;
            }

        }
    }
}
