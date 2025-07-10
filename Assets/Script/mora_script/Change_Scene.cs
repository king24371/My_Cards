using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneStateController
{
    private SceneState m_State;
    private bool m_bRunBegin = false;

    public SceneStateController() { }

    public void setState(SceneState State, string loadSceneName)
    {
        Debug.Log("Set state: " + State.ToString());
        m_bRunBegin = false;

        //Load Scene
        LoadScene(loadSceneName);

        //call the last State is over
        if (m_State != null)
            m_State.StateEnd();

        m_State = State;
    }

    //Load Scene
    private void LoadScene(string loadSceneName)
    {
        if (loadSceneName == null || loadSceneName.Length == 0)
            return;
        SceneManager.LoadScene(loadSceneName);
    }

    public void StateUpdate()
    {
        if (Application.isLoadingLevel)
        {
            return;
        }

        //call new State begin
        if(m_State != null && m_bRunBegin == false)
        {
            m_State.StateBegin();
            m_bRunBegin = true;
        }

        if (m_State != null)
            m_State.StateUpdate();
    }
}

public class Change_Scene : MonoBehaviour 
{
	public static bool Isbgm_chs;

    void Awake()
    {
		var currentScene = SceneManager.GetActiveScene();
		var currentSceneName = currentScene.name;
		Debug.Log("1：" + SceneManager.GetActiveScene().name);
		if (currentScene.name == "猜猜拳_開頭")
		{
			PlayerPrefs.DeleteKey("henshin press");
			Debug.Log("i in 0= " + PlayerPrefs.GetInt("henshin press"));
			PlayerPrefs.DeleteKey("e_henshin press");
			Debug.Log("i in 0= " + PlayerPrefs.GetInt("henshin press"));
            PlayerPrefs.DeleteKey("First roll");
            Debug.Log("roll = " + PlayerPrefs.GetInt("First roll"));
        }
	}

	// Use this for initialization
	void Start ()
	{
		var currentScene = SceneManager.GetActiveScene();
		var currentSceneName = currentScene.name;
		if (currentScene.name == "First")
		{
			//AudioManager.Playroll();
		}

		if (currentScene.name == "猜猜拳")
		{
			//AudioManager.Playbattle();
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void Current()
	{
		SceneManager.LoadScene("猜猜拳");

		//AudioManager.Playbattle();
	}

    void play()
    {

    }

	public void exitscene()
	{
		SceneManager.LoadScene("猜猜拳_開頭");

		AudioManager.Playtittle();
	}

	
}
