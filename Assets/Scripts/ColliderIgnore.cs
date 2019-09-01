using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderIgnore : MonoBehaviour
{
    void Start()
    {
        Physics.IgnoreLayerCollision(15, 16, ignore: false);
    }
}
