using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Public Variables
    public GameObject tunnel; //The tunnel (so it can be moved)
    public GameObject hurdle; //The hurdle prefab
    public GameObject itemBox; //The item box prefab
    public float moveSpeed; //The speed, set in the editor
    public float rotationStepAmount; //The amount the player rotates per repeat
    public int counter; //The amount of repeats per player rotation
    //Static Variables
    public static float speed; //The actual speed
    //Private Variables
    private int preTouchCount; //The TouchCount of the last frame
    private float placeTimer; //The time inbetween objects
    private bool readyToPlace = false; //Is the object ready to place?
    private int placeType; //What is the object getting placed going to be?
    private int placeLocation; //Where is the object getting placed?
    private int counterProgress = 0; //The progress of a player rotation
    private bool onTop = false; //Is the player is on the "top" of the tunnel?
    private bool tapping = false; //Records if the player tapped that frame
    private int lives = 5; //Lives remaining, must be 5
    private int invincibilityTime = 0;
    private Quaternion sideRotation = new Quaternion(0, 0, 90, 90);

    void Start()
    {
        speed = moveSpeed;
        counterProgress = counter;
        Application.targetFrameRate = 30;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(invincibilityTime == 0)
        {
            if(collision.gameObject.tag == "Ouch")
            {
                Destroy(collision.gameObject);
                Debug.Log("ouch");
                if(lives != 0)
                {
                    lives--;
                    transform.position -= new Vector3(0, 0, 2);
                    invincibilityTime = 75;
                } else {
                    Debug.Log("mega ouch");
                    invincibilityTime = 0;
                }
            }
        }
    }

    void Update()
    {
        //Checking if it's tapping
        if(tapping)
        {
            tapping = false;
        } else if(preTouchCount != Input.touchCount)
        {
            if(preTouchCount == 0)
            {
                tapping = true;
            }
        }
        preTouchCount = Input.touchCount;
        if(lives != 0)
        {
            //Update "starts" here
            if(invincibilityTime != 0) // Invincibility
            {
                invincibilityTime--;
            }
            tunnel.transform.position += Vector3.forward * speed * Time.deltaTime; //Gravity flipper pt. 1
            if(Input.GetKeyDown(KeyCode.Space) || tapping)
            {
                if(counterProgress == counter)
                {
                    counterProgress = 0;
                    if(onTop)
                    {
                        Physics.gravity = new Vector3(0, -9.81f, 0);
                        onTop = false;
                    } else {
                        Physics.gravity = new Vector3(0, 9.81f, 0);
                        onTop = true;
                    }
                }
            }
            if(!readyToPlace)
            {
                placeType = Random.Range(0, 4);
                placeLocation = Random.Range(0, 4);
                placeTimer = tunnel.transform.position.z + Random.Range(20, 35);
                readyToPlace = true;
                Debug.Log("Type: " + placeType + " side: " + placeLocation);
            }
            if(tunnel.transform.position.z >= placeTimer)
            {
                if(placeType == 0 || placeType == 1 || placeType == 2)
                {
                    if(placeLocation == 0)
                    {
                        Instantiate(hurdle, new Vector3(0, -1.125f, tunnel.transform.position.z + 300), Quaternion.identity);
                    } else if(placeLocation == 1) {
                        Instantiate(hurdle, new Vector3(0, 1.125f, tunnel.transform.position.z + 300), Quaternion.identity);
                    } else if(placeLocation == 2) {
                        Instantiate(hurdle, new Vector3(-1.125f, 0, tunnel.transform.position.z + 300), sideRotation);
                    } else {
                        Instantiate(hurdle, new Vector3(1.125f, 0, tunnel.transform.position.z + 300), sideRotation);
                    }

                } else {
                    if(placeLocation == 0)
                    {
                        Instantiate(itemBox, new Vector3(0, -1.125f, tunnel.transform.position.z + 300), Quaternion.identity);
                    } else if(placeLocation == 1) {
                        Instantiate(itemBox, new Vector3(0, 1.125f, tunnel.transform.position.z + 300), Quaternion.identity);
                    } else if(placeLocation == 2) {
                        Instantiate(itemBox, new Vector3(-1.125f, 0, tunnel.transform.position.z + 300), sideRotation);
                    } else {
                        Instantiate(itemBox, new Vector3(1.125f, 0, tunnel.transform.position.z + 300), sideRotation);
                    }
                }
                readyToPlace = false;
            }
        }
        if(counterProgress < counter) //Gravity flipper pt. 2
        {
            transform.Rotate(0, 0, rotationStepAmount, Space.Self);
            counterProgress++;
        }
    }
}