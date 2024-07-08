using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightPropulsionSystem : MonoBehaviour,IDroneComponent
{
    private Drone drone;
    [SerializeField]
    private float hoverSpeed = 5f;
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
        float verticalMovement = 0f;
        if (Input.GetKey(KeyCode.Space))
        {
            verticalMovement = 1f;
            drone.NotifyObservers(DroneActions.Hovering);

        }
        else if (Input.GetKey(KeyCode.C))
        {
            drone.NotifyObservers(DroneActions.Hovering);
            verticalMovement = -1f;
        }

        Hover(verticalMovement);
    }
    public void Hover(float verticalInput)
    {
        if (drone != null)
        {
            Vector3 newPosition = drone.transform.position;
            newPosition.y += verticalInput * hoverSpeed * Time.deltaTime;
            drone.transform.position = newPosition;
        }
    }
}
