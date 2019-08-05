using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Variables
    public float speed = 0.5f; //Go figure
    public GameObject Camera; //Reference for the camera GameObject
    //End of Variables
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            transform.position = transform.position + Camera.transform.forward * speed * Time.deltaTime;
        } else if(Input.touchCount > 0)
        {
            transform.position = transform.position + Camera.transform.forward * speed * Time.deltaTime;
        }
    }
}
