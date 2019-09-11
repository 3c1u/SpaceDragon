using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    [SerializeField] float speed;

    //Behaviour halo;

    RockManager rockManager;

    //float middleHP;
    Vector3 forwardVec;

    bool once;

    private IceManager _iceManager;
    private RockManager _rockManager;
    private int middleHP;

    // Start is called before the first frame update
    void Start()
    {
        //halo = (Behaviour)this.transform.GetComponent("Halo");
        forwardVec = GameController.Instance.BulletSpawnPoint;
//        forwardVec = Camera.main.transform.forward;
        this.transform.position = 1.0f * forwardVec - 0.6f * Camera.main.transform.up;

        once = true;
    }

    // Update is called once per frame
    void Update()
    {
        // パフォーマンス的におｋ？
        this.transform.position += speed * forwardVec;
    }

    /*private void OnTriggerEnter(Collider other)
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

                    rockManager.HP = (int) middleHP;
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
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Rock")
        {
            Debug.Log("Rock");
            HitTarget(other.gameObject);
        }
    }

    /*private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Rock")
        {
            Debug.Log("Rock");
            HitTarget(other.gameObject);
        }
    }*/



    private void HitTarget(GameObject other)
    {


        if (other.GetComponent<RockManager>())
        {
            _rockManager = other.gameObject.GetComponent<RockManager>();




            if (GameController.Instance.Player.Voice.isActive && _rockManager)
            {
                middleHP = _rockManager.HP - (int)GameController.Instance.Player.Breath.Power * 10;
                _rockManager.HP = (int)middleHP;
            }

            once = false;
            Debug.Log(middleHP);
            if (middleHP <= 0)
            {
                //Debug.Log("1");
                DestroyEnemy(other);
                Destroy(other.gameObject);
            }
        }
    }

    private void DestroyEnemy(GameObject other)
    {
        //Debug.Log("2");
        if (other.GetComponent<IceManager>())
        {
            GameController.Instance.AddScore(IceManager.Point);
            //Debug.Log("氷かさん");
        }
        if (other.GetComponent<RockManager>())
        {
            GameController.Instance.AddScore(RockManager.Point);

            //Debug.Log("イワかさん");
        }
    }




    /*private void OnDestroy()
    {
        Destroy(halo);
    }*/
}
