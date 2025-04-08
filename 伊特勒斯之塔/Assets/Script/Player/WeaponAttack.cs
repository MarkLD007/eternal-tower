using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    public int distense;
    public float aspeed;
    Boolean attck = true;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy"&&attck)
        {
            attck = false;
            GameObject enemy = collision.gameObject;
            GameObject weapon = gameObject.GetComponent<Transform>().parent.gameObject;
            Vector3 ep = enemy.GetComponent<Transform>().position;
            Vector3 wp = weapon.GetComponent<Transform>().position;
            Vector3 p = new Vector3(ep.x - wp.x, ep.y - wp.y, ep.z - wp.z);
          
        
        }

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        aspeed += Time.deltaTime;
        if (aspeed >= 1)
        {
            attck = true;
            aspeed = 0;

        }

    }
}
