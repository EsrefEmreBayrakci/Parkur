using UnityEngine;

public class carkKontrol : MonoBehaviour
{
    public float hiz = 10f;
    public float donusHizi = 100f;
    public Transform donecekTransform;

    private Vector3 baslangicPozisyon;

    void Start()
    {
        
        baslangicPozisyon = donecekTransform.position;
    }

    void Update()
    {
        
        donecekTransform.RotateAround(donecekTransform.position, Vector3.forward, donusHizi * Time.deltaTime);

        
        float xOffset = Mathf.PingPong(Time.time * hiz, 2.8f) - 1.4f;
        donecekTransform.position = new Vector3(baslangicPozisyon.x + xOffset, baslangicPozisyon.y, baslangicPozisyon.z);
    }
}

