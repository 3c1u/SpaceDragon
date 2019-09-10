using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    [SerializeField] float speed;

    //Behaviour halo;

    RockManager rockManager;

    float middleHP;

    bool once;

    // Start is called before the first frame update
    void Start()
    {
        //halo = (Behaviour)this.transform.GetComponent("Halo");
        this.transform.position = new Vector3(0, -1, -7);

        once = true;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0, 0, speed);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Rock")
        {
            if (once)
            {
                Debug.Log("多摩の方で衝突してます");

                rockManager = other.gameObject.GetComponent<RockManager>();

                Debug.Log(rockManager);

                if (GameController.Instance.Player.Voice.isActive && rockManager)
                {
                    middleHP = rockManager.HP - GameController.Instance.Player.Voice.Power;

                    rockManager.HP = middleHP;
                }

                once = false;
                Debug.Log(middleHP);
                if (middleHP <= 0)
                {
                    Destroy(other.gameObject);
                }
                Destroy(this.gameObject);
            }
        }
    }




    /*private void OnDestroy()
    {
        Destroy(halo);
    }*/
}
