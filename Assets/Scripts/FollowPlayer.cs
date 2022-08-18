using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float zOffset;

    void Update()
    {
        Vector3 newPosition =  new Vector3(target.position.x, target.position.y, zOffset);
        this.transform.position = Vector3.Lerp(this.transform.position, newPosition, Time.deltaTime);
    }
}
