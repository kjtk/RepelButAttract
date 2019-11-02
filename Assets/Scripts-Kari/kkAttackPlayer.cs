using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kkAttackPlayer : MonoBehaviour
{
    float speed = 1.0f;
    public GameObject playerTarget;
    Vector2 target;
    Vector2 position;

    // Start is called before the first frame update
    void Start()
    {
        position = gameObject.transform.position;
        target = new Vector2(0.0f, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, target, step);
    }
}
