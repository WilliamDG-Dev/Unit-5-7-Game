using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Towers : MonoBehaviour
{
    public GameObject towerGroup;
    GameObject clone;
    float randomY;
    float timer = 0.1f;
    Rigidbody2D clonerb;
    bool startSpawn = false;
    private int speed;
    List<GameObject> clonesToDestroy = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        speed = LevelManager.instance.GetSpeed();
        if (Input.GetKeyDown(KeyCode.Space) && startSpawn == false && LevelManager.instance.NameEntered() == true)
        {
            startSpawn = true;
        }
        if (startSpawn == true)
        {
            CloneTower();
        }
    }
    void CloneTower()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            clone = Instantiate(towerGroup);
            clonesToDestroy.Add(clone);
            randomY = Random.Range(-2, 2);
            clone.transform.position = new Vector2(10.2f, randomY);
            clonerb = clone.GetComponent<Rigidbody2D>();
            timer =  7.6f / speed;
        }
        if (clonesToDestroy.Count > 1 && clonesToDestroy[0].transform.position.x <= -13.2)
        {
            Destroy(clonesToDestroy[0]);
            clonesToDestroy.Remove(clonesToDestroy[0]);
        }
        if (clonerb != null)
        {
            clonerb.linearVelocity = new Vector2(-speed, 0);
        }
    }
}
