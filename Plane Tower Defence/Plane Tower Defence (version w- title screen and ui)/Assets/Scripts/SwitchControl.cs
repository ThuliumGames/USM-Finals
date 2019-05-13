using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchControl : MonoBehaviour {
	
	public Rigidbody Heli;
	public GameObject Person;
	
	public bool canLeave;
	public bool canReturn;
	
	public CamControl  CC;
	
	void Update () {
		if (SSInput.B[GetComponent<PlaneControl>().S.Player] == "Pressed" && canLeave && GetComponent<PlaneControl>().enabled) {
			GetComponent<PlaneControl>().enabled = false;
			Person.SetActive (true);
			Person.transform.position = transform.position - (transform.right*2);
			CC.ObjToFollow = Person.transform;
			Heli.isKinematic = true;
			Person.GetComponent<Rigidbody>().isKinematic = false;
		}
		if (SSInput.A[GetComponent<PlaneControl>().S.Player] == "Pressed" && canReturn) {
			GetComponent<PlaneControl>().enabled = true;
			CC.ObjToFollow = transform;
			Person.SetActive (false);
			Person.GetComponent<Rigidbody>().isKinematic = true;
			Heli.isKinematic = false;
		}
	}
}
