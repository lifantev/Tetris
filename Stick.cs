using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
		public class Stick : Figure
		{
				public Stick(int x, int y, char sym)
				{
						points[0] = new Point(x, y, sym);
						points[1] = new Point(x, y + 1, sym);
						points[2] = new Point(x, y + 2, sym);
						points[3] = new Point(x, y + 3, sym);
				}

				public override void Rotate()
				{
						if (points[0].X == points[1].X)
						{
								RotateHorizontal();
						}
						else
						{
								RotateVertical();
						}

				}

				private void RotateVertical()
				{
						for (int i = 0; i < points.Length; i++)
						{
								points[i].X = points[0].X;
								points[i].Y = points[i].Y + i;
						}
				}

				private void RotateHorizontal()
				{
						for (int i = 0; i < points.Length; i++)
						{
								points[i].Y = points[0].Y;
								points[i].X = points[i].X + i;
						}
				}
		}
}
