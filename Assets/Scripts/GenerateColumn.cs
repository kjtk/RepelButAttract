using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateColumn : MonoBehaviour
{
    public Camera cam;
    public GameObject columnPrefab;
    public Transform columnContainer;

    float columnWidth = 6.375f;
    float cameraRightEdge = 25f;
    float currentCameraPositionX = 0f;
    float previousColumnPositionX = 0f;

    private void Start() {
        previousColumnPositionX = cam.transform.position.x + cameraRightEdge;
        //Instantiate(columnPrefab, cam.transform.position, Quaternion.identity, columnContainer);
        //columnWidth = GetComponent<Sprite>
    }
    void Update() {
        currentCameraPositionX = cam.transform.position.x + cameraRightEdge;
        if(currentCameraPositionX >= (previousColumnPositionX + columnWidth) ) {
            previousColumnPositionX = currentCameraPositionX;
            Instantiate(columnPrefab, cam.transform.position + new Vector3(cameraRightEdge, 0f,0f), Quaternion.identity, columnContainer);
            //previousColumnPositionX = currentCameraPositionX;
        }
    }
}
