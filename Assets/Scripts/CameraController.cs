using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConntroller : MonoBehaviour
{

    Transform target;
    Vector3 velocity = Vector3.zero;

    [Range(0, 1)]
    public float smoothTime;

    public Vector3 positionoffset;

    [Header("Axis limitation")]
    public Vector2 XLimit;
    public Vector2 Ylimit;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position+positionoffset;
        targetPosition = new Vector3(Mathf.Clamp(targetPosition.x, XLimit.x, XLimit.y), Mathf.Clamp(targetPosition.y, Ylimit.x, Ylimit.y), -10);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}