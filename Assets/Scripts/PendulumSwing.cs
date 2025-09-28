using UnityEngine;

public class PendulumSwing : MonoBehaviour
{
    public float maxAngle = 60f;       
    public float swingSpeed = 2f;      

    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.localRotation;
    }

    void Update()
    {
        
        float angle = maxAngle * Mathf.Sin(Time.time * swingSpeed);

       
        transform.localRotation = initialRotation * Quaternion.Euler(0f, 0f, angle);
    }
}
