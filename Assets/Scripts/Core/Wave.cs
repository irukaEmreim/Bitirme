using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave 
{
    public GameObject[] enemyPrefab; // Spawn edilecek d��man prefab'�
    public int enemyCount;         // Bu wave'deki d��man say�s�
    public float spawnInterval;    // D��manlar aras�ndaki spawn s�resi
}
