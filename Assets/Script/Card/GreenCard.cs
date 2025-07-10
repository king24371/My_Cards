using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCard : MonoBehaviour
{
    string cardName;
    int ep;
    int count;
    string vow;

    public GreenCard(string Name, int Ep, int Count, string Vow)
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

    public void heal_Small(data_card player)
    {
        int heal = count;
        mora.inst.healTest(count, ep, player);
        Debug.Log(string.Format($"{player} :{vow} 治癒.小- ep:{ep}, heal:{count}"));
    }

    public void heal(data_card player)
    {
        int heal = count;
        mora.inst.healTest(count, ep, player);
        Debug.Log(string.Format($"{player} :{vow} 治癒- ep:{ep}, heal:{count}"));
    }

    public void natureMage(data_card player)
    {
        int charge = count;
        mora.inst.chargeTest(count, ep, player);
        Debug.Log(string.Format($"{player} :{vow} 道法自然- ep:{ep}, charge:{count}"));
    }

    public void giveUp2Force(data_card player)
    {
        mora.inst.chargeTest(count, ep, player);
        Debug.Log(string.Format($"{player} :{vow} 卸負回能- ep:{ep}, charge:{count}"));
    }

    public void Nap(data_card player)
    {
        //int heal = count;
        Debug.Log(string.Format($"{player} :{vow} 孤注一擲- ep:{ep}, heal:{count}"));
    }

    public void flashInspiration(data_card player)
    {
        //int heal = count;
        Debug.Log(string.Format($"{player} :{vow} 福至心靈- ep:{ep}, heal:{count}"));
    }

    public void energyColapse(data_card player)
    {
        //int heal = count;
        Debug.Log(string.Format($"{player} :{vow} 能量坍縮- ep:{ep}, heal:{count}"));
    }

    public void Calm(data_card player)
    {
        //int heal = count;
        Debug.Log(string.Format($"{player} :{vow} 處變不驚- ep:{ep}, heal:{count}"));
    }
}
