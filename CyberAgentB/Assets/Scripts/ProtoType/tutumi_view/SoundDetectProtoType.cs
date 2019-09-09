using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ProtoType;

public class SoundDetectProtoType : MonoBehaviour
{
    [SerializeField] bool isBreath;

    [Header("Breath Data")]
    [SerializeField] float breathPower;

    [Header("Voice Data")]
    [SerializeField] float voicePower;
    [SerializeField] float voicePitch;

    private void Update()
    {
        GameController.Instance.Player.Voice.isActive = !isBreath;
        GameController.Instance.Player.Breath.isActive = isBreath;

        GameController.Instance.Player.Voice.Power = voicePower;
        GameController.Instance.Player.Voice.Pitch = voicePitch;

        GameController.Instance.Player.Breath.Power = breathPower;
    }
}
