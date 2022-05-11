using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemies
{
    private Rigidbody rb;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
        Movement();
    }

    protected override void Movement()
    {
        base.Movement();

        rb.AddRelativeForce(Vector2.down, ForceMode.Impulse);
    }

    protected override void Destruir()
    {
        base.Destruir();

        if (vida <= 0)
        {
            Destroy(gameObject);
            gameController.EnemyDie();
            gameController.Win();
        }
    }
}
