using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Public Variables
    public float moveSpeed; //The speed, set in the editor
    public float rotationStepAmount; //The amount the player rotates per repeat
    public int counter; //The amount of repeats per player rotation
    //Static Variables
    public static float speed; //The actual speed
    //Private Variables
    private int preTouchCount; //The TouchCount of the last frame
    private int counterProgress = 0; //The progress of a player rotation
    private bool onTop = false; //Is the player is on the "top" of the tunnel?
    private bool tapping = false; //Records if the player tapped that frame

    void Start()
    {
        speed = moveSpeed;
        counterProgress = counter;
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
        //Update "starts" here
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
        if(counterProgress < counter)
        {
            transform.Rotate(0, 0, rotationStepAmount, Space.Self);
            counterProgress++;
        }
    }
}