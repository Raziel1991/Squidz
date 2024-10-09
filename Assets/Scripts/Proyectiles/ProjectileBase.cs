
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 500.0f;
    public float maxLifeTime = 10.0f; //lifetime 10.0f equal to 10 seconds 
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Project(Vector2 direction)
    {
        rb.AddForce(direction * this.speed);
        Destroy(this.gameObject, this.maxLifeTime);
    }
}
