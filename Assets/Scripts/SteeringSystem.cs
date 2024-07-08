using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringSystem : MonoBehaviour,IDroneComponent
{
    private Drone drone;
    [SerializeField]
    private float rotationSpeed = 100f;
    [SerializeField]
    private float moveSpeed;
    public void AttachToDrone(Drone d)
    {
        drone = d;
    }
    public void DetachFromDrone()
    {
        if (drone != null)
        {
            drone = null;
        }
    }
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        RotateDrone(horizontalInput);
        float verticalInput = Input.GetAxis("Vertical");
        MoveDrone(verticalInput);
    }
    private void RotateDrone(float horizontalInput)
    {
        if (drone != null)
        {
            float rotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;
            drone.transform.Rotate(Vector3.up, rotationAmount);
            drone.NotifyObservers(DroneActions.Steering);
        }
    }
    private void MoveDrone(float verticalInput)
    {
        if (drone != null)
        {
            Vector3 movementDirection = drone.transform.forward;
            Vector3 newPosition = drone.transform.position + movementDirection * verticalInput * moveSpeed * Time.deltaTime;
            drone.transform.position = newPosition;
            drone.NotifyObservers(DroneActions.Steering);

        }
    }
}
