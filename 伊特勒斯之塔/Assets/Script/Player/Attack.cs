using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Attack : MonoBehaviour
{
    public GameObject arry;
    public GameObject c;
    public float AttackDistace = 5f;
    private Boolean auto = true;
   
    void Start()
    {
     //计时器展开碰撞检查攻击距离最近的
    }

    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (auto&&collision.gameObject.tag == "Enemy")//定时
        {
            Vector3 gp = gameObject.transform.position;
            Vector3 tp = collision.gameObject.transform.position;
            Vector3 cp = new Vector3(gp.x - tp.x, gp.y - tp.y, 0);
            Vector3 way = Vector3.Normalize(cp);
          
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
    void SubjectAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            auto = false;
        }
        if (Input.GetMouseButtonUp(0))
        {
            auto = true;
        }
    }
}
