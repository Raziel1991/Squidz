using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBlowerBehaviour : GunBehavior
{
    // Start is called before the first frame update
    void Start()
    {
        gunCooldown = 0.2f;
        gunRecoil = 0.505f;
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
