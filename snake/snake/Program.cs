using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(85, 30);

            HorizontalLine upLine = new HorizontalLine(0, 78, 0, '+');
            HorizontalLine downLine = new HorizontalLine(0, 78, 24, '+');
            VerticalLine leftLine = new VerticalLine(0, 24, 0, '+');
            VerticalLine rightLine = new VerticalLine(0, 24, 78, '+');
            upLine.Drow();
            downLine.Drow();
            leftLine.Drow();
            rightLine.Drow();

            Point p = new Point(3, 4, '*');
            Snake snake = new Snake(p, 8, Direction.RIGHT);
            snake.Drow();

            while(true)                                                 //бесконечный цикл
            {
                if(Console.KeyAvailable)                                //проверяем была ли нажата клавиша с прошлого витка цикла
                {
                    ConsoleKeyInfo key = Console.ReadKey();             //получаем значение клавиши
                    snake.HandleKey(key.Key);
                }
                Thread.Sleep(110);
                snake.Move();
            }
         }
    }
}
