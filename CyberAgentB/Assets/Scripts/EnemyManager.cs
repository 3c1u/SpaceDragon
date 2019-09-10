using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public GameObject EnemyRock;

    public GameObject IceEnemy;

    float GameTime;

    float IntervalTime;

    int whichEnemy;

    [SerializeField]float r = 15;

    float theta;

    float phi;

    float x;

    float y;

    float z;

    // Start is called before the first frame update
    void Start()
    {
        GameTime = 0f;

        IntervalTime = 3.5f;
        
    }

    // Update is called once per frame
    void Update()
    {
        GameTime += Time.deltaTime;

        IntervalTime -= Time.deltaTime;

        if(IntervalTime<=0){

            whichEnemy = Random.Range(0, 2);

            theta = Random.Range(0f, 360f);

            phi = Random.Range(0, 45);

            x = r * Mathf.Cos(Mathf.Deg2Rad*phi) * Mathf.Cos(Mathf.Deg2Rad*theta);

            y = r * Mathf.Sin(Mathf.Deg2Rad*phi);

            z = r * Mathf.Cos(Mathf.Deg2Rad*phi) * Mathf.Sin(Mathf.Deg2Rad*theta);

            if (whichEnemy == 1)
            {

                var enemy = Instantiate(EnemyRock,new Vector3(x,y,z),Quaternion.identity);

                RockManager rock = enemy.GetComponent<RockManager>();

                if(rock==null){

                    Debug.Log("rockがぬる");

                    enemy.AddComponent<RockManager>();

                    Debug.Log("Addされました");
                }

                IntervalTime = 2.0f;
            
            }else{
                Instantiate(IceEnemy,new Vector3(x,y,z),Quaternion.identity);

                IntervalTime = 2.0f;
            }
        }


        
    }
}
