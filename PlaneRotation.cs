using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SCRIPT FOR ROTATING LEVEL PLANE
public class PlaneRotation : MonoBehaviour {

    public GameObject timer;
    public bool rotateRandom;
    public bool rotateStandard;
    public float turnSpeed = 2f;

    int rotationGoal = 0;
    int rotationDirection = 1;
    private bool doIt = false;


    void Update()
    {
        if (rotateStandard)
        {
            int s = timer.GetComponent<Timer>().getTime();
            if (s >= 15 && s < 30)
            {
                if (transform.rotation.eulerAngles.y <= 90f) transform.Rotate(Vector3.up, turnSpeed);
            }

            else if (s >= 30 && s < 45)
            {
               // print("2nd turn" + transform.rotation.eulerAngles.y);
              

                if (transform.rotation.eulerAngles.y <= 91f) transform.Rotate(Vector3.down, turnSpeed);
            }

            else if (s >= 45)
            {
               // print("3rd turn");
                if (transform.rotation.eulerAngles.y >= 270f) transform.Rotate(Vector3.down, turnSpeed);
            }


        }

        else if (rotateRandom)
        {
            if (doIt) transform.Rotate(0, rotationDirection * turnSpeed * Time.deltaTime, 0);
            if ((rotationGoal - 5 <= transform.rotation.eulerAngles.y && transform.rotation.eulerAngles.y <= rotationGoal + 5) && doIt)
            {
                //print("Stopped!");
                doIt = false;
            }
            if (((rotationGoal + 25 >= transform.rotation.eulerAngles.y && transform.rotation.eulerAngles.y >= rotationGoal + 5) && doIt) || (rotationGoal - 5 >= transform.rotation.eulerAngles.y && transform.rotation.eulerAngles.y >= rotationGoal - 25) && doIt) turnSpeed = 5;
            if (timer.GetComponent<Timer>().getTime() % 10 == 0 && Time.frameCount % 60 == 0) rotatePlane();
        }

    }
    public void setStuff(int goal, int dir)
    {
        print("new Goal " + goal.ToString());
        print(dir);
        rotationGoal = goal;
        rotationDirection = dir;
    }
    void rotatePlane()
    {
        print("Rotate!");
        turnSpeed = 50;
        int goal = Random.Range(-1, 1) * 90;
        int dir;
        int diff = (goal + 180) - ((int) transform.rotation.eulerAngles.y + 180);
        if (diff > 0) dir = 1;
        else if (diff == 0) dir = 0;
        else dir = -1;
        doIt = true;

        setStuff(goal, dir);

    }
}
