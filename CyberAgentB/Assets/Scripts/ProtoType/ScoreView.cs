using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;


public class ScoreView : MonoBehaviour
{
    public Text Text;
    void Start()
    {
        Text = GetComponent<Text>();
    }

    private void Update()
    {
        Text.text = $" score : {GameController.Instance.Score}";
    }
}
