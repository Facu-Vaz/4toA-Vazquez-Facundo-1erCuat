using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public float initialSpeed;
    public float acelerationRate;
    bool start = false;
    int rotation;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
            float add = acelerationRate * Time.deltaTime;
            if (rb.velocity.x < 0)
            {
                rb.velocity -= new Vector3(add, 0, 0);
            }
            else
            {
                rb.velocity += new Vector3(add, 0, 0);
            }

            if (rb.velocity.y < 0)
            {
                rb.velocity -= new Vector3(0, add, 0);
            }
            else
            {
                rb.velocity += new Vector3(0, add, 0);
            }


        }

    }
}
