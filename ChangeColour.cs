using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SCRIPT FOR BUILIDNG MANAGEMENT - KARMA LEVEL, POINT GENERATION, COLOR CHANGE
public class ChangeColour : MonoBehaviour {

    private Renderer rend;
    public GameObject p1;
    public GameObject p2;
    private int karmaLevel = 0;
    private int pointsPlayer1 = 0;
    private int pointsPlayer2 = 0;

    public int buildingValue = 1;


    private void Start()
    {
        p1 = GameObject.Find("Player1");
        p2 = GameObject.Find("Player2");
        rend = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.name == "ball_1(Clone)")   // if hit by shot from player 1:
        {
            print("Player1 hit building");  
            karmaLevel += 1;                        // increases the karma level of the hit building by one
            print(karmaLevel);
        }
        else if (col.collider.name == "ball_2(Clone)") // if hit by shot from player 2:
        {
            karmaLevel -= 1;                        // decreases the karma level of the hit building by one
            print("Player2 hit building");  
        }

        if (karmaLevel > 0)                         // changes colour of buildings to blue(player1), if hit from a ball
        {       
            for (int i = 0; i < rend.materials.Length; ++i) rend.materials[i].color = new Color(0.066F, 0.622F, 0.897F, 1.000F);
        }        
        else if (karmaLevel < 0)                    // changes colour of buildings to orange(player2), if hit from a ball
        {
            for (int i = 0; i < rend.materials.Length; ++i) rend.materials[i].color = new Color(0.963F, 0.503F, 0.120F, 1.000F);
        }
        else                                        // sets colour to grey if karmaLevel in 0
        {
            for (int i = 0; i < rend.materials.Length; ++i) rend.materials[i].color = Color.grey;
        }
    }

    private void Update()
    {
        if (Time.timeScale == 1)
        {
            // generating points for player 1
            if (karmaLevel > 0)
            {
                print("adding point to " + p1.name);
                pointsPlayer1 += buildingValue;
                p1.GetComponent<PlayerPoints>().addPoints(buildingValue);

            }
            // generating points for player 2
            if (karmaLevel < 0)
            {
                pointsPlayer2 += buildingValue;
                p2.GetComponent<PlayerPoints>().addPoints(buildingValue);
            }
        }
    }


}
