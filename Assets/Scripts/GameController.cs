using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text textContador;
    public int spawnScore;
    private bool bossFight;
    private Asteroide asteroide;
    public int score;

    public GameObject boss;
    public Transform spawnerPosition;

    public GameObject[] arrayPowerUps;
    public int cant;
    public float timeRepeating;
    private PlayerController player;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
        asteroide = FindObjectOfType<Asteroide>();
        player = FindObjectOfType<PlayerController>();
        score = 0;
        InvokeRepeating("SpawnpowerUp", 10, timeRepeating);
        textContador.text = score.ToString() + "/" + spawnScore;
    }

    private void Update()
    {
        if (score >= spawnScore && !bossFight)
        {
            bossFight = true;
            Instantiate(boss, spawnerPosition.transform.position, Quaternion.identity);
        }
    }

    IEnumerator SpawnWaves()
    {
        while(true)
        {
            yield return new WaitForSeconds(startWait);
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(hazard, spawnPosition, Quaternion.Euler(0f, 0f, 0f));

                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(spawnWait);
        }
    }

    void SpawnpowerUp()
    {
        int cantObj = Random.Range(1, cant);
        
        if (cantObj == 1 && player.tipoPowerUp != "tiroDoble")
        {
            Vector3 spawnPositionPowerUp = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Instantiate(arrayPowerUps[0], spawnPositionPowerUp, Quaternion.Euler(0f, 0f, 0f));
        }

        if (cantObj == 2 && player.tipoPowerUp != "tiroLateral")
        {
            Vector3 spawnPositionPowerUp = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Instantiate(arrayPowerUps[1], spawnPositionPowerUp, Quaternion.Euler(0f, 0f, 0f));
        }
    }

    public void EnemyDie()
    {
        score++;
        textContador.text = score.ToString() + "/" + spawnScore;
    }

    public void Win()
    {
        SceneManager.LoadScene("Winner");
    }

    public void Lose()
    {
        SceneManager.LoadScene("GameOver");
    }
}