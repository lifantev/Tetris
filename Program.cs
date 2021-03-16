using System;
using System.Threading;
using System.Timers;

namespace Tetris
{
		class Program
		{
				static FigureGenerator generator;
				static Figure currentFigure;

				const int TIMER_INTERVAL = 500;
				static System.Timers.Timer timer;
				static private Object _lockObject = new object();

				static void Main(string[] args)
				{
						Console.SetWindowSize(Field.Width, Field.Height);
						Console.SetBufferSize(Field.Width, Field.Height);

						generator = new FigureGenerator(15, 0, Drawer.DEF_SYMBOL);
						currentFigure = generator.GetNewFigure();
						SetTimer();

						while (true)
						{
								if (Console.KeyAvailable)
								{
										var key = Console.ReadKey();
										Monitor.Enter(_lockObject);

										var result = HandleKey(currentFigure, key);
										ProcessResult(result, ref currentFigure);

										Monitor.Exit(_lockObject);
								}
						}
				}

				private static void SetTimer()
				{
						timer = new System.Timers.Timer(TIMER_INTERVAL);
						timer.Elapsed += OnTimeEvent;
						timer.AutoReset = true;
						timer.Enabled = true;
				}

				private static void OnTimeEvent(object sender, ElapsedEventArgs e)
				{
						Monitor.Enter(_lockObject);

						var res = currentFigure.TryMove(Direction.DOWN);
						ProcessResult(res, ref currentFigure);

						Monitor.Exit(_lockObject);
				}

				private static bool ProcessResult(Result result, ref Figure currentFigure)
				{
						if (result == Result.HEAP_STRIKE || result == Result.DOWN_BORDER_STRIKE)
						{
								Field.AddFigure(currentFigure);
								Field.TryDeleteLines();

								if (currentFigure.IsOnTop())
								{
										GameOver();
										timer.Elapsed -= OnTimeEvent; 
										return true;
								}
								else
								{
										currentFigure = generator.GetNewFigure();
										return false;
								}
						}
						else
								return false;
				}

				private static void GameOver()
				{
						Console.SetCursorPosition(Field.Width / 2 - 8, Field.Height);
						Console.WriteLine("GAME OVER");
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
