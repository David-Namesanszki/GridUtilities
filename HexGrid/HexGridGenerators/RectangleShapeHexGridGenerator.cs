using GridUtilities.HexGrid.DataStructs;
using GridUtilities.HexGrid.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridUtilities.HexGrid.HexGridGenerators;

public class RectangleShapeHexGridGenerator : IHexGridGenerator
{
    private readonly int left, right, top, bottom;

    public RectangleShapeHexGridGenerator(int left, int right, int top, int bottom)
    {
        this.left = left;
        this.right = right;
        this.top = top;
        this.bottom = bottom;
    }

    public ICollection<CubeCoord> GenerateFlatTopGrid()
    {
		ICollection<CubeCoord> grid = new HashSet<CubeCoord>();

        for (int q = left; q <= right; q++)
        {
            int qOffest = (int)Math.Floor(q / 2.0);

            for (int r = top - qOffest; r <= bottom - qOffest; r++)
            {
                grid.Add(new CubeCoord(q, r, -q - r));
            }
        }
        return grid;
    }
}
