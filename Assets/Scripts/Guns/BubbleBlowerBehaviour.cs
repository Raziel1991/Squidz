using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBlowerBehaviour : GunBehavior
{
    // Start is called before the first frame update
    void Start()
    {
        gunCooldown = 0.1f;
        gunRecoil = 1.05f;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }

    new public float Shoot()
    {
        return base.Shoot();
    }
}
