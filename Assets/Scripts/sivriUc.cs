using UnityEngine;
using System.Collections;

public class sivriUc : MonoBehaviour
{
    public Transform sivri_uc;
    public float kapali_suresi = 1f;
    public float acik_suresi = 2f;

    
    public void DisableSivriUc()
    {
        sivri_uc.gameObject.SetActive(false);
    }
    
    public void EnableSivriUc()
    {
        sivri_uc.gameObject.SetActive(true);
    }

    void Start()
    {
        StartCoroutine(SurekliBekleme());
    }

    IEnumerator SurekliBekleme()
    {
        while (true)
        {
            DisableSivriUc();
            yield return new WaitForSeconds(kapali_suresi);
            EnableSivriUc();
            yield return new WaitForSeconds(acik_suresi);
        }
    }
}
