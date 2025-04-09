using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Sword : MonoBehaviour
{
    public int shangHai;
    public int abstractHp;//Ӱ������Ѫ��
    public int substanceHp;//Ӱ������Ѫ��
    public float inSpeed;//Ӱ���ٶ�
    public HealthBar healthBar;
   
    void Start()
    {
        healthBar = GameObject.Find("healthBar").GetComponent<HealthBar>();
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
       // limit();
      
    }
  
}
