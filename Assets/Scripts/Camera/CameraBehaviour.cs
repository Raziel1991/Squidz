using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    // References to the two players
    public GameObject targetPlayerOne;
    public GameObject targetPlayerTwo;

    // Speed of the camera movement
    public float cameraSpeed = 5f;

    // Zoom variables
    public float zoomSpeed = 2f;         // Speed at which the camera zooms
    public float maxDistance = 10f;      // The distance where the camera is fully zoomed out
    public float minDistance = 3f;       // The distance where the camera is fully zoomed in
    public float minZoom = 2f;           // Zoom in size when players are very close
    public float maxZoom = 5f;           // Zoom out size when players are far apart
    private Vector2 positionPlayerOne;           // Player Position Vector   
    private Vector2 positionPlayerTwo;           // Player Position Vector   

    private Camera cameraComponent;

    void Start()
    {
        // Ensure both targets are assigned
        if (targetPlayerOne == null || targetPlayerTwo == null)
        {
            Debug.LogError("Player targets not assigned!");
        }

        // Get the Camera component
        cameraComponent = GetComponent<Camera>();
        if (cameraComponent == null)
        {
            Debug.LogError("No camera found on this object!");
        }
    }

    // FixedUpdate is called at a fixed interval
    void FixedUpdate()
    {
        if (targetPlayerOne != null && targetPlayerTwo != null)
        {
            // Get the positions of the players
            positionPlayerOne = targetPlayerOne.transform.position;
            positionPlayerTwo = targetPlayerTwo.transform.position;

            // Calculate the center position
            Vector2 centerPosition = (positionPlayerOne + positionPlayerTwo) / 2;

            // Create a target position for the camera, preserving the Z-axis
            Vector3 targetPosition = new Vector3(centerPosition.x, centerPosition.y, transform.position.z);

            // Smoothly move the camera towards the target position using Lerp
            transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeed * Time.fixedDeltaTime);

            // Calculate the distance between the two players
            float distance = Vector2.Distance(positionPlayerOne, positionPlayerTwo);

            // Clamp the distance between the min and max distance
            distance = Mathf.Clamp(distance, minDistance, maxDistance);

            // Interpolate the orthographic size based on the distance
            float desiredZoom = Mathf.Lerp(minZoom, maxZoom, (distance - minDistance) / (maxDistance - minDistance));

            // Smoothly change the camera's orthographic size to zoom in/out
            cameraComponent.orthographicSize = Mathf.Lerp(cameraComponent.orthographicSize, desiredZoom, Time.fixedDeltaTime * zoomSpeed);

            // Log for debugging purposes
            Debug.Log("Center Position: " + targetPosition + ", Distance: " + distance + ", Zoom: " + cameraComponent.orthographicSize);
        }

        // when a player is defeated 
        else if (targetPlayerOne != null )
        {
            centerCameraToObject(targetPlayerOne);           
        }
        else if (targetPlayerTwo != null) 
        {
            centerCameraToObject(targetPlayerTwo);    
        }

        // centers the camera to a specific object // current case for players
        void centerCameraToObject(GameObject targetObject)
        {
            Vector2 positionObject = targetObject.transform.position;
            Vector3 targetPosition = new Vector3(positionObject.x, positionObject.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeed * Time.fixedDeltaTime);

            // Smoothly change the camera's orthographic size to zoom in/out
            cameraComponent.orthographicSize = Mathf.Lerp(cameraComponent.orthographicSize, minZoom, Time.fixedDeltaTime * zoomSpeed);

            // Log for debugging purposes
            Debug.Log("Focusing on: " + targetObject.name + ", Camera Position: " + transform.position + ", Zoom: " + cameraComponent.orthographicSize);
        }
    }
}
