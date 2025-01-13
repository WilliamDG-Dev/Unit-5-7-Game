using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public List<GameObject> pages = new List<GameObject>();
    int pageShowGroup;
    int pageHideGroup;
    float timeWait = 1;
    public void ShowUI(int pageNum)
    {
        pageShowGroup = pageNum;
        StartCoroutine(WaitForShow());
    }
    public void HideUI(int pageNum)
    {
        pageHideGroup = pageNum;
        StartCoroutine(WaitForHide());
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void QuitGame()
    {
        StartCoroutine(QuitTimeOut());
    }
    IEnumerator QuitTimeOut()
    {
        yield return new WaitForSeconds(3);
        Application.Quit();
        Debug.Log("Quitting Game");
    }
    IEnumerator WaitForShow()
    {
        yield return new WaitForSeconds(timeWait);
        pages[pageShowGroup].SetActive(true);
    }
    IEnumerator WaitForHide()
    {
        yield return new WaitForSeconds(timeWait / 4);
        pages[pageHideGroup].SetActive(false);
    }
}
