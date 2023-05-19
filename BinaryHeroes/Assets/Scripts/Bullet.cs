using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Bullet : MonoBehaviour
{
    public float damage;
    public int per;

    Rigidbody2D rigid;

    void Awake() {
        rigid = GetComponent<Rigidbody2D>();
    }

    //데미지, 관통력, 방향
    public void Init(float damage, int per, Vector3 dir){
        this.damage = damage;
        this.per = per;

        if (per >= 0){
            rigid.velocity = dir * 15f; // 속력 곱해서 총알 날아가는 속도 증가
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(!collision.CompareTag("Enemy") || per == -100) //-100
            return;

        per--; // 관통력 줄여줌

        if(per < 0){
            rigid.velocity = Vector2.zero;
            gameObject.SetActive(false);
        }
    }

    //area 밖에 나가면 투사체 제거
    void OnTriggerExit2D(Collider2D collision) {        
        if(!collision.CompareTag("Area") || per == -100)
            return;
        
        gameObject.SetActive(false);
    }
}
