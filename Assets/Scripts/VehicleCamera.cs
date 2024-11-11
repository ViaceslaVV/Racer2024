using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class VehicleCamera : MonoBehaviour
{
    [Range(0f, 1f)]public float posSpeed;
   
    public Vehicle target;
    public Camera cam;

    void LateUpdate()
    {
        //var targetPos = target.position + transform.TransformPoint(offset);
        cam.fieldOfView = Mathf.Lerp(50f, 100f, target.speedRatio);
        transform.position = Vector3.Lerp( transform.position,target.transform.position, posSpeed);
        transform.forward = target.transform.forward;
    }
}
