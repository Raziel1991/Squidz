using UnityEngine;

public class BloopAnimationController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayIdle()
    {
        animator.SetTrigger("TriggerIdle_bloop");
    }

    public void PlayWinning()
    {
        animator.SetTrigger("TriggerWinning_bloop");
    }

    public void PlayDamage()
    {
        animator.SetTrigger("TriggerDamage_bloop");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            PlayDamage();
        }
    }
}

