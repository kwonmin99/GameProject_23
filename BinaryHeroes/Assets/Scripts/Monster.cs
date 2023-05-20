using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed;
    public RuntimeAnimatorController[] animaCon;
    public float health;
    public float maxHealth;
    public Rigidbody2D target;

    bool isLive = true;

    Rigidbody2D rigid;
    SpriteRenderer spriter;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();


    }

    void FixedUpdate()
    {
        if (!isLive)
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


    void OnTriggerEnter2D(Collider2D collison)
    {
        if (!collison.CompareTag("Bullet"))
            return;

        health -= collison.GetComponent<Bullet>().damage;
        if (health > 0)
        {
            //hit--act
        }
        else
        {
            //die
            Dead();
        }
    }
    void Dead()
    {
        gameObject.SetActive(false);
    }

}

