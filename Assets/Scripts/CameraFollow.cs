using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,
            player.transform.position + Vector3.back * 10, 0.05f);
    }
}
