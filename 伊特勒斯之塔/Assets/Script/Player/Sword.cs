using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public float shangHai;
    public float aspeed;
    public float inHp;//影响上限血量
    public float outHp;//影响下限血量
    public float inSpeed;//影响速度
    public float AttackDistace = 5f;
    private Boolean auto = true;
   
    void Start()
    {
       
    }
    void kunbang()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject enemy = collision.gameObject;
            enemy.GetComponent<EnemyManager>().hp -= shangHai;
            GameObject player = gameObject.transform.parent.GameObject();
            player.GetComponent<PlayerManager>().SubstanceHP += outHp; 
        }
    }
    void InfluencePLayer(float inhp,float inspeed)
    {
        GameObject player = gameObject.transform.parent.GameObject();
        if (player.name == "Player")
        {
            player.GetComponent<PlayerManager>().AbstactHP += inHp;
            player.GetComponent<PlayerManager>().speed+=inSpeed;
        }

    }
    private void OnEnable()
    {
        InfluencePLayer(inHp,inSpeed);
    }
    private void OnDisable()
    {
        InfluencePLayer(-inHp,-inSpeed);
    }
   
    void Update()
    {
        
    }
}
