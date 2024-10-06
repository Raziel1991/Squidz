using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkCanonBehaviour : GunBehavior
{
    // Start is called before the first frame update
    void Start()
    {
        gunCooldown = 3f;
        gunRecoil = 9f;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }

    new float Shoot()
    {
        return base.Shoot();
    }
}
