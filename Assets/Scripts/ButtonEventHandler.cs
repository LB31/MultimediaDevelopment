using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


public class ButtonEventHandler : MonoBehaviour, IVirtualButtonEventHandler{
    public VirtualButtonBehaviour[] buttons;
    public GameObject currentSparkle;
    public GameObject player;

    public float speed = 5;
    public float rotationSpeed = 0.1f;

    public bool leftPressed = false;
    public bool rightPressed = false;
    public bool forwardPressed = false;
    public bool bakcwardsPressed = false;


    // Use this for initialization
    void Start () {
        buttons = GetComponentsInChildren<VirtualButtonBehaviour>();

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].RegisterEventHandler(this);
        }

    }
	
	// Update is called once per frame
	void Update () {
        if(leftPressed)
            player.transform.Rotate(new Vector3(0, rotationSpeed * -1, 0));
        if (rightPressed)
            player.transform.Rotate(new Vector3(0, rotationSpeed, 0));
        if (forwardPressed)
            player.transform.position += player.transform.forward * speed;
        if (bakcwardsPressed)
            player.transform.position += player.transform.forward * speed * -1;
    }


    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        
        switch (vb.VirtualButtonName)
        {
            
            case "ButtonForwards":
                forwardPressed = true;
                break;
            case "ButtonBackwards":
                bakcwardsPressed = true;
                break;
            case "ButtonLeft":
                leftPressed = true;
                break;
            case "ButtonRight":
                rightPressed = true;
                break;
            default:
                break;
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        switch (vb.VirtualButtonName)
        {

            case "ButtonForwards":
                forwardPressed = false;
                break;
            case "ButtonBackwards":
                bakcwardsPressed = false;
                break;
            case "ButtonLeft":
                leftPressed = false;
                break;
            case "ButtonRight":
                rightPressed = false;
                break;
            default:
                break;
        }
    }


}
