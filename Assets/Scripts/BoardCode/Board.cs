using Cell;
using CheckerCode;
using UnityEngine;

namespace BoardCode
{
    public class Board : MonoBehaviour
    {
        [SerializeField] private BoardData _boardData;

        private void Start()
        {
            GenerateBoard();
        }

        private void GenerateChecker(bool isWhite, IChessCell chessCell)
        {
            Vector3 checkerPosition = chessCell.Position.position + Vector3.up * 0.5f;
            Checker checker = Instantiate(_boardData.CheckerPrefab, checkerPosition, Quaternion.identity, transform);
            Material material = isWhite ? _boardData.WhiteCheckerMaterial : _boardData.BlackCheckerMaterial;
            checker.Initialize(material);
        }

        private void GenerateBoard()
        {
            bool isWhite = true;
            Vector3 startPosition = transform.position - new Vector3((_boardData.SizeX - 1) * _boardData.CellSize / 2,
                0, (_boardData.SizeY - 1) * _boardData.CellSize / 2);

            for (int x = 0; x < _boardData.SizeX; x++)
            {
                for (int y = 0; y < _boardData.SizeY; y++)
                {
                    Vector3 position = startPosition + new Vector3(x * _boardData.CellSize, 0, y * _boardData.CellSize);

                    ChessCell cube = Instantiate(_boardData.CellPrefab, position, Quaternion.identity, this.transform);

                    Material material = isWhite ? _boardData.WhiteCellMaterial : _boardData.BlackCellMaterial;
                    cube.Initialize(material);

                    //Create checkers
                    if (y < 2)
                    {
                        if (!isWhite)
                        {
                            GenerateChecker(true, cube);
                            cube.HaveChecker = true;
                        }
                    }
                    else if (y >= _boardData.SizeY - 2)
                    {
                        if (isWhite)
                        {
                            GenerateChecker(false, cube);
                            cube.HaveChecker = true;
                        }
                    }

                    isWhite = !isWhite;
                }

                isWhite = !isWhite;
            }
        }
    }
}