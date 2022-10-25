using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    public Rigidbody rb;
    private float jumpForce=1.0f;
    public Vector3 jump;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 3.0f, 0.0f);
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("ObstacleCollided");
            SceneManager.LoadScene("GameOverScene");

        }
    }
}
