using Unity.VisualScripting;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public AudioSource engineSound;

    public float accelaration;
    public float decelaration;
    public float maxSpeed;
    public float maxRevelantSpeed;
    public float speedRatio;
    public AnimationCurve enginePitchCurve;
    Rigidbody rb;
    

    public void Gas()
    {
        speed += accelaration *  Time.deltaTime;
        if(speed > maxSpeed) speed = maxSpeed;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Brake()
    {
        
    }
    void Update()
    {

        speedRatio = speed / maxSpeed;
        engineSound.pitch = enginePitchCurve.Evaluate(speedRatio);

        //friction
        speed *= decelaration;


        var y = rb.velocity.y;
        rb.velocity = transform.forward * speed;
        rb.velocity = new Vector3(rb.velocity.x,y, rb.velocity.z);
        
    }

    public void Turn(float side)
    {
        rb.angularVelocity = new Vector3(0, side * turnSpeed * Mathf.Deg2Rad,0);
       
    }
    
}