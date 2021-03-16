using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
		public abstract class Figure
		{
				const int POINT_NUMBER = 4;
				public Point[] Points = new Point[POINT_NUMBER];

				public void Draw()
				{
						foreach (Point p in Points)
						{
								p.Draw();
						}
				}

				public void Move(Point[] pList, Direction dir)
				{
						foreach (var p in pList)
						{
								p.Move(dir);
						}
				}

				internal Result TryMove(Direction dir)
				{
						Hide();

						var clone = Clone();
						Move(clone, dir);

						var result = VerifyPosition(clone);
						if (result == Result.SUCCESS)
								Points = clone;

						Draw();

						return result;
				}

				private Result VerifyPosition(Point[] pList)
				{
						foreach (var p in pList)
						{
								if (p.Y >= Field.Height)
										return Result.DOWN_BORDER_STRIKE;

								if (p.X >= Field.Width || p.X < 0 || p.Y < 0)
										return Result.BORDER_STRIKE;

								if (Field.CheckStrike(p))
										return Result.HEAP_STRIKE;
						}

						return Result.SUCCESS;
				}

				private Point[] Clone()
				{
						var newPoints = new Point[POINT_NUMBER];
						for (int i = 0; i < POINT_NUMBER; i++)
						{
								newPoints[i] = new Point(Points[i]);
						}

						return newPoints;
				}


				internal void Hide()
				{
						foreach (Point p in Points)
						{
								p.Hide();
						}
				}

				public abstract void Rotate(Point[] pList);

				internal Result TryRotate()
				{
						Hide();

						var clone = Clone();
						Rotate(clone);

						var result = VerifyPosition(clone);
						if (result == Result.SUCCESS)
								Points = clone;

						Draw();

						return result;
				}
		}
}
