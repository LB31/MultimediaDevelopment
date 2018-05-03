using Leap.Unity;
using Leap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {
	private float moveHorizontal;
	private float moveVertical;

	public float speed = 5;
	public float rotationSpeed = 2;
    public float jumpPower = 10;

    LeapServiceProvider provider;
    bool LeapMotionActive = false;

    // Use this for initialization
    void Start () {
        provider = FindObjectOfType<LeapServiceProvider>();
     
    }
	
	// Update is called once per frame
	void FixedUpdate () {
      
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
            this.transform.Rotate(new Vector3(0, moveHorizontal * rotationSpeed, 0));
            this.transform.position += transform.forward * moveVertical * Time.deltaTime * speed;
        
     
            

            Frame frame = provider.CurrentFrame;
            foreach (Hand hand in frame.Hands)
             {

            Debug.DrawRay(hand.PalmPosition.ToVector3(), hand.Direction.ToVector3(), Color.red);

                Quaternion leapRotation = hand.Rotation.ToQuaternion();
           
                this.transform.Rotate(new Vector3(0, leapRotation.z * -1 * rotationSpeed, 0));
                this.transform.position += transform.forward * leapRotation.x * Time.deltaTime * speed;
                this.GetComponent<Rigidbody>().AddForce(new Vector3(0f, hand.PalmVelocity.y * jumpPower, 0f));
        }


        }
    }



