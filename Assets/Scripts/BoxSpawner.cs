using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private GameObject BoxToSpawn;
    [SerializeField] private float xPos;
    [SerializeField] private float minSpawnDelay = 0.2f;
    [SerializeField] private float maxSpawnDelay = 1.0f;

    [SerializeField] private bool spawn = true;
    private bool spawnerCoroutine = true;


    void Start() {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner(){
        while(spawnerCoroutine){
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            if(spawn){
                SpawnBox();
            }
        }
    }

    private void SpawnBox(){
        if(!BoxToSpawn){ Debug.Log("Could not find Box to spawn GameObject/Prefab"); return; }                               

        xPos = Random.Range((float) -7.5, (float)8.5); //x: -7, 7(inclusive); y: 6; z: 1
        GameObject newCube =  Instantiate(BoxToSpawn, new Vector3(xPos, 6, 1), Quaternion.identity) as GameObject;
        newCube.transform.parent = transform;
    }

    
    public void StopSpawnerCoroutine() => spawnerCoroutine = false;
    public void StopSpawning() => spawn = false;
    public void StartSpawning() => spawn = true;
}
