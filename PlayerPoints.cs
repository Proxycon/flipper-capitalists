using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SCRIPT FOR HANDLING PLAYER SCORE DATA
public class PlayerPoints : MonoBehaviour {
	private int points;
	public int playerId;
	private string pName;        // player name

	void Start () {
        points = 0;
        // fetching player names
		if(playerId == 1){
            pName = PlayerPrefs.GetString("nameP1", "Player1");
		}
        else if (playerId == 2){
            pName = PlayerPrefs.GetString("nameP2", "Player2");
            print("palyer 2 identified as" + pName);
		}
        //print(pName);
	}

    // returns player points - can be called by other scripts
	public int getPoints(){
		return points;
	}

    // adding points - can be called by other scripts
	public void addPoints(int added){
         points += added;
	}

    // returns player name - can be called by other scripts
	public string getName(){
		return pName;
	}
}
