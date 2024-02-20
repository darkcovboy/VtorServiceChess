using UnityEngine;

namespace PlayerControl
{
    public class CameraZoom : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private float zoomSpeed = 0.5f; // Скорость изменения масштаба
        [SerializeField] private float minZoom = 1.0f; // Минимальное значение масштаба
        [SerializeField] private float maxZoom = 5.0f; // Максимальное значение масштаба

        private void Update()
        {
            if (Input.touchCount == 2)
            {
                Touch touch0 = Input.GetTouch(0);
                Touch touch1 = Input.GetTouch(1);

                if (touch0.phase == TouchPhase.Moved && touch1.phase == TouchPhase.Moved)
                {
                    Vector2 touch0PrevPos = touch0.position - touch0.deltaPosition;
                    Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;

                    float prevTouchDeltaMag = (touch0PrevPos - touch1PrevPos).magnitude;
                    float touchDeltaMag = (touch0.position - touch1.position).magnitude;

                    float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag; 

                    _mainCamera.fieldOfView += deltaMagnitudeDiff * zoomSpeed;

                    _mainCamera.fieldOfView = Mathf.Clamp(_mainCamera.fieldOfView, minZoom, maxZoom);
                }
            }
        }
    }
}