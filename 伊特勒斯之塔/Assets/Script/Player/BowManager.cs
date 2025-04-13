using System;
using Unity.Mathematics;
using UnityEngine;

public class BowManager : MonoBehaviour
{
    public float aspeed = 1;
    public Boolean attck = true;
    GameObject weapon;
    float stime = -1;
    float arrowtime = -1;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && attck)
        {
            stime = 0;
            attck = false;
            GameObject enemy = collision.gameObject;
            Vector3 ep = enemy.GetComponent<Transform>().position;
            Vector3 wp = weapon.GetComponent<Transform>().position;
            Vector3 p = Vector3.Normalize(new Vector3(ep.x - wp.x, ep.y - wp.y, ep.z - wp.z));
            weapon.transform.eulerAngles =new Vector3(0,0, math.degrees(math.atan2(p.y, p.x)));
            weapon.GetComponent<Rigidbody2D>().AddForce(new Vector2(-p.x * 1000, -p.y * 1000));
            weapon.GetComponent<DanMu>().enabled = true;
            weapon.GetComponent<DanMu>().way = new Vector2(p.x,p.y+0.2f);
            arrowtime = 0;
        }
    }
    void Start()
    {
        weapon = gameObject.GetComponent<Transform>().parent.gameObject;

    }

    private void OnEnable()
    {
        gameObject.GetComponent<Transform>().localPosition = new Vector3(0, 0, 0);
    }
    void Update()
    {
        if (stime >= 0)
            stime += Time.deltaTime;
        if (stime >= aspeed && attck == false)
        {
            attck = true;
            stime = -1;
        }
      
        if (arrowtime >= 0)
            arrowtime += Time.deltaTime;
        if(arrowtime>0.11)
        {
            weapon.GetComponent<DanMu>().enabled = false;
            arrowtime = -1;
        }
    }
}
