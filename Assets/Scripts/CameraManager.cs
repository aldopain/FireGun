using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
	public Transform target;
	Vector3 diff;

	void Start () {
		diff = transform.position - target.position;
	}

	// Update is called once per frame
	void Update () {
		transform.position = target.position + diff;
	}
}