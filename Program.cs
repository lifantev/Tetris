using System;

namespace Tetris
{
		class Program
		{
				static FigureGenerator generator;

				static void Main(string[] args)
				{
						Console.SetWindowSize(Field.Width, Field.Height);
						Console.SetBufferSize(Field.Width, Field.Height);

						generator = new FigureGenerator(15, 0, Drawer.DEF_SYMBOL);
						Figure currentFigure = generator.GetNewFigure();

						while (true)
						{
								if (Console.KeyAvailable)
								{
										var key = Console.ReadKey();
										var result = HandleKey(currentFigure, key);
										ProcessResult(result, ref currentFigure);
								}
						}
				}

				private static bool ProcessResult(Result result, ref Figure currentFigure)
				{
						if (result == Result.HEAP_STRIKE || result == Result.DOWN_BORDER_STRIKE)
						{
								Field.AddFigure(currentFigure);
								Field.TryDeleteLines();
								currentFigure = generator.GetNewFigure();
								return true;
						}
						else
								return false;
				}

				private static Result HandleKey(Figure currentFigure, ConsoleKeyInfo key)
				{
						switch (key.Key)
						{
								case ConsoleKey.RightArrow:
										return currentFigure.TryMove(Direction.RIGHT);
								case ConsoleKey.LeftArrow:
										return currentFigure.TryMove(Direction.LEFT);
								case ConsoleKey.DownArrow:
										return currentFigure.TryMove(Direction.DOWN);
								case ConsoleKey.Spacebar:
										return currentFigure.TryRotate();
								default:
										return Result.SUCCESS;
						}
				}
		}
}
