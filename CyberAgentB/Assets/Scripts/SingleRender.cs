using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR;

public class SingleRender : MonoBehaviour
{
    [SerializeField] bool useDeviceRotation = true;
    
    // Start is called before the first frame update
    void Start()
    {
        XRSettings.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!useDeviceRotation)
            return;
        
        Camera.main.transform.rotation = InputTracking.GetLocalRotation(XRNode.CenterEye);
    }
}
