﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
		public abstract class Figure
		{
				protected Point[] points = new Point[4];

				public void Draw()
				{
						foreach (Point p in points)
						{
								p.Draw();
						}
				}

				public void Move(Direction dir)
				{
						foreach (Point p in points)
						{
								p.Move(dir);
						}
				}

				internal void Hide()
				{
						foreach (Point p in points)
						{
								p.Hide();
						}
				}

				public abstract void Rotate();
		}
}
