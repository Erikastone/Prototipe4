using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefabs;
    private float spawnRange = 9;
    public int enemyCount;
    public int waveNumber=1;
    public GameObject powerupPrefab;
   
    void Start()
    {
        Instantiate(powerupPrefab, GenerateSpawnPozition(), powerupPrefab.transform.rotation);
        SpawnManagerWave(waveNumber);
     
    }
    private void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            Instantiate(powerupPrefab, GenerateSpawnPozition(), powerupPrefab.transform.rotation);
            waveNumber++;
            SpawnManagerWave(waveNumber);
        }
    }

    private Vector3 GenerateSpawnPozition()
    {
        float PosX = Random.Range(-spawnRange, spawnRange);
        float posZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(PosX, 0, posZ);
        return randomPos;
    }
    
    void SpawnManagerWave(int ememiesToSpawn)
    {
        for (int i = 0; i < ememiesToSpawn; i++)
        {
            Instantiate(enemyPrefabs, GenerateSpawnPozition(), enemyPrefabs.transform.rotation);
        }
    }
}
