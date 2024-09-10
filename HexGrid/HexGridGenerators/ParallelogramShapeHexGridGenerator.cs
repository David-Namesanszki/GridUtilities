using GridUtilities.HexGrid.DataStructs;
using GridUtilities.HexGrid.Services;

namespace GridUtilities.HexGrid.HexGridGenerators;

public class ParallelogramShapeHexGridGenerator : IHexGridGenerator
{
    private readonly int r1, r2, s1, s2;

    public ParallelogramShapeHexGridGenerator(int r1, int r2, int s1, int s2)
    {
        this.r1 = r1;
        this.r2 = r2;
        this.s1 = s1;
        this.s2 = s2;
    }

    public ICollection<CubeCoord> GenerateFlatTopGrid()
    {
		ICollection<CubeCoord> grid = new HashSet<CubeCoord>();

        for (var r = r1; r < r2; r++)
        {
            for (var s = s1; s < s2; s++)
            {
                grid.Add(new CubeCoord(-r - s, r, s));
            }
        }

        return grid;
    }
}
