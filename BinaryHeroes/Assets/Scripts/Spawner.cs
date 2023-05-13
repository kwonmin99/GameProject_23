using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // public Transform[] spawnPoint;
    // public SpawnData[] spawnData;

    // int leve;
    // float timer;

    // void Awake(){
    //     spawnPoint = GetComponentInChildren<Transform>();
    // }

    // void Update(){
    //     timer += Time.deltaTime;
    //     level = Mathf.FloorToInt(GameManager.instance.gameTime / 10f);

    //     if(timer > (level == 0 ? 0.5f : 0.2f)){
    //         timer = 0;
    //         Spawn();
    //     }
    // }
    // void Spawn(){
    //     gameObject enemy = GameManager.instance.pool.Get(level);
    //     enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)];
    // }
}
//직렬화
[System.Serializable]
public class SpawnData{

    // public int spriteType; // 스프라이트 타입
    // public float spawnTime; // 소환시간
    // public int health; // 체력
    // public float speed; // 속도
}
