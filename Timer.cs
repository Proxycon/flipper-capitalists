using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//SCRIPT FOR TIMER
public class Timer : MonoBehaviour
{
    private string timedis;              // display for game time
    private float sec;
    private int min;
    private Text text;                   // timer text field

    public bool starttime = false;       // to activate timer

    void Start()
    {
        text = gameObject.GetComponent<Text>();
        sec = 0;
        min = 0;
    }

    void Update()
    {
        // counts time only when this is true
        if (starttime == true)
        {
            // adding seconds
            sec += Time.deltaTime;
            // adding minutes
            if (Mathf.Floor(sec) >= 60)
            {
                sec = 0; min = min + 1;
            }
            // display time
            timedis = (min.ToString() + ":" + Mathf.Floor(sec).ToString());
            text.text = timedis;
        }
    }

    // returns current game time in seconds
    public int getTime(){
        return min*60 + (int)sec;
    }
}
