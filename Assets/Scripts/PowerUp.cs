using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    [SerializeField] protected float duration;
    protected PlayerController player;

    public virtual void effect()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public virtual IEnumerator PowerUpDuration(float time)
    {
        yield return new WaitForSeconds(time);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            effect();
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
