using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicShotBehaviour : GunBehavior
{


    // Start is called before the first frame update
    void Start()
    {
        gunCooldown = 1.5f;
        gunRecoil = 3f;
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
