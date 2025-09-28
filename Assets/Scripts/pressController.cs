using UnityEngine;
using System.Collections;

public class pressController : MonoBehaviour
{
    public Transform hedefNokta;  
    public float hiz = 5f;
    public float beklemeSuresi = 0.5f;

    private Vector3 baslangicPozisyon;
    private bool ileriGidiyor = true;

    void Start()
    {
        baslangicPozisyon = transform.position;
        StartCoroutine(IleriGeriHareket());
    }

    IEnumerator IleriGeriHareket()
    {
        while (true)
        {
            Vector3 hedef = ileriGidiyor ? hedefNokta.position : baslangicPozisyon;

            
            while (Vector3.Distance(transform.position, hedef) > 0.05f)
            {
                transform.position = Vector3.MoveTowards(transform.position, hedef, hiz * Time.deltaTime);
                yield return null;
            }

            
            yield return new WaitForSeconds(beklemeSuresi);
            ileriGidiyor = !ileriGidiyor;
        }
    }
}
