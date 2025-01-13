using UnityEngine;

public class Background : MonoBehaviour
{
    Rigidbody2D rb;
    public int speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(1,0);
    }

    // Update is called once per frame
    void Update()
    {
        speed = LevelManager.instance.GetSpeed();
        if (transform.position.x <= -19)
        {
            transform.position = new Vector2(1, 0);
        }
        else
        {
            rb.linearVelocity = new Vector2(-speed, 0);
        }
    }
}