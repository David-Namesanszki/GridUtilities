using System.Collections.Generic;
using GridUtilities.HexGrid.DataStructs;

namespace HexGrid;

public static class Grid
{
	public static IList<CubeCoord> CreateParalelogramShapeGrid(int r1, int r2, int s1, int s2)
	{
		IList<CubeCoord> grid = new List<CubeCoord>();

		for (var r = r1; r < r2; r++)
		{
			for (var s = s1; s < s2; s++)
			{
				grid.Add(new CubeCoord(-r - s, r, s));
			}
		}

		return grid;
	}

	public static IList<CubeCoord> CreateHexagonShapeGrid(int N)
	{
		IList<CubeCoord> grid = new List<CubeCoord>();

		for (int q = -N; q <= N; q++)
		{
			int r1 = Math.Max(-N, -q - N);
			int r2 = Math.Min(N, -q + N);
			for (int r = r1; r <= r2; r++)
			{
				grid.Add(new CubeCoord(q, r, -q - r));
			}
		}

		return grid;
	}

	public static IList<CubeCoord> CreateRectengleShapeGrid(int left, int right, int top, int bottom)
	{
		IList<CubeCoord> grid = new List<CubeCoord>();

		for(int q = left; q <= right; q++)
		{
			int qOffest = (int)Math.Floor(q / 2.0);

			for (int r = top - qOffest; r <= bottom - qOffest; r++)
			{
				grid.Add(new CubeCoord(q, r, -q - r));
			}
		}
		return grid;
	}
}
