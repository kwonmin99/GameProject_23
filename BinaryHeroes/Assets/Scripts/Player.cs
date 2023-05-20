using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    public Vector2 inputVec;

    public DynamicJoystick joystic;
    
    public Scanner scanner;
    Rigidbody2D rigid;



	private void Awake()
	{
        rigid = GetComponent<Rigidbody2D>();
        // spriter = GetComponent<SpriteRenderer>();
        // anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
	}

    void Update()
    {
        inputVec.x = joystic.Horizontal;
        inputVec.y = joystic.Vertical;
    }

	private void FixedUpdate()
	{
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
}
