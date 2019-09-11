using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInPanel : MonoBehaviour
{
    private Image Image;

    public GameObject GameObject;

    private Animator Animator;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        GameObject.SetActive(true);
        Animator = GameObject.GetComponent<Animator>();
        Text text = GameObject.GetComponent<Text>();
        text.text = "";
        yield return StartCoroutine(FadeOut());
        text.text = "GameStart!!";
        Animator.SetBool("TextTrigger",true);
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
