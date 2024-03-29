using UnityEngine;
using UnityEngine.SceneManagement;

public class Rabbit : MonoBehaviour
{
    //player physics
    public Rigidbody2D rigidBody;

    // Update is called once per frame
    void Update()
    {
        Controls();
    }

    void Controls()
    {
        Vector2 pos = transform.localPosition;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //move right
            if (pos.x > -4.5 && pos.x < 3.9)
            {
                rigidBody.MovePosition(rigidBody.position + Vector2.right);

                GetComponent<AudioSource>().Play();
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //move left
            if (pos.x > -4 && pos.x < 4.5)
            {
                rigidBody.MovePosition(rigidBody.position + Vector2.left);

                GetComponent<AudioSource>().Play();
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //move up
            rigidBody.MovePosition(rigidBody.position + Vector2.up);

            GetComponent<AudioSource>().Play();

            Score.currentScore += 10;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //move down
            if (pos.y > -4.5)
            {
                rigidBody.MovePosition(rigidBody.position + Vector2.down);

                GetComponent<AudioSource>().Play();

                Score.currentScore -= 10;
            }
        }

        transform.localPosition = pos;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Game Over!");

            Score.currentScore = 0;

            SceneManager.LoadScene("GameOver");
        }
   }
}
