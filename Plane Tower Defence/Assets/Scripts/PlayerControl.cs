using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	
	public Transform Cam;
	public int PlayerHealth;
	int MaxHealth;
	public Vector3 SpawnPoint;
	
	public Stats S;
	
	void Start () {
		S = GetComponentInParent<Stats>();
		MaxHealth = PlayerHealth;
	}
	
	void Update () {
		
		GetComponent<Rigidbody>().velocity = (transform.forward * (new Vector2(SSInput.LVert[S.Player], SSInput.LHor[S.Player]).magnitude*10*Time.deltaTime)) + new Vector3 (0, GetComponent<Rigidbody>().velocity.y, 0);
		if (new Vector2 (GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.z).magnitude > 0.05f) {
			transform.localEulerAngles = new Vector3 (0, Cam.eulerAngles.y + (Mathf.Atan2(SSInput.LHor[S.Player], SSInput.LVert[S.Player])*Mathf.Rad2Deg), 0);
			GetComponent<Animator>().SetBool("Moving", true);
		} else {
			GetComponent<Animator>().SetBool("Moving", false);
		}
	}

	public void GetsHit() {
		PlayerHealth--;
		if (PlayerHealth <= 0) {
			transform.position = SpawnPoint;
			transform.LookAt(new Vector3(0, 0, 0), transform.up);
			PlayerHealth = MaxHealth;
		}
	}
}
