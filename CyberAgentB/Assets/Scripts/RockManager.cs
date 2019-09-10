using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockManager : MonoBehaviour
{

    GameObject target;

    Rigidbody myRock;

    [SerializeField] float speed=5;

    public float ratePercentage = 200f;

    public float HP=100;

    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        myRock = GetComponent<Rigidbody>();
        Debug.Log("Start完了");
        Debug.Log(target);
        Debug.Log(myRock);

    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーの方向に向かって移動していく
        //Vector3 diff = new Vector3(target.transform.position.x - transform.position.x,0f,target.transform.position.z-transform.position.z); //プレイヤーと対照との差分を取得

        //myRock.AddForce(diff * speed/ratePercentage);

        this.transform.LookAt(target.transform);

        this.transform.position += transform.forward * speed/ratePercentage;

        if(this.transform.position.z<-2){
            Destroy(this);
        }

        if(HP<=0){
            Destroy(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        HP -= GameController.Instance.Player.Voice.Power * 100;

        Debug.Log("衝突！");
    }
}
