using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyTex : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Texture texture = Resources.Load<Texture>("bg") as Texture;
        GetComponent<Renderer>().material.mainTexture = texture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
