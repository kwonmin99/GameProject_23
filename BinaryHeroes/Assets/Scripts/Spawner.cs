using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public SpawnData[] spawnData;

    int level;
    float timer;

    void Awake(){
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    void Update(){
        timer += Time.deltaTime; //한 프레임이 소비한 시간을 계속 더함 ,, 결국 게임 시간이 나오게 됨
        level = Mathf.FloorToInt(GameManager.instance.gameTime / 10f);

        
        if(timer > (level == 0 ? 0.5f : 0.2f)){
            timer = 0;
            Spawn();
        }
    }
    void Spawn(){

        //유튜브에서는 이렇게하는데 이렇게 하면 오류남
        // GameObject enemy = GameManager.instance.pool.Get(level);
        // enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)];

        
        GameObject enemy = GameManager.instance.pool.Get(level);
        Transform spawnTransform = spawnPoint[Random.Range(1, spawnPoint.Length)];
        enemy.transform.position = spawnTransform.position;
    }
}

// 직렬화
[System.Serializable]
public class SpawnData
{
    public float spawnTime; // 소환시간
    public int spriteType; // 스프라이트 타입
    public int health; // 체력
    public float speed; // 속도
}
