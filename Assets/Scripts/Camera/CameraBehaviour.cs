using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject targetPlaerOne;
    public GameObject targetPlaerTwo;
    public float cameraSpeed = 5f;
    public float smoothFactor = 0.1f;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 positionPlayerOne = targetPlaerOne.transform.position;
        Vector2 positionPlayerTwo = targetPlaerTwo.transform.position;
        Vector2 centerPosition = (positionPlayerOne + positionPlayerTwo) / 2;
        Vector3 targetPosition = new Vector3(centerPosition.x, centerPosition.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothFactor);
        Debug.Log(centerPosition); // Print the position to the console
    }
}
