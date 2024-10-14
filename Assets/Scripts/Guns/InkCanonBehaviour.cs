using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkCanonBehaviour : GunBehavior
{
    //public AudioSource audioCannon;
    // Start is called before the first frame update
    void Start()
    {
        gunCooldown = 3f;
        gunRecoil = 6f;
        //audioCannon = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    new void FixedUpdate()
    {
        base.FixedUpdate();
    }

    new float Shoot()
    {
        //audioCannon.PlayOneShot(audioCannon.clip);
        return base.Shoot();
    }
}
