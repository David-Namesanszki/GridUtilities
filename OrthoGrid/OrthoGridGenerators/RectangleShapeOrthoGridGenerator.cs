using GridUtilities.OrthoGrid.DataStructs;
using GridUtilities.OrthoGrid.Services;

namespace GridUtilities.OrthoGrid.OrthoGridGenerators
{
	public class RectangleShapeOrthoGridGenerator : IOrthoGridGenerator
	{
		private readonly int height, width;

		public RectangleShapeOrthoGridGenerator(int height, int width)
		{
			this.height = height;
			this.width = width;
		}

		public ICollection<CartesianCoord> GenerateGrid()
		{
			ICollection<CartesianCoord> grid = new HashSet<CartesianCoord>();

			for (int h = 0; h < height; h++)
			{
				for (int w = 0; w < width; w++)
				{
					grid.Add(new CartesianCoord(h, w));
				}
			}

			return grid;
		}
	}
}
