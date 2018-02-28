using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SCRIPT FOR MOVING BALLS SHOT BY PLAYER
public class Mover : MonoBehaviour {

    public float speed;             // speed of ball - can be set in inspector
    private Rigidbody rb;

    // moves ball with given speed
    void Start(){
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }
}
