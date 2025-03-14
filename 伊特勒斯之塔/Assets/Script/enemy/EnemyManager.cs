using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    GameObject target;
    public float HP = 100;
    public float hp = 100;
    public float shanghai = 100;
    public float speed = 0.003f;
    public GameObject animationPond;
    private States state = States.move;
    private float hurtTime=-1;

    public 
    void Start()
    {
        target = GameObject.Find("Player");
    }
   
    void Update()
    {
        chasing();
        hurt();
        died();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            player.GetComponent<PlayerManager>().SubstanceHP -= shanghai;
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
        if (hp < HP)
        {
            HP = hp;
            state = States.hurt;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            hurtTime = 0;
            switchAnimation(animationPond.transform.GetChild(1).GameObject());
        }
        if (hurtTime >= 0.75)//animation ±º‰
        {
            state = States.move;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            hurtTime = -1;
        }
    }
    void died()
    {
        if (hp<=0)
        {
            state = States.died;
            switchAnimation(animationPond.transform.GetChild(2).GameObject());
            Destroy(gameObject);
          }
    }
    
}
