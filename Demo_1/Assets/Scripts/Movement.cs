using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Variables
    public GameObject player2;
    public float speed = 1.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
        player2.transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
