using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimalTop", startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomAnimalRight", startDelay, spawnInterval);
    }
    void Update()
    {      
    }
    void SpawnRandomAnimalTop()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        float spawnPositionX = Random.Range(-20, 20);
        GameObject animal = animalPrefabs[animalIndex];
        Vector3 spawnPosition = new Vector3(spawnPositionX, 0, 20);
        animal.transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
        Instantiate(animal, spawnPosition, animal.transform.rotation);
    }
    void SpawnRandomAnimalRight()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        float spawnPositionZ = Random.Range(-13, 13);
        GameObject animal = animalPrefabs[animalIndex];
        Vector3 spawnPosition = new Vector3(25, 0, spawnPositionZ);
        animal.transform.eulerAngles = new Vector3(0.0f, 270.0f, 0.0f);
        Instantiate(animal, spawnPosition, animal.transform.rotation);
    }
}
