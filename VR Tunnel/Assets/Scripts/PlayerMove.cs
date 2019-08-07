using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public static float speed;
    private int preTouchCount;
    private bool tapping = false;
    // Start is called before the first frame update
    void Start()
    {
        speed = moveSpeed;
    }

    // Update is called once per frame
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
            Debug.Log(Input.touchCount);
        }
    }
}
