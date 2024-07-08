using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDroneComponent
{
    void AttachToDrone(Drone d);
    void DetachFromDrone();
}
