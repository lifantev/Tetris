using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
		internal class FigureGenerator
		{
				private int _x;
				private int _y;
				private char _sym;

				private Random _rand = new Random();

				public FigureGenerator(int x, int y, char sym)
				{
						_x = x;
						_y = y;
						_sym = sym;
				}

				public Figure GetNewFigure()
				{
						int randomFigureType = _rand.Next((int)FigureType.LENGTH);

						switch (randomFigureType)
						{
								case (int)FigureType.SQUARE:
										return new Square(_x, _y, _sym);
								case (int)FigureType.STICK:
										return new Stick(_x, _y, _sym);
								default:
										return default;
						}

				}

		}
}
