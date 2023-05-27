using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    public Vector2 inputVec;

    public DynamicJoystick joystic;
    
    Rigidbody2D rigid;

    public Scanner scanner;

    public GameObject deadEffect;

    Animator anim;

    bool isDead = false;
	private void Awake()
	{
        rigid = GetComponent<Rigidbody2D>();
        scanner = GetComponent<Scanner>();
        anim = GetComponent<Animator>();
	}

	void Start()
    {
       
    }

    void Update()
    {
        if (!GameManager.instance.isLive)
            return;

        inputVec.x = joystic.Horizontal;
        inputVec.y = joystic.Vertical;
    }

	private void FixedUpdate()
	{
        if (!GameManager.instance.isLive)
            return;

        Move();
	}


    //�����϶� �̿��ϴ� �Լ�
    void Move()
	{
        // Ű �Է°� ����ȭ * �ӵ�
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;  

        // Ű �Է´�� �����̱�
        rigid.MovePosition(rigid.position + nextVec);


    }

	private void OnCollisionStay2D(Collision2D collision)
	{
        if (!GameManager.instance.isLive)
            return;

        GameManager.instance.health -= Time.deltaTime * 10;

        if(GameManager.instance.health <0 )
		{
            for(int index = 2; index <transform.childCount; index++)
			{
                transform.GetChild(index).gameObject.SetActive(false);
			}
            if(!isDead)
			{
                AudioManager.instance.PlaySfx(AudioManager.Sfx.PDead);
                anim.SetTrigger("Dead");
                Instantiate(deadEffect, transform.position, transform.rotation);
                
                isDead = true;
                GameManager.instance.GameOver();
            }
            
            
		}
	}
}
