using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceManager : MonoBehaviour
{

    GameObject target;

    public float ratePercentage = 200f;

    public int HP = 100;

    [SerializeField] float speed = 5;

    public static int Point = 10;


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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Destroy(this.gameObject);

            GameController.Instance.TakenDamage();
        }
    }
}
