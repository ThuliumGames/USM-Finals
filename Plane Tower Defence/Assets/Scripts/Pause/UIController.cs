﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {
    [SerializeField] private SettingsPopup settingsPopup;
    [SerializeField] private PlaneControl plane;
    

    public void OnOpenSettings() {
		settingsPopup.Open ();
    }
		
	void Start () {
        settingsPopup.Close ();
	}

	public void Resume(){
		settingsPopup.Close ();
	}

	public void Restart(){
        SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

    public void Quit(){
        Application.Quit();
    }

}
