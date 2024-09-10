using System.Diagnostics.CodeAnalysis;

namespace GridUtilities.OrthoGrid.DataStructs;

public struct CartesianCoord
{
	public int X { get; }
	public int Y { get; }

	public CartesianCoord(int x, int y)
	{
		X = x;
		Y = y;
	}

	public int Length()
	{
		return (int)Math.Sqrt(X * X + Y * Y);
	}

	public static CartesianCoord Empty
	{
		get { return new CartesianCoord(int.MinValue, int.MinValue); }
	}

	public override string ToString()
	{
		return $"{X}, {Y}";
	}

	public override bool Equals([NotNullWhen(true)] object? obj)
	{
		if (obj is CartesianCoord vector)
		{
			return X == vector.X && Y == vector.Y;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(X, Y);
	}

	public static bool operator ==(CartesianCoord left, CartesianCoord right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(CartesianCoord left, CartesianCoord right)
	{
		return !(left == right);
	}

	public static CartesianCoord operator +(CartesianCoord left, CartesianCoord right)
	{
		return new CartesianCoord(left.X + right.X, left.Y + right.Y);
	}

	public static CartesianCoord operator -(CartesianCoord left, CartesianCoord right)
	{
		return new CartesianCoord(left.X - right.X, left.Y - right.Y);
	}

	public static CartesianCoord operator *(CartesianCoord vector, int scalar)
	{
		return new CartesianCoord(vector.X * scalar, vector.Y * scalar);
	}

	public static int operator *(CartesianCoord left, CartesianCoord right)
	{
		return left.X * right.X + left.Y * right.Y;
	}
}
