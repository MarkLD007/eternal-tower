using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    States state=States.idle;
    public int AbstactHP = 100;//决定上限
    public int SubstanceHP = 100;//决定下限
    private int DynamicHP;
    public float speed = 0.01f;
    private float hurtTime = -1;
    private float diedTime = -1;
    public GameObject HPbar;
    public GameObject weaponPond;
    public GameObject animationPond;
    private int swordXuho = 0;
    private Vector3 position;
    private Rigidbody2D rigid;

    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        DynamicHP = SubstanceHP;
    }
    public void equip(int xuhao=-1)
    {
        if (xuhao == -1)
        {
            int childLength = weaponPond.transform.childCount;
            int randomChild = UnityEngine.Random.Range(0, childLength);
            GameObject weapon = GameObject.Instantiate(weaponPond);
            GameObject sword = weapon.transform.GetChild(randomChild).GameObject();
            sword.transform.SetParent(gameObject.transform);
            sword.GetComponent<DistanceJoint2D>().enabled = true;
            sword.GetComponent<DistanceJoint2D>().connectedBody = gameObject.GetComponent<Rigidbody2D>();
            sword.transform.localPosition = new Vector3(0, 0, 0);

            Destroy(weapon);
        }
        else
        {
            int childLength = weaponPond.transform.childCount;
            GameObject weapon = GameObject.Instantiate(weaponPond);
            GameObject sword = weapon.transform.GetChild(xuhao).GameObject();
            sword.transform.SetParent(gameObject.transform);
            sword.GetComponent<Joint2D>().enabled = true;
            sword.GetComponent<Joint2D>().connectedBody = gameObject.GetComponent<Rigidbody2D>();
            sword.transform.localPosition = new Vector3(0,0.5f,0);

            Destroy(weapon);
        }
    }
   void limitHP()
    {
        if (SubstanceHP > AbstactHP)
            SubstanceHP = AbstactHP;
        if (SubstanceHP > DynamicHP)
            DynamicHP = SubstanceHP;
          
    }
 void limitPosition()
    {
        if (math.abs(gameObject.transform.localPosition.x) > 465 || math.abs(gameObject.transform.localPosition.y) > 225)
            gameObject.transform.position = new Vector3(UnityEngine.Random.Range(-465, 465), UnityEngine.Random.Range(-225, 225), 0);
    }
    void Update()
    {
        limitHP();
        limitPosition();
        switchSword();
        move();
        hurt();
        died();
    }
  
    void switchSword()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            int swordNum = gameObject.transform.childCount;
            if (swordXuho >= swordNum)
                swordXuho = 0;
            for (int i = 0; i < swordNum; i++)
                gameObject.transform.GetChild(i).GameObject().SetActive(false);
            gameObject.transform.GetChild(swordXuho).GameObject().SetActive(true);
            swordXuho++;
        }
    }
    void move()
    {
        if (state == States.idle)
        {
            switchAnimation(animationPond.transform.GetChild(0).GameObject());
            if (Input.GetKey(KeyCode.A))
            {
                switchAnimation(animationPond.transform.GetChild(1).GameObject());
                gameObject.GetComponent<SpriteRenderer>().flipX = true;

                rigid.velocity = new Vector2(-speed, rigid.velocity.y);
            }
            if (Input.GetKey(KeyCode.D))
            {
                switchAnimation(animationPond.transform.GetChild(1).GameObject());
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                rigid.velocity = new Vector2(speed, rigid.velocity.y);
            }
            if (Input.GetKey(KeyCode.W))
            {
                switchAnimation(animationPond.transform.GetChild(1).GameObject());
                rigid.velocity = new Vector2(rigid.velocity.x,speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                switchAnimation(animationPond.transform.GetChild(1).GameObject());
                rigid.velocity = new Vector2(rigid.velocity.x, -speed);
            }
        }
    }

    void hurt()
    {
        if (hurtTime >= 0)
            hurtTime += Time.deltaTime;
        if (SubstanceHP < DynamicHP&&SubstanceHP>1)
        {
            DynamicHP = SubstanceHP;
            state = States.hurt;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            hurtTime = 0;
            switchAnimation(animationPond.transform.GetChild(2).GameObject());
                              }
        if (hurtTime >= 0.63)//animation时间
             state = States.idle;
         
        if (hurtTime >= 2)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            hurtTime = -1;
        }
    }
    void died()
    {
        if (diedTime >= 0)
            diedTime += Time.deltaTime;
        if (SubstanceHP <= 0)
        {
            SubstanceHP = 1;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            state = States.died;
            switchAnimation(animationPond.transform.GetChild(3).GameObject());
            diedTime = 0;
                  }
        if (diedTime >= 1)
        {
            Destroy(gameObject);
            GameObject canvas = GameObject.Find("Canvas");
            if(canvas!=null)
            {
                canvas.SetActive(false);
                canvas.SetActive(true);
            }
            SceneManager.LoadScene(0);
        }
              }
    void switchAnimation(GameObject stateAnimation)
    {
        gameObject.GetComponent<NewAnimation>().animations = stateAnimation;
    }
}
