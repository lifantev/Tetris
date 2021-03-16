using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
		public static class Drawer
		{
				public const char DEF_SYMBOL = '*';
				
				public static void DrawPoint(int i, int j, char c = DEF_SYMBOL)
				{
						Console.SetCursorPosition(i, j);
						Console.Write(c);
						Console.CursorVisible = false;
				}

				public static void HidePoint(int i, int j)
				{
						DrawPoint(i, j, ' ');
				}
		}
}