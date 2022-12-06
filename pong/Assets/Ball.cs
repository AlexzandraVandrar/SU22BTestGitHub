using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    [SerializeField, Range(1, 20)]
    float speed = 8;
    float keepSpeed;

    Vector3 direction;

    TextMeshProUGUI scoreText; 

    int playerLGoals = 0;
    int playerRGoals = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = FindObjectOfType<TextMeshProUGUI>();

        // ball random movement 
        int x = Random.Range(0, 2);
        if (x == 0)
        {
            x = -1;
        }

        keepSpeed = speed;
    }

    private void ResetBall()
    {
        speed = keepSpeed;
         transform.position = new Vector3(0, 0, 0);
            int x = Random.Range(0, 2);
            if (x == 0)
            {
                x = -1;
            }
            direction = new Vector3(x, Random.Range(-1, 2), 0);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = playerLGoals+" - " + playerRGoals;

        if (transform.position.x > 17.5f)
        {
            print("goal right");
            playerLGoals += 1;
            ResetBall();
        }

        if (transform.position.x < -17.5f)
        {
            print("goal left");
            playerRGoals += 1;
            ResetBall();
        }

        //move
        #region Movement 

        speed = Mathf.Clamp(speed, 1, 20);

        if (Input.GetKeyDown(KeyCode.Return))
        {
            ResetBall();
        }
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            speed *= 1.025f; 
            direction.x *= -1;

            if (transform.position.y > collision.transform.position.y + 1)
            {
                direction.y = 0.33f;
            }
            else if (transform.position.y < collision.transform.position.y - 1)
            {
                direction.y = -0.33f;
            }
            else
            {
                direction.y = 0;
            }

        }
        else
        {
            speed *= 1.02f;
            direction.y *= -1;
        }
        #endregion
    }
}   