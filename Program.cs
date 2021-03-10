using System;

namespace Tetris
{
		class Program
		{
				static void Main(string[] args)
				{
						Console.SetWindowSize(Field.WIDHT, Field.HEIGHT);
						Console.SetBufferSize(Field.WIDHT, Field.HEIGHT);
						Console.SetWindowSize(Field.WIDHT, Field.HEIGHT);

						FigureGenerator generator = new FigureGenerator(15, 0, '*');
						Figure currentFigure = generator.GetNewFigure();

						while (true)
						{
								if (Console.KeyAvailable)
								{
										var key = Console.ReadKey();
										HandleKey(currentFigure, key);
								}
						}
				}

				private static void HandleKey(Figure currentFigure, ConsoleKeyInfo key)
				{
						switch (key.Key)
						{
								case ConsoleKey.RightArrow:
										currentFigure.TryMove(Direction.RIGHT);
										break;
								case ConsoleKey.LeftArrow:
										currentFigure.TryMove(Direction.LEFT);
										break;
								case ConsoleKey.DownArrow:
										currentFigure.TryMove(Direction.DOWN);
										break;
								case ConsoleKey.Spacebar:
										currentFigure.TryRotate();
										break;
								default:
										break;
						}
				}
		}
}
