using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
	public GameObject playerObject;
	public float speed = 1f;
    public bool attached = false;
    public bool isPositive = true;
    public AudioClip enemyAttachSFX;
    public AudioClip enemyExplodeSFX;
    public Sprite BlueBall;
    public Sprite RedBall;
    public SpriteRenderer enemySprite;
    Vector3 playerPosition;
    Vector3 enemyDirection;
    public GameObject childBlue;
    public GameObject childRed;
    //public GameObject particle;

    void Start()
    {
        //Destroy(gameObject, 8f);
		playerObject = GameObject.Find("Player");
        enemySprite = gameObject.GetComponent<SpriteRenderer>();
        playerPosition = playerObject.transform.position;
        enemyDirection = playerPosition - transform.position;
        childBlue = this.gameObject.transform.GetChild(1).gameObject;
        childRed = this.gameObject.transform.GetChild(0).gameObject;
        //particle = gameObject.GetComponentInChildren<ParticleSystem>();
    }

    //void Update2() {
    //    if (!attached) {
    //        if ((playerObject.GetComponent<PlayerMove>().isPositive && isPositive)
    //        || (!playerObject.GetComponent<PlayerMove>().isPositive && !isPositive)) { return; }
    //        else if ((playerObject.GetComponent<PlayerMove>().isPositive && !isPositive)) {
    //            enemySprite.sprite = RedBall;
    //            enemySprite.transform.localScale = new Vector2(0.25f, 0.25f);
    //            transform.position += enemyDirection * speed;
    //        }
    //        else {
    //            enemySprite.sprite = BlueBall;
    //            enemySprite.transform.localScale = new Vector2(0.25f, 0.25f);
    //            transform.position += enemyDirection * speed / 2;
    //        }
    //    }
    //}

    void Update() {
        if (!attached) {
            if (playerObject.GetComponent<PlayerMove>().isPositive) {
                isPositive = true;
                childBlue.SetActive(false);
                childRed.SetActive(true);
                //enemySprite.sprite = RedBall;
                //enemySprite.transform.localScale = new Vector2(0.25f, 0.25f);
                transform.position += enemyDirection * speed;
            }
            else {
                isPositive = false;
                childRed.SetActive(false);
                childBlue.SetActive(true);
                //enemySprite.sprite = BlueBall;
                //enemySprite.transform.localScale = new Vector2(0.25f, 0.25f);
                transform.position += enemyDirection * speed / 2;
            }
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
        if (isPositive) {
            AudioSource.PlayClipAtPoint(enemyExplodeSFX, Camera.main.transform.position);
            playerObject.GetComponent<PlayerManager>().loseHealth(5f);
            GetComponentInChildren<ParticleSystem>().Play();
            //ParticleSystem.EmissionModule emis = GetComponent<ParticleSystem>().emission;
            //emis.enabled = true;
            //gameObject.GetComponent<ParticleSystem>().emission;
            Destroy(gameObject);
        }
		PickUp(t);
	}
}
