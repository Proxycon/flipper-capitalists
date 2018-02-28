using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//SCRIPT FOR DISPALYING SCORE
public class ShowPonits : MonoBehaviour {
	public GameObject player;
	private Text text;          // text field
	private string pName;       // player name

    // assings components
    void Start () {
		text = gameObject.GetComponent<Text>();
		pName = player.GetComponent<PlayerPoints>().getName();
        print(pName);
	}

    // showing player points in text field
	void Update () {
		text.text = pName + ": " + player.GetComponent<PlayerPoints>().getPoints() + "€";
	}
}
