using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject pongBall;
    public Text oneScore;
    public Text twoScore;
    public GameObject oneWin;
    public GameObject twoWin;
    public GameObject restart;
    public int playerOnePoints;
    public int playerTwoPoints;
    public bool done;
    AudioSource score;
    public GameObject ball;
    GameObject UwU;
    int max = 10;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(pongBall, new Vector3(0, 0.5f, 0), transform.rotation);
        playerOnePoints = 0;
        playerTwoPoints = 0;
        twoScore.text = "0";
        oneScore.text = "0";
        done = false;
        score = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (done)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                oneWin.SetActive(false);
                twoWin.SetActive(false);
                restart.SetActive(false);
                GameObject[] pongs = GameObject.FindGameObjectsWithTag("Ball");
                foreach (GameObject obj in pongs)
                {
                    Destroy(obj);
                }
                Start();
            }
            else
            {
                for (int i = 0; i < max; i++)
                {
                    UwU = Instantiate(ball, new Vector3(0, 0.5f, 0), Quaternion.identity);
                    Destroy(UwU, 0.4f);
                }
            }
        }

    }

    public void playerOneScore()
    {
        playerOnePoints++;
        oneScore.text = playerOnePoints.ToString();
        if (playerOnePoints > 2)
        {
            oneWin.SetActive(true);
            restart.SetActive(true);
            done = true;
        }
        else
        {
            Instantiate(pongBall, new Vector3(0, 0.5f, 0), transform.rotation);
            score.Play();
        }        
    }

    public void playerTwoScore()
    {
        playerTwoPoints++;
        twoScore.text = playerTwoPoints.ToString();
        if (playerTwoPoints > 2)
        {
            twoWin.SetActive(true);
            restart.SetActive(true);
            done = true;
        }
        else
        {
            Instantiate(pongBall, new Vector3(0, 0.5f, 0), transform.rotation);
            score.Play();
        }
    }
}
