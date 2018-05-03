using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour {
	[SerializeField]
	private GameObject cubePrefab;

	[SerializeField]
	private int amountOfCubes = 1;

	public static bool startReady = false;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < amountOfCubes; i++){
			for(int k = 0; k < amountOfCubes; k++){
				GameObject currentCube = Instantiate (cubePrefab);
				currentCube.GetComponent<CubeMover> ().changeDirection = true;
				currentCube.transform.position = new Vector3 (k * 5f, i * 5f, 0f);
				Instantiate (cubePrefab).transform.position = new Vector3(k * 5f, i * 5f, 20f);
			}

		}
		startReady = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
