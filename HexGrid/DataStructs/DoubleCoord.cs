using System.Diagnostics.CodeAnalysis;

namespace GridUtilities.HexGrid.DataStructs;

public struct DoubledCoord
{
    public DoubledCoord(int col, int row)
    {
        Col = col;
        Row = row;
    }
    public int Col { get; }
    public int Row { get; }

	public static DoubledCoord Empty
	{
		get { return new DoubledCoord(int.MinValue, int.MinValue); }
	}

	public CubeCoord ToCubeFlatTop()
    {
        int q = Col;
        int r = (Row - Col) / 2;
        int s = -q - r;
        return new CubeCoord(q, r, s);
    }

	public int Length()
	{
		return ToCubeFlatTop().Length();
	}

	public override string ToString()
	{
		return $"{Col}, {Row}";
	}

	public override bool Equals([NotNullWhen(true)] object? obj)
	{
		if (obj is DoubledCoord vector)
		{
			return Col == vector.Col && Row == vector.Row;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(Col, Row);
	}

	public static bool operator ==(DoubledCoord left, DoubledCoord right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(DoubledCoord left, DoubledCoord right)
	{
		return !(left == right);
	}

	public static DoubledCoord operator +(DoubledCoord left, DoubledCoord right)
	{
		return new DoubledCoord(left.Col + right.Col, left.Row + right.Row);
	}

	public static DoubledCoord operator -(DoubledCoord left, DoubledCoord right)
	{
		return new DoubledCoord(left.Col - right.Col, left.Row - right.Row);
	}

	public static DoubledCoord operator *(DoubledCoord vector, int scalar)
	{
		return new DoubledCoord(vector.Col * scalar, vector.Row * scalar);
	}

	public static int operator *(DoubledCoord left, DoubledCoord right)
	{
		return left.Col * right.Col + left.Row * right.Row;
	}
}
