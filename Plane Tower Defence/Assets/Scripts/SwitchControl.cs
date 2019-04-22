using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchControl : MonoBehaviour {
	
	public Rigidbody Heli;
	public GameObject Person;
	
	public bool canLeave;
	public bool canReturn;
	
	void Update () {
		if (SSInput.B[0] == "Pressed" && canLeave) {
			GetComponent<PlaneControl>().enabled = false;
			Person.SetActive (true);
			Person.transform.position = transform.position - (transform.right*2);
			GameObject.FindObjectOfType<CamControl>().ObjToFollow = Person.transform;
			Heli.isKinematic = true;
			Person.GetComponent<Rigidbody>().isKinematic = false;
		}
		if (SSInput.A[0] == "Pressed" && canReturn) {
			GetComponent<PlaneControl>().enabled = true;
			GameObject.FindObjectOfType<CamControl>().ObjToFollow = transform;
			Person.SetActive (false);
			Person.GetComponent<Rigidbody>().isKinematic = true;
			Heli.isKinematic = false;
		}
	}
}
