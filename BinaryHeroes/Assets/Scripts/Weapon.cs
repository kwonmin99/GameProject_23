using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int prefabId;
    public float damage;
    public int count;
    public float speed;


    void Start()
    {
        Init();
    }


    void Update()
    {
        
    }
    public void Init()
    {
        switch (id)
        {
            case 0:
                speed = -150;
                Batch();

                break;

            default:
                break;
        }
    }

    void Batch()
    {
        for(int index= 0; index < count; index++)
        {
            Transform bullet = GameManager.instance.pool.Get(prefabId).tranform;
            bullet.parent = transform;
            bullet.GetComponent<Bullet>().Init(damage, -1);
        }
    }

}
