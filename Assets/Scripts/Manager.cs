using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject pongBall;
    public Text oneScore;
    public Text twoScore;
    public int playerOnePoints;
    public int playerTwoPoints;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(pongBall, new Vector3(0, 0.5f, 0), transform.rotation);
        playerOnePoints = 0;
        playerTwoPoints = 0;
        twoScore.text = "0";
        oneScore.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playerOneScore()
    {
        playerOnePoints++;
        oneScore.text = playerOnePoints.ToString();
        Instantiate(pongBall, new Vector3(0, 0.5f, 0), transform.rotation);
    }

    public void playerTwoScore()
    {
        playerTwoPoints++;
        twoScore.text = playerTwoPoints.ToString();
        Instantiate(pongBall, new Vector3(0, 0.5f, 0), transform.rotation);
    }
}
