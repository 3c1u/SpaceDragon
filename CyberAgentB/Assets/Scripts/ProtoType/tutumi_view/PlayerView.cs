using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ProtoType;

public class PlayerView : MonoBehaviour
{
    public UnityEngine.GameObject Bullet;
    public UnityEngine.GameObject Fire;

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
                SetFirePower(0);
            }
        }

        if (GameController.Instance.Player.Breath.isActive)
        {
            SetFirePower(GameController.Instance.Player.Breath.Power);
            //Fire.SetActive(true);
        }
        else
        {
            SetFirePower(0);
            //Fire.SetActive(false);
        }
    }

    void LoanchBullet(float Power)
    {
        var _bullet = Instantiate(Bullet);
        _bullet.transform.localScale = new Vector3(1, 1, 1) * Power;
        Destroy(_bullet, 5f);
    }

    void SetFirePower(float power)
    {
        var out_fire = GameObject.Find("out");
        var in_fire = GameObject.Find("in");

        out_fire.GetComponent<ParticleSystem>().startLifetime = power;
        in_fire.GetComponent<ParticleSystem>().startLifetime = power;

    }
}
