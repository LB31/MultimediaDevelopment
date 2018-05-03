using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : MonoBehaviour {
	[SerializeField]
	private float runningTime = 0;
	[SerializeField]
	private int endTime = 2;

	public bool changeDirection = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Aufgabe 1
		runningTime += Time.deltaTime;
		if (runningTime >= endTime) {
			runningTime = 0;
			changeDirection = !changeDirection;
		}
		if (changeDirection)
			transform.position += new Vector3 (0f, 0f, 0.3f);
		else 
			transform.position -= new Vector3 (0f, 0f, 0.3f);

		// Aufgabe 3
		transform.Rotate(new Vector3 (Mathf.Cos(10), Mathf.Sin(10), 0f));

		// Aufgabe 4
		transform.Rotate(Random.Range(-0.05f, 0.05f), Random.Range(-0.05f, 0.05f), Random.Range(-0.05f, 0.05f));
	}

	// Aufgabe 2
	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.GetComponent<CubeMover>() != null)
			changeDirection = !changeDirection;
	}
}
