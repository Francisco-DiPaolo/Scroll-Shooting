using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    protected PlayerController player;
    private Rigidbody rb;
    public float speed;

    protected virtual void Start()
    {
        player = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Movement();
    }

    public virtual void effect()
    {

    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            effect();
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;

        }
    }

    protected void Movement()
    {
        rb.AddRelativeForce(Vector2.down * speed * Time.deltaTime, ForceMode.Force);
    }
}
