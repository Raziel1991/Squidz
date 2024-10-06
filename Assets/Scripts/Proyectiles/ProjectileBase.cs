
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 shootDirection;
    float damage = 30f;
    public float speed = 1.0f;
    public float maxLifeTime = 10.0f; //lifetime 10.0f equal to 10 seconds 
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.position += (shootDirection * speed)/20000;
    }

    public void Project(Vector3 direction)
    {
        shootDirection = direction;
        Destroy(gameObject, maxLifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("ProjColFunc");
            collision.gameObject.GetComponent<NewPlayerMovement>().OnHit(damage);
            Destroy(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

}
