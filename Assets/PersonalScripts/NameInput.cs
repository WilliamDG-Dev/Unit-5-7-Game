using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;

public class NameInput : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject startText;
    string playerName;
    bool accepted = false;

    public void OK()
    {
        string name = inputField.text.Replace(" ", string.Empty);
        if (name.Length > 3 && name.Length <= 10)
        {
            if (LevelManager.instance.CompareName().Count > 0)
            {
                for (int i = 0; i < LevelManager.instance.CompareName().Count; i++)
                {
                    if (name == LevelManager.instance.CompareName()[i])
                    {
                        LevelManager.instance.ReplaceLeaderboardRow(i);
                        LevelManager.instance.NeedToReplace(true);
                    }
                }
            }
            accepted = true;
        }

        if (accepted)
        {
            playerName = inputField.text;
            LevelManager.instance.AddNameToLeaderboard(playerName);
            LevelManager.instance.EnterName(true);
            startText.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void Cancel()
    {
        SceneManager.LoadScene("FrontEnd");
    }
}
