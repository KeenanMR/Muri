using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastInteract : MonoBehaviour
{

    Ray interacterRay;
    RaycastHit hitData;
    public Canvas canvas;
    public FirstPerson script;
    public List<GameObject> lines;
    public List<GameObject> backGround;

    public GameObject stay;
    public GameObject leave;
    public GameObject inter;

    private int count = 0;


    // Start is called before the first frame update
    void Start()
    {
        interacterRay = Camera.main.ViewportPointToRay(new Vector3(0.7f, 0.7f, 0));

        canvas.enabled = false;
        Time.timeScale = 1;

        for (int i = 0; i < lines.Count; i++)
        {
            lines[i].SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        interacterRay = Camera.main.ViewportPointToRay(new Vector3(0.3f, 0.3f, 0));

        Debug.DrawRay(interacterRay.origin, interacterRay.direction * 5);


        if (Physics.Raycast(interacterRay, out hitData, 15))
        {

            if (hitData.collider.tag == "Inter")
            {
                canvas.enabled = true;

                if (Input.GetKeyDown(KeyCode.F))
                {
                    backGround[0].SetActive(true);
                    backGround[1].SetActive(true);


                    if (count == 0)
                    {
                        lines[count].SetActive(true);
                    }
                    else if(count == 9)
                    {
                        lines[count - 1].SetActive(false);

                        

                        stay.SetActive(true);
                        leave.SetActive(true);

                        backGround[0].SetActive(false);
                        backGround[1].SetActive(false);
                        inter.SetActive(false);
                    }
                    else
                    {
                        lines[count].SetActive(true);
                        lines[count - 1].SetActive(false);
                    }


                       

                 
                    if(count <= 8)
                    {
                        count++;
                    }
                    

                }



            }
            else
            {
                canvas.enabled = false;

            }

        }



    }
}

