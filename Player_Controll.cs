using UnityEngine;

//SCRIPT FOR PALYER CONTROLL AND INPUT HANDLING
public class Player_Controll : MonoBehaviour {

    public float TurnSpeed = 180f;              
    public int PlayerID;

    // input axis
    private string h_TurnAxisName;
    private float h_TurnInputValue;
    private string v_TurnAxisName;
    private float v_TurnInputValue;
    private float rotationX = 0f;
    private float rotationY = 0f;

    private float nextFire;             
    private GameObject[] shots;  

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;              // shot cooldown


    private void OnEnable()
    {
        h_TurnInputValue = 0f;
        v_TurnInputValue = 0f;
    }

    private void Start()
    {

        // input for player 1
        if (PlayerID == 1)
        {
            h_TurnAxisName = "Horizontal1";
            v_TurnAxisName = "Vertical1";
        }
        
        // input for player 2
        else
        {
            h_TurnAxisName = "Horizontal2";
            v_TurnAxisName = "Vertical2";
        }


    }
    
    // shooting the ball for player 1 and 2
    private void Update()
    {
        h_TurnInputValue = Input.GetAxis(h_TurnAxisName);
        v_TurnInputValue = Input.GetAxis(v_TurnAxisName);

     
        if (Input.GetButton("Fire1") && Time.time > nextFire && PlayerID == 1)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }

        if (Input.GetButton("Fire2") && Time.time > nextFire && PlayerID == 2)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }


        shotLimit();
    }

    // limitig shots on screne to 3 balls per player
    void shotLimit()
    {
        shots = GameObject.FindGameObjectsWithTag("Ball" + PlayerID.ToString());

        if (shots.Length > 3)
        {
            shots[0].GetComponent<destroyBall>().DestroyBall();
        }
    }

    private void FixedUpdate()
    {
        Turn();
    }

    // movement of the players (restricted)
    private void Turn()
    {
        rotationX += v_TurnInputValue * TurnSpeed * Time.deltaTime;
        rotationX = Mathf.Clamp(rotationX, -60, 60);

        rotationY += h_TurnInputValue * TurnSpeed * Time.deltaTime; ;
        rotationY = Mathf.Clamp(rotationY, -60, 60);

        transform.localEulerAngles = new Vector3(rotationX, rotationY, transform.localEulerAngles.z);
    }
}
