using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kkMovePlayer : MonoBehaviour
{
    public float speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    void FixedUpdate() {
        var newPosition = transform.position;
        // GetKeyDown ei sallittu FixedUpdate:ssa...
        if (Input.GetKey(KeyCode.LeftArrow)) {
            // Time.deltatimeen tuleekin Time.fixedDeltaTime:n arvo väliaikaisesti (Unity hoitaa automaattisesti)
            // Voi toki käyttää Time.fixedDeltaTime
            newPosition += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            newPosition += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            // Time.deltatimeen tuleekin Time.fixedDeltaTime:n arvo väliaikaisesti (Unity hoitaa automaattisesti)
            // Voi toki käyttää Time.fixedDeltaTime
            newPosition += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            newPosition += Vector3.down * speed * Time.deltaTime;
        }
        newPosition.x = Mathf.Clamp(newPosition.x, -4, 4);
        transform.position = newPosition;
    }
}
