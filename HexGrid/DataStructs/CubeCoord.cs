using Cotd_csharp_logic.MapGeneration.Common;
using System.Diagnostics.CodeAnalysis;

namespace GridUtilities.HexGrid.DataStructs;

public struct CubeCoord
{
    public IntVector3 Position { get; set; }

    public CubeCoord(int q, int r, int s)
    {
        Q = q;
        R = r;
        S = s;
        if (Q + R + S != 0) throw new ArgumentException("q + r + s must be 0");
    }

    public CubeCoord(int q, int r)
    {
        Q = q;
        R = r;
        S = -q - r;
        if (Q + R + S != 0) throw new ArgumentException("q + r + s must be 0");
    }

	public int Q { get; }
    public int R { get; }
    public int S { get; }

    public DoubledCoord ToDoubledFlatTop()
    {
		int col = Q;
		int row = 2 * R + Q;
		return new DoubledCoord(col, row);
	}

	public int Length()
	{
		return (int)((Math.Abs(Q) + Math.Abs(R) + Math.Abs(S)) / 2);
	}

	public static CubeCoord Empty
    {
        get { return new CubeCoord(int.MinValue, int.MinValue, int.MinValue); }
    }

    public override string ToString()
    {
        return $"{Q}, {R}, {S}";
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        if (obj is CubeCoord vector)
        {
            return Q == vector.Q && R == vector.R && S == vector.S;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Q, R, S);
    }

    public static bool operator ==(CubeCoord left, CubeCoord right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(CubeCoord left, CubeCoord right)
    {
        return !(left == right);
    }

    public static CubeCoord operator +(CubeCoord left, CubeCoord right)
    {
        return new CubeCoord(left.Q + right.Q, left.R + right.R, left.S + right.S);
    }

    public static CubeCoord operator -(CubeCoord left, CubeCoord right)
    {
        return new CubeCoord(left.Q - right.Q, left.R - right.R, left.S - right.S);
    }

    public static CubeCoord operator *(CubeCoord vector, int scalar)
    {
        return new CubeCoord(vector.Q * scalar, vector.R * scalar, vector.S * scalar);
    }

    public static int operator *(CubeCoord left, CubeCoord right)
    {
        return left.Q * right.Q + left.R * right.R + left.S * right.S;
    }
}
