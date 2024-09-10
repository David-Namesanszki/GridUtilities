using System.Diagnostics.CodeAnalysis;

namespace GridUtilities.Common;

public struct IntVector2
{
    public int X { get; }
    public int Y { get; }

    public IntVector2(int x, int y)
    {
        X = x;
        Y = y;
    }
    public static IntVector2 Empty
    {
        get { return new IntVector2(int.MinValue, int.MinValue); }
    }

	

	public override string ToString()
    {
        return $"{X}, {Y}";
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        if (obj is IntVector2 vector)
        {
            return X == vector.X && Y == vector.Y;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public static bool operator ==(IntVector2 left, IntVector2 right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(IntVector2 left, IntVector2 right)
    {
        return !(left == right);
    }

    public static IntVector2 operator +(IntVector2 left, IntVector2 right)
    {
        return new IntVector2(left.X + right.X, left.Y + right.Y);
    }

    public static IntVector2 operator -(IntVector2 left, IntVector2 right)
    {
        return new IntVector2(left.X - right.X, left.Y - right.Y);
    }

    public static IntVector2 operator *(IntVector2 vector, int scalar)
    {
        return new IntVector2(vector.X * scalar, vector.Y * scalar);
    }

    public static int operator *(IntVector2 left, IntVector2 right)
    {
        return left.X * right.X + left.Y * right.Y;
    }
}
