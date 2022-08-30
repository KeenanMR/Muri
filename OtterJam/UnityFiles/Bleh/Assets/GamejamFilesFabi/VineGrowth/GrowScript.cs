using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowScript : MonoBehaviour
{
    public List<MeshRenderer> growMeshes;
    public float time = 5;
    public float refreshRate = 0.05f;
    [Range(0, 1)]
    public float minGrow = 0.2f;
    [Range(0, 1)]
    public float maxGrow = 0.97f;

    public float yes;

    private List<Material> growMats = new List<Material>();
    private bool fullGrown;


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < growMeshes.Count;i++)
        {
            Debug.Log("here");
            for (int j = 0; j <growMeshes[i].materials.Length; j++)
            {
                
                if (growMeshes[i].materials[j].HasProperty("Grow"))
                {
                    growMeshes[i].materials[j].SetFloat("Grow", minGrow);
                    growMats.Add(growMeshes[i].materials[j]);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            
            for(int i = 0; i < growMats.Count; i++)
            {
                StartCoroutine(GrowObj(growMats[i]));
            }
        }
    }

    IEnumerator GrowObj (Material mat)
    {
        float growValue = mat.GetFloat("Grow");
        
        if (!fullGrown)
        {
            
            while (growValue < maxGrow)
            {
                growValue += 1 / (time / refreshRate);
                mat.SetFloat("Grow", growValue);

                yield return new WaitForSeconds(refreshRate);
            }
        }
        else
        {
            while (growValue > maxGrow)
            {
                growValue -= 1 / (time / refreshRate);
                mat.SetFloat("Grow", growValue);

                yield return new WaitForSeconds(refreshRate);
            }
        }

        if(growValue >= maxGrow)
        {
            fullGrown = true;
        }
        else
        {
            fullGrown = false;
        }

    }

}
