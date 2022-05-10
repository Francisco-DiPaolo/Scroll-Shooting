using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
    // Player Movement
    [Header("Movement")]
    public float speed;
    public float tilt;
    public Boundary boundary;
    private Rigidbody rb;

    [Header("Shooting")]
    // Shot
    public GameObject shot;
    public Transform shotSpawn;
    public Transform shotSpawnDoble1;
    public Transform shotSpawnDoble2;
    public float fireRate;
    public float fireImpulse;
    private float nextFire;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject bullet = Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            bullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * fireImpulse, ForceMode2D.Impulse);

            Destroy(bullet, 2);
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);
        rb.velocity = movement * speed;
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax), 0f);
        rb.rotation = Quaternion.Euler(0f, rb.velocity.x * -tilt, 0f);
    }
}
