using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    private List<IDroneObserver> observers = new List<IDroneObserver>();
    private List<IDroneComponent> components = new List<IDroneComponent>();

    public DroneUI droneUI;
    private void OnEnable()
    {
        AddComponent(GetComponent<SteeringSystem>());
        AddComponent(GetComponent<WeaponSystem>());
        AddComponent(GetComponent<FlightPropulsionSystem>());
        AddComponent(GetComponent<CameraSystem>());
        droneUI=FindAnyObjectByType<DroneUI>();
        if (droneUI != null )
        AddObserver(droneUI);
    }
    private void OnDisable()
    {
        RemoveComponent(GetComponent<SteeringSystem>());
        RemoveComponent(GetComponent<WeaponSystem>());
        RemoveComponent(GetComponent<FlightPropulsionSystem>());
        RemoveComponent(GetComponent<CameraSystem>());


    }

    public void AddObserver(IDroneObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IDroneObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers(DroneActions action)
    {
        foreach (var observer in observers)
        {
            observer.OnNotify(action);
        }
    }

    public void AddComponent(IDroneComponent component)
    {
        components.Add(component);
        component.AttachToDrone(this);
    }

    public void RemoveComponent(IDroneComponent component)
    {
        components.Remove(component);
        component.DetachFromDrone();
    }
  

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            WeaponSystem weaponModule = GetComponent<WeaponSystem>();
            if (weaponModule != null)
            {
                weaponModule.SwitchWeapon();
            }
        }
    }

}
