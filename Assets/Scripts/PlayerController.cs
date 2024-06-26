using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro; 


public class PlayerController : MonoBehaviour
{
    public float speed = 0;

    private Rigidbody rb;

    private int score;
    public TextMeshProUGUI scoreText;
    public GameObject winTextObject; 

    private float movementX;
    private float movementY; 


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        score = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

     void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y; 
    }

    void SetCountText()
    {
        scoreText.text = "Score: " + score.ToString();
        if(score >= 11)
        {
            winTextObject.SetActive(true);
        }
    }
    // Update is called once per frame
     void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(-movement * speed);
    }

    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            score = score + 1;

            SetCountText();
        }
        

    }
}
