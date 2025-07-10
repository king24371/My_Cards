using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Roll_Script : MonoBehaviour {

    public TittleState tittleState;
    public Tittle tittle;
    public SceneStateController controller = new SceneStateController();
    public Model_script model_Script;

    public Image R_player, Slct;
	public List<Sprite> Charators = new List<Sprite>(6);
	public Button roll;
	public Button Back;
	int i,r,r1;
	// Use this for initialization
	void Start() {
        tittleState = new TittleState(controller);

        for(int i = 0; i < Charators.Count; i++)
        {
            Charators[i] = model_Script.listCard[i].Psprite;
        }

		Slct.gameObject.SetActive(false);

        roll.onClick.AddListener(First_roll);
        Back.onClick.AddListener(tittle.closeRoll);

		i = Random.Range(0, 5);
		Debug.Log("i:" + i);
		PlayerPrefs.SetInt("enemy roll", i);
		PlayerPrefs.Save();
		Debug.Log("Enemy was saved:" + PlayerPrefs.GetInt("enemy roll"));
	}

	// Update is called once per frame
	void Update() {
		
	}

	public void First_roll()
	{
		//AudioManager.PlayRollV();

        StartCoroutine(rolling());

        i = Random.Range(0, 6);
		Debug.Log("i:" + i);
		PlayerPrefs.SetInt("First roll", i);
		PlayerPrefs.Save();
		Debug.Log("Card was saved");
		Debug.Log("First roll：" + (PlayerPrefs.GetInt("First roll")+1));
		
		StartCoroutine(LoadSecond());
	}

	IEnumerator rolling()
	{
		for(r = 0;r < 500; r++)
        {
			r1 = Random.Range(0, 4);
			R_player.sprite = Charators[r1];
			yield return new WaitForSeconds(0.1f);
			R_player.sprite = Charators[r1++];
		}
		
		yield return new WaitForSeconds(3);
	}

	IEnumerator LoadSecond()
    {
        yield return new WaitForSeconds(1.5f);//括號內填入影片時間
        roll.gameObject.SetActive(false);
        Slct.gameObject.SetActive(true);

        Slct.sprite = Charators[i];

        //AudioManager.Playcharactor();

        yield return new WaitForSeconds(1);
       tittleState.StateFunc();
    }
	
}
