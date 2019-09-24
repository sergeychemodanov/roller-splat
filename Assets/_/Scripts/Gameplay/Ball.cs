using System;
using System.Linq;
using AwesomeCompany.Common.Input;
using UnityEngine;

namespace AwesomeCompany.RollerSplat.Gameplay
{
    public class Ball : MonoBehaviour
    {
        public event Action onMoved;

        private SwipeDetector _swipeDetector;

        private Vector2Int _currentPosition;


        public void Teleport(Vector2Int currentPosition)
        {
            _currentPosition = currentPosition;
            transform.position = new Vector3(_currentPosition.x, 0f, _currentPosition.y);
        }

        public void Activate()
        {
            _swipeDetector.onSwipe += OnSwipe;
        }

        public void Deactivate()
        {
            _swipeDetector.onSwipe -= OnSwipe;
        }


        private void Awake()
        {
            _swipeDetector = gameObject.AddComponent<SwipeDetector>();
        }

        private void OnSwipe(Direction direction)
        {
            var path = App.instance.gameController.GetCellsPath(_currentPosition, direction);
            if (path.Count <= 0)
                return;

            foreach (var cell in path)
                cell.Complete();

            Teleport(path.Last().index);
            onMoved?.Invoke();
        }
    }
}