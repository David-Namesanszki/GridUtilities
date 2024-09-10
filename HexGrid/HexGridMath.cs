using GridUtilities.HexGrid.DataStructs;
using HexGrid;

namespace GridUtilities.HexGrid;

public static class HexGridMath
{
	static public List<CubeCoord> Directions = new List<CubeCoord> { new CubeCoord(1, 0, -1), new CubeCoord(1, -1, 0), new CubeCoord(0, -1, 1), new CubeCoord(-1, 0, 1), new CubeCoord(-1, 1, 0), new CubeCoord(0, 1, -1) };

	static public CubeCoord Direction(int direction)
	{
		return Directions[direction];
	}

	public static FractionalCubeCoord CubeLerp(FractionalCubeCoord a, FractionalCubeCoord b, double t)
	{
		return new FractionalCubeCoord(a.Q * (1.0 - t) + b.Q * t, a.R * (1.0 - t) + b.R * t, a.S * (1.0 - t) + b.S * t);
	}

	public static int Distance(CubeCoord a, CubeCoord b)
	{
		return (a - b).Length();
	}

	public static List<CubeCoord> HexLinedraw(CubeCoord a, CubeCoord b)
	{
		int N = Distance(a, b);
		FractionalCubeCoord a_nudge = new FractionalCubeCoord(a.Q + 1e-06, a.R + 1e-06, a.S - 2e-06);
		FractionalCubeCoord b_nudge = new FractionalCubeCoord(b.Q + 1e-06, b.R + 1e-06, b.S - 2e-06);
		List<CubeCoord> results = new List<CubeCoord> { };
		double step = 1.0 / Math.Max(N, 1);
		for (int i = 0; i <= N; i++)
		{
			results.Add(CubeLerp(a_nudge, b_nudge, step * i).HexRound());
		}
		return results;
	}
}
