using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public List<TextMeshProUGUI> score = new List<TextMeshProUGUI>();
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
            for (int i = 0; i < score.Count; i++)
            {
                for (int j = 0; j < score.Count; j++)
                {
                    if (score[i].text == LevelManager.instance.GetLeaderboardText(j))
                    {
                        score.RemoveAt(i);
                    }
                }
            }
        }
        catch
        {
            for (int i = index; i < score.Count; i++)
            {
                score[i].text = "";
            }
        }
    }
}
