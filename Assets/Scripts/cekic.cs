using UnityEngine;

public class cekic : MonoBehaviour
{
    public float initialForce = 500f;      
    public float maxAngle = 60f;          
    public float returnTorque = 20f;      

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 100f;
        rb.AddTorque(Vector3.right * initialForce, ForceMode.Impulse); 
    }

    void FixedUpdate()
    {
        float zAngle = NormalizeAngle(transform.localEulerAngles.z);

        if (zAngle > maxAngle)
        {
            rb.AddTorque(Vector3.left * returnTorque, ForceMode.Force);  
        }
        else if (zAngle < -maxAngle)
        {
            rb.AddTorque(Vector3.right * returnTorque, ForceMode.Force); 
        }
    }

    
    float NormalizeAngle(float angle)
    {
        if (angle > 180f) angle -= 360f;
        return angle;
    }
}
