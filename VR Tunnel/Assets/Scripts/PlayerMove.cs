using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Public Variables
    public float moveSpeed; //The speed, set in the editor
    public float rotationSpeed; //The speed of tunnel rotation
    public GameObject Door; //The GameObject that rotates everything
    //Static Variables
    public static float speed; //The actual speed
    //Private Variables
    private int preTouchCount; //The TouchCount of the last frame
    private bool tapping = false; //Records if the player tapped that frame
    
    private int switcher = 0; 

    private int counter = 30; 

    void Start()
    {
        speed = moveSpeed;
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
        //Update "starts" here ----
        /* if(Input.GetKeyDown(KeyCode.Space) || tapping)
        {
            OpenDoor();
        }*/ 
        if(Input.GetKeyDown(KeyCode.Space) || tapping)
        {
            switcher++; 
        }
        if(switcher > 0) 
        {
            for(int i = 0; i < counter; i++)
            {
                //OpenDoor(); 
                switcher = 0; 
            }
          
        }
    }
    void OpenDoor() //Function for when the door needs do be opened
    {
        Quaternion newRotation = Quaternion.AngleAxis(-90, Vector3.up);
        Door.transform.rotation = Quaternion.Slerp(Door.transform.rotation, newRotation, 0.05f);
    }
}



    /* void AxisTurn()
    {
        Quaternion newRotation = Quaternion.AngleAxis(-10, new Vector3(1, 0, 0));
        rotationAxis.transform.rotation = Quaternion.Slerp(rotationAxis.transform.rotation, newRotation, rotationSpeed * Time.deltaTime); //Switches gravity
    } */