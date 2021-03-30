using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
		internal class FigureGenerator
		{
				private int _x;
				private int _y;

				private Random _rand = new Random();

				public FigureGenerator(int x, int y)
				{
						_x = x;
						_y = y;
				}

				public Figure GetNewFigure()
				{
						int randomFigureType = _rand.Next((int)FigureType.LENGTH);

						switch (randomFigureType)
						{
								case (int)FigureType.SQUARE:
										return new Square(_x, _y);
								case (int)FigureType.STICK:
										return new Stick(_x, _y);
						}

						return default;
				}

		}
}
