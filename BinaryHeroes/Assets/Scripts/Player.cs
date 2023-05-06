using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    public Vector2 inputVec;

    public DynamicJoystick joystic;
    
    Rigidbody2D rigid;



	private void Awake()
	{
        rigid = GetComponent<Rigidbody2D>();
	}

	void Start()
    {
       
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


    //움직일때 이용하는 함수
    void Move()
	{
        // 키 입력값 평준화 * 속도
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;  

        // 키 입력대로 움직이기
        rigid.MovePosition(rigid.position + nextVec);


    }
}
