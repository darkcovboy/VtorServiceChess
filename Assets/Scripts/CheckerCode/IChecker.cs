using UnityEngine;

namespace CheckerCode
{
    public interface IChecker
    {
        Transform Transform { get; }
        void MoveToPosition(Vector3 at);
    }
}