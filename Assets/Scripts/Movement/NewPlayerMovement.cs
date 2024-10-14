using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{

    public float rotationSpeed = 200f;
    public float hp = 100f;
    public GunBehavior gun;
    public AudioSource audioBump, audioHit;

    [SerializeField] private bool isPlayer2 = false;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gun = GetComponentInChildren<GunBehavior>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleRotation();

        if (!isPlayer2)
        {
            if (Input.GetKey(KeyCode.S))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.L))
            {
                Shoot();
            }
        }

        if (rb.velocity.magnitude > 0)
        {
            rb.velocity = rb.velocity * 0.98f;
        }

    }

    void Shoot()
    {
        // Apply an impulse in the opposite direction of the current rotation (backward)

        //rb.velocity = Vector2.zero;
        rb.AddForce(-transform.up * gun.Shoot(), ForceMode2D.Impulse);

        // Start tracking movement time and position

        //Shoot bullet
        //ProjectileBase projectile = Instantiate(this.projectilePrefab, this.transform.position, this.transform.rotation);
        // projectile.Project(this.transform.up);
    }

    void HandleRotation()
    {
        // Rotate the player
        if (!isPlayer2)
        {
            float horizontalInput = Input.GetAxis("Horizontal"); // Z is -1, X is +1
            if (horizontalInput != 0)
            {
                transform.Rotate(Vector3.forward * -horizontalInput * rotationSpeed * Time.deltaTime);
            }
        }
        else
        {
            float horizontalInput = Input.GetAxis("Horizontal2"); // , is -1, . is +1
            if (horizontalInput != 0)
            {
                transform.Rotate(Vector3.forward * -horizontalInput * rotationSpeed * Time.deltaTime);
            }
        }
    }

    public void OnHit(float damage)
    {
        
        hp -= damage;
        Debug.Log(hp);
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    // Wall_hit sfx
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Bullet":
                audioHit.Play();
                break;
        }
            
        if(collision.gameObject.CompareTag("Wall"))
        {
            audioBump.Play();
        }
    }

}
