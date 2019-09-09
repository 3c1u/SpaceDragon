using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ProtoType;

public class PlayerView : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject Fire;

    Vector3 Pos;
    Quaternion Rot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GameController.Instance.Player.Voice.isActive)
            {
                LoanchBullet(GameController.Instance.Player.Voice.Power);
            }
            else if(GameController.Instance.Player.Breath.isActive)
            {

            }
        }
    }

    void LoanchBullet(float Power)
    {
        var _bullet = Instantiate(Bullet);
        _bullet.transform.localScale = new Vector3(1, 1, 1) * Power;
        Destroy(_bullet, 5f);
    }
}
