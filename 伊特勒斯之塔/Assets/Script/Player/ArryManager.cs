using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArryManager : MonoBehaviour
{
    public float Shanghai=10;
    public float speed = 1;
 
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject enemy = collision.gameObject;
            enemy.GetComponent<EnemyManager>().hp -= Shanghai;
        }
    }

    void Update()
    {
        
    }
}
