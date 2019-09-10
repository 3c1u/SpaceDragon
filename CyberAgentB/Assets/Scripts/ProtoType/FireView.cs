using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireView : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
//        Debug.Log(other.gameObject.name);
    }

    private void OnParticleCollision(UnityEngine.GameObject other)
    {
        GameObject.Instance.AddScore(1);
    }
}
