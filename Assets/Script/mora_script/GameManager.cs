using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Scene State
    SceneStateController m_SceneStateController = new SceneStateController();

    private void Awake()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        //Set the first scene
        m_SceneStateController.setState(new TittleState(m_SceneStateController), "");

    }

    // Update is called once per frame
    void Update()
    {
        m_SceneStateController.StateUpdate();
    }
}
