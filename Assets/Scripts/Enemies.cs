using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemies : MonoBehaviour
{
    [SerializeField] protected float speed;
    //[SerializeField] protected float shotPrefab;
    //[SerializeField] protected float shotSpawn;
    [SerializeField] protected float vida;

    public virtual void Movement()
    {

    }
    
    public virtual void Destruir()
    {

    }

    public virtual void Disparar()
    {

    }

    public virtual void RecibirDaño()
    {
        vida -= 100;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            RecibirDaño();
        }
    }
}
