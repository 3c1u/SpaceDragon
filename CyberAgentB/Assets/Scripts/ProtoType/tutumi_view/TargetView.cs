using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ProtoType;

public class TargetView : MonoBehaviour
{

    [SerializeField] Transform TartgetPoint; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(GameController.Instance.Player.Position, Vector3.up);
    }
}
