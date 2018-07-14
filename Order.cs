using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour {

    [SerializeField] LightUp[] obj; //objects containing the LightUp script.

    public int orderCounter = 2; //start with 2 buttons

    public List<int> sequence = new List<int>();//list of chosen buttons in order

    private void Start()
    {
        StartCoroutine(StartOrder());
    }  
    public IEnumerator ShowOrder()//blink the buttons in order
    {
        for (int i = 0; i < sequence.Count; i++)
        {
            yield return new WaitForSeconds(1f);
            if (sequence[i] == 1)
            {
                //red 0.01f
                StartCoroutine(obj[0].Blink(0.01f, 0.6f));
            }
            if (sequence[i] == 2)
            {
                //green 0.41f
                StartCoroutine(obj[1].Blink(0.41f, 0.6f));
            }
            if (sequence[i] == 3)
            {
                //blue 0.66f
                StartCoroutine(obj[2].Blink(0.66f, 0.6f));
            }
            if (sequence[i] == 4)
            {
                //yellow 0.16f
                StartCoroutine(obj[3].Blink(0.16f, 0.6f));
            }        
        }
    }

    public IEnumerator StartOrder()//choose first 2 buttons
    {    
        for (int i = 0; i < orderCounter; i++)
        {
            ChooseButton();
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(ShowOrder());
    }   

    public void ChooseButton()//choose a random button
    {
        float randNum = Random.Range(0, 4); 
        if (randNum == 0)
        {
            //red 0.01f
            sequence.Add(1);
        }

        if (randNum == 1)
        {
            //green 0.41f
            sequence.Add(2);
        }

        if (randNum == 2)
        {
            //blue 0.66f
            sequence.Add(3);
        }

        if (randNum == 3)
        {
            //yellow 0.16f
            sequence.Add(4);
        }
    }
}
