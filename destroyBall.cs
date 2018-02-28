using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SCRIPT FOR BALL MANAGEMENT
public class destroyBall : MonoBehaviour {

    public float maxLifeTime;                                // can be changed in inspector

    // destroys ball after maxLifeTime
    private void Start()
    {
        Destroy(gameObject, maxLifeTime);
    }

    // destroys ball if beneath plane
    private void Update()
    {
        if (gameObject.transform.position.y < -1.0f)
        {
            DestroyBall();
        }
    }

    // destroys ball - can be called by other scripts
    public void DestroyBall()
    {
        Destroy(gameObject);
    }
}