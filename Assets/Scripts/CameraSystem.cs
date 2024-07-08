using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour,IDroneComponent
{
    private Drone drone;
    [SerializeField]
    private CinemachineVirtualCamera fppCamera;
    [SerializeField]
    private CinemachineVirtualCamera tppCamera;
    private void Start()
    {
        SwitchToTPP();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            ToggleCameraView();
        }
        if (fppCamera.gameObject.activeSelf)
        {
            fppCamera.transform.position = transform.position +transform.forward * 0.5f;
            fppCamera.transform.rotation = transform.rotation;
        }
    }
    public void AttachToDrone(Drone d)
    {
        drone = d;
    }

    public void DetachFromDrone()
    {
        drone = null;
    }

    public void ToggleCameraView()
    {
        if (fppCamera.gameObject.activeSelf)
        {
            SwitchToTPP();
        }
        else
        {
            SwitchToFPP();
        }
    }

    private void SwitchToFPP()
    {
        fppCamera.gameObject.SetActive(true);
        tppCamera.gameObject.SetActive(false);
        drone.NotifyObservers(DroneActions.FirstPerson);
    }
    private void SwitchToTPP()
    {
        fppCamera.gameObject.SetActive(false);
        tppCamera.gameObject.SetActive(true);
        drone.NotifyObservers(DroneActions.ThirdPerson);
    }
}
