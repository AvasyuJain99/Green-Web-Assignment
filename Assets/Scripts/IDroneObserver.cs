using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDroneObserver 
{
    public void OnNotify(DroneActions action);
}
