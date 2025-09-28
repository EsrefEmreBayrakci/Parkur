using UnityEngine;

public class ziplatma : MonoBehaviour
{
    [SerializeField] private float ziplamaGucu = 15f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                
                Vector3 velocity = rb.linearVelocity;
                velocity.y = 0;
                rb.linearVelocity = velocity;

                
                rb.AddForce(Vector3.up * ziplamaGucu, ForceMode.VelocityChange);
                rb.AddForce(Vector3.forward * 1f, ForceMode.VelocityChange);


            }
        }
    }

    
    private void Update()
    {
        float yPozisyon = Mathf.PingPong(Time.time * 1f, 1f) - 1f;
        transform.position = new Vector3(transform.position.x, yPozisyon + 7.3f, transform.position.z);
    }
}
