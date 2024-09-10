using GridUtilities.HexGrid.DataStructs;

namespace GridUtilities.HexGrid.Services
{
	public interface IHexGridGenerator
	{
		ICollection<CubeCoord> GenerateFlatTopGrid();
	}
}