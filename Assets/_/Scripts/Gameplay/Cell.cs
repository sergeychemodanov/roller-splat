using AwesomeCompany.RollerSplat.Dynamic;
using UnityEngine;

namespace AwesomeCompany.RollerSplat.Gameplay
{
    public class Cell : MonoBehaviour
    {
        public Vector2Int index { get; protected set; }

        public CellType type { get; private set; }

        public bool isCompleted { get; private set; }

        [SerializeField] private Material _completedMaterial;

        [SerializeField] private MeshRenderer _meshRenderer;
        
        
        public void Initialize(Vector2Int index, CellType type)
        {
            this.index = index;
            this.type = type;
            transform.position = new Vector3(index.x, 0f, index.y);
        }

        public void Complete()
        {
            if (isCompleted)
                return;

            isCompleted = true;

            if (_meshRenderer == null || _completedMaterial == null)
                return;

            _meshRenderer.material = _completedMaterial;
        }
    }
}