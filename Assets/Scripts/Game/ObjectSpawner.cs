using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

	public GameObject[] objects;

	// the range of X
	[Header ("X Spawn Range")]
	public float xMin;
	public float xMax;

	// the range of y
	[Header ("Y Spawn Range")]
	public float yMin;
	public float yMax;

	void Start(){
		int objAmount = Random.Range(0,4);
		for (int i = 0; i < objAmount; i++){
			spawnObject();
		}
	}

	void Update(){}

	void spawnObject(){
		Vector3 pos = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0);

		GameObject obj = objects[Random.Range(0,objects.Length)];

		Instantiate(obj, pos, Quaternion.identity);
	}

}
