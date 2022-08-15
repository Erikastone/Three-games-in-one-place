using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;

    private float delaySpawn = 3f;
    private float intervalSpawn = 2f;
    private float xPositionMin = 9f;
    private float xPositionMax = 15f;
    private float yPosition = -1.1f;
    private float zPosition = -2.776484f;
    private PlayerController playerController;
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObjects", delaySpawn, intervalSpawn);

    }
   void SpawnObjects()
    {
        Vector3 spawnLocation = new Vector3(Random.Range(xPositionMin , xPositionMax), yPosition , zPosition);
        int index = Random.Range(0, obstaclePrefabs.Length);

        if (!playerController.gameOver)
        {
            Instantiate(obstaclePrefabs[index], spawnLocation, obstaclePrefabs[index].transform.rotation);
        }          
    } 
}
