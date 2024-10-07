
using Unity.VisualScripting;
using UnityEngine;

public abstract class ProjectileBase : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Vector3 shootDirection;
    protected float damage;
    protected float speed; //= 1.0f;
    protected float maxLifeTime = 10.0f; //lifetime 10.0f equal to 10 seconds 
    protected void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected void FixedUpdate()
    {
        transform.position += (shootDirection * speed)/100;
    }

    public void Project(Vector3 direction)
    {
        shootDirection = direction;
        Destroy(gameObject, maxLifeTime);
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("ProjColFunc");
            collision.gameObject.GetComponent<NewPlayerMovement>().OnHit(damage);
            Destroy(gameObject);
        }

        else if (!collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }

}
