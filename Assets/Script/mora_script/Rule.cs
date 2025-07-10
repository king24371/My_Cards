using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rule : MonoBehaviour {

    public Tittle tittle;
	public Image r;
	public Button nxt, Last, Back;
	public Sprite[] rule;
    public int next ,last ,count ;

	// Use this for initialization
	void Start () {
        Last.gameObject.SetActive(false);
        nxt.onClick.AddListener(delegate
        {
            count++;
            NxtEvent();
        });

        Last.onClick.AddListener(delegate
        {
            count--;
            NxtEvent();
        });

        Back.onClick.AddListener(tittle.closeRule);
    }

    // Update is called once per frame
    void Update () {
		
	}

    void NxtEvent()
    {
        if (next > 5)
            next = 0;
        if (last < 0)
            last = 2;

        switch (count)
        {
            case 0:
                Last.gameObject.SetActive(false);
                nxt.gameObject.SetActive(true);
                r.sprite = rule[0];
                //Debug.Log(l);
                break;
            case 1:
                r.sprite = rule[count];
                Last.gameObject.SetActive(true);
                break;
            case 2:
                r.sprite = rule[count];
                break;
            case 3:
                r.sprite = rule[count];
                break;
            case 4:
                r.sprite = rule[count];
                break;
            case 5:
                r.sprite = rule[count];
                nxt.gameObject.SetActive(false);
                break;
        }
    }

 
}
