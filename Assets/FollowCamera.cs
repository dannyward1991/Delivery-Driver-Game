using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject thingToFollow;
    Vector3 cameraOffset = new Vector3(0, 0, -10);
    //Camera pos should be the same as the car

    // LateUpdate is called once per frame at the end of Update
    void LateUpdate()
    {
        transform.position = thingToFollow.transform.position + cameraOffset;
    }
}
