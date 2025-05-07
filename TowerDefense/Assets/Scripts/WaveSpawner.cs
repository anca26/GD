using UnityEngine;
using System.Collections;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive = 0;
    public Wave[] waves;

    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;  //doar pt testare e asa mic
    private float countdown = 2f;
    private int waveNumber = 0;

    public TextMeshProUGUI waveCountdownText;

    public GameManager gameManager;


    void Update()
    {
        if(enemiesAlive > 0)
        {
            return;
        }
        if (waveNumber == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;

        }
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown = countdown - Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.0}", countdown);
    }

    IEnumerator SpawnWave()
    {

        PlayerStats.rounds++;

        Wave wave = waves[waveNumber];

        enemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveNumber++;

       
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
