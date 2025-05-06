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


    void Update()
    {
        if(enemiesAlive > 0)
        {
            return;
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

        for(int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveNumber++;

        if (waveNumber == waves.Length)
        {
            Debug.Log("LEVEL WON!");
            this.enabled = false; 
            //return;
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        enemiesAlive++;
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
