using UnityEngine;

public class BalanceBeam : MonoBehaviour
{
    public Transform player;
    public float torqueStrength = 2f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (player == null) return;

        // Oyuncunun çubuğa göre lokal pozisyonu
        Vector3 localPos = transform.InverseTransformPoint(player.position);

        float direction = Mathf.Clamp(localPos.x, -1f, 1f); 
        rb.AddTorque(Vector3.forward * -direction * torqueStrength);
    }
}
