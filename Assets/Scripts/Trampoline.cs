using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [Header("Zıplama Ayarları")]
    public float bounceForce = 10f;              
    public float bounceDelay = 0.1f;             

    [Header("Yüzey Animasyonu (isteğe bağlı)")]
    public Transform trampolineSurface;
    public float squashAmount = 0.2f;
    public float squashSpeed = 10f;

    private Vector3 originalScale;

    private void Start()
    {
        if (trampolineSurface != null)
            originalScale = trampolineSurface.localScale;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.rigidbody;

        if (rb != null)
        {
            
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z); 

            rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);

            
            if (trampolineSurface != null)
                StopAllCoroutines(); 
            StartCoroutine(SquashSurface());
        }
    }

    private System.Collections.IEnumerator SquashSurface()
    {
        Vector3 squashed = originalScale - new Vector3(0f, squashAmount, 0f);

        
        while (Vector3.Distance(trampolineSurface.localScale, squashed) > 0.01f)
        {
            trampolineSurface.localScale = Vector3.Lerp(trampolineSurface.localScale, squashed, Time.deltaTime * squashSpeed);
            yield return null;
        }

        
        while (Vector3.Distance(trampolineSurface.localScale, originalScale) > 0.01f)
        {
            trampolineSurface.localScale = Vector3.Lerp(trampolineSurface.localScale, originalScale, Time.deltaTime * squashSpeed);
            yield return null;
        }
    }
}

