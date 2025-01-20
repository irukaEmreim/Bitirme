using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public Wave[] waves;
    public GameObject hmm,gameOverScene;

    public int currentWaveIndex = 0;
    private int enemyCount;
    [SerializeField] private TextMeshProUGUI enemyCountText, waveCountText;
    private GameObject[] enemies;
    private int waveBonusResource = 50;


    private void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount= enemies.Length;
        enemyCountText.text =enemyCount.ToString();
        waveCountText.text = currentWaveIndex.ToString();
        if (currentWaveIndex>=waves.Length)
        {
            gameOverScene.SetActive(true);
        }
        
        if (isWaveActive)
        {
            hmm.SetActive(false);
            CheckWave();
            if (!isWaveActive)
            {
                hmm.SetActive(true);
                ResourceManager.Instance.AddResource(waveBonusResource * currentWaveIndex / 2);
                ResourceTower[] resourceTowers = FindObjectsOfType<ResourceTower>();
                foreach (var tower in resourceTowers)
                {
                    tower.GenerateResource();
                }
            }
        }

    }

    private void CheckWave() 
    {
        if (enemyCount==0)
        {
            isWaveActive = false;
        }
    }



    public bool isWaveActive = false;
    public void StartNextWave() 
    {
        if (waves.Length > currentWaveIndex && !isWaveActive)
        {
            //G�R�YOR BURAYA
            isWaveActive = true;
            currentWaveIndex++;
        }
    }

    

    



}
