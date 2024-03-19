using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Flash());

    }

    IEnumerator Flash()
    {
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
        new WaitForSeconds(1f);
        this.gameObject.SetActive(true);
       
    }

}
