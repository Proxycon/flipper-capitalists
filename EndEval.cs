using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//SCRIPT FOR SCORE EVALUATION AND RESULT DISPLAYING IN ENDSCREEN
public class EndEval : MonoBehaviour {

	public Text t;                                 // main text field
	public Text s;                                 // score text field
	int p1p;                                       // points from player 1
	int p2p;                                       // points from player 2
    string nameP1;                                 // name from player 1
    string nameP2;                                 // name from player 2



    void Start () {
        // fetching data from previous scenes
		nameP1 = PlayerPrefs.GetString("nameP1", "Player1");
		nameP2 = PlayerPrefs.GetString("nameP2", "Player2");
		p1p = PlayerPrefs.GetInt("finalP1", 0);
		p2p = PlayerPrefs.GetInt("finalP2", 0);

        // displaying winner
		if(p1p > p2p){
			t.text = nameP1 + " WINS THE GAME!";
		}else if(p1p < p2p){
			t.text = nameP2 + " WINS THE GAME!";
		}else{
			t.text = "DRAW!";
		}
        // displaying final score
		s.text = p2p.ToString() + "€ : " + p1p.ToString()+ "€";
	}
}
