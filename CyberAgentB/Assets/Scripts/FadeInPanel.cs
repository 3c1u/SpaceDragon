using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInPanel : MonoBehaviour
{
    private Image Image;
    // Start is called before the first frame update
    void Start()
    {
        Image = GetComponent<Image>();
        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeOut()
    {
        Image = GetComponent<Image>();
        for (float i = 1; i > 0; i -= 0.01f)
        {
            Image.color = new Color(0f, 0f, 0f, i);
            yield return null;
        }
    }


}
