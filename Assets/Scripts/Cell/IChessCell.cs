using UnityEngine;

namespace Cell
{
    public interface IChessCell
    {
        Transform Position { get; }
        bool HaveChecker { get; set; }
    }
}