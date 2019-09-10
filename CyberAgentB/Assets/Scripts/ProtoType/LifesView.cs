using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class LifesView : MonoBehaviour
{
    private int LifeCount => GameController.Instance.LifeCount;
    private List<GameObject> LifeList = new List<GameObject>();
    
    private void Start()
    {
        for (var i = 0; i < LifeCount; i++)
        {
            var obj =  Resources.LoadAsync("Life");
            var instance = (GameObject)Instantiate(obj.asset,
                new Vector3(0.0f, 0.0f, 0.0f),
                Quaternion.identity);
            instance.transform.localScale = new Vector3(0.02f,0.02f,0.02f);
            instance.gameObject.transform.parent = transform;
            LifeList.Add(instance);
        }

        GameController.Instance.TakenDamageAction = DestroyLife();
    }

    private Action DestroyLife()
    {
        return () =>
        {
            var life = LifeList.First();
            life.gameObject.SetActive(false);
        };
    }

}
