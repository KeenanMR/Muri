using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("QuitGame", 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void QuitGame()
    {
        Application.Quit();
    }
}
