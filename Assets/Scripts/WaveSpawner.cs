using System.Collections;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;
    public Transform spawnPoint;
    public float timeBetweenWaves = 10f;
    private float countdown;
    private int waveIndex;
    public TMP_Text waveCountdownText;

    public GameManager gameManager;

    private void Start()
    {
        InitializeSpawner();
    }

    private void InitializeSpawner()
    {
        Debug.Log("WaveSpawner initialized");
        countdown = 2f;
        waveIndex = 0;
        EnemiesAlive = 0;
        StopAllCoroutines(); 
    }

    private void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
            return; 
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        foreach (var group in wave.enemyGroups)
        {
            EnemiesAlive += group.count;

            for (int i = 0; i < group.count; i++)
            {
                SpawnEnemy(group.enemyPrefab);
                yield return new WaitForSeconds(1f / group.rate);
            }
        }

        waveIndex++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
