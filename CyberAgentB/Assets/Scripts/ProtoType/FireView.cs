﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireView : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        GameObject.Instance.AddScore(1);
    }
}