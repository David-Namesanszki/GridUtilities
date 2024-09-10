using GridUtilities.HexGrid.DataStructs;

namespace HexGrid;

struct Layout
{
	public Layout(Orientation orientation, Point size, Point origin)
	{
		Orientation = orientation;
		Size = size;
		Origin = origin;
	}

	public Orientation Orientation { get; }
	public Point Size { get; }
	public Point Origin { get; }
	static public Orientation pointy = new Orientation(Math.Sqrt(3.0), Math.Sqrt(3.0) / 2.0, 0.0, 3.0 / 2.0, Math.Sqrt(3.0) / 3.0, -1.0 / 3.0, 0.0, 2.0 / 3.0, 0.5);
	static public Orientation flat = new Orientation(3.0 / 2.0, 0.0, Math.Sqrt(3.0) / 2.0, Math.Sqrt(3.0), 2.0 / 3.0, 0.0, -1.0 / 3.0, Math.Sqrt(3.0) / 3.0, 0.0);

	public Point HexToPixel(CubeCoord h)
	{
		Orientation M = Orientation;
		double x = (M.F0 * h.Q + M.F1 * h.R) * Size.X;
		double y = (M.F2 * h.Q + M.F3 * h.R) * Size.Y;
		return new Point(x + Origin.X, y + Origin.Y);
	}

	public FractionalCubeCoord PixelToHex(Point p)
	{
		Orientation M = Orientation;
		Point pt = new Point((p.X - Origin.X) / Size.X, (p.Y - Origin.Y) / Size.Y);
		double q = M.B0 * pt.X + M.B1 * pt.Y;
		double r = M.B2 * pt.X + M.B3 * pt.Y;
		return new FractionalCubeCoord(q, r, -q - r);
	}

	public Point HexCornerOffset(int corner)
	{
		Orientation M = Orientation;
		double angle = 2.0 * Math.PI * (M.StartAngle - corner) / 6.0;
		return new Point(Size.X * Math.Cos(angle), Size.Y * Math.Sin(angle));
	}

	public List<Point> PolygonCorners(CubeCoord h)
	{
		List<Point> corners = new List<Point> { };
		Point center = HexToPixel(h);
		for (int i = 0; i < 6; i++)
		{
			Point offset = HexCornerOffset(i);
			corners.Add(new Point(center.X + offset.X, center.Y + offset.Y));
		}
		return corners;
	}
}
