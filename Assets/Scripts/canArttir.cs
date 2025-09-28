using UnityEngine;
using System.Collections;

public class canArttir : MonoBehaviour
{
    [SerializeField]
    private int iyilesmeMiktari = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealtController healtController = other.GetComponent<HealtController>();
            if (healtController != null)
            {
                healtController.iyiles(iyilesmeMiktari);

                Transform body011 = other.transform.Find("Body_011");
                if (body011 != null)
                {
                    Renderer renderer = body011.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        renderer.material.color = Color.green;
                        StartCoroutine(RenkDegistir(renderer, Color.white, 0.5f));
                    }
                }

                
                GetComponent<Collider>().enabled = false;

                
                foreach (Renderer r in GetComponentsInChildren<Renderer>())
                {
                    r.enabled = false;
                }

                
            }
        }
    }

    private IEnumerator RenkDegistir(Renderer renderer, Color yeniRenk, float sure)
    {
        yield return new WaitForSeconds(sure);
        renderer.material.color = yeniRenk;

        
        Destroy(gameObject);
    }


    void Update()
    {
        gameObject.transform.Rotate(Vector3.right, 100 * Time.deltaTime);
    }
}
