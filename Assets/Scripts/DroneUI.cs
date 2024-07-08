using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DroneUI : MonoBehaviour,IDroneObserver
{
    [SerializeField]
     public TextMeshProUGUI statusText;
    [SerializeField]
    private TextMeshProUGUI ammoCountText;
    [SerializeField]
    private TextMeshProUGUI currentWeaponNameText;
    private WeaponSystem weaponSystem;
    [SerializeField]
    private TextMeshProUGUI cameraModeText;
    private void Start()
    {
        weaponSystem = FindObjectOfType<WeaponSystem>();
    }
    public void OnNotify(DroneActions action)
    {
       switch (action)
        {
            case DroneActions.Hovering:
                UpdateStatus("Hovering");
                break;
            case DroneActions.Steering:
                UpdateStatus("Steering");
                break;
            case DroneActions.Shooting:
                UpdateStatus("Shooting");
                UpdateAmmo();
                break;
            case DroneActions.FirstPerson:
                UpdateCameraMode("First-Person");
                break;
            case DroneActions.ThirdPerson:
                UpdateCameraMode("Third-Person");
                break;
            default:
                break;
        }
    }
    public void UpdateStatus(string status)
    {
       if (statusText != null)
        {
            statusText.text = status;
        }
    }
    public void UpdateCameraMode(string mode)
    {
        if (cameraModeText != null)
        {
            cameraModeText.text = mode;
        }

    }
    public void UpdateAmmo()
    {
        if (ammoCountText != null && currentWeaponNameText != null && weaponSystem != null)
        {
            ammoCountText.text =weaponSystem.GetCurrentAmmo().ToString();
            currentWeaponNameText.text =weaponSystem.GetCurrentWeapon();
        }
    }

}
