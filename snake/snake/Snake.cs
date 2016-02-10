﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    class Snake : Figure
    {
        Direction direction;

        public Snake (Point tail, int lenght, Direction _direction)
        {
            direction = _direction;
            pList = new List<Point>();
            for(int i = 0; i < lenght; i++)
            {
                Point p = new Point(tail);  // в цикле создаем точки, являющиеся точными копиями хвостовой точки "Point Tail", которы переданы в конструкторе Snake.
                p.Move(i, direction);       // сдвигаем точку на i-позиций, по направлению Direction.
                pList.Add(p);               // добавляем точку в список (новое положение головы).
            }
        }

        internal void Move()
        {
            Point tail = pList.First();     // 
            pList.Remove(tail);
            Point head = GetNextPoint();    // переменная HEAD заполнится значением, которая вернет функцию GetNextPoint
            pList.Add(head);

            tail.Clear();                   // затираем хвостовую точку
            head.Draw();                    // выводим новую головную точку
        }

        public Point GetNextPoint()
        {
            Point head = pList.Last();         // узнаем текущую позицию головы, до того как она переместилась
            Point nextPoint = new Point(head); // создаем новую точку, которая является копией предыдущего положения головы
            nextPoint.Move(1, direction);      // сдвигаем по направлению direction
            return nextPoint;                  // новое положение головы
        }

        internal bool IsHitTail()
        {
            var head = pList.Last();
            for (int i = 0; i < pList.Count - 2; i++)
            {
                if (head.IsHit(pList[i]))
                    return true;
            }
            return false;
        }

        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)                //делаем проверку клавиши
                direction = Direction.LEFT;
            else if (key == ConsoleKey.RightArrow)
                direction = Direction.RIGHT;
            else if (key == ConsoleKey.UpArrow)
                direction = Direction.UP;
            else if (key == ConsoleKey.DownArrow)
                direction = Direction.DOWN;
        }

        internal bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.IsHit(food))                       //если точка головы совпадает с точкой еды, то будет акт питания
            {
                food.sym = head.sym;                    //превращает $ => *
                pList.Add(food);                        //заносит точку
                return true;
            }
            else
                return false;
        }
    }
}
