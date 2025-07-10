using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Red Cards
/// </summary>
public class RedCard : MonoBehaviour
{
    string cardName;
    int ep;
    int count;
    string vow;

    public RedCard(string Name, int Ep, int Count, string Vow)
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

    public void derectAttack(data_card player)
    {
        int damage = count;
        mora.inst.actionTest(count, ep, player);
        Debug.Log(string.Format($"{player} :{vow} 直接攻擊- ep:{ep}, damage:{count}"));
    }

    public void firstAttack(data_card player)
    {
        int damage = count;
        mora.inst.actionTest(count, ep, player);
        Debug.Log(string.Format($"{player} :{vow} 先手攻擊- ep:{ep}, damage:{count}"));
    }

    public void breakShiled(data_card player)
    {
        int damage = count;
        mora.inst.actionTest(count, ep, player);
        mora.inst.sheidEvent(3, player);
        Debug.Log(string.Format($"{player} :{vow} 破盾- ep:{ep}, damage:{count}"));
    }

    public void attackToDef(data_card player)
    {
        int damage = count;
        mora.inst.actionTest(count, ep, player);
        mora.inst.lastIsRed(player, "以攻做防");
        Debug.Log(string.Format($"{player} :{vow} 以攻做防- ep:{ep}, damage:{count}"));
    }

    public void warMinePlus(data_card player)
    {
        int damage = count;
        mora.inst.actionTest(count, ep, player);
        mora.inst.lastIsRed(player, "戰意疊加");
        Debug.Log(string.Format($"{player} :{vow} 戰意疊加- ep:{ep}, damage:{count}"));
    }

    public void powerFeedback(data_card player)
    {
        int charge = count;
        mora.inst.actionTest(count, ep, player);
        mora.inst.lastIsRed (player, "動能反饋");
        Debug.Log(string.Format($"{player} :{vow} 動能反饋- ep:{ep}, charge:{count}"));
    }
}
