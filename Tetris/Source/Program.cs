using System;
using System.Threading;
using System.Timers;
using Microsoft.SmallBasic.Library;

namespace Tetris
{
		class Program
		{
				static FigureGenerator generator;
				static Figure currentFigure;

				const int TIMER_INTERVAL = 500;
				static System.Timers.Timer timer;
				static private Object _lockObject = new object();

				static bool gameOver = false;

				static void Main(string[] args)
				{
						DrawerProvider.Drawer.InitField();
						SetTimer();

						generator = new FigureGenerator(Field.Width / 2, 0);
						currentFigure = generator.GetNewFigure();
						GraphicsWindow.KeyDown += GraphicsWindow_KeyDown;

				}

				private static void GraphicsWindow_KeyDown()
				{
						Monitor.Enter(_lockObject);
						var res = HandleKey(currentFigure, GraphicsWindow.LastKey);

						if (GraphicsWindow.LastKey == "Down")
								gameOver = ProcessResult(res, ref currentFigure);

						Monitor.Exit(_lockObject);
				}

				private static void SetTimer()
				{
						timer = new System.Timers.Timer(TIMER_INTERVAL);
						timer.Elapsed += OnTimedEvent;
						timer.AutoReset = true;
						timer.Enabled = true;
				}

				private static void OnTimedEvent(object sender, ElapsedEventArgs e)
				{
						Monitor.Enter(_lockObject);

						var result = currentFigure.TryMove(Direction.DOWN);
						gameOver = ProcessResult(result, ref currentFigure);

						if (gameOver)
								timer.Stop();

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
										DrawerProvider.Drawer.GameOver();
										timer.Elapsed -= OnTimedEvent;
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

				private static Result HandleKey(Figure currentFigure, String lastKey)
				{
						switch (lastKey.ToString())
						{
								case "Left":
										return currentFigure.TryMove(Direction.LEFT);
								case "Right":
										return currentFigure.TryMove(Direction.RIGHT);
								case "Down":
										return currentFigure.TryMove(Direction.DOWN);
								case "Up":
										return currentFigure.TryMove(Direction.UP);
								case "Space":
										return currentFigure.TryRotate();
						}

						return Result.SUCCESS;
				}
		}
}
