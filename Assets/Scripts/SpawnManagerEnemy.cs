using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerEnemy : MonoBehaviour
{
    private float spawnRange = 9;

    public GameObject enemyPrefabs;    
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerupPrefab;
    private PlayerControllerBoll playerControllerBoll;
    private ManagerBoll managerBoll;
    void Start()
    {
        Instantiate(powerupPrefab, GenerateSpawnPozition(), powerupPrefab.transform.rotation);
        SpawnManagerWave(waveNumber);
        playerControllerBoll =GameObject.Find("Player").GetComponent<PlayerControllerBoll>();  
        managerBoll = GetComponent<ManagerBoll>();  
    }
    private void Update()
    {
        PrefabSpawn();
    }
    private void PrefabSpawn()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;     
            if (enemyCount == 0 && !playerControllerBoll.gameOver)
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
