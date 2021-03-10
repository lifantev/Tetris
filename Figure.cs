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

				internal void TryMove(Direction dir)
				{
						Hide();

						var clone = Clone();
						Move(clone, dir);

						if (VerifyPosition(clone))
								Points = clone;

						Draw();
				}

				private bool VerifyPosition(Point[] pList)
				{
						foreach (var p in pList)
						{
								if (p.X < 0 || p.Y < 0 || p.X >= Field.Width || p.Y >= Field.Height)
										return false;
						}

						return true;
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

				internal void TryRotate()
				{
						Hide();

						var clone = Clone();
						Rotate(clone);

						if (VerifyPosition(clone))
								Points = clone;

						Draw();
				}
		}
}
