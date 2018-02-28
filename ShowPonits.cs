using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//SCRIPT FOR DISPALYING SCORE
public class ShowPonits : MonoBehaviour {
	public GameObject player;
	private Text text;          // text field

    // assings components
    void Start () {
		text = gameObject.GetComponent<Text>();
		
    }

    // showing player points in text field
	void Update () {
		text.text = player.GetComponent<PlayerPoints>().getName() + ": " + player.GetComponent<PlayerPoints>().getPoints() + "€";
	}
}
