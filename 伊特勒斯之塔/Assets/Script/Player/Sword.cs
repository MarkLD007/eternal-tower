using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Sword : MonoBehaviour
{
    public int shangHai;
    public float aspeed;
    public int abstractHp;//影响上限血量
    public int substanceHp;//影响下限血量
    public float inSpeed;//影响速度
    public HealthBar healthBar;
   
    void Start()
    {
        healthBar = GameObject.Find("healthBar").GetComponent<HealthBar>();
    }
    
    void Attack()
    {

        if (Input.GetMouseButton(0))
        {
            gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(aspeed, aspeed));
        }
     
        if (Input.GetMouseButton(1))
        {
          gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-aspeed, -aspeed));
        }
           
                 }
    private void OnTriggerEnter2D(Collider2D collision)
    {
     
         if (collision.gameObject.tag == "Enemy")
        {
            GameObject enemy = collision.gameObject;
            enemy.GetComponent<EnemyManager>().hp -= shangHai;
            GameObject player = gameObject.transform.parent.GameObject();
            player.GetComponent<PlayerManager>().SubstanceHP += substanceHp;
            healthBar.SetHealthBar(player.GetComponent<PlayerManager>().SubstanceHP);
        }
    }
    void InfluencePLayer(int abstracthp, float inspeed)
    {
        GameObject player = gameObject.transform.parent.GameObject();
        if (player.name == "Player")
        {
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
