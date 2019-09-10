using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    [SerializeField] bool isBreath = false;

    [Header("breath data")]
    [SerializeField] float breathPower;

    [Header("voice data")]
    [SerializeField] float voiceVolume;
    [SerializeField] float voicePitch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
