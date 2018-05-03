using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class AccessLeapHands : MonoBehaviour {
    LeapServiceProvider provider;


    // Use this for initialization
    void Start () {
        provider = FindObjectOfType<LeapServiceProvider>();
	}
	
	// Update is called once per frame
	void Update () {
        Frame frame = provider.CurrentFrame;
        foreach(Hand hand in frame.Hands)
        {
            if (hand.IsLeft)
            {
                Vector3 leapPosition = hand.PalmPosition.ToVector3();
                Debug.Log(leapPosition);
            }
        }
	}
}
