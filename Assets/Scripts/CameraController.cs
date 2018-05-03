using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public Transform playerPosition;
	private Vector3 offset;

	private Quaternion previous;

	// Position / offset fields
	public float leaning = 20f;
	public float distanceBehindPlayer = 2f;
	public float distanceAbovePlayer = 1.5f;

	// Use this for initialization
	void Start () {
		previous = transform.rotation;

	}
	
	// Update is called once per frame
	void Update () {
		
	
		transform.position = playerPosition.position - playerPosition.forward * distanceBehindPlayer + new Vector3 (0f, distanceAbovePlayer, 0f);
//		Debug.DrawLine (playerPosition.position, playerPosition.position + playerPosition.forward, Color.red);

		Quaternion nextRotation = Quaternion.LookRotation(playerPosition.forward) * Quaternion.Euler(leaning, 0, 0);

		transform.rotation = Quaternion.Slerp(previous, nextRotation, 0.06f);

		previous = transform.rotation;
	}











}
