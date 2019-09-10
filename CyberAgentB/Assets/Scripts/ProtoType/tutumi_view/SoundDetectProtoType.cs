using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ProtoType;

public class SoundDetectProtoType : MonoBehaviour
{
    [SerializeField] SoundState state;

    [Header("Breath Data")]
    [SerializeField] float breathPower;

    [Header("Voice Data")]
    [SerializeField] float voicePower;
    [SerializeField] float voicePitch;

    private void Update()
    {
        switch (state)
        {
            case SoundState.breath:
                GameController.Instance.Player.Breath.isActive = true;
                GameController.Instance.Player.Voice.isActive = false;
                break;
            case SoundState.voice:
                GameController.Instance.Player.Voice.isActive = true;
                GameController.Instance.Player.Breath.isActive = false;
                break;
            case SoundState.no_input:
                GameController.Instance.Player.Voice.isActive = false;
                GameController.Instance.Player.Breath.isActive = false;
                break;
            default:
                break;

        }

        GameController.Instance.Player.Voice.Power = voicePower;
        GameController.Instance.Player.Voice.Pitch = voicePitch;

        GameController.Instance.Player.Breath.Power = breathPower;
    }
}
