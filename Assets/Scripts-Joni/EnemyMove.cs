using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
	public GameObject playerObject;
	public float speed = 1f;
    public bool attached = false;
    
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
		transform.SetParent(newParent);
        attached = true;
        gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
	}

	void OnTriggerEnter2D(Collider2D c) {
        if (attached) { return; }
        print("JOO");
		Transform t = c.gameObject.transform;
		PickUp(t);
	}
}
