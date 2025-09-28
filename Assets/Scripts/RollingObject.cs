using UnityEngine;
using System.Collections;




public class RollingObject : MonoBehaviour
{
    public float lifetime = 5f;         
    public float respawnDelay = 2f;      

    private Vector3 startPosition;
    private Quaternion startRotation;
    private Rigidbody rb;

    private int hasarMiktari = 10; 

    private Renderer rend;
    private Collider col;

    public ParticleSystem explosionEffectPrefab;

    private void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;

        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        col = GetComponent<Collider>();

        StartCoroutine(Lifecycle());
    }

    IEnumerator Lifecycle()
    {
        while (true)
        {
            
            Respawn();

            
            yield return StartCoroutine(SpawnAnimation());

            
            yield return new WaitForSeconds(lifetime);


            ExplodeIfDiken();

            
            Hide();

            
            yield return new WaitForSeconds(respawnDelay);
        }
    }


    void ExplodeIfDiken()
    {
        if (CompareTag("Diken"))
        {


            if (explosionEffectPrefab != null)
            {
                
                ParticleSystem explosion = Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);

                
                Destroy(explosion.gameObject, 0.5f);

            }
            
            float explosionForce = 500f;
            float explosionRadius = 2f;


            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
            foreach (Collider hit in colliders)
            {
                Rigidbody hitRb = hit.attachedRigidbody;
                if (hitRb != null && hitRb != rb) 
                {

                    hitRb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                    HealtController hc = hit.GetComponent<HealtController>();

                    
                    if (hit.CompareTag("Player") && hc != null)
                    {
                        hc.hasarAl(hasarMiktari);

                        
                        Transform body011 = hit.transform.Find("Body_011");
                        if (body011 != null)
                        {
                            Renderer bodyRenderer = body011.GetComponent<Renderer>();
                            if (bodyRenderer != null)
                            {
                                bodyRenderer.material.color = Color.red;
                                StartCoroutine(RenkDegistir(bodyRenderer, Color.white, 0.5f));
                            }
                        }

                    }


                }
            }

            // Son olarak kendini de durdur
            rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
        }
    }

    private IEnumerator RenkDegistir(Renderer renderer, Color yeniRenk, float sure)
    {
        yield return new WaitForSeconds(sure);
        renderer.material.color = yeniRenk;
    }


    void Respawn()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;
        transform.localScale = Vector3.one;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        rend.enabled = true;
        col.enabled = true;
        rb.isKinematic = false;
    }

    void Hide()
    {
        rend.enabled = false;
        col.enabled = false;
        rb.isKinematic = true;
    }

    IEnumerator SpawnAnimation()
    {
        float duration = 0.5f;
        float timer = 0f;
        Vector3 startScale = Vector3.zero;
        Vector3 endScale = Vector3.one;

        transform.localScale = startScale;

        while (timer < duration)
        {
            transform.localScale = Vector3.Lerp(startScale, endScale, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }

        transform.localScale = endScale;
    }
}
