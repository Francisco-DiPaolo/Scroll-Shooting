using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asteroide : Enemies
{
    public float vel;
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
}
