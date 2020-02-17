using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifetime;

    private void Start()
    {        
        Destroy(gameObject, lifetime);
        StartCoroutine(Expand());
    }
    IEnumerator Expand ()
    {
        int a = 0;
        float b = 1;
        float c = 1;                
       
        while (a <50)
        {
            a++;
            b += 0.02f;
            c -= 0.04f;
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, c);            
            GetComponent<Transform>().localScale = new Vector2(b, b);
            yield return new WaitForSeconds(0.05f);
        }        
    }
}


