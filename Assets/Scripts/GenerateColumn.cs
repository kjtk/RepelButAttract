using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateColumn : MonoBehaviour
{
    public Camera cam;
    public GameObject columnPrefab;
    public Transform columnContainer;

    //float columnWidth = 6.375f;
    float columnWidth = 6.40f;
    float cameraRightEdge = 25f;
    float currentCameraPositionX = 0f;
    float previousColumnPositionX = 0f;
    float currentColumnPositionX = 0f;

    private void Start() {
        previousColumnPositionX = cam.transform.position.x + cameraRightEdge;
        //Instantiate(columnPrefab, cam.transform.position, Quaternion.identity, columnContainer);
        //columnWidth = GetComponent<Sprite>
    }
    void Update() {
        currentCameraPositionX = cam.transform.position.x;
        if(currentCameraPositionX >= (currentColumnPositionX) ) {
            Instantiate(columnPrefab, new Vector3(currentColumnPositionX,0f,0f) + new Vector3(cameraRightEdge, 0f,0f), Quaternion.identity, columnContainer);
            currentColumnPositionX += columnWidth;

        }
    }
}
