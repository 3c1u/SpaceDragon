using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireView : MonoBehaviour
{
    private IceManager _iceManager;
    private RockManager _rockManager;
    int middleHP;

    bool once;

    public GameObject Explosion;

    private void Start()
    {
        once = true;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Ice")
        {
                Debug.Log("氷");
                var manager = other.GetComponent<IceManager>();
                HitTarget(other);

            Instantiate(Explosion, other.gameObject.transform.position, Quaternion.identity);
                
        }else if (other.gameObject.tag == "Rock")
        {
            Debug.Log("Rock");
            HitTarget(other);
        }
    }

    private void HitTarget(GameObject other)
    {
        if (other.GetComponent<IceManager>())
        {
            _iceManager = other.gameObject.GetComponent<IceManager>();
        }

        if (other.GetComponent<RockManager>())
        {
            _rockManager = other.gameObject.GetComponent<RockManager>();
        }


        if (GameController.Instance.Player.Breath.isActive && _iceManager)
        {
            middleHP = (int) (_iceManager.HP - (int)GameController.Instance.Player.Breath.Power * 10);
            _iceManager.HP = (int) middleHP;
        }

        if (GameController.Instance.Player.Breath.isActive && _rockManager)
        {
            middleHP = _rockManager.HP - (int)GameController.Instance.Player.Breath.Power * 10;
            _rockManager.HP = (int) middleHP;
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

}
