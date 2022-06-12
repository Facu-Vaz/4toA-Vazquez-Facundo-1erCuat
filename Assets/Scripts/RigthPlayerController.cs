﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigthPlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float movSpeed;
    public float rotSpeed;
    public bool isBoosted; 
    
    public GameObject manager;
    Manager isDone;
    AudioSource power;
    bool done;
    // Start is called before the first frame update
    void Start()
    {
        isBoosted = false;
        isDone = manager.GetComponent<Manager>();

        power = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isDone.done)
        {
            if (Input.GetKey(KeyCode.UpArrow) && transform.position.z < 6.75 && !isBoosted)
            {
                transform.position += new Vector3(0, 0, movSpeed);
            }
            else if (Input.GetKey(KeyCode.DownArrow) && transform.position.z > -6.75 && !isBoosted)
            {
                transform.position += new Vector3(0, 0, -movSpeed);
            }

            if (Input.GetKey(KeyCode.LeftArrow) && transform.rotation.y > -0.1 && !isBoosted)
            {
                transform.Rotate(0, -rotSpeed, 0);
            }
            else if (Input.GetKey(KeyCode.RightArrow) && transform.rotation.y < 0.1 && !isBoosted)
            {
                transform.Rotate(0, rotSpeed, 0);
            }

            if (Input.GetKey(KeyCode.UpArrow) && transform.position.z < 6.25 && isBoosted)
            {
                transform.position += new Vector3(0, 0, movSpeed);
            }
            else if (Input.GetKey(KeyCode.DownArrow) && transform.position.z > -6.25 && isBoosted)
            {
                transform.position += new Vector3(0, 0, -movSpeed);
            }
        }
    }

    public void PowerUp()
    {
        transform.rotation = Quaternion.identity;
        transform.localScale = new Vector3(0.3f, 1, 3);
        isBoosted = true;
        if (transform.position.z < -6.25)
        {
            transform.position = new Vector3 (13.5f, 0.5f, -6.25f);
        }
        if (transform.position.z > 6.25)
        {
            transform.position = new Vector3(13.5f, 0.5f, 6.25f);
        }
        power.Play();
    }

    public void PowerDown()
    {
        transform.rotation = Quaternion.identity;
        transform.localScale = new Vector3(0.3f, 1, 2);
        isBoosted = false;
    }
}
