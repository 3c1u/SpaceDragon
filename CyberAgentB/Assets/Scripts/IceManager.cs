using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceManager : MonoBehaviour
{

    GameObject target;

    public float ratePercentage = 200f;

    public float HP = 100;

    [SerializeField] float speed = 5;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");

        Debug.Log("Start完了");
        Debug.Log(target);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(target.transform);

        this.transform.position += transform.forward * speed / ratePercentage;

        if (this.transform.position.z < -2)
        {
            Destroy(this);
        }

        if (HP <= 0)
        {
            Destroy(this);
        }

    }
}
