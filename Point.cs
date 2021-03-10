using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
		public class Point
		{
				public int X { get; set; }
				public int Y { get; set; }
				public char Sym { get; set; }

				public Point()
				{ 
						X = 0; 
						Y = 0;
						Sym = ' ';
				}
				public Point(int x, int y, char sym)
				{
						X = x;
						Y = y;
						Sym = sym;
				}
				public Point(Point p)
				{
						X = p.X;
						Y = p.Y;
						Sym = p.Sym;
				}

				public void Draw()
				{
						Console.SetCursorPosition(X, Y);
						Console.Write(Sym);
						Console.CursorVisible = false;
				}

				public void Hide()
				{
						Console.SetCursorPosition(X, Y);
						Console.Write(' ');
				}

				internal void Move(Direction dir)
				{
						switch (dir)
						{
								case Direction.LEFT:
										X--;
										break;
								case Direction.RIGHT:
										X++;
										break;
								case Direction.DOWN:
										Y++;
										break;
								default:
										break;
						}
				}

		}
}
