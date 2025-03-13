using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour//¹¥»÷£¬ÊÜÉË£¬¸ú×Ù£¬ËÀÍö
{
    GameObject target;
    public float HP = 100;
    public float hp = 100;
    public float speed = 0.003f;
    public States state = States.move;
    public float AttackDistace = 0.5f;
    public 
    void Start()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GengZhong();
        Attack();
    }
   void GengZhong()
    {
        Vector3 gp = gameObject.transform.position;
        Vector3 tp = target.transform.position;
        float distance = Vector3.Distance(gp, tp);
        if (distance > AttackDistace && state == States.move)
        {
            Vector3 cp = new Vector3(gp.x - tp.x, gp.y - tp.y, 0);
            Vector3 way = Vector3.Normalize(cp);
            gameObject.transform.position = new Vector3(gp.x - way.x * speed, gp.y - way.y * speed, 0);
        }
    }
   void ShouShang()
    {
        if (hp < HP)
        {
             HP= hp;
            state = States.hurt;

        }
    }
    void Attack()
    {
        Vector3 gp = gameObject.transform.position;
        Vector3 tp = target.transform.position;
        float distance = Vector3.Distance(gp, tp);
        if (distance < AttackDistace)
        {

        }
    }
}
