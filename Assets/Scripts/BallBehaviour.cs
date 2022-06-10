using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public float initialSpeed;
    public float acelerationRate;
    float whenSpawnPower;
    bool start = false;
    int rotation;
    Rigidbody rb;

    public GameObject power;
    bool hasDonePower = false;
    bool lastOneLeft = false;

    GameObject manager;
    GameObject playerRigth;
    GameObject playerLeft;

    Manager manage;
    RigthPlayerController rigthPlayer;
    LeftPlayerController leftPlayer;
    GameObject actualPow;

    void Start()
    {
        playerRigth = GameObject.FindWithTag("PlayerR");
        playerLeft = GameObject.FindWithTag("PlayerL");

        rb = GetComponent<Rigidbody>();
        whenSpawnPower = Random.Range(1.0f, 2.0f);
        manager = GameObject.FindWithTag("Manage");
        manage = manager.GetComponent<Manager>();

        rigthPlayer = playerRigth.GetComponent<RigthPlayerController>();
        leftPlayer = playerLeft.GetComponent<LeftPlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!start && Input.GetKey(KeyCode.Space))
        {
           start = true;
           rotation = Random.Range(0, 365);
           gameObject.transform.Rotate(0, rotation, 0);
           rb.velocity = transform.forward * initialSpeed;
        }
        if (start)
        {
            whenSpawnPower -= Time.deltaTime;
            float add = acelerationRate * Time.deltaTime;
            if (rb.velocity.x < 0)
            {
                rb.velocity -= new Vector3(add, 0, 0);
            } else
            {
                rb.velocity += new Vector3(add, 0, 0);
            }

            if (rb.velocity.y < 0)
            {
                rb.velocity -= new Vector3(0, add, 0);
            } else
            {
                rb.velocity += new Vector3(0, add, 0);
            }

            if (whenSpawnPower < 0 && !hasDonePower)
            {
                actualPow = Instantiate(power, new Vector3(0, 0.5f, 0), transform.rotation);
                hasDonePower = true;
            }

        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "DieWallLeft")
        {
            manage.playerTwoScore();
            Destroy(gameObject);
            Destroy(actualPow);
            leftPlayer.PowerDown();
            rigthPlayer.PowerDown();
            playerRigth.transform.position = new Vector3(13.5f, 0.5f, 6.25f);
            playerLeft.transform.position = new Vector3(-13.5f, 0.5f, 6.25f);
        }
        if (col.gameObject.name == "DieWallRight")
        {
            manage.playerOneScore();
            Destroy(gameObject);
            Destroy(actualPow);
            leftPlayer.PowerDown();
            rigthPlayer.PowerDown();
        }

        if (col.gameObject.name == "PlayerRight")
        {
            lastOneLeft = false;
        }
        if (col.gameObject.name == "PlayerLeft")
        {
            lastOneLeft = true;
        }  
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Power")
        {
            if (lastOneLeft)
            {
                leftPlayer.PowerUp();
            }
            else
            {
                rigthPlayer.PowerUp();
            }

            Destroy(col.gameObject);
        }
    }

}
