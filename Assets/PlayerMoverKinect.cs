using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;

public class PlayerMoverKinect : MonoBehaviour {
    private MultiSourceFrameReader multiReader;
    private KinectSensor sensor;
    private Body[] bodyData;

    public float speed = 1;
    public float rotationSpeed = 2;
    public float rotationLock = 0.8f;
    public float jumpPower = 10;

    public float startHead = 0;

    // Use this for initialization
    void Start () {
        sensor = KinectSensor.GetDefault();
        if (sensor != null)
        {
            multiReader = sensor.OpenMultiSourceFrameReader(FrameSourceTypes.Body);

            if (!sensor.IsOpen)
            {
                sensor.Open();
            }
        }

        

    }
	
	// Update is called once per frame
	void Update () {
        if (multiReader != null)
        {
            var frame = multiReader.AcquireLatestFrame();
            if(frame != null)
            {
                BodyFrame bodyFrame = frame.BodyFrameReference.AcquireFrame();
                if (bodyFrame != null)
                {
                    if(bodyData == null)
                    {
                        bodyData = new Body[bodyFrame.BodyFrameSource.BodyCount];
                    }
                    bodyFrame.GetAndRefreshBodyData(bodyData);
                    bodyFrame.Dispose();
                    bodyFrame = null;
                }
            }
            frame = null;
        }

        if (bodyData == null) return;
        int index = -1;
        for (int i = 0; i < sensor.BodyFrameSource.BodyCount; i++)
        {
            if (bodyData[i] == null) continue;
            if (bodyData[i].IsTracked) index = i;
        }


        if (index > -1)
        {
            float xPos = bodyData[index].Joints[JointType.HandLeft].Position.X;
            float yPos = bodyData[index].Joints[JointType.HandLeft].Position.Y;
            float zPos = bodyData[index].Joints[JointType.HandLeft].Position.Z;
          //  this.transform.position += transform.forward * yPos * Time.deltaTime * speed;
 


            float shoulderLeft = bodyData[index].Joints[JointType.ShoulderLeft].Position.Z;
            float shoulderRight = bodyData[index].Joints[JointType.ShoulderRight].Position.Z;
            float finalRotation = shoulderLeft > shoulderRight ? shoulderLeft * -1 : shoulderRight;
            if(Mathf.Abs(shoulderLeft - shoulderRight) > 0.1)
            this.transform.Rotate(new Vector3(0, finalRotation, 0));
            //Debug.Log(shoulderLeft + " left");
            //Debug.Log(shoulderRight + " right");


            float head = bodyData[index].Joints[JointType.Head].Position.Y;
            float spineBase = bodyData[index].Joints[JointType.SpineBase].Position.Y;
            if (Mathf.Abs(head - spineBase) < 0.7)
                this.transform.position += transform.forward * Time.deltaTime * speed;
            //Debug.Log(head + " head");
            //Debug.Log(spineBase + " spineBase");

            if (startHead == 0)
                startHead = head;
            if(head > startHead + 0.1)
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower);

            Debug.Log(head + " head");
            Debug.Log(startHead + " startHead");
        }

    }


 
}
