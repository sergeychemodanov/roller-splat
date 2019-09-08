using AwesomeCompany.RollerSplat.Dynamic;
using UnityEngine;

namespace AwesomeCompany.RollerSplat.Gameplay
{
    public class GameController : MonoBehaviour
    {
        public void Play(Level level)
        {
            var xLength = level.cells.GetLength(0);
            var zLength = level.cells.GetLength(1);
            
            for (var x = 0; x < xLength; x++)
            {
                for (var z = 0; z < zLength; z++)
                {
                    var cellType = level.cells[x, z];
                    var index = new Vector2Int(x, z);
                    LevelFactory.CreateCell(cellType, index);
                }
            }
            
            LevelFactory.CreateBall(level.spawnPoint);
        }
    }
}