using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private List<string> names = new List<string>();
    private List<int> scores = new List<int>();
    private List<string> leaderboardRow = new List<string>();
    private int speed = 4;
    private int difficultySetting = 0;
    bool nameEntered = false;
    int indexToReplace;
    bool replaceNeeded = false;
    string currentName;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        GetPrefs();
    }
    private void GetPrefs()
    {
        if (PlayerPrefs.HasKey("NameIndex") == true)
        {
            for (int i = 0; i < PlayerPrefs.GetInt("NameIndex"); i++)
            {
                if (PlayerPrefs.HasKey("Name" + i) == true)
                {
                    names.Add(PlayerPrefs.GetString("Name" + i));
                }
            }
        }
        if (PlayerPrefs.HasKey("ScoreIndex") == true)
        {
            for (int i = 0; i < PlayerPrefs.GetInt("ScoreIndex"); i++)
            {
                if (PlayerPrefs.HasKey("Score" + i) == true)
                {
                    scores.Add(PlayerPrefs.GetInt("Score" + i));
                }
            }
        }
        if (PlayerPrefs.HasKey("LeaderboardIndex") == true)
        {
            for (int i = 0; i < PlayerPrefs.GetInt("LeaderboardIndex"); i++)
            {
                if (PlayerPrefs.HasKey("Leaderboard" + i) == true)
                {
                    leaderboardRow.Add(PlayerPrefs.GetString("Leaderboard" + i));
                }
            }
        }
    }
    public bool NameEntered()
    {
        return nameEntered;
    }
    public void EnterName(bool entered)
    {
        nameEntered = entered;
    }
    public List<string> CompareName()
    {
        return names;
    }
    public void ReplaceLeaderboardRow(int index)
    {
        indexToReplace = index;
    }
    public void NeedToReplace(bool needToRelpace)
    {
        replaceNeeded = needToRelpace;
    }
    public void AddNameToLeaderboard(string name)
    {
        currentName = name;
    }
    public void AddDetailsToLeaderboard(int score)
    {
        if (replaceNeeded && score > scores[indexToReplace])
        {
            scores[indexToReplace] = score;
        }
        else if (!replaceNeeded)
        {
            names.Add(currentName);
            scores.Add(score);
        }
        leaderboardRow.Clear();
        for (int i = 0; i < scores.Count; i++)
        {
            leaderboardRow.Add("| " + names[i] + "| " + scores[i].ToString());
            leaderboardRow.Sort((x, y) =>
            {
                int scoreX = int.Parse(x.Split('|')[2].Trim());
                int scoreY = int.Parse(y.Split('|')[2].Trim());
                return scoreY.CompareTo(scoreX);
            });
        }
        replaceNeeded = false;
    }

    public string GetLeaderboardText(int index)
    {
        return leaderboardRow[index];
    }

    public void SetDifficulty(int value)
    {
        difficultySetting = value;
        if (value == 0)
        {
            speed = 4;
        }
        else if (value == 1)
        {
            speed = 6;
        }
        else if (value == 2)
        {
            speed = 8;
        }
    }
    public int GetDifficulty()
    {
        return difficultySetting;
    }
    public int GetSpeed()
    {
        return speed;
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("NameIndex", names.Count);
        PlayerPrefs.SetInt("ScoreIndex", scores.Count);
        PlayerPrefs.SetInt("LeaderboardIndex", leaderboardRow.Count);
        for (int i = 0; i < names.Count; i++)
        {
            PlayerPrefs.SetString("Name" + i, names[i]);
        }
        for (int i = 0; i < scores.Count; i++)
        {
            PlayerPrefs.SetInt("Score" + i, scores[i]);
        }
        for (int i = 0; i < leaderboardRow.Count; i++)
        {
            PlayerPrefs.SetString("Leaderboard" + i, leaderboardRow[i]);
        }
    }
}
