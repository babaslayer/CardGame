using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bravo : MonoBehaviour
{
    Material dissolveMaterial;
    float dissolveValue;
    [SerializeField] float dissolveSpeed;
    [SerializeField] bool isDissolving;
    // Start is called before the first frame update
    void Start()
    {
        isDissolving = false;
        dissolveMaterial = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Dissolve();
    }
    void Dissolve()
    {
        if (isDissolving)
        {
            dissolveValue = Mathf.MoveTowards(dissolveValue, 1f, dissolveSpeed * Time.deltaTime);
            dissolveMaterial.SetFloat("_alpha", dissolveValue);
            if (dissolveValue >= 1f)
            {
                Destroy(gameObject);
            }
        }
    }

    void Dead()
    {
        isDissolving = true;

        //Destroy(gameObject);
    }
}


