using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Catch_rider2 : MonoBehaviour {

	public static Catch_rider2 inst;
    public Final final;

    public Model_script model;
    public Model_script model_E;

	public Image[] Final_charator;
	public Image en_player,back;
	public string y;
	//public int i,r,e;

	void Awake() {
		inst = this;
	}
	// Use this for initialization
	void Start () {
        final = GetComponent<Final>();

		var currentScene = SceneManager.GetActiveScene();
		var currentSceneName = currentScene.name;

		en_player.sprite = model_E.listCard[PlayerPrefs.GetInt("enemy roll")].Psprite;
	}
	
	public void loadPIC(int count)
    {
        for(int i = 0; i < count; i++)
        {
            Final_charator[i].sprite = final.playerParty[i].Psprite;
            Final_charator[i].gameObject.SetActive(true);
        }
    }



	}
	

