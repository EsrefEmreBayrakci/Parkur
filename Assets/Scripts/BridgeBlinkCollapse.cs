using UnityEngine;
using System.Collections;




public class BridgeBlinkCollapse : MonoBehaviour
{
    [Header("Yanıp Sönme Ayarları")]
    [SerializeField] private int blinkCount = 5;
    [SerializeField] private float blinkInterval = 0.2f;

    [Header("Kapanma-Açılma Süreleri")]
    [SerializeField] private float collapseDuration = 2f;
    [SerializeField] private float openDuration = 3f;

    private Renderer[] renderers;
    private Collider[] colliders;

    private void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
        colliders = GetComponentsInChildren<Collider>();

        StartCoroutine(BridgeLoop());
    }

    private IEnumerator BridgeLoop()
    {
        while (true)
        {
            
            for (int i = 0; i < blinkCount; i++)
            {
                SetBridgeState(false); 
                yield return new WaitForSeconds(blinkInterval);
                SetBridgeState(true);  
                yield return new WaitForSeconds(blinkInterval);
            }

            
            SetBridgeState(false);
            yield return new WaitForSeconds(collapseDuration);

            
            SetBridgeState(true);
            yield return new WaitForSeconds(openDuration);
        }
    }

    private void SetBridgeState(bool isActive)
    {
        foreach (Renderer r in renderers)
            r.enabled = isActive;

        foreach (Collider c in colliders)
            c.enabled = isActive;
    }
}


