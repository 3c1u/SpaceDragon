using System.Numerics;

namespace ProtoType
{
    public class TargetModel
    {
        public int Score { get; private set; } = 1;
        public int Size { get; private set; } = 1;
        public Vector3 TargetPos => GameController.Instance.Player.Position;

        public void SetSize(int num)
        {
            Size = num;
        }

        public void SetScore(int num)
        {
            Score = num;
        }
    }
}