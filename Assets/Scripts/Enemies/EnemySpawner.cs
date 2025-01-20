using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public Transform[] spawnPositions;

    public WaveManager waveManager;
    

    public void StartInstantiation() 
    {
        if (!waveManager.isWaveActive)
        {
            StartCoroutine(HandleWave());
        }
    }


    IEnumerator HandleWave() 
    {
        if (waveManager.currentWaveIndex < waveManager.waves.Length)
        {
            // mevcut wave'i ba�lat
            Wave currentWave = waveManager.waves[waveManager.currentWaveIndex];
            yield return StartCoroutine(SpawnEnemies(currentWave));

            yield return StartCoroutine(WaitEnemiesToDie());
        }
        else
        {
            print("Wave Yok Daha");
        }


    }

    IEnumerator SpawnEnemies(Wave wave)
    {

        for (int i = 0; i < wave.enemyCount; i++)
        {
            Instantiate(wave.enemyPrefab[Random.Range(0,wave.enemyPrefab.Length)], spawnPositions[Random.Range(0, spawnPositions.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(wave.spawnInterval);
        }

    }

    IEnumerator WaitEnemiesToDie()
    {
        while (GameObject.FindGameObjectsWithTag("Enemy").Length>0)
        {
            yield return null;
        }
    }






}
