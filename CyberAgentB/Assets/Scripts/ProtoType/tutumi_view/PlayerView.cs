using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ProtoType;

public class PlayerView : MonoBehaviour
{
    public UnityEngine.GameObject Bullet;
    public UnityEngine.GameObject Fire;
    [SerializeField] private ParticleSystem out_fire;
    [SerializeField] private ParticleSystem in_fire;

    Vector3 Pos;
    Quaternion Rot;

    bool once;

    // Start is called before the first frame update
    void Start()
    {
        once = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.Instance.Player.Voice.isActive)
        {
                once = true;
                LoanchBullet(GameController.Instance.Player.Voice.Power);
                SetFirePower(0);
            }
            if (GameController.Instance.Player.Breath.isActive)
        {
            SetFirePower(GameController.Instance.Player.Breath.Power);
        }
        else
        {
            SetFirePower(0);
        }
    }

    void LoanchBullet(float Power)
    {
        if (once)
        {
            if (!(Power < 0.3))
            {
                var _bullet = Instantiate(Bullet);
                _bullet.transform.localScale = new Vector3(1, 1, 1) * Power;
                Destroy(_bullet, 1f);
                once = false;
            }
            
        }
    }

    void SetFirePower(float power)
    {
        out_fire.GetComponent<ParticleSystem>().startLifetime = power;
        in_fire.GetComponent<ParticleSystem>().startLifetime = power;

    }
}
