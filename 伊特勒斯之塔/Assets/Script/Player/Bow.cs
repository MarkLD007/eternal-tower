
using Unity.VisualScripting;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public float inSpeed;//Ó°ÏìËÙ¶È
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void InfluencePLayer( float inspeed)
    {
        GameObject player = gameObject.transform.parent.GameObject();
        if (player.name == "Player")
       
            player.GetComponent<Rigidbody2D>().drag += inspeed;
        

    }
    private void OnEnable()
    {
        InfluencePLayer( inSpeed);
    }
    private void OnDisable()
    {
        InfluencePLayer(-inSpeed);
    }
    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().flipX = gameObject.transform.parent.GetComponent<SpriteRenderer>().flipX;
    }
}
