using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Vector3 position;
    private float speed=0.005f;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            position = gameObject.transform.position;
            gameObject.transform.position = new Vector3(position.x-speed, position.y, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            position = gameObject.transform.position;
            gameObject.transform.position = new Vector3(position.x + speed, position.y, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            position = gameObject.transform.position;
            gameObject.transform.position = new Vector3(position.x, position.y + speed, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            position = gameObject.transform.position;
            gameObject.transform.position = new Vector3(position.x, position.y - speed, 0);
        }
    }
}
