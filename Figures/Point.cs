using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
		public class Point
		{
				public int X { get; set; }
				public int Y { get; set; }

				public Point(int x, int y)
				{
						X = x;
						Y = y;
				}
				public Point(Point p)
				{
						X = p.X;
						Y = p.Y;
				}

				public void Draw()
				{
						DrawerProvider.Drawer.DrawPoint(X, Y);
				}

				public void Hide()
				{
						DrawerProvider.Drawer.HidePoint(X, Y);
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
								case Direction.UP:
										Y--;
										break;
						}
				}

		}
}
