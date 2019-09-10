using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockManager : MonoBehaviour
{

    GameObject target;

    Rigidbody myRock;

    [SerializeField] float speed=5;

    public float ratePercentage = 200f;

    public int HP=100;

    public float damage;

    public static int Point = 20;

    
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
        Debug.Log(HP);
        //プレイヤーの方向に向かって移動していく

        transform.LookAt(target.transform);

        transform.position += transform.forward * speed/ratePercentage;

//        if(transform.position.z<-2){
//            Destroy(this);
//        }

        if(HP<=0){
            Destroy(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player"){

            Destroy(this.gameObject);

            GameController.Instance.TakenDamage();
        }
    }

}
