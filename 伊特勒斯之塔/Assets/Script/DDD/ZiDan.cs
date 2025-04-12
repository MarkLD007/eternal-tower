using System;
using UnityEngine;

public class ZiDan : MonoBehaviour
{
    public int shangHai;
    public Boolean play;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.Find("healthBar").GetComponent<HealthBar>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
            Destroy(gameObject);
        if (collision.gameObject.tag == "Enemy"&&play)
        {
            GameObject enemy = collision.gameObject;
            enemy.GetComponent<EnemyManager>().hp -= shangHai;
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player" &&play==false)
        {
            GameObject player = collision.gameObject;
            player.GetComponent<PlayerManager>().SubstanceHP -= shangHai;
               Destroy(gameObject);
            healthBar.SetHealthBar(player.GetComponent<PlayerManager>().SubstanceHP);
        }
    }
    
}
