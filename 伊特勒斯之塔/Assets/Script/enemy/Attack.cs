using System;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject attackAnimation;
    public int shanghai=60;
    private float attackTime = -1;
    private Boolean onattack = false;
    void Start()
    {
     //计时器展开碰撞检查攻击距离最近的
    }

    void Update()
    {
        onAttack();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (onattack)
            {

                GameObject player = collision.gameObject;
                player.GetComponent<PlayerManager>().SubstanceHP -= shanghai;
            }

            if (attackTime < 0&& UnityEngine.Random.Range(0, 100)>50)
            {
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                GameObject boss = gameObject.transform.parent.GameObject();
                boss.GetComponent<EnemyManager>().state = States.attack;
                boss.GetComponent<NewAnimation>().animations = attackAnimation;
                attackTime = 0;
            }
        }
      
    }
   void onAttack()
    {
        if (attackTime >= 0)
            attackTime += Time.deltaTime;
        if (attackTime >= 1.2)
        {
            onattack = true;
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }
        if (attackTime >= 1.6)
        {
            onattack = false;
            GameObject boss = gameObject.transform.parent.GameObject();
            boss.GetComponent<EnemyManager>().state = States.move;
            attackTime = -1;
        }
           

    }
   
}
