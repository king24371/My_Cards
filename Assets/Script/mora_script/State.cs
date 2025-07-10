using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneState
{
    //State Name
    private string m_StateName = "SceneState";
    public string stateName
    {
        get { return m_StateName; }
        set { m_StateName = value; }
    }

    //controller
    protected SceneStateController m_Controller = null;

    //structure
    public SceneState(SceneStateController Controller)
    {
        m_Controller = Controller;
    }

    public virtual void StateBegin()
    {

    }

    public virtual void StateEnd()
    {

    }

    public virtual void StateUpdate()
    {

    }

    public virtual void StateFunc()
    {

    }

    public override string ToString()
    {
        return string.Format($"[I_SceneState：StateName={stateName}]");
    }

}
