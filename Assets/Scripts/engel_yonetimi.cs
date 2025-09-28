using UnityEngine;
using System.Collections;

public class engel_yonetimi : MonoBehaviour
{

    [SerializeField]
    private int hasarMiktari;

    
    private void OnCollisionEnter(Collision collision)
    {

          
        if (collision.gameObject.CompareTag("Player"))
        {

            collision.gameObject.GetComponent<HealtController>().hasarAl(hasarMiktari); // 

            
            Transform body011 = collision.transform.Find("Body_011");
            if (body011 != null)
            {
                
                Renderer renderer = body011.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material.color = Color.red;
                    
                    StartCoroutine(RenkDegistir(renderer, Color.white, 0.5f));


                }



            }


        }


    }

    private IEnumerator RenkDegistir(Renderer renderer, Color yeniRenk, float sure)
    {
        yield return new WaitForSeconds(sure);
        renderer.material.color = yeniRenk;
    }
}
