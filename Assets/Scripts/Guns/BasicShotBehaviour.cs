using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicShotBehaviour : GunBehavior
{


    // Start is called before the first frame update
    void Start()
    {
        gunCooldown = 1.0f;
        gunRecoil = 2.5f;
    }

    // Update is called once per frame
    new void FixedUpdate()
    {
        base.FixedUpdate();
    }

    new public float Shoot()
    {
        return base.Shoot();
    }
}
