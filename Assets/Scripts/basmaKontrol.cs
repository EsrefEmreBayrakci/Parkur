using UnityEngine;
using System.Collections;

public class basmaKontrol : MonoBehaviour
{
    [Header("Zaman Ayarları")]
    [SerializeField] private int blinkCount = 7;
    [SerializeField] private float blinkInterval = 0.2f;
    [SerializeField] private float bridgeRespawnTime = 5f;

    private Renderer[] renderers;
    private Collider[] colliders;
    private bool hasCollapsed = false;

    private Vector3 originalPosition;

    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
        colliders = GetComponentsInChildren<Collider>();
        originalPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasCollapsed) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            hasCollapsed = true;
            StartCoroutine(BlinkThenCollapse());
        }
    }

    private IEnumerator BlinkThenCollapse()
    {


        
        for (int i = 0; i < blinkCount; i++)
        {
            SetRenderersVisible(false); 
            yield return new WaitForSeconds(blinkInterval);
            SetRenderersVisible(true);  
            yield return new WaitForSeconds(blinkInterval);
        }


        
        SetBridgeState(false);

        
        yield return new WaitForSeconds(bridgeRespawnTime);

        SetBridgeState(true);
        hasCollapsed = false;
    }

    private void SetRenderersVisible(bool state)
    {
        foreach (Renderer r in renderers)
            r.enabled = state;
    }

    private void SetBridgeState(bool state)
    {
        foreach (Renderer r in renderers)
            r.enabled = state;

        foreach (Collider c in colliders)
            c.enabled = state;
    }
}
