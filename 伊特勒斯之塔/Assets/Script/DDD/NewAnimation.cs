
using UnityEngine;

public class NewAnimation : MonoBehaviour
{
    public GameObject animations;
    private float timer=0;
    private int xuhao=0;
    private string huanchun="0";


    void Update()
    {
        act();
    }
    void act()
    {
        if (huanchun != animations.name||huanchun=="0")//·ÀÖ¹Í»È»ÇÐ»»×´Ì¬µ¼ÖÂchildcount²»Í¬
            xuhao = 0;
        timer += Time.deltaTime;
        if (timer >= animations.transform.localEulerAngles.z)
        {
            if (xuhao == animations.transform.childCount)
                xuhao = 0;
            timer = 0;
            Sprite sprite = animations.transform.GetChild(xuhao).GetComponent<SpriteRenderer>().sprite;
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
            xuhao++;
        }
        huanchun = animations.name;
    }
}
