using GridUtilities.OrthoGrid.DataStructs;

namespace GridUtilities.OrthoGrid.Services;

public interface IOrthoGridGenerator
{
	ICollection<CartesianCoord> GenerateGrid();
}
