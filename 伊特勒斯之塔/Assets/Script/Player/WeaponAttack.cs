using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    public float aspeed=1;
  public  Boolean attck = true;
    GameObject weapon;
    float stime = -1;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy"&&attck)
        {
            stime = 0;
            attck = false;
            GameObject enemy = collision.gameObject;
            Vector3 ep = enemy.GetComponent<Transform>().position;
            Vector3 wp = weapon.GetComponent<Transform>().position;
            Vector3 p = new Vector3(ep.x - wp.x, ep.y - wp.y, ep.z - wp.z);
            weapon.GetComponent<Rigidbody2D>().AddForce(new Vector2(p.x * 500, p.y * 500));
            weapon.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    void Start()
    {
        weapon = gameObject.GetComponent<Transform>().parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (stime >= 0)
            stime += Time.deltaTime;
        if (stime >= 0.5 && stime <= 0.55)
        {
            weapon.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            weapon.GetComponent<BoxCollider2D>().enabled = false;
        }
         
        if (stime >= aspeed&&attck==false)
        {
            attck = true;
            stime = -1;
        }

    }
}
