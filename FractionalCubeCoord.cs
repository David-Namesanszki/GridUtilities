using GridUtilities.HexGrid.DataStructs;

namespace HexGrid;

public struct FractionalCubeCoord
{
	public FractionalCubeCoord(double q, double r, double s)
	{
		Q = q;
		R = r;
		S = s;
		if (Math.Round(q + r + s) != 0) throw new ArgumentException("q + r + s must be 0");
	}

    public double Q { get; }
    public double R { get; }
    public double S { get; }

	public CubeCoord HexRound()
	{
		int qi = (int)(Math.Round(Q));
		int ri = (int)(Math.Round(R));
		int si = (int)(Math.Round(S));
		double q_diff = Math.Abs(qi - Q);
		double r_diff = Math.Abs(ri - R);
		double s_diff = Math.Abs(si - S);
		if (q_diff > r_diff && q_diff > s_diff)
		{
			qi = -ri - si;
		}
		else
			if (r_diff > s_diff)
		{
			ri = -qi - si;
		}
		else
		{
			si = -qi - ri;
		}
		return new CubeCoord(qi, ri, si);
	}


	public FractionalCubeCoord HexLerp(FractionalCubeCoord b, double t)
	{
		return new FractionalCubeCoord(Q * (1.0 - t) + b.Q * t, R * (1.0 - t) + b.R * t, S * (1.0 - t) + b.S * t);
	}


	static public List<CubeCoord> HexLinedraw(CubeCoord a, CubeCoord b)
	{
		int N = a.Distance(b);
		FractionalCubeCoord a_nudge = new FractionalCubeCoord(a.Q + 1e-06, a.R + 1e-06, a.S - 2e-06);
		FractionalCubeCoord b_nudge = new FractionalCubeCoord(b.Q + 1e-06, b.R + 1e-06, b.S - 2e-06);
		List<CubeCoord> results = new List<CubeCoord> { };
		double step = 1.0 / Math.Max(N, 1);
		for (int i = 0; i <= N; i++)
		{
			results.Add(a_nudge.HexLerp(b_nudge, step * i).HexRound());
		}
		return results;
	}

}
