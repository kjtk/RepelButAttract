﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
	public GameObject playerObject;
	public float speed = 1f;
    public bool attached = false;
    public AudioClip enemyAttachSFX;
    public Sprite BlueBall;
    public Sprite RedBall;
    public SpriteRenderer enemySprite;
    Vector3 playerPosition;
    Vector3 enemyDirection;

    void Start()
    {
        Destroy(gameObject, 8f);
		playerObject = GameObject.Find("Player");
        enemySprite = gameObject.GetComponent<SpriteRenderer>();
        playerPosition = playerObject.transform.position;
        enemyDirection = playerPosition - transform.position;
    }

    void Update()
    {
        
        if (!attached) {
            if (playerObject.GetComponent<PlayerMove>().isPositive == true) {
                gameObject.GetComponent<SpriteRenderer>().sprite = RedBall;
                enemySprite.transform.localScale = new Vector2(0.25f, 0.25f);
                transform.position += enemyDirection * speed;// * Time.deltaTime;

                //transform.position += enemyDirection * speed * Time.deltaTime;
                //var playerPosition = playerObject.transform.position;
                //transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed);
            }
            else {
                gameObject.GetComponent<SpriteRenderer>().sprite = BlueBall;
                enemySprite.transform.localScale = new Vector2(0.25f, 0.25f);
                transform.position += enemyDirection * speed/2;// * Time.deltaTime;

                //transform.position += playerPosition * speed * Time.deltaTime;
                //transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed/3);
                //var playerPosition = playerObject.transform.position;
            }
            //transform.position += enemyDirection * speed;// * Time.deltaTime;
        }
	}

	public void PickUp(Transform newParent) {
        AudioSource.PlayClipAtPoint(enemyAttachSFX, Camera.main.transform.position);
        transform.SetParent(newParent);
        attached = true;
        gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
	}

	void OnTriggerEnter2D(Collider2D c) {
        if (attached) { return; }
        //print("JOO");
        var pm = c.GetComponent<PlayerMove>();
        var em = c.GetComponent<EnemyMove>();
        if (pm == null && (em == null || !em.attached)) { return; }
		Transform t = c.gameObject.transform;
		PickUp(t);
	}
}
