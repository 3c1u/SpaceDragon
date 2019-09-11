using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class LifesView : MonoBehaviour
{
    private int LifeCount => GameController.Instance.LifeCount;
    Queue<GameObject> _lifeQueue =  new Queue<GameObject>();

    [SerializeField] AudioSource damage;
    
    private void Start()
    {
        for (var i = 0; i < LifeCount; i++)
        {
            var obj =  Resources.LoadAsync("Life");
            var instance = (GameObject)Instantiate(obj.asset,
                transform.position,
                Quaternion.identity);
            instance.transform.localScale = new Vector3(1f,1f,1f);
            instance.gameObject.transform.parent = transform;
            _lifeQueue.Enqueue(instance);
        }

        GameController.Instance.TakenDamageAction = DestroyLife();
    }

    private Action DestroyLife()
    {
        return () =>
        {
            if (_lifeQueue != null)
            {
                damage.Play();
                var life = _lifeQueue.Peek();
                Destroy(life.gameObject);
                _lifeQueue.Dequeue();
            }
        };
    }

}
