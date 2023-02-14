using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public List<CPlayer> players = new List<CPlayer>();
    public GameObject[] playersUI;
    public GameObject[] posRed, posGreen, posBlue, posYellow, posPink, posBlack;
    public GameObject exitConfirm;
    public Sprite[] meeples;
    public GameObject gameEnd;
    public TMP_Text endText, endScore;
    public Image endSprite;
    public GameObject endConfirm;
    private bool goldminesDLC;
    void Start()
    {
        string save = PlayerPrefs.GetString("Players", "111111");
        if (PlayerPrefs.GetInt("goldminesDLC", 0) == 0) goldminesDLC = false;
        else goldminesDLC = true;


        for (int i = 0; i < save.Length; i++)
        {
            CPlayer player = ScriptableObject.CreateInstance<CPlayer>();
            players.Add(player);
        }

        int cnt = 0;
        foreach (char curChar in save)
        {
            if (curChar == '1') players[cnt].isActive = true;
            else players[cnt].isActive = false;
            cnt++;
        }
        ResetPlayersScore();
        UpdateField();
    }

    private void UpdateField()
    {
        int cnt = 0;
        foreach (CPlayer player in players)
        {
            if (player.isActive)
            {
                playersUI[cnt].GetComponentInChildren<TMP_Text>().text = player.score.ToString();
                switch (cnt)
                {
                    case 0:
                        int scoreRed;
                        if (player.score >= 50) scoreRed = player.score % 50;
                        else if (player.score < 0) scoreRed = (50 + player.score) % 50;
                        else scoreRed = player.score;
                        for (int i = 0; i < posRed.Length; i++)
                        {
                            if (i == scoreRed) posRed[i].SetActive(true);
                            else posRed[i].SetActive(false);
                        }
                        break;
                    case 1:
                        int scoreGreen;
                        if (player.score >= 50) scoreGreen = player.score % 50;
                        else if (player.score < 0) scoreGreen = (50 + player.score) % 50;
                        else scoreGreen = player.score;
                        for (int i = 0; i < posGreen.Length; i++)
                        {
                            if (i == scoreGreen) posGreen[i].SetActive(true);
                            else posGreen[i].SetActive(false);
                        }
                        break;
                    case 2:
                        int scoreBlue;
                        if (player.score >= 50) scoreBlue = player.score % 50;
                        else if (player.score < 0) scoreBlue = (50 + player.score) % 50;
                        else scoreBlue = player.score;
                        for (int i = 0; i < posBlue.Length; i++)
                        {
                            if (i == scoreBlue) posBlue[i].SetActive(true);
                            else posBlue[i].SetActive(false);
                        }
                        break;
                    case 3:
                        int scoreYellow;
                        if (player.score >= 50) scoreYellow = player.score % 50;
                        else if (player.score < 0) scoreYellow = (50 + player.score) % 50;
                        else scoreYellow = player.score;
                        for (int i = 0; i < posYellow.Length; i++)
                        {
                            if (i == scoreYellow) posYellow[i].SetActive(true);
                            else posYellow[i].SetActive(false);
                        }
                        break;
                    case 4:
                        int scorePink;
                        if (player.score >= 50) scorePink = player.score % 50;
                        else if (player.score < 0) scorePink = (50 + player.score) % 50;
                        else scorePink = player.score;
                        for (int i = 0; i < posPink.Length; i++)
                        {
                            if (i == scorePink) posPink[i].SetActive(true);
                            else posPink[i].SetActive(false);
                        }
                        break;
                    case 5:
                        int scoreBlack;
                        if (player.score >= 50) scoreBlack = player.score % 50;
                        else if (player.score < 0) scoreBlack = (50 + player.score) % 50;
                        else scoreBlack = player.score;
                        for (int i = 0; i < posBlack.Length; i++)
                        {
                            if (i == scoreBlack) posBlack[i].SetActive(true);
                            else posBlack[i].SetActive(false);
                        }
                        break;
                    default: break;
                }
                playersUI[cnt].SetActive(true);
            }
            else playersUI[cnt].SetActive(false);
            cnt++;
        }

    }

    public void SetPlayerScore(int playerID, int score)
    {
        players[playerID].score += score;
        if (players[playerID].score % 5 == 0 && goldminesDLC)
        {
            Debug.LogFormat("Trigger " + playerID.ToString());
        }
        UpdateField();
    }

    public void ResetPlayersScore()
    {
        foreach (CPlayer player in players)
        {
            player.score = 0;
        }
        UpdateField();
    }

    public void ExitGame()
    {
        exitConfirm.SetActive(true);
    }
    public void DiscardExit()
    {
        exitConfirm.SetActive(false);
    }
    public void ConfirmExit()
    {
        Application.Quit();
    }

    public void ConfirmEnd()
    {
        endConfirm.SetActive(false);
        int cnt = 0;
        int maxScore = 0;
        int winnerID = 0;
        foreach (CPlayer player in players)
        {
            if (player.score > maxScore)
            {
                maxScore = player.score;
                winnerID = cnt;
            }
            cnt++;
        }
        switch (winnerID)
        {
            case 0:
                endText.text = "The winner is Red!";
                break;
            case 1:
                endText.text = "The winner is Green!";
                break;
            case 2:
                endText.text = "The winner is Blue!";
                break;
            case 3:
                endText.text = "The winner is Yellow!";
                break;
            case 4:
                endText.text = "The winner is Pink!";
                break;
            case 5:
                endText.text = "The winner is Black!";
                break;
        }
        endSprite.sprite = meeples[winnerID];
        endScore.text = "Score: " + maxScore.ToString();
        gameEnd.SetActive(true);
    }

    public void EndGame()
    {
        endConfirm.SetActive(true);
    }

    public void DiscardEnd()
    {
        endConfirm.SetActive(false);
    }
}
