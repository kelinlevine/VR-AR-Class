using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Variables
    public float speed = 0.5f; //The speed of our movement
    public GameObject cameraa; //Reference for the camera
    private Vector3 spawnPoint; //The respawn location
    public GameObject bounds; //Reference for the boundaries that respawn the player
    public GameObject Door; //Reference for the door
    public GameObject Key; //Reference for the key
    public bool gotKey = false; //Keeps track of if we got the key
    public bool doorUnlocked = false; //Keeps track of if the door is unlocked
    //End of Variables
    void Start() // Runs when the game starts
    {
        spawnPoint = transform.position; //Sets the respawn point to where the player starts
    }

    private void OnTriggerEnter(Collider collide) //When it hits stuff
    {
        if(collide.gameObject.tag == "Respawn")
        {
            transform.position = spawnPoint;
        } else if(collide.gameObject.tag == "Door")
        {
            doorUnlocked = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Key")
        {
            gotKey = true;
            Destroy(other.gameObject);
        }
    }
    
    void OpenDoor() //Function for when the door needs do be opened
    {
        Quaternion newRotation = Quaternion.AngleAxis(-90, Vector3.up);
        Door.transform.rotation = Quaternion.Slerp(Door.transform.rotation, newRotation, 0.05f);
        Door.tag = "Untagged";
    }

    void Update() //Runs every frame
    {
        if(doorUnlocked == true)
        {
            OpenDoor();
        }
        if(Input.GetKey(KeyCode.Space))
        {
            transform.position = transform.position + cameraa.transform.forward * speed * Time.deltaTime;
        } else if(Input.touchCount > 0)
        {
            transform.position = transform.position + cameraa.transform.forward * speed * Time.deltaTime;
        }
    }
}
