using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Calculator : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject calculator;
    public Toggle tgglRoad;
    public Toggle tgglCastle;
    public Image playerSprite;
    public Sprite[] meepleSprites;
    public TMP_Text scoreText;
    private string score;
    private bool sign = true;
    private int playerID;
    public void EnableCalculator(int playerID)
    {
        this.playerID = playerID;
        playerSprite.sprite = meepleSprites[playerID];
        score = "0";
        sign = true;
        int dlc = PlayerPrefs.GetInt("countKingRobberDLC", 0);
        if (dlc == 1)
        {
            tgglRoad.isOn = false;
            tgglCastle.isOn = false;
            tgglRoad.interactable = true;
            tgglCastle.interactable = true;
        }
        UpdateCalculator();
        calculator.SetActive(true);
    }

    public void AddNumber(int number)
    {
        if (score == "0") score = number.ToString();
        else score += number.ToString();
        UpdateCalculator();
    }

    private void UpdateCalculator()
    {
        if(sign == true) scoreText.text = "+" + score;
        else scoreText.text = "-" + score;
    }
    public void ChangeSign()
    {
        if(sign == true) sign = false;
        else sign = true;
        UpdateCalculator();
    }

    public void AddRoad()
    {
        if (tgglCastle.isOn && tgglRoad.isOn)
        {
            tgglCastle.isOn = false;
        }
    }

    public void AddCastle()
    {
        if (tgglRoad.isOn && tgglCastle.isOn)
        {
            tgglRoad.isOn = false;
        }
    }

    public void DisableCalculator()
    {
        calculator.SetActive(false);
    }

    public void SetScore()
    {
        int countKingRobber;
        if (tgglRoad.isOn) countKingRobber = 0;
        else if (tgglCastle.isOn) countKingRobber = 1;
        else countKingRobber = -1;
        if (sign == true) mainCam.GetComponent<GameController>().SetPlayerScore(playerID, Int32.Parse(score), countKingRobber);
        else mainCam.GetComponent<GameController>().SetPlayerScore(playerID, -1 * Int32.Parse(score), countKingRobber);
        DisableCalculator();
    }
}
