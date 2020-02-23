using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] mygameObjects;
    public bool stopSpawning = false;
    public bool Spawn = false;
    public float spawnTime;
    public float spawnDelay;
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }
    // void Awake()
    // {
    // }

    public void SpawnObject() {
        float arrayLen = mygameObjects.Length;
        int i = (int)Random.Range(0f, arrayLen);
        Instantiate(mygameObjects[i], transform.position, transform.rotation);
        if (stopSpawning)
            CancelInvoke("SpawnObject");
    }
    // Update is called once per frame
    void Update()
    {
        if (Spawn) {
            InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
            Spawn = false;
        }
        
    }
}
