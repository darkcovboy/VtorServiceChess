using UnityEngine;

namespace Cell
{
    public class ChessCell : MonoBehaviour, IChessCell
    {
        public void Initialize(Material currentMaterial)
        {
            gameObject.GetComponent<MeshRenderer>().material = currentMaterial;
        }
        public Transform Position => gameObject.transform;
        public bool HaveChecker { get; set; }
    }
}