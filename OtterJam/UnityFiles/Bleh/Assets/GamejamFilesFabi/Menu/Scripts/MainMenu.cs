using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public CanvasGroup group;
    public GameObject firstSet;
    public GameObject secondSet;
    public float fadeTime;
    float time = 0.1f;
    bool starting = false, fading = false;

    // Start is called before the first frame update
    void Start()
    {
        firstSet.SetActive(true);
        secondSet.SetActive(false);


    }

    void Update()
    {
        if (group.alpha < 1 && !starting)
        {
            time += Time.deltaTime;
            group.alpha = Mathf.Clamp01(time / fadeTime);
        }

        if(fading)
        {
            time -= Time.deltaTime;
            group.alpha = Mathf.Clamp01(time / 5);
        }
    }

    public void PlayButton()
    {
        starting = true;

        while (group.alpha > 0)
        {
            time -= Time.deltaTime;
            group.alpha = Mathf.Clamp01(time / fadeTime);
        }

        if (group.alpha <= 0)
        {


            firstSet.SetActive(false);
            secondSet.SetActive(true);

            Invoke("Fading", 3);

            Invoke("Play", 8);

              while (group.alpha < 1)
            {
                time += Time.deltaTime;
                group.alpha = Mathf.Clamp01(time / fadeTime);
            }

        }

    }

    private void Play()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    private void Fading()
    {

        fading = true;
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
