using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
	public GameObject playerObject;
	public float speed = 1f;
    public bool attached = false;

    public AudioClip enemyAttachSFX;
    
    void Start()
    {
		playerObject = GameObject.Find("Player");
    }

    void Update()
    {
        if (!attached) {
            var playerPosition = playerObject.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed);
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
        print("JOO");
        var pm = c.GetComponent<PlayerMove>();
        var em = c.GetComponent<EnemyMove>();
        if (pm == null && (em == null || !em.attached)) { return; }
		Transform t = c.gameObject.transform;
		PickUp(t);
	}
}
