using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTile : MonoBehaviour
{
    // Start is called before the first frame update

    public string TileType = "-";
    public Sprite MinusTile;
    public Sprite PlusTile;
    public Transform cam;

    void Start() {

        var c = cam.GetComponent<Camera>();
        float edgeDistance = c.orthographicSize;
        //var newpos = 2 / 3 * edgeDistance;
        //transform.position.y = newpos;

        if (Random.Range(0.0f, 1.0f)>0.5f){
            TileType = "+";
            gameObject.GetComponent<SpriteRenderer>().sprite = PlusTile;
        } else {
            TileType = "-";
            gameObject.GetComponent<SpriteRenderer>().sprite = MinusTile;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
