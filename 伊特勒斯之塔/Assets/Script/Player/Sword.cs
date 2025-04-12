
using Unity.VisualScripting;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public int shangHai;
    public int abstractHp;//影响上限血量
    public int substanceHp;//影响下限血量
    public float inSpeed;//影响速度
    public HealthBar healthBar;
   
    void Start()
    {
        if (gameObject.name == "sword-1")
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(100, 100);

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
            player.GetComponent<Rigidbody2D>().drag +=inspeed;
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
      
    }
  
}
