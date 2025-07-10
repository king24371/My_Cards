using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tittle : MonoBehaviour
{
    [Header("Tittle")]
    public Button Play;
    public Button Rule;
    public Button Quit;

    [Header("Rule")]
    public GameObject rulePanel;

    [Header("Roll")]
    public GameObject rollPanel;

    // Start is called before the first frame update
    void Start()
    {
        Play.onClick.AddListener(roll);

        Rule.onClick.AddListener(rule);

        Quit.onClick.AddListener(exit);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void roll()
    {
        rollPanel.SetActive(true);
    }

    public void closeRoll()
    {
        rollPanel.SetActive(false);
    }

    void rule()
    {
        rulePanel.SetActive(true);
    }

    public void closeRule()
    {
        rulePanel.SetActive(false);
    }

    public void exit()
    {
        Application.Quit();
    }
}


//Tittle Scene(Start)
public class StartState : SceneState
{
    public StartState(SceneStateController Controller) : base(Controller) {
        this.stateName = "StartState";
    }

    public override void StateBegin()
    {

    }

    public override void StateUpdate()
    {
        //m_Controller.setState(new TittleState(m_Controller), "猜猜拳_開頭");
    }
}

//Tittle Scene
[System.Serializable]
public class TittleState : SceneState
{
   
    public TittleState(SceneStateController Controller) : base(Controller)
    {
        this.stateName = "TittlleState";
    }

    public override void StateBegin()
    {       

    }   

    public override void StateFunc()
    {
        //if (PlayerPrefs.GetInt("First roll") == 0)
        //{
        //    return;
        //}
        //else
        m_Controller.setState(new BattleState(m_Controller), "猜猜拳");
    }
}

