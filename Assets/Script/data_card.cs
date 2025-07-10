 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Create new card")]
[System.Serializable]
public class data_card :ScriptableObject
{
    public int number;
    public string pName;
    //public atk_and_ele.Element ele;
    public float atk, def, hp, ep, sanity;
    public Sprite Psprite, Effect, Active;

    public int Number
    {
        get
        {
            return number;
        }
    }

    public string Name
    {
        get
        {
            return pName;
        }
    }

    public int Atk
    {
        get
        {
            return (int)atk;
        }
        set
        {
            atk = value;
        }
    }

    public int Def
    {
        get
        {
            return (int)def;
        }
        set
        {
            def = value;
            if (def < 0)
            {
                def = 0;
            }
        }
    }

    public int HP
    {
        get
        {
            return (int)hp;
        }
        set
        {
            hp = value;
            if (hp < 0)
            {
                hp = 0;
            }
        }
    }

    public int EP
    {
        get
        {
            return (int)ep;
        }
        set
        {
            ep = value;
            if (ep < 0)
            {
                ep = 0;
            }
        }
    }

    public int Sanity
    {
        get
        {
            return (int)sanity;
        }
        set
        {
             sanity= value;
            if (sanity < 0)
            {
                sanity = 0;
            }
        }
    }

    public void X()
    {
        Debug.Log(pName);
    }
}




