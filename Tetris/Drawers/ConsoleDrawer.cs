﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
		class ConsoleDrawer : IDrawer
		{
				public void DrawPoint(int x, int y)
				{
						Console.SetCursorPosition(x, y);
						Console.Write('*');
						Console.SetCursorPosition(0, 0);
				}

				public void HidePoint(int x, int y)
				{
						Console.SetCursorPosition(x, y);
						Console.Write(' ');
						Console.SetCursorPosition(0, 0);
				}

				public void GameOver()
				{
						Console.SetCursorPosition(Field.Width / 2, Field.Height / 2);
						Console.WriteLine("GAME OVER");
				}

				public void InitField()
				{
						Console.SetWindowSize(Field.Width, Field.Height);
						Console.SetBufferSize(Field.Width, Field.Height);
				}
		}
}
