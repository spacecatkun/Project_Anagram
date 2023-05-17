using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnpoint;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int waveNumber = 1;

    public TMP_Text waveCountDownText;

    private void Update() {
        if (countdown <= 0f){
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
        waveCountDownText.text = Mathf.Floor(countdown).ToString();
    }

    IEnumerator SpawnWave ()
    {
        waveNumber++;
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEneny();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEneny()
    {
        Instantiate(enemyPrefab, spawnpoint.position, spawnpoint.rotation);
    }
}
