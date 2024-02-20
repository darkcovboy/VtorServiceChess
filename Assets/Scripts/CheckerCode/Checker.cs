using Cell;
using DG.Tweening;
using UnityEngine;

namespace CheckerCode
{
    public class Checker : MonoBehaviour, IChecker
    {
        [SerializeField] private float _duration = 0.2f;
        
        private IChessCell _currentCell;

        public void Initialize(Material material)
        {
            gameObject.GetComponent<MeshRenderer>().material = material;
        }

        public Transform Transform => transform;

        public void MoveToPosition(Vector3 at)
        {
            transform.DOMove(at, _duration);
        }
    }
}