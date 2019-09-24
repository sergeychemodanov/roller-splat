using System;
using UnityEngine;

namespace AwesomeCompany.Common.Input
{
    public class SwipeDetector : MonoBehaviour
    {
        public event Action<Direction> onSwipe;

        private bool _isStarted;

        private Vector2 _startPosition;

        private void Update()
        {
#if UNITY_EDITOR
            CheckKeyboard();
#else
            CheckTouches();
#endif
        }

        private void CheckKeyboard()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.UpArrow))
            {
                onSwipe?.Invoke(Direction.Up);
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.RightArrow))
            {
                onSwipe?.Invoke(Direction.Right);
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.DownArrow))
            {
                onSwipe?.Invoke(Direction.Down);
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow))
            {
                onSwipe?.Invoke(Direction.Left);
            }
        }

        private void CheckTouches()
        {
            if (UnityEngine.Input.touchCount <= 0)
                return;
            
            var touch = UnityEngine.Input.GetTouch(0);
                
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _isStarted = true;
                    _startPosition = touch.position;
                    break;
                case TouchPhase.Moved:
                    if (!_isStarted)
                        return;
                    
                    var direction = (touch.position - _startPosition).normalized;
                    
                    if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x))
                    {
                        if (direction.y > 0)
                        {
                            onSwipe?.Invoke(Direction.Up);
                            _isStarted = false;
                        } 
                        else if (direction.y < 0) 
                        {
                            onSwipe?.Invoke(Direction.Down);
                            _isStarted = false;
                        }
                    }
                    else
                    {
                        if (direction.x > 0)
                        {
                            onSwipe?.Invoke(Direction.Right);
                            _isStarted = false;
                        }
                        else if (direction.x < 0)
                        {
                            onSwipe?.Invoke(Direction.Left);
                            _isStarted = false;
                        }
                    }
                    break;
            }
        }
    }
}