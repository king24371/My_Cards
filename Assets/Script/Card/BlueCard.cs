using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Red Cards
/// </summary>
public class BlueCard : MonoBehaviour
{
    string cardName;
    int ep;
    int count;
    string vow;

    public BlueCard(string Name, int Ep, int Count, string Vow)
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

    public void derectDefense(data_card player)
    {
        int defense = count;
        mora.inst.defTest(count, ep, player);
        Debug.Log(string.Format($"{player} :{vow} 架樁格擋- ep:{ep}, defense:{count}"));
    }

    public void chainDefense(data_card player)
    {
        int defense = count;
        mora.inst.defTest(count, ep, player);
        Debug.Log(string.Format($"{player} :{vow} 連續防禦- ep:{ep}, defense:{count}"));
    }

    public void fastDefense(data_card player)
    {
        int defense = count;
        mora.inst.defTest(count, ep, player);
        Debug.Log(string.Format($"{player} :{vow} 快速回防- ep:{ep}, defense:{count}"));
    }

    public void backDefense(data_card player)
    {
        int defense = count;
        mora.inst.defTest(count, ep, player);
        Debug.Log(string.Format($"{player} :{vow} 退步格架- ep:{ep}, defense:{count}"));
    }

    public void train1000(data_card player)
    {
        int defense = count;
        mora.inst.defTest(count, ep, player);
        Debug.Log(string.Format($"{player} :{vow} 千錘百煉- ep:{ep}, defense:{count}"));
    }

    public void returnDefense(data_card player)
    {
        int defense = count;
        mora.inst.defTest(count, ep, player);
        Debug.Log(string.Format($"{player} :{vow} 回身格擋- ep:{ep}, defense:{count}"));
    }
}
