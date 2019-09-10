using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeView : MonoBehaviour
{
    public Text Text;
    void Start()
    {
        Text = GetComponent<Text>();
        StartCoroutine(StartTime());
    }

    IEnumerator StartTime()
    {
        while (true)
        {
            if (GameController.Instance.Time <= 0)
            {
                yield break;
            }
            yield return new WaitForSeconds(1.0f);
            GameController.Instance.DecreaseTime();
            Text.text = $"time : {GameController.Instance.Time}";
        }
    }

    
}
