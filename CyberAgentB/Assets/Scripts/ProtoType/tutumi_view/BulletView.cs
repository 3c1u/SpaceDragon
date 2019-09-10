using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    [SerializeField] float speed;

    //Behaviour halo;

    // Start is called before the first frame update
    void Start()
    {
        //halo = (Behaviour)this.transform.GetComponent("Halo");
        this.transform.position = new Vector3(0, -1, -7);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0, 0, speed);
    }

    /*private void OnDestroy()
    {
        Destroy(halo);
    }*/
}
