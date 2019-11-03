using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTile : MonoBehaviour
{
    // Start is called before the first frame update

    public string TileType = "-";
    public Sprite MinusTile;
    public Sprite PlusTile;
    //public Transform cam;

    public GameObject enemySpawnerPrefab;
    public Transform enemySpawnerContainer;

    void Start() {

        Camera c = GameObject.Find("Main Camera").GetComponent<Camera>();

        //Kamera katoaa prefabista...
        //c = cam.GetComponent<Camera>();

        float edgeDistance = c.orthographicSize;
        var newposFix = 0f;
        //var newposFix = -1f;
        if (gameObject.name == "TileTop") {
            newposFix = 2f / 3f * edgeDistance;
        } else if (gameObject.name == "TileBottom") {
            newposFix = -2f / 3f * edgeDistance;
        }
        transform.position = new Vector2(transform.position.x, newposFix);
        
        print("top: "+ edgeDistance + " newposFix: " + newposFix);
        if (Random.value>0.5f){
            TileType = "+";
            gameObject.GetComponent<SpriteRenderer>().sprite = PlusTile;
        } else {
            TileType = "-";
            gameObject.GetComponent<SpriteRenderer>().sprite = MinusTile;
        }
        
        var tileSprite = gameObject.GetComponent<SpriteRenderer>();
        tileSprite.transform.localScale = new Vector2(0.80f, 0.80f);

        if (Random.value > 0.0f) {
            Instantiate(enemySpawnerPrefab, transform.position, Quaternion.identity, enemySpawnerContainer);
            //print("ENEMY SPAWNER LUOTU");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
