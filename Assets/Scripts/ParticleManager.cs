using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour {
	[SerializeField]
	private GameObject particleSystemPrefab;
	[SerializeField]
	private CubeMover[] cubes;
	[SerializeField]
	private GameObject[] particles;

	private bool initReady = false;

	void Init () {
		cubes = Object.FindObjectsOfType<CubeMover> ();
		particles = new GameObject[cubes.Length];
		insertParticle ();
	}
	
	// Update is called once per frame
	void Update () {
		if (CubeManager.startReady) {
			if (!initReady) {
				Init ();
				initReady = true;
			}
			for (int i = 0; i < cubes.Length; i++) {
				particles [i].transform.position = cubes [i].transform.position;
			}
		}
	}

	void insertParticle(){
		for (int i = 0; i < cubes.Length; i++) {
			particles [i] = Instantiate (particleSystemPrefab) as GameObject;
		}
	}

}
