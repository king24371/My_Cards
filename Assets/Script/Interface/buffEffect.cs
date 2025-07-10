using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBuff : Buff
{
    private int _attackBonus;
    private data_card _card;

    public PowerBuff(data_card card, int attackBonus)
    {
        _card = card;
        _attackBonus = attackBonus;
    }

    public void applyBuff()
    {
        _card.Atk += _attackBonus;
    }

    public void removeBuff()
    {
        _card.Atk -= _attackBonus;
    }
}

public class JakutenBuff : Buff
{
    private int _attackBonus;
    private data_card _card;

    public JakutenBuff(data_card card, int attackBonus)
    {
        _card = card;
        _attackBonus = attackBonus;
    }

    public void applyBuff()
    {
        _card.Def -= _attackBonus;
    }

    public void removeBuff()
    {
        _card.Def += _attackBonus;
    }
}
