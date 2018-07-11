using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    public Text scoreObject;
    public static int score;
    public Text hs1;
    public Text hs2;
    public Text hs3;
    public Text hs4;
    public Text hs5;

    private void Awake()
    {
        score = 0;
    }

    private void Update()
    {
        scoreObject.text = score.ToString();
        if (MainScript.isGameOver)
        {
            CheckAndSort();
        }

    }

    public void HighscoreInit()
    {
        if (PlayerPrefs.HasKey("HS5"))
        {
            hs5.text = PlayerPrefs.GetInt("HS5").ToString();
        }
        else
        {
            hs5.text = "0";
        }
        if (PlayerPrefs.HasKey("HS4"))
        {
            hs4.text = PlayerPrefs.GetInt("HS4").ToString();
        }
        else
        {
            hs4.text = "0";
            hs5.text = "0";
        }
        if (PlayerPrefs.HasKey("HS3"))
        {
            hs3.text = PlayerPrefs.GetInt("HS3").ToString();
        }
        else
        {
            hs3.text = "0";
            hs4.text = "0";
            hs5.text = "0";
        }
        if (PlayerPrefs.HasKey("HS2"))
        {
            hs2.text = PlayerPrefs.GetInt("HS2").ToString();
        }
        else
        {
            hs2.text = "0";
            hs3.text = "0";
            hs4.text = "0";
            hs5.text = "0";
        }
        if (PlayerPrefs.HasKey("HS1"))
        {
            hs1.text = PlayerPrefs.GetInt("HS1").ToString();
        }
        else
        {
            hs1.text = "0";
            hs2.text = "0";
            hs3.text = "0";
            hs4.text = "0";
            hs5.text = "0";
        }
    }

    public void CheckAndSort()
    {
        int pPrefScore;
        int currScore = score;
        for(int i = 1; i <=5; i++)
        {
            string hsNum = "HS" + i;
            pPrefScore = PlayerPrefs.GetInt(hsNum);
            if (currScore > pPrefScore)
            {
                PlayerPrefs.SetInt(hsNum, currScore);
                currScore = pPrefScore;
            }
        }
        HighscoreInit();
    }
}
