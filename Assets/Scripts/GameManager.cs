using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI leftTxt, rightTxt;

    public int leftScore, rightScore;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        leftScore = 0;
        rightScore = 0;
    }


    public void LeftPuanArttir()
    {
        leftScore++;

        rightTxt.text = leftScore.ToString();
    }

    public void RightPuanArttir()
    {
        rightScore++;
        leftTxt.text = rightScore.ToString();
    }
}
