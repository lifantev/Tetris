using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
		public class Stick : Figure
		{
				public Stick(int x, int y)
				{
						Points[0] = new Point(x, y);
						Points[1] = new Point(x, y + 1);
						Points[2] = new Point(x, y + 2);
						Points[3] = new Point(x, y + 3);

						Draw();
				}

				public override void Rotate()
				{
						if (Points[0].X == Points[1].X)
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
						for (int i = 0; i < Points.Length; i++)
						{
								Points[i].X = Points[0].X;
								Points[i].Y = Points[i].Y + i;
						}
				}

				private void RotateHorizontal()
				{
						for (int i = 0; i < Points.Length; i++)
						{
								Points[i].Y = Points[0].Y;
								Points[i].X = Points[i].X + i;
						}
				}
		}
}
