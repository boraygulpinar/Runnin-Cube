using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpSpeed;
    public float horizontalInput;
    bool isGround = true;
    bool facingRight = true;
    private int jumpCount = 0;
    private int maxJumpCount = 2;
    private bool isDead = false;


    Rigidbody2D rb;
    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        PlayerControl();

        if (facingRight == false && horizontalInput > 0)
        {
            Flip();
        }
        if (facingRight == true && horizontalInput < 0)
        {
            Flip();
        }

        Death();
    }

    
    private void PlayerControl()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGround || jumpCount < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            if (jumpCount == 1)
            {
                isGround = false;
            }
            jumpCount++;
        }
    }

    

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }


    // GAMEPLAY

    public GameObject happenedObject;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Darling"))
        {
            int currentSceneIndex;
            currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }

        if (collision.gameObject.CompareTag("WhatHappened"))
        {
            happenedObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WhatHappened"))
        {
            happenedObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            jumpCount = 0;
        }

        if (collision.gameObject.CompareTag("DeathArea"))
        {
            isDead = true;
        }
    }

    private void Death()
    {
        if (isDead == true)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }



}
