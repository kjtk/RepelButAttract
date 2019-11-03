using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform enemyContainer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.value < 0.005f) {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity, enemyContainer);
        }
    }
}
