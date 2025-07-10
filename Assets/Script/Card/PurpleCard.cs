using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleCard : MonoBehaviour
{
    string cardName;
    int ep;
    int count;
    string vow;

    public PurpleCard(string Name, int Ep, int Count, string Vow)
    {
        this.cardName = Name;
        this.ep = Ep;
        this.count = Count;
        this.vow = Vow;

    }

    public string Name
    {
        get
        {
            return cardName;
        }
    }

    public string Vow
    {
        get
        {
            return vow;
        }

    }

    public int Ep
    {
        get
        {
            return ep;
        }
    }

    public int Count
    {
        get
        {
            return count;
        }
        set
        {
            count = value;
        }
    }

    public void horror()
    {
        int sanity = count;
        Debug.Log(string.Format($"{vow} 威嚇- ep:{ep}, sanity:{count}"));
    }

    public void hurtSelf()
    {
        int trueDamage = count;
        Debug.Log(string.Format($"{vow} 自殘- ep:{ep}, trueDamage:{count}"));
    }

    public void omniscientCurse()
    {
        int trueDamage = count;
        Debug.Log(string.Format($"{vow} 全知詛咒- ep:{ep}, trueDamage:{count}"));
    }

    public void weaknessNotice()
    {
        int sanity = count;
        Debug.Log(string.Format($"{vow} 弱點洞悉- ep:{ep}, sanity:{count}"));
    }

    public void tearPrey()
    {
        //int sanity = count;
        Debug.Log(string.Format($"{vow} 撕扯獵物- ep:{ep}, sanity:{count}"));
    }

    public void absorbArcane()
    {
        int trueDamage = count;
        Debug.Log(string.Format($"{vow} 汲能祕法- ep:{ep}, trueDamage:{count}"));
    }
}
