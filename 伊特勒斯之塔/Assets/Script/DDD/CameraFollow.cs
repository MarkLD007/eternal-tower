
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject player;
    Vector3 tp;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        tp = player.transform.position;
        gameObject.transform.position = new Vector3(tp.x,tp.y,-10);
    }
}
