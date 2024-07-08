using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour,IDroneComponent
{
    private Drone drone;
    [SerializeField]
    private GameObject rocketPrefab;
    [SerializeField]
    private GameObject bombPrefab;
    [SerializeField]
    private int bombAmmo;
    [SerializeField]
    private int rocketAmmo;
    [SerializeField]
    private int ammoCount;
    private string currentWeaponName;
    private GameObject currentWeaponPrefab;

    public void AttachToDrone(Drone d)
    {
        drone = d;

        currentWeaponPrefab = rocketPrefab;
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
        if (Input.GetMouseButtonDown(0)) 
        {
            Fire();
            
        }
    }
    public void Fire()
    {
        if (ammoCount > 0 && currentWeaponPrefab != null && drone != null)
        {
            Instantiate(currentWeaponPrefab, drone.transform.position, drone.transform.rotation);
            ammoCount--;
            drone.NotifyObservers(DroneActions.Shooting);
        }
        
    }
    public void SwitchWeapon()
    {
        if (currentWeaponPrefab == rocketPrefab)
        {
            currentWeaponPrefab = bombPrefab;
            ammoCount = bombAmmo;
            currentWeaponName = "Bomb";
            drone.NotifyObservers(DroneActions.Shooting);

        }
        else
        {
            currentWeaponPrefab = rocketPrefab;
            ammoCount = rocketAmmo;
            currentWeaponName = "Rocket";
            drone.NotifyObservers(DroneActions.Shooting);

        }
    }
    public int GetCurrentAmmo()
    {
        return ammoCount;
    }

    public string GetCurrentWeapon()
    {
        return currentWeaponName;
    }
}
