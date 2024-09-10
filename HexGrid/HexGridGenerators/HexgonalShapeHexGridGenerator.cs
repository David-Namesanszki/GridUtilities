using GridUtilities.HexGrid.DataStructs;
using GridUtilities.HexGrid.Services;

namespace GridUtilities.HexGrid.HexGridGenerators;

public class HexgonalShapeHexGridGenerator : IHexGridGenerator
{
    private readonly int N;

    public HexgonalShapeHexGridGenerator(int N)
    {
        this.N = N;
    }

    public ICollection<CubeCoord> GenerateFlatTopGrid()
    {
		ICollection<CubeCoord> grid = new HashSet<CubeCoord>();

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
}
