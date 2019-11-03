using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
	public float maxX = 10f;
	public float maxY = 10f;
	public float speed = 5f;
    public Vector2 localpos;
    public Transform cam;
    public Vector2 clampPos;
    public bool isPositive = true;
    GameObject[] allEnemies;
    

	void Update() {
        //var newPosition = transform.position;
        if (Input.GetKey(KeyCode.LeftArrow)) {
        	localpos += Vector2.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            localpos += Vector2.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            localpos += Vector2.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            localpos += Vector2.down * speed * Time.deltaTime;
        }
        //newPosition.y = Mathf.Clamp(newPosition.y, -maxY, maxY);
        //newPosition.x = Mathf.Clamp(newPosition.x, -maxX, maxX);
        //transform.position = newPosition;
        localpos = Vector2.Min(clampPos, localpos);
        localpos = Vector2.Max(-clampPos, localpos);
        var newPos = cam.position + (Vector3)localpos;
        newPos.z = 0;
        transform.position = newPos;
	}

    void Start() {
        var c = cam.GetComponent<Camera>();
        clampPos = new Vector2(c.aspect * c.orthographicSize, c.orthographicSize);
    }

    private void OnTriggerEnter2D(Collider2D c) {
        if (c.gameObject.layer == LayerMask.NameToLayer("Tile")) {
            //Debug.Log("Touched a tile");
            if (c.gameObject.GetComponent<CreateTile>().TileType == "-") {
                isPositive = false;
                //print("negative");
            }
            else {
                isPositive = true;
                //print("positive");
            }
        }
        if (c.gameObject.layer == LayerMask.NameToLayer("Collector")) {
            allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in allEnemies) {
                if (enemy.GetComponent<EnemyMove>().attached) { Destroy(enemy); }
            }
        }
    }
}
