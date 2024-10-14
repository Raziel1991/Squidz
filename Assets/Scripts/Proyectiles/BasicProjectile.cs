using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BasicProjectile : ProjectileBase
{
    // Start is called before the first frame update
    new void Awake()
    {
        base.Awake();
        damage = 20;
        speed = 10.0f;
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
