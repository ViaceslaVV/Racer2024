using UnityEngine;

// AI CAR
public class Brain : MonoBehaviour
{
    public float speed;
    public float minTurnAngle;
    public Path path;
    public float minTargetDistance;
    Transform target;
    public float sensitivity;
    public float turnSensitivity = 30f;

    Vehicle vehicle;

    void Start()
    {
        vehicle = GetComponent<Vehicle>();
        target = path.GetClosestPoint(transform.position);
    }


    void Update()
    {
        vehicle.Gas();


        float angle = Vector3.SignedAngle(transform.forward, target.position - transform.position, Vector3.up);
        if(angle< -minTurnAngle || angle > minTurnAngle)
        {
            float side = Mathf.Sign(angle);
            float power = Mathf.Abs(angle) / turnSensitivity;
            vehicle.Turn(side * power);
        }
        

        transform.position  = Vector3.MoveTowards(transform.position,target.position, speed * Time.deltaTime);
        var distance = Vector3.Distance(transform.position, target.position);
        if (distance < minTargetDistance)
        {
            target = path.GetNextPoint(target);
        }


    }
}