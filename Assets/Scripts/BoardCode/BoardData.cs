using Cell;
using CheckerCode;
using UnityEngine;
using UnityEngine.Serialization;

namespace BoardCode
{
    [CreateAssetMenu(fileName = "BoardData", menuName = "Board", order = 0)]
    public class BoardData : ScriptableObject
    {
        [SerializeField] private ChessCell _cellPrefab;
        [SerializeField] private Checker _checkerPrefab;
        [FormerlySerializedAs("_whiteMaterial")] [SerializeField] private Material _whiteCellMaterial;
        [FormerlySerializedAs("_blackMaterial")] [SerializeField] private Material _blackCellMaterial;
        [SerializeField] private Material _whiteCheckerMaterial;
        [SerializeField] private Material _blackCheckerMaterial;
        [SerializeField] private int _sizeX = 8;
        [SerializeField] private int _sizeY = 8;
        [SerializeField] private float _cellSize = 1;

        public ChessCell CellPrefab => _cellPrefab;

        public Checker CheckerPrefab => _checkerPrefab;

        public Material WhiteCellMaterial => _whiteCellMaterial;

        public Material BlackCellMaterial => _blackCellMaterial;

        public Material WhiteCheckerMaterial => _whiteCheckerMaterial;

        public Material BlackCheckerMaterial => _blackCheckerMaterial;

        public int SizeX => _sizeX;

        public int SizeY => _sizeY;

        public float CellSize => _cellSize;
    }
}