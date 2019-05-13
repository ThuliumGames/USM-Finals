using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneControl : MonoBehaviour {

	public GameObject Light;
	
	float coolDownVal;
	public float coolDown;
	
	public AudioSource GunSound;
	public AudioSource BladeSound;
	
	public GameObject DirtPart;
	
	public Transform WindPart;
	
	public Stats S;
	
	void Start () {
		S = GetComponentInParent<Stats>();
	}

	void Update () {
		
		//Gun Cool Down
		coolDownVal -= Time.deltaTime;
		coolDownVal = Mathf.Clamp (coolDownVal, 0, coolDown);
		
		//Move Up And Down By Changing Mass
		if (SSInput.DUp[S.Player] == "Down") {
			GetComponent<Rigidbody>().mass -= 10*Time.deltaTime;
		}
		if (SSInput.DDown[S.Player] == "Down") {
			GetComponent<Rigidbody>().mass += 20*Time.deltaTime;
		}
		//Smooth Reset Mass
		GetComponent<Rigidbody>().mass = Mathf.Clamp(GetComponent<Rigidbody>().mass, 10, 40);
		GetComponent<Rigidbody>().mass = Mathf.Lerp (GetComponent<Rigidbody>().mass, 20.4f-Mathf.Abs(SSInput.LVert[S.Player]*2), 1*Time.deltaTime);
		
		if (GetComponent<SwitchControl>().canLeave) {
			
			WindPart.position = new Vector3 (transform.position.x, -1000, transform.position.z);
			
			//Turn Off Blade
			BladeSound.pitch = Mathf.Lerp (BladeSound.pitch, 0, 3*Time.deltaTime);
			GetComponent<Animator>().SetFloat ("Speed", Mathf.Lerp (GetComponent<Animator>().GetFloat ("Speed"), 0, 3*Time.deltaTime));
		} else {
			
			//Put Wind Particles Below Helicopter
			if (transform.position.y < 10) {
				WindPart.position = new Vector3 (transform.position.x, 0, transform.position.z);
			} else {
				WindPart.position = new Vector3 (transform.position.x, -1000, transform.position.z);
			}
			
			//Change Pitch based On Mass
			BladeSound.pitch = Mathf.Lerp (BladeSound.pitch, -((GetComponent<Rigidbody>().mass/20.4f)/2) + 1.75f, 0.75f*Time.deltaTime);
			GetComponent<Animator>().SetFloat ("Speed", Mathf.Lerp (GetComponent<Animator>().GetFloat ("Speed"), -((GetComponent<Rigidbody>().mass/20.4f)) + 2.5f, 0.75f*Time.deltaTime));
		}
		
		//All Rotation
		transform.localEulerAngles += new Vector3 (SSInput.LVert[S.Player]*25*Time.deltaTime, SSInput.LHor[S.Player]*100*Time.deltaTime, -SSInput.LHor[S.Player]*25*Time.deltaTime);
		
		//Calculate Smooth Return
		if (transform.localEulerAngles.x > 180) {
			transform.localEulerAngles = new Vector3 (Mathf.Lerp (transform.localEulerAngles.x, 360, 1*Time.deltaTime), transform.localEulerAngles.y, transform.localEulerAngles.z);
		} else {
			transform.localEulerAngles = new Vector3 (Mathf.Lerp (transform.localEulerAngles.x, 0, 1*Time.deltaTime), transform.localEulerAngles.y, transform.localEulerAngles.z);
		}
		if (transform.localEulerAngles.z > 180) {
			transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, transform.localEulerAngles.y, Mathf.Lerp (transform.localEulerAngles.z, 360, 1*Time.deltaTime));
		} else {
			transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, transform.localEulerAngles.y, Mathf.Lerp (transform.localEulerAngles.z, 0, 1*Time.deltaTime));
		}
		
		//Blade Force
		GameObject G = new GameObject();
		G.transform.position = transform.position;
		G.transform.localEulerAngles = new Vector3 (0, transform.localEulerAngles.y, 0);
		GetComponent<Rigidbody>().AddForce ((transform.up*10000*Time.deltaTime) + (G.transform.forward*SSInput.LVert[S.Player]*10000*Time.deltaTime));
		Destroy(G);
		
		//Shoot
		if (SSInput.X[S.Player] == "Down" && coolDownVal <= 0) {
			GunSound.Play();
			coolDownVal = coolDown;
			Light.SetActive(true);
			RaycastHit Hit;
			if (Physics.Raycast(Light.transform.position, Light.transform.forward, out Hit, 100)) {
				Instantiate (DirtPart, Hit.point, Quaternion.Euler (Hit.normal));
				if (Hit.collider.gameObject.tag == "Tower Base") {
					if (GetComponentInParent<Stats>().Player != Hit.collider.gameObject.GetComponent<KillThings>().TowerNumber) {
						--Hit.collider.gameObject.GetComponent<KillThings>().Health;
					}
				}
				if (Hit.collider.gameObject.GetComponentInParent<Stats>()) {
					if (Hit.collider.gameObject.GetComponentInParent<Stats>().ScrapMetal > 0) {
						--Hit.collider.gameObject.GetComponentInParent<Stats>().ScrapMetal;
						Hit.collider.gameObject.GetComponentInParent<Stats>().drop = true;
					}
				}
				if (Hit.collider.gameObject.GetComponentInParent<GiveMetal>()) {
					if (!Hit.collider.gameObject.GetComponentInParent<GiveMetal>().isMetal) {
						Hit.collider.gameObject.GetComponentInParent<GiveMetal>().drop = true;
					}
				}
			}
		} else if (coolDownVal <= coolDown/1.25f) {
			Light.SetActive(false);
		}
	}
}
