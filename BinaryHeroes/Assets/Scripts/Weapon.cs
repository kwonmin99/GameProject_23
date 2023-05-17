using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id; // 무기 ID
    public int prefabId; // 프리펩 ID
    public float damage; // 무기 데미지
    public int count; //관통력
    public float speed; // 연사속도


    float timer; // 게임시간
    Player player;


    void Awake() {
        player = GetComponentInParent<Player>();
        // player = GameManager.instance.player;
    }

    void Update() {
        switch (id){
            case 0:
                transform.Rotate(Vector3.back * speed * Time.deltaTime);
                speed = -150;
                Batch();
                break;
            default:
                timer += Time.deltaTime;

                if(timer > speed){ // 게임시간이 스피드 보다 크면 
                    timer = 2f; // 초기화하면서 발사 
                    Fire();
                }
                break;
        }
        
    }

    public void LevelUp(float damage, int count){
        this.damage = damage;
        this.count += count; // 관통

        if (id == 0)
            Batch();

        // player.BroadcastMessage("ApplyGear", SendMessageOptions.Dontrequ)
        // // Test Code
        // if (Input.GetbuttonDown("Jump")){
        //     LevelUp(10, 1); // 데미지랑 관통력
        // }
    }

    public void Init(ItemData data) {

        // Basic Set
        name = "Weapon" + data.itemId;
        transform.parent = player.transform;
        transform.localPosition = Vector3.zero;

        // Property Set
        id = data.itemId;
        // damage = data.baseDamage * Character.Damage;
        // count = data.baseCount + Character.Count;

        switch (id){
            case 0:
                speed = -150;
                Batch();
                break;
            default:
                speed = 0.3f; // 연사속도, 적을수록 많이 발사
                break;
        }

        //Hang Set
        // Hand hand = player.hand[(int)data.itemType];
        // hand.spriter.sprite = data.hand;
        // hand.gameObject.SetActive(true);
    }

    void Batch() {
        for(int index=0; index < count; index++) {
            Transform bullet = null;
            
            if(index < transform.childCount){
                bullet = transform.GetChild(index);
            }

            else{
                bullet = GameManager.instance.pool.Get(prefabId).transform;
                bullet.parent = transform;
            }

            bullet.localPosition = Vector3.zero;
            bullet.localRotation = Quaternion.identity;
            
            Vector3 rotVec = Vector3.forward * 360 * index / count;
            bullet.Rotate(rotVec);
            bullet.Translate(bullet.up * 1.5f, Space.World);
            bullet.GetComponent<Bullet>().Init(damage, -1, Vector3.zero);  //.. -100 is Infinity Per
        }
    }

    void Fire(){

        if(!player.scanner.nearestTarget)
            return;

        Vector3 targetPos = player.scanner.nearestTarget.position; // 위치
        Vector3 dir = targetPos - transform.position; // 방향
        dir = dir.normalized;

        Transform bullet = GameManager.instance.pool.Get(prefabId).transform;
        bullet.position = transform.position; // 위치
        bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir); // 지정된 축을 중심으로 목표를 향해 회전
        bullet.GetComponent<Bullet>().Init(damage, count, dir); // -1 is Infinity Per
        
    }
    
}