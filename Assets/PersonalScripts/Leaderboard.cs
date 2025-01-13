using TMPro;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public TextMeshProUGUI[] score;
    int index = 0;
    void Update()
    {
        try
        {
            int pos = index + 1;
            score[index].text = pos.ToString() + LevelManager.instance.GetLeaderboardText(index);
            if (score[index].text != "")
            {
                index++;
            }
        }
        catch
        {
            for (int i = index; i < score.Length; i++)
            {
                score[i].text = "";
            }
        }
    }
}
