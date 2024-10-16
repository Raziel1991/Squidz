using UnityEngine;

public class InkyAnimationController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayIdle()
    {
        animator.SetTrigger("TriggerIdle_inky");
    }

    public void PlayWinning()
    {
        animator.SetTrigger("TriggerWinning_inky");
    }

    public void PlayDamage()
    {
        animator.SetTrigger("TriggerDamage_inky");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            PlayDamage();
        }
    }
}
