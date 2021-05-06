using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float moveSpeed = 10f;

    public TextMeshProUGUI scoreText; //This will display current the score

    private float score;
    private float xInput;
    private float yInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    //Good for player movements
    private void FixedUpdate()
    {
        OnMove();
    }

    private void PlayerInput()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
    }

    private void OnMove()
    {
        rb.AddForce(new Vector3(xInput, 0f, yInput) * moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            score += 15;
            SetScoreText();

            if (score >= 250)
            {
                SceneManager.LoadScene(2);
            }
        }
    }

    private void SetScoreText()
    {
        scoreText.text = "score:" + score.ToString(); // score: 1
    }

}
