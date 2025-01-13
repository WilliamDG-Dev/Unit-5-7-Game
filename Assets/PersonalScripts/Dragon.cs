using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class Dragon : MonoBehaviour
{
    Rigidbody2D rb;
    public TextMeshProUGUI points;
    public GameObject startText;
    bool startGame = false;
    bool offScreen = false;
    int score = 0;
    void Start()
    {
        startText.gameObject.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        transform.position = new Vector2(-5, 0);
        LevelManager.instance.EnterName(false);
    }

    // Update is called once per frame
    void Update()
    {
        points.text = score.ToString();
        if (Input.GetKeyDown(KeyCode.Space) && startGame == false && LevelManager.instance.NameEntered() == true)
        {
            startGame = true;
            rb.gravityScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.Space) && startGame == true && offScreen == false)
        {
            startText.gameObject.SetActive(false);
            rb.linearVelocity = new Vector2(0, 5);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Object")
        {
            LevelManager.instance.AddDetailsToLeaderboard(score);
            StartCoroutine(ExitTime());
        }
        if (other.gameObject.tag == "Top")
        {
            offScreen = true;
        }
        if (other.gameObject.tag == "Point")
        {
            score++;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Top")
        {
            offScreen = false;
        }
    }
    public void BackToMainMenu()
    {
        StartCoroutine(ExitTime()); 
    }
    IEnumerator ExitTime()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("FrontEnd");
    }
}
