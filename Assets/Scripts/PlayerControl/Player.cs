using Cell;
using CheckerCode;
using UnityEngine;

namespace PlayerControl
{
    public class Player : MonoBehaviour
    {
        private IChecker _checkerCurrent;
        
        private void Update()
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) 
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    GameObject clickedObject = hit.collider.gameObject;

                    if (clickedObject.TryGetComponent(out IChecker checker))
                    {
                        _checkerCurrent = checker;
                        return;
                    }
                    
                    if (clickedObject.TryGetComponent(out IChessCell cell))
                    {
                        if (_checkerCurrent != null && !cell.HaveChecker)
                        {
                            Vector3 newPosition = new Vector3(cell.Position.position.x, _checkerCurrent.Transform.position.y,cell.Position.position.z);
                            _checkerCurrent.MoveToPosition(newPosition);
                            cell.HaveChecker = false;
                            _checkerCurrent = null;
                        }
                    }
                }
            }
        }
    }
}