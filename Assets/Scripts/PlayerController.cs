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

    // Shot
    [Header("Shooting")]
    public GameObject shot;
    public Transform shotSpawn;
    public Transform shotSpawnDoble1;
    public Transform shotSpawnDoble2;
    public Transform shotSpawnLateral1;
    public Transform shotSpawnLateral2;
    public float fireRate;
    public float fireImpulse;
    public string tipoPowerUp;
    private float nextFire;

    [Header("Shooting")]
    public int vida;
    protected GameController gameController;
    public bool canTakeDamage;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        tipoPowerUp = "tiroSimple";
        gameController = FindObjectOfType<GameController>();

        canTakeDamage = true;
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        switch (tipoPowerUp)
        {

        case "tiroSimple":

            Shooting(shotSpawn);
            break;

        case "tiroDoble":

            Shooting(shotSpawnDoble1);
            Shooting(shotSpawnDoble2);
            break;

        case "tiroLateral":

            Shooting(shotSpawn);
            ShootingLateralDerecho(shotSpawnLateral1);
            ShootingLateralIzquierdo(shotSpawnLateral2);
            break;

        default:
            break;
        }

        if (vida <= 0)
        {
            gameController.Lose();
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);
        rb.velocity = movement * speed;
        rb.rotation = Quaternion.Euler(0f, rb.velocity.x * -tilt, 0f);
    }

    void Shooting(Transform positionShot)
    {
        {
            nextFire = Time.time + fireRate;
            GameObject bullet = Instantiate(shot, positionShot.position, shotSpawn.rotation);
            bullet.GetComponent<Rigidbody>().AddRelativeForce(Vector2.up * fireImpulse, ForceMode.Impulse);

            Destroy(bullet, 2);
        }
    }

    void ShootingLateralDerecho(Transform positionShot)
    {
        {
            nextFire = Time.time + fireRate;
            GameObject bullet = Instantiate(shot, positionShot.position, Quaternion.Euler(0f, 0f, -90f));
            bullet.GetComponent<Rigidbody>().AddRelativeForce(Vector2.up * fireImpulse, ForceMode.Impulse);

            Destroy(bullet, 2);
        }
    }

    void ShootingLateralIzquierdo(Transform positionShot)
    {
        {
            nextFire = Time.time + fireRate;
            GameObject bullet = Instantiate(shot, positionShot.position, Quaternion.Euler(0f, 0f, 90f));
            bullet.GetComponent<Rigidbody>().AddRelativeForce(Vector2.up * fireImpulse, ForceMode.Impulse);

            Destroy(bullet, 2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            LoseHealth();
        }
    }

    void LoseHealth()
    {
        if (!canTakeDamage) return;

        vida--;

        StartCoroutine(DamageCD(2));
    }

    public IEnumerator DamageCD(float delay)
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(delay);
        canTakeDamage = true;
    }
}
