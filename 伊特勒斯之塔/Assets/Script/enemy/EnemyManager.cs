using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    GameObject target;
    public int HP = 100;
    public int hp = 100;
    public int shanghai = 100;
    public float speed = 0.003f;
    public GameObject animationPond;
    public States state = States.move;
    public Boolean monster = true;
    public HealthBar healthBar;
    private float hurtTime=-1;
    private float jcTime;
    private float diedTime=-1;
    private float xsTime;

    public 
    void Start()
    {
        prepareAnimation();
        target = GameObject.Find("Player");
    }
   void  prepareAnimation()
    {
        GameObject hurtAnimation = animationPond.transform.GetChild(1).GameObject();
        jcTime = hurtAnimation.transform.rotation.eulerAngles.z * hurtAnimation.transform.childCount;
        GameObject diedAnimation = animationPond.transform.GetChild(2).GameObject();
        xsTime = diedAnimation.transform.rotation.eulerAngles.z * diedAnimation.transform.childCount;
    }
   
    void Update()
    {
        chasing();
        hurt();
        died();
    }
    
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"&&monster)
        {
            GameObject player = collision.gameObject;
            player.GetComponent<PlayerManager>().SubstanceHP -= shanghai;
            healthBar.SetHealthBar(player.GetComponent<PlayerManager>().SubstanceHP);
        }
    }
    void switchAnimation(GameObject stateAnimation)
    {
        gameObject.GetComponent<NewAnimation>().animations = stateAnimation;
    }
    void chasing()
    {
          if ( state == States.move)
        {
            switchAnimation(animationPond.transform.GetChild(0).GameObject());
            Vector3 gp = gameObject.transform.position;
            Vector3 tp = target.transform.position;
            Vector3 cp = new Vector3(gp.x - tp.x, gp.y - tp.y, 0);
            Vector3 way = Vector3.Normalize(cp);
            gameObject.transform.position = new Vector3(gp.x - way.x * speed, gp.y - way.y * speed, 0);
        }
    }
   void hurt()
    {
      
        if (hurtTime >= 0)
            hurtTime += Time.deltaTime;
        if (hp < HP&&hp>1)
        {
            HP = hp;
            state = States.hurt;
            gameObject.GetComponent<AudioSource>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            hurtTime = 0;
            switchAnimation(animationPond.transform.GetChild(1).GameObject());
        }
        if (hurtTime >= jcTime)//animationÊ±¼ä
            state = States.move;
        if (hurtTime >= 2)
        {
            gameObject.GetComponent<AudioSource>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            hurtTime = -1;
        }
    }
    void died()
    {
        if (diedTime >= 0)
            diedTime += Time.deltaTime;
        if (hp<=0)
        {
            hp = 1;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            state = States.died;
            switchAnimation(animationPond.transform.GetChild(2).GameObject());
            diedTime = 0;
        }
        if (diedTime >= xsTime)
            Destroy(gameObject);
       
    }
  
    
}
