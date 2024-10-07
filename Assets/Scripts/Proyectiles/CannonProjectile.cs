using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonProjectile : ProjectileBase
{
    new void Awake()
    {
        base.Awake();
        damage = 40;
        speed = 40.0f;
    }

    // Update is called once per frame
    new void FixedUpdate()
    {
        base.FixedUpdate();
    }

    new public void Project(Vector3 direction)
    {
        base.Project(direction);
    }

    new void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }
}
