using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject playerSelection;
    public Toggle[] toggles;
    public Toggle goldminesDLCToggle;
    private string save;
    public void GoToPlayerSelection()
    {
        playerSelection.SetActive(true);
    }
    public void GoToMainMenu()
    {
        playerSelection.SetActive(false);
    }
    public void StartGame()
    {
        save = "";
       foreach(Toggle curToggle in toggles)
       {
            if (curToggle.isOn) save += "1";
            else save += "0";
       }
        PlayerPrefs.SetString("Players", save);
        if (goldminesDLCToggle.isOn) PlayerPrefs.SetInt("goldminesDLC", 1);
        else PlayerPrefs.SetInt("goldminesDLC", 0);
        Debug.LogFormat(save + " " + PlayerPrefs.GetInt("goldminesDLC", 0).ToString());
        SceneManager.LoadScene("Gameplay");
    }
}
