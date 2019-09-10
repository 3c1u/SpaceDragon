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
                GameObject.Instance.Player.Breath.isActive = true;
                GameObject.Instance.Player.Voice.isActive = false;
                break;
            case SoundState.voice:
                GameObject.Instance.Player.Voice.isActive = true;
                GameObject.Instance.Player.Breath.isActive = false;
                break;
            case SoundState.no_input:
                GameObject.Instance.Player.Voice.isActive = false;
                GameObject.Instance.Player.Breath.isActive = false;
                break;
            default:
                break;

        }

        GameObject.Instance.Player.Voice.Power = voicePower;
        GameObject.Instance.Player.Voice.Pitch = voicePitch;

        GameObject.Instance.Player.Breath.Power = breathPower;
    }
}
