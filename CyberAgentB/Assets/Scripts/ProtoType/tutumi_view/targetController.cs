using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetController : MonoBehaviour
{
    [SerializeField] UnityEngine.GameObject target;

    float t = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        t += Time.deltaTime;
        if (t > 1f)
        {
            var obj = Instantiate(target);
            Destroy(obj, 3.5f);
            t = 0;
        }
    }
}
