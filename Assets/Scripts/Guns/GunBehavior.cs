using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunBehavior : MonoBehaviour
{
    public float gunRecoil;
    public Sprite gunSprite;
    public float gunCooldown;
    public float cooldownTimer = 0;
    public Transform shootingPoint;
    public ProjectileBase bulletPrefab;
    public AudioSource audioGun;
    void Start()
    {
        audioGun = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    protected void FixedUpdate()
    {
        cooldownTimer -= Time.deltaTime;
    }

    public float Shoot()
    {
        audioGun.Play();
        if (cooldownTimer > 0) return 0;
        ProjectileBase projectile = Instantiate(bulletPrefab, shootingPoint.transform.position, transform.rotation);
        projectile.Project(this.transform.up);

        //Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
        cooldownTimer = gunCooldown;
        return gunRecoil;
    }
}
