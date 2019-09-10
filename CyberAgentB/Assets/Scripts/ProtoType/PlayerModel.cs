using System.Numerics;

namespace ProtoType
{
    public class PlayerModel
    {
        public VoiceModel Voice = new VoiceModel();
        public BreathModel Breath = new BreathModel();
        public Vector3 Position = new Vector3();
        public Quaternion Rotate = new Quaternion();
    }
}