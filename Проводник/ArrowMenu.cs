using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Проводник
{
    internal class ArrowMenu
    {
        public int currentPosition;
        public int min;
        public int max;
        public ArrowMenu(int min, int max)
        {
            this.min = min;
            this.max = max;

            this.currentPosition = min;
        }

        public void DrawArrow(int position)
        {
            Console.SetCursorPosition(0, position);
            Console.WriteLine("->");

            //ClearArrow();
        }
        public void ClearArrow(int position)
        {
            Console.SetCursorPosition(0, position);
            Console.WriteLine("  ");
        }
        public int UserChoice()
        {
            while (true)
            {
                this.DrawArrow(this.currentPosition);
                // diskMenu.DrawArrow(position);

                ConsoleKeyInfo InputKey = Console.ReadKey();

                switch (InputKey.Key)
                {
                    case (ConsoleKey.UpArrow):
                        if (this.currentPosition != this.min)
                        {
                            // diskMenu.ClearArrow(position);
                            this.ClearArrow(this.currentPosition);
                            //position--;
                            this.currentPosition--;
                        }
                        break;
                    case (ConsoleKey.DownArrow):
                        if (this.currentPosition != this.max)
                        {
                            //  diskMenu.ClearArrow(position);
                            this.ClearArrow(this.currentPosition);
                            //  position++;
                            this.currentPosition++;
                        }
                        break;
                    case (ConsoleKey.Enter):

                        return this.currentPosition;

                        break;
                    case (ConsoleKey.Escape):
                        Explorer.ShowDisks();
                        break;
                    default:
                        break;
                }

            }
        }
        public bool IsEmptyMenu()
        {
            if (this.min == this.max)
            {
                return true;
            }
            return false;
        }
    }
}
