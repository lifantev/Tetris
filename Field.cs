using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
		static class Field
		{
				private static int _width = 30;
				private static int _height = 20;

				private static bool[][] _heap; 

				public static int Width
				{
						get
						{
								return _width;
						}
						set
						{
								_height = value;
								Console.SetBufferSize(_width, Field.Height);
								Console.SetWindowSize(_width, Field.Height);
						}
				}
				public static int Height
				{
						get
						{
								return _height;
						}
						set
						{
								_height = value;
								Console.SetBufferSize(Field.Width, _height);
								Console.SetWindowSize(Field.Width, _height);
						}
				} 
				
				static Field()
				{
						_heap = new bool[Height][];

						for (int i = 0; i < Height; i++)
						{
								_heap[i] = new bool[Width];
						}
				}

				public static bool CheckStrike(Point p)
				{
						return _heap[p.X][p.Y];
				}

				public static void AddFigure(Figure fig)
				{
						foreach (var p in fig.Points)
						{
								_heap[p.Y][p.X] = true;
						}
				}
		}
}
