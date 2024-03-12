using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiderSpawnerScript : MonoBehaviour
{
    private Singleton _singletonManager;
    private RaiderScript _raiderScript;

    public Transform[] spawnLocations;
    public GameObject[] raidersPrefab;
    public GameObject raiderSpawnedPrefab;
    public Transform raiderHolder;

    private bool canSpawn = true;

    public float maxTime = 5.0f;
    private float timer = 0.0f;


    void Start() {
        _singletonManager = Singleton.Instance;
    } //-- start end

    void Update() {
        
    } //-- Update end

    void FixedUpdate() {
        if (canSpawn) {
            canSpawn = false;
            
            SpawnRaiders();

            /*
            int spawnCount = Random.Range(2, 5);

            for(int i = 0; i < spawnCount; i++) {
                int raiderIndex = Random.Range(0, raidersPrefab.Length);
                int spawnLocIndex = Random.Range(0, spawnLocations.Length);

                GameObject raiderSpawnedPrefab = Instantiate(raidersPrefab[raiderIndex], raiderHolder);
                raiderSpawnedPrefab.transform.position = spawnLocations[spawnLocIndex].position;
            }
            */
        }
    } //-- FixedUpdate end

    private void SpawnRaiders() {
        int spawnCount = Random.Range(2, 5);

        for(int i = 0; i < spawnCount; i++) {
            int raiderIndex = Random.Range(0, raidersPrefab.Length - 1);
            int spawnLocIndex = Random.Range(0, spawnLocations.Length);

            GameObject raiderSpawnedPrefab = Instantiate(raidersPrefab[raiderIndex], raiderHolder);
            raiderSpawnedPrefab.transform.position = spawnLocations[spawnLocIndex].position;

            _raiderScript = raiderSpawnedPrefab.GetComponent<RaiderScript>();

            if(spawnLocIndex < 5)
                _raiderScript.SetDirection(false);
            else
                _raiderScript.SetDirection(true);
        }
    } //-- SpawnRaiders end

} //-- class end


/*
Project: 
Made by: 
*/

