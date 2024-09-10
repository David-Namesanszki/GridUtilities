namespace GridUtilities.HexGrid.DataStructs;

struct OffsetCoord
{
    public OffsetCoord(int col, int row)
    {
        this.col = col;
        this.row = row;
    }
    public readonly int col;
    public readonly int row;
    static public int EVEN = 1;
    static public int ODD = -1;

    static public OffsetCoord QoffsetFromCube(int offset, CubeCoord h)
    {
        int col = h.Q;
        int row = h.R + (h.Q + offset * (h.Q & 1)) / 2;
        if (offset != EVEN && offset != ODD)
        {
            throw new ArgumentException("offset must be EVEN (+1) or ODD (-1)");
        }
        return new OffsetCoord(col, row);
    }


    static public CubeCoord QoffsetToCube(int offset, OffsetCoord h)
    {
        int q = h.col;
        int r = h.row - (h.col + offset * (h.col & 1)) / 2;
        int s = -q - r;
        if (offset != EVEN && offset != ODD)
        {
            throw new ArgumentException("offset must be EVEN (+1) or ODD (-1)");
        }
        return new CubeCoord(q, r, s);
    }


    static public OffsetCoord RoffsetFromCube(int offset, CubeCoord h)
    {
        int col = h.Q + (h.R + offset * (h.R & 1)) / 2;
        int row = h.R;
        if (offset != EVEN && offset != ODD)
        {
            throw new ArgumentException("offset must be EVEN (+1) or ODD (-1)");
        }
        return new OffsetCoord(col, row);
    }


    static public CubeCoord RoffsetToCube(int offset, OffsetCoord h)
    {
        int q = h.col - (h.row + offset * (h.row & 1)) / 2;
        int r = h.row;
        int s = -q - r;
        if (offset != EVEN && offset != ODD)
        {
            throw new ArgumentException("offset must be EVEN (+1) or ODD (-1)");
        }
        return new CubeCoord(q, r, s);
    }

}
