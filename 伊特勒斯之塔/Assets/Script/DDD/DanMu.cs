
using Unity.VisualScripting;
using UnityEngine;

public class DanMu : MonoBehaviour
{
    public GameObject arrow;
    public float gaptime;
    public float shoottime;
    public float times;
    public float speed;
    public int shangHai;
    public Vector2 way;
    private float timer1 = 0;
    private float timer2 = 0;
    private float stimes = 0;
   
    void Update()
    {

        Pre();
    }
   void Pre()
    {

        if (timer1 >= 0)
            timer1 += Time.deltaTime;
        if (timer1 >= gaptime)
        {
            timer1 = -1;
            stimes = times;
        }
        if (stimes > 0)
            timer2 += Time.deltaTime;
        if (timer2 >= shoottime)
            Shoot();
    }
   void Shoot()
    {
        stimes--;
        if (stimes == 0)
            timer1 = 0;
        GameObject sarrow = GameObject.Instantiate(arrow);
        if (gameObject.tag == "Enemy")
            sarrow.transform.parent = gameObject.transform.GameObject().transform.parent;
        else
            sarrow.transform.parent = gameObject.transform.GameObject().transform.parent.GameObject().transform.parent;
        sarrow.GetComponent<ZiDan>().shangHai = shangHai;
        sarrow.transform.position = gameObject.transform.position;
        sarrow.GetComponent<Rigidbody2D>().velocity = new Vector2(way.x * speed, way.y * speed);
        timer2 = 0;
    }
}
