using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMove : MonoBehaviour
{

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(Time.deltaTime * speed, 0, 0);
        if (transform.position.x <= -20)
        {
            transform.position = new Vector3(20, transform.position.y, 1);
        }
    }
}
