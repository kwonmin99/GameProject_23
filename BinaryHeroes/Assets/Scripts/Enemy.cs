using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    public float maxHealth;
    public RuntimeAnimatorController[] animCon;
    public Rigidbody2D target;

    bool isLive;

    Rigidbody2D rigid;
    Collider2D coll;
    SpriteRenderer spriter;
    Animator anim;
    WaitForFixedUpdate wait;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
        wait = new WaitForFixedUpdate();
    }

    void Init(SpawnData data)
    {
        anim.runtimeAnimatorController = animCon[data.spriteType];
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;
    }
    void OnEnable()
     { 
        target = GameManager.instance.player.GetComponent<Rigidbody2D>(); // 자기 스스로 타깃을 추가
        
        isLive = true;
        coll.enabled = true;
        rigid.simulated = true;
        spriter.sortingOrder = 2;
        anim.SetBool("Dead", false);
        health = maxHealth;
    }

    void FixedUpdate()
    {
        if (!isLive || anim.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
            return;

        Vector2 dirVec = target.position - rigid.position;
        Vector2 nexVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nexVec);
        rigid.velocity = Vector2.zero;
    }

	private void LateUpdate()
	{
        if (!isLive)
            return;

        spriter.flipX = target.position.x < rigid.position.x;
	}

    void OnTriggerEnter2D(Collider2D collision) {
        if(!collision.CompareTag("Bullet") || !isLive)
            return;

        health -= collision.GetComponent<Bullet>().damage;
        StartCoroutine(KnockBack());
        if(health > 0){
            //..살아 있을 때 힛 모션
            anim.SetTrigger("Hit"); // 애니메이터에 있도 정확히 "Hit"인지 확인
        }
        else{
            // 몬스터가 죽으면
            isLive = false;
            coll.enabled = false;
            rigid.simulated = false;
            spriter.sortingOrder = 1;
            anim.SetBool("Dead", true);
            GameManager.instance.kill++;
            GameManager.instance.GetExp();
        }
    }

    //코루틴 : 생명 주기와 비동기처럼 실행되는 함수
    IEnumerator KnockBack(){
        yield return wait; // 다음 하나의 물리 프레임 딜레이
        Vector3 platerPos = GameManager.instance.player.transform.position;
        Vector3 dirVec = transform.position - platerPos;
        rigid.AddForce(dirVec.normalized * 3, ForceMode2D.Impulse); // 넉백 크기 곱해줌
    }

    
    void Dead(){
        gameObject.SetActive(false);
    }
}
