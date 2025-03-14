using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Sword : MonoBehaviour
{
    public float shangHai;
    public float aspeed;
    public float abstractHp;//影响上限血量
    public float substanceHp;//影响下限血量
    public float inSpeed;//影响速度
   
    void Start()
    {
       
    }
    
    void Attack()
    {
        if (Input.GetMouseButton(0))
            gameObject.GetComponent<Rigidbody2D>().AddTorque(aspeed);
        if (Input.GetMouseButton(1))
            gameObject.GetComponent<Rigidbody2D>().AddTorque(-aspeed);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject enemy = collision.gameObject;
            enemy.GetComponent<EnemyManager>().hp -= shangHai;
            GameObject player = gameObject.transform.parent.GameObject();
            player.GetComponent<PlayerManager>().SubstanceHP += substanceHp; 
        }
    }
    void InfluencePLayer(float abstracthp, float inspeed)
    {
        GameObject player = gameObject.transform.parent.GameObject();
        if (player.name == "Player")
        {
            gameObject.GetComponent<DistanceJoint2D>().connectedBody = player.GetComponent<Rigidbody2D>();
            player.GetComponent<PlayerManager>().AbstactHP += abstracthp;
            player.GetComponent<PlayerManager>().speed+=inspeed;
        }

    }
    private void OnEnable()
    {
        InfluencePLayer(abstractHp,inSpeed);
    }
    private void OnDisable()
    {
        InfluencePLayer(-abstractHp,-inSpeed);
    }
   
    void Update()
    {
        Attack();
    }
  
}
