using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float health = 100f;
    public float score = 0f;
    public Text healthText;
    public Text scoreText;
    public Slider healthBar;

    void Start()
    {
        
    }

    public void gainScore(int amount) {
        score += amount;
        scoreText.text = "Score: " + score;
    }

    public void loseHealth(float amount) {
        health -= amount;
        if (health < 0) {
            health = 0;
        }
        healthBar.value = health;
        healthText.text = "Health: " + (int)health;
    }

    public void gainHealth(float amount) {
        health += amount;
        if (health > 100) {
            health = 100;
        }
        healthBar.value = health;
        healthText.text = "Health: " + (int)health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0) {
            Debug.LogError("GAME OVER");
            Time.timeScale = 0;
        }
    }
}
