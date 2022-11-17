using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportParent : MonoBehaviour
{
    public float teleportTime = 0f;
    // Start is called before the first frame update

    public float getTeleportTime()
    {
        return teleportTime;
    }
}
