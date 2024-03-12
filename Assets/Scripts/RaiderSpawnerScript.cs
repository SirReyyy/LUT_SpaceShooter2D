using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public float maxTime = 30.0f;
    private float timer = 0.0f;


    void Start() {
        _singletonManager = Singleton.Instance;
    } //-- start end

    void Update() {
        if (timer > maxTime) {
            canSpawn = true;
            timer = 0;
        }
        timer += Time.deltaTime;
    } //-- Update end

    void FixedUpdate() {
        if (canSpawn) {
            canSpawn = false;
            SpawnRaiders();
        }
    } //-- FixedUpdate end

    private void SpawnRaiders() {
        List<Transform> tempSpawnLoc = new List<Transform>();
        int spawnCount = Random.Range(3, 8);

        for(int i = 0; i < spawnCount; i++) {
            int raiderIndex = Random.Range(0, raidersPrefab.Length);
            int spawnLocIndex = Random.Range(0, spawnLocations.Length);
            float spawnLocalScale = Random.Range(0.08f, 0.14f);

            if (tempSpawnLoc.Contains(spawnLocations[spawnLocIndex])) {
                spawnLocIndex = Random.Range(0, spawnLocations.Length - 1);
                tempSpawnLoc.Add(spawnLocations[spawnLocIndex]);
            } else {
                tempSpawnLoc.Add(spawnLocations[spawnLocIndex]);
            }

            GameObject raiderSpawnedPrefab = Instantiate(raidersPrefab[raiderIndex], raiderHolder);
            raiderSpawnedPrefab.transform.position = spawnLocations[spawnLocIndex].position;
            raiderSpawnedPrefab.transform.localScale = new Vector3(spawnLocalScale, spawnLocalScale, spawnLocalScale);

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

