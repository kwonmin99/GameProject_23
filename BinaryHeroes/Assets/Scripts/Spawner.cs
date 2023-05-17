using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public SpawnData[] spawnData;

    float timer;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }


    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 0.2f)
        {
            timer = 0;
            Spawn();
        }
    }

    void Spawn()
    {
        

    }
}

[System.Serializable]
public class SpawnData
{
    public int spriteType;
}
