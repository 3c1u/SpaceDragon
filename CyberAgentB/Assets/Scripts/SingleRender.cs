using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR;

public class SingleRender : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        XRSettings.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.rotation = InputTracking.GetLocalRotation(XRNode.CenterEye);
    }
}
