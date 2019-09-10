using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireView : MonoBehaviour
{

    IceManager iceManager;

    float middleHP;

    bool once;

    private void Start()
    {
        once = true;
    }

    private void OnParticleCollision(GameObject other)
    {
        GameController.Instance.AddScore(1);


        Debug.Log("氷");
        if (other.gameObject.tag == "Ice")
        {
            if (once)
            {
                Debug.Log("氷衝突している");

                iceManager = other.gameObject.GetComponent<IceManager>();

                Debug.Log(iceManager);

                if (GameController.Instance.Player.Breath.isActive && iceManager)
                {
                    middleHP = iceManager.HP - GameController.Instance.Player.Breath.Power;

                    iceManager.HP = middleHP;
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

}
