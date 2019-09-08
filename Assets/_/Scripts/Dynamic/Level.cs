using UnityEngine;

namespace AwesomeCompany.RollerSplat.Dynamic
{
    public class Level
    {
        public CellType[,] cells { get; }
        
        public Vector2Int spawnPoint { get; }

        public Level(CellType[,] cells, Vector2Int spawnPoint)
        {
            this.cells = cells;
            this.spawnPoint = spawnPoint;
        }
    }
}