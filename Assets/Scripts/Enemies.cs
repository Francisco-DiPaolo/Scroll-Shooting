using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemies : MonoBehaviour
{
    [SerializeField] protected float vida;
    protected GameController gameController;
    protected PlayerController playerController;

    protected virtual void Start()
    {
        gameController = FindObjectOfType<GameController>();
        playerController = FindObjectOfType<PlayerController>();
    }
    protected virtual void Movement()
    {

    }

    protected virtual void Update()
    {
        Destruir();

        if (transform.position.y <= -5.5f)
        {
            Destroy(gameObject);
            playerController.vida--;
        }
    }

    protected virtual void Destruir()
    {
        if (vida <= 0)
        {
            Destroy(gameObject);
            gameController.EnemyDie();
        }
    }

    protected virtual void RecibirDaño()
    {
        vida -= 100;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Bullet"))
        {
            RecibirDaño();
            Destroy(other.gameObject);
        }
    }
}
