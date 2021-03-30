using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SmallBasic.Library;

namespace Tetris
{
		class GuiDrawer : IDrawer
		{
				public const int SIZE = 20;

				public void DrawPoint(int x, int y)
				{
						GraphicsWindow.PenColor = "Black";
						GraphicsWindow.PenWidth = 2;
						GraphicsWindow.DrawRectangle(x*SIZE, y*SIZE, SIZE, SIZE);
				}

				public void GameOver()
				{
						GraphicsWindow.PenColor = "Red";
						GraphicsWindow.FontSize = 16;
						GraphicsWindow.DrawText(0, 0, "Game Over!");
				}

				public void HidePoint(int x, int y)
				{
						GraphicsWindow.PenColor = GraphicsWindow.BackgroundColor;
						GraphicsWindow.PenWidth = 3;
						GraphicsWindow.DrawRectangle(x * SIZE, y * SIZE, SIZE, SIZE);
				}

				public void InitField()
				{
						GraphicsWindow.BackgroundColor = "White";
						GraphicsWindow.Width = Field.Width * SIZE;
						GraphicsWindow.Height = Field.Height * SIZE;
				}
		}
}
