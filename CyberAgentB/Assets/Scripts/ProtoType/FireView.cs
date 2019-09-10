using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireView : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        GameController.Instance.AddScore(1);
    }
}
