using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveOnTrigger : MonoBehaviour
{

    public float dissolveTime = 5;
    public float refreshRate = 0.05f;
    public Material mat;
    public float minCutoff = -40.0f;
    public float maxCutoff = 60.0f;

    private bool dissolved = false;


    // Start is called before the first frame update
    void Start()
    {
        mat.SetFloat("Cutoff", 60.0f);

    }

    // Update is called once per frame
    void Update()
    {

 
       

    }

    public void StartDissolve()
    {
        
        StartCoroutine(DissolveObj(mat));
        
    }


    IEnumerator DissolveObj(Material mat)
    {
        float cutOff = mat.GetFloat("Cutoff");

        if (!dissolved)
        {
            while (cutOff > minCutoff)
            {
                cutOff -= 1 / (dissolveTime / refreshRate);
                mat.SetFloat("Cutoff", cutOff);

                yield return new WaitForSeconds(refreshRate);
            }
        }
        else
        {
            while (cutOff < maxCutoff)
            {
                cutOff += 1 / (dissolveTime / refreshRate);
                mat.SetFloat("Cutoff", cutOff);
                yield return new WaitForSeconds(refreshRate);
            }
        }

        if(cutOff <= minCutoff)
        {
            dissolved = true;
        }
        else
        {
            dissolved = false;
        }

    }
}