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
    public int distense;
    public int abstractHp;//影响上限血量
    public int substanceHp;//影响下限血量
    public float inSpeed;//影响速度
    public HealthBar healthBar;
   
    void Start()
    {
        healthBar = GameObject.Find("healthBar").GetComponent<HealthBar>();
    }
   void limit()
    {
        GameObject player = gameObject.GetComponent<Transform>().parent.gameObject;
        Vector3 mp = gameObject.GetComponent<Transform>().position;
        Vector3 pp=player.GetComponent<Transform>().position;
        Vector3 w = new Vector3(mp.x - pp.x, mp.y - pp.y, mp.z - pp.z);
        Vector2 lw = Vector3.Normalize(w);
        float angle =math.degrees( math.atan2(lw.y , lw.x));
        gameObject.GetComponent<Transform>().eulerAngles = new Vector3(0,0, angle-90);
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
