using System.Diagnostics.CodeAnalysis;

namespace Cotd_csharp_logic.MapGeneration.Common;

public struct IntVector3
{
	public int X { get; }
	public int Y { get; }
	public int Z { get; }

	public IntVector3(int x, int y, int z)
	{
		X = x;
		Y = y;
		Z = z;
	}

	public static IntVector3 Empty
	{
		get { return new IntVector3(int.MinValue, int.MinValue, int.MinValue); }
	}

	public override string ToString()
	{
		return $"{X}, {Y}, {Z}";
	}

	public override bool Equals([NotNullWhen(true)] object? obj)
	{
		if (obj is IntVector3 vector)
		{
			return X == vector.X && Y == vector.Y && Z == vector.Z;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(X, Y, Z);
	}

	public static bool operator ==(IntVector3 left, IntVector3 right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(IntVector3 left, IntVector3 right)
	{
		return !(left == right);
	}

	public static IntVector3 operator +(IntVector3 left, IntVector3 right)
	{
		return new IntVector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
	}

	public static IntVector3 operator -(IntVector3 left, IntVector3 right)
	{
		return new IntVector3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
	}

	public static IntVector3 operator *(IntVector3 vector, int scalar)
	{
		return new IntVector3(vector.X * scalar, vector.Y * scalar, vector.Z * scalar);
	}

	public static int operator *(IntVector3 left, IntVector3 right)
	{
		return left.X * right.X + left.Y * right.Y + left.Z * right.Z;
	}
}
