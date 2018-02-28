using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System;

//SCRIPT FOR SCENE AND DATA MANAGEMENT
public class UIManager : MonoBehaviour {

    // game objects used in script
	public GameObject timer = null;
	public GameObject p1 = null;
	public GameObject p2 = null;

    // default player names
	private String nameP1 = "Player1";
	private String nameP2 = "Player2";

	GameObject[] pauseObjects;                                                  // all game objects only shown when paused


	void Start () {
		Time.timeScale = 1;                                                     // default game state: running
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");        // collecting all gameObjects that should only be displayed when game is paused by tag
		hidePaused();                                                           // hide said elements
	}

	void Update () {
        //uses the p button to pause and unpause the game (only possible during the actual game)
        if (SceneManager.GetActiveScene().name == "FlippBall"){
			if(Input.GetKeyDown(KeyCode.P))
			{
				if(Time.timeScale == 1)               // if game is running --> pause game
				{
					Time.timeScale = 0;               // pause game time
					showPaused();                     // show pause menu elements 
				} else if (Time.timeScale == 0){      // if game is paused --> unpause
					Time.timeScale = 1;               // continue game time
					hidePaused();                     // hide pause menu elements 
                }
			}

            // quits scene and loads scene "EndScreen" if timer runs over 60 seconds ( or key "Q" is pressed - for debugging purposes only)
            else if ((timer.GetComponent<Timer>().getTime() >= 60 || Input.GetKeyDown(KeyCode.Q))){
                //fetching player points from components
				var p1p = p1.GetComponent<PlayerPoints>().getPoints();
				var p2p = p2.GetComponent<PlayerPoints>().getPoints();
                // providing player points for next scene
				PlayerPrefs.SetInt( "finalP1", p1p);
				PlayerPrefs.SetInt( "finalP2", p2p);
       
				LoadLevel("EndScreen");                // load scene "EndScreen"
            }
		}
	}

	//shows objects with ShowOnPause tag
	public void showPaused(){
		foreach(GameObject g in pauseObjects){
			g.SetActive(true);
		}
	}

	//hides objects with ShowOnPause tag
	public void hidePaused(){
		foreach(GameObject g in pauseObjects){
			g.SetActive(false);
		}
	}

	//loads a certain level - also called by other scripts
	public void LoadLevel(string level){
        //if in title screen set player names
        if (SceneManager.GetActiveScene().name == "TitleScreen"){
            setNames();
		}

		SceneManager.LoadScene(level);
	}

    // providing player names given by user for coming scenes
    public void setNames(){
		nameP2 = GameObject.Find("TextP1").GetComponent<Text>().text;
		nameP1 = GameObject.Find("TextP2").GetComponent<Text>().text;
        PlayerPrefs.SetString( "nameP1", nameP1);
		PlayerPrefs.SetString( "nameP2", nameP2);
        print(PlayerPrefs.GetString("nameP2", "Player2"));
	}

    // quits application - called by other scripts
	public void quit(){
		Application.Quit();
	}
}
