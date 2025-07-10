using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    public static BuffManager inst;

    private List<Buff> _buffs;
    private data_card _card;

    private void Awake()
    {
        inst = this;
    }

    public BuffManager(data_card card)
    {
        _buffs = new List<Buff>();
        _card = card;
    }

    public void AddBuff(Buff buff)
    {
        buff.applyBuff();
        _buffs.Add(buff);
    }

    public void RemoveBuff(Buff buff)
    {
        buff.removeBuff();
        _buffs.Remove(buff);
    }

    public void UpdateBuffs()
    {
        foreach (var buff in _buffs)
        {
            buff.applyBuff();
        }
    }
}
