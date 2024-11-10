using UnityEngine;

public class Player : MonoBehaviour
{
    Vehicle vehicle;

    void Start()
    {
        vehicle = GetComponent<Vehicle>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W)) vehicle.Gas();
        if(Input.GetKey(KeyCode.S)) vehicle.Brake();
        vehicle.Turn(Input.GetAxis("Horizontal"));
    }
}