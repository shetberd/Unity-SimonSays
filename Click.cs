using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour {

    Order order;

    float red = 0.01f;//values for hue
    float green = 0.41f;
    float blue = 0.66f;
    float yellow = 0.16f;

    int clickCounter = 0;

    public List<int> clickedSequence = new List<int>();//add clicked button to this list

    private void Start()
    {
        order = gameObject.GetComponent<Order>();
    }
    private void Update()
    {
        //check if the left mouse has been pressed down this frame
        if (Input.GetMouseButtonDown(0))
        {
            //empty RaycastHit object which raycast puts the hit details into
            RaycastHit hit;
            //ray shooting out of the camera from where the mouse is
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray,out hit))
            {             
                if (hit.collider.gameObject.name == "Red")
                {
                    StartCoroutine(hit.collider.gameObject.GetComponent<LightUp>().Blink(red,0.4f));
                    clickedSequence.Add(1);                   
                }
                if (hit.collider.gameObject.name == "Yellow")
                {
                    StartCoroutine(hit.collider.gameObject.GetComponent<LightUp>().Blink(yellow, 0.4f));
                    clickedSequence.Add(4);
                }
                if (hit.collider.gameObject.name == "Blue")
                {
                    StartCoroutine(hit.collider.gameObject.GetComponent<LightUp>().Blink(blue, 0.4f));
                    clickedSequence.Add(3);
                }
                if (hit.collider.gameObject.name == "Green")
                {
                    StartCoroutine(hit.collider.gameObject.GetComponent<LightUp>().Blink(green, 0.4f));
                    clickedSequence.Add(2);
                }

                if (clickedSequence[clickCounter] == order.sequence[clickCounter])//check if clicked button is the same as the chosen button
                {
                    //print("correct");
                    clickCounter += 1;
                    if (order.sequence.Count == clickedSequence.Count)//check if clicked list length is the same as random list
                    {
                        order.ChooseButton();
                        StartCoroutine(order.ShowOrder());
                        clickedSequence.Clear();
                        clickCounter = 0;
                    }
                }
                else
                {
                    SceneManager.LoadScene("MainMenu");
                }
            }               
        }
    }
}
