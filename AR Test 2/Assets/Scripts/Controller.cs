using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    //Variables
    public float speed = 1f;
    public GameObject spawn_1;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }
    void OnTriggerEnter(Collider gate)
    {
        if(gate.gameObject.tag == "Gate_1")
        {
            transform.position = spawn_1.transform.position;
        }
    }
}
