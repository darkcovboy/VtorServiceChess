using UnityEngine;

namespace PlayerControl
{
    public class BoardRotation : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 1.0f;
        [SerializeField] private float _rightAngle = 90.0f;
        [SerializeField] private float _leftAngle = -90.0f;

        private Vector2 _touchStartPos; 

        private void Update()
        {
            
            if (Input.touchCount == 2)
            {
                Touch touch0 = Input.GetTouch(0);
                Touch touch1 = Input.GetTouch(1);

                if (touch0.phase == TouchPhase.Began && touch1.phase == TouchPhase.Began)
                {
                    _touchStartPos = (touch0.position + touch1.position) / 2.0f; 
                }
                else if (touch0.phase == TouchPhase.Moved && touch1.phase == TouchPhase.Moved)
                {
                    Vector2 touchCurrentPos = (touch0.position + touch1.position) / 2.0f; 
                    float swipeDelta = touchCurrentPos.x - _touchStartPos.x; 

                    float rotationAngle = Mathf.Clamp(swipeDelta * _rotationSpeed, _leftAngle, _rightAngle);

                    transform.Rotate(Vector3.up, rotationAngle, Space.World);

                    _touchStartPos = touchCurrentPos; 
                }
            }
        }

    }
}