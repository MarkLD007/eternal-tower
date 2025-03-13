using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerManager : MonoBehaviour
{
    States state=States.idle;
    public float AbstactHP = 100;//决定上限
    public float SubstanceHP = 100;//决定下限
    private float dynamicHP;
    public float speed = 0.01f;
    private float hurtTime = -1;
    public GameObject weaponPond;
    public GameObject animationPond;
    private Vector3 position;

    void Start()
    {
        dynamicHP = SubstanceHP;
        equip();
    }
   public void equip()
    {
        int childLength = weaponPond.transform.childCount;
        int randomChild = UnityEngine.Random.Range(0, childLength);
        weaponPond.transform.GetChild(randomChild).SetParent(gameObject.transform);
    }
   void limitHP()
    {
        if (SubstanceHP > AbstactHP)
            SubstanceHP = AbstactHP;
    }
    void Update()
    {
        limitHP();
        move();
        hurt();
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
                position = gameObject.transform.position;
                gameObject.transform.position = new Vector3(position.x - speed, position.y, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                switchAnimation(animationPond.transform.GetChild(1).GameObject());
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                position = gameObject.transform.position;
                gameObject.transform.position = new Vector3(position.x + speed, position.y, 0);
            }
            if (Input.GetKey(KeyCode.W))
            {
                switchAnimation(animationPond.transform.GetChild(1).GameObject());
                position = gameObject.transform.position;
                gameObject.transform.position = new Vector3(position.x, position.y + speed, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                switchAnimation(animationPond.transform.GetChild(1).GameObject());
                position = gameObject.transform.position;
                gameObject.transform.position = new Vector3(position.x, position.y - speed, 0);
            }
        }
    }

    void hurt()
    {
        if (hurtTime >= 0)
            hurtTime += Time.deltaTime;
        if (SubstanceHP < dynamicHP)
        {
            dynamicHP = SubstanceHP;
            state = States.hurt;
            hurtTime = 0;
            switchAnimation(animationPond.transform.GetChild(2).GameObject());
            if (hurtTime>=0.63)//animation时间
            {
                state = States.idle;
                hurtTime = -1;
            }
           
        }
    }
    void died()
    {
        if (SubstanceHP <= 0)
        {
            state = States.died;
            switchAnimation(animationPond.transform.GetChild(3).GameObject());
        }
    }
    void switchAnimation(GameObject stateAnimation)
    {
        gameObject.GetComponent<NewAnimation>().animations = stateAnimation;
    }
}
