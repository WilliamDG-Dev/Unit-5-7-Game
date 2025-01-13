using TMPro;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    TMP_Dropdown dropdown;
    void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        dropdown.value = LevelManager.instance.GetDifficulty();
    }

    public void OnDifficultyChange()
    {
        LevelManager.instance.SetDifficulty(dropdown.value);
    }
}
