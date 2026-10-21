using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    
    public Rigidbody2D RB;
    
    public TextMeshPro ScoreText;
    public TextMeshPro LivesText;
    
    public float Speed = 5;
    
    public int Score = 0;
    public int SpawnRequirement = 5;

    public int Lives = 3;
    
    public GameObject Hazard;
    
    
    
    void Start()
    {
        //During setup we call UpdateScore to make sure our score text looks correct
        UpdateScore();
        UpdateLives();
    }
    
    void Update()
    {
        //First we make a variable that we'll use to record how we want to move
        Vector2 vel = new Vector2(0,0);
        
        if (Keyboard.current.dKey.isPressed)
        {
            vel.x = Speed;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            vel.x = -Speed;
        }
        if (Keyboard.current.wKey.isPressed)
        {
            vel.y = Speed;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            vel.y = -Speed;
        }
        
        RB.linearVelocity = vel;

        if (Score == SpawnRequirement)
        {
            SpawnHazard();
            SpawnRequirement += 5;
        }
    }

    //This gets called whenever you bump into another object, like a wall or coin.
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Hazard"))
        {
            LoseLife();
            UpdateLives();
            if (Lives <= 0)
            {
                Die();
            }
        }
        
        CoinScript coin = other.gameObject.GetComponent<CoinScript>();
        if (coin != null)
        {
            coin.GetBumped();
            Score++;
            UpdateScore();
        }
    }
    
    public void UpdateScore()
    {
        ScoreText.text = "Score: " + Score;
    }

    public void LoseLife()
    {
        Lives -= 1;
    }

    public void UpdateLives()
    {
        LivesText.text = "Lives: " + Lives;
    }
    
    public void Die()
    {
        SceneManager.LoadScene("Game Over");
    }
    
    public void SpawnHazard()
    {
        Instantiate(Hazard, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
