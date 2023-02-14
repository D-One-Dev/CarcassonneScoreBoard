using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject playerSelection;
    public Toggle[] toggles;
    public Toggle messengersDLCToggle;
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
        if (messengersDLCToggle.isOn) PlayerPrefs.SetInt("messengersDLC", 1);
        else PlayerPrefs.SetInt("messengersDLC", 0);
        Debug.LogFormat(save + " " + PlayerPrefs.GetInt("messengersDLC", 0).ToString());
        SceneManager.LoadScene("Gameplay");
    }
}
