using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Stats_UI : MonoBehaviour {

    public Stats stats;
    public KillThings killthings; 
    public Text ScrapMetalDisplay;
    public Text AmmoDisplay;
    public Text TowerHealthDisplay;
    public Text WinLose; 

    public void Update()
    {
        ScrapMetalDisplay.text = "Scrap Metal: " + stats.ScrapMetal;
        AmmoDisplay.text = "Ammo: " + stats.Ammo;
        TowerHealthDisplay.text = "Tower Health: " + killthings.Health;

        if (GameObject.Find("Tower (" + stats.Player + ")/TowerTop") == null) 
        {
            Invoke("GameEnd", 5);

            WinLose.text = "GAME OVER";





        }
    }

    public void GameEnd ()
    {
        Application.LoadLevel("Title");
    }
}
