using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {
	
	public int Player;
	public int Ammo;
	public float TowerMoveTime;
	public int HeliHealth;
	public int ScrapMetal;
	public GameObject Metal;
	public bool drop;

	public GameObject TowerTop;
	public GameObject TowerSegments;
	public List <GameObject> Towers;
	public Vector3 TowerPos;
	GameObject NewTower;

	void Update () {

		if (drop) {
			GameObject G = Instantiate (Metal, transform.position+(Vector3.up*10), Quaternion.Euler (Vector3.zero));
			G.GetComponent<Rigidbody>().AddForce (Random.Range (-1000.0f, 1000.0f), Random.Range (500.0f, 1000.0f), Random.Range (-1000.0f, 1000.0f));
			G.GetComponent<Rigidbody>().AddTorque (Random.Range (-1000.0f, 1000.0f), Random.Range (-1000.0f, 1000.0f), Random.Range (-1000.0f, 1000.0f));
			drop = false;
		}

		if (SSInput.Y[Player] == "Pressed") {
			AddTower();
		}

		foreach (GameObject G in Towers) {
			//Vector3 TargetPos = G.transform.position + new Vector3(0, 4, 0);
			Vector3 TargetPos = new Vector3 (G.transform.position.x, Towers.IndexOf(G) * 4, G.transform.position.z);
			G.transform.position = TargetPos;
		}

		if (Towers.Count == 1) {
			TowerTop.tag = "Tower Base";
		} else {
			TowerTop.tag = "Untagged";
		}
	}
	public void AddTower () {
		NewTower = Instantiate(TowerSegments, TowerPos, TowerSegments.transform.rotation);
		NewTower.GetComponent<KillThings>().TowerNumber = Player;
		Towers.Insert(0, NewTower);
	}
}
