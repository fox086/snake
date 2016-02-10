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

            Walls walls = new Walls(80, 25);
            walls.Draw();

            Point p = new Point(3, 4, '*');
            Snake snake = new Snake(p, 3, Direction.RIGHT);
            snake.Drow();

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');     //указываем пищу с параметрами
            Point food = foodCreator.CreateFood();                      //создаем произволно новую точку еды
            food.Draw();                                                //выводим еду на экран

            while(true)                                                 //бесконечный цикл
            {
                if (walls.IsHit(snake) || snake.IsHitTail())            //проверка на столкновение со стенкой или хвостом
                {
                    break;
                }

                if (snake.Eat(food))                                     
                {
                    food = foodCreator.CreateFood();                    
                    food.Draw();                                        
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(110);

                if (Console.KeyAvailable)                                //проверяем была ли нажата клавиша с прошлого витка цикла
                {
                    ConsoleKeyInfo key = Console.ReadKey();             //получаем значение клавиши
                    snake.HandleKey(key.Key);
                }
            }
         }
    }
}
