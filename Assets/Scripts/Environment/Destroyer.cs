using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public string parentName;

    void Start()
    {
        parentName = transform.name;
        StartCoroutine(DestroyClone());
    }

    IEnumerator DestroyClone()
    {
        Debug.Log("DestroyClone started");
        yield return new WaitForSeconds(45);
        if (parentName == "Section(Clone)")
        {
             Debug.Log("Destroying: " + gameObject.name); 
            Destroy(gameObject);
        }
    }


}
