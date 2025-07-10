//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public abstract class CardEffect
//{
//    public abstract void ApplyEffect(CardStatus cardStatus, data_card player);
//}

#region 紅牌
public class derectAttackEffect : CardStatus
{
    public string Name { get { return "直接攻擊"; } }
    public string Vow { get { return "剪"; } }
    public int Ep { get { return 1; } }
    private int count = 2;  // 私有字段
    public int Count { get { return count; } set { count = value; } }  // 公共屬性
    public int Count1 { get { return count; } set { count = value; } }  // 公共屬性
    public int Count2 { get { return count; } set { count = value; } }  // 公共屬性

    public void setStatus(data_card player)
    {
        count = (int)(player.Atk * 0.15f);
    }

    public void ApplyEffect()
    {
        
    }

    public void Action(data_card player)
    {
        int damage = Count;
        mora.inst.actionTest(Count, Ep, player);
        Debug.Log(string.Format($"{player} :{Vow} 直接攻擊- ep:{Ep}, damage:{Count}"));
    }

    public void ApplyEffect(bool b)
    {
         
    }
}

public class firstAttackEffect : CardStatus
{
    public string Name { get { return "先手攻擊"; } }
    public string Vow { get { return "剪"; } }
    public int Ep { get { return 0; } }
    private int count = 3;  // 私有字段
    public int Count { get { return count; } set { count = value; } }  // 公共屬性
    public int Count1 { get { return count; } set { count = value; } }  // 公共屬性
    public int Count2 { get { return count; } set { count = value; } }  // 公共屬性

    public void ApplyEffect()
    {

    }

    public void setStatus(data_card player)
    {
        count = (int)(player.Atk * 0.1f);
    }

    public void Action(data_card player)
    {
        int damage = Count;
        mora.inst.actionTest(Count, Ep, player);
        Debug.Log(string.Format($"{player} :{Vow} {Name}- ep:{Ep}, damage:{Count}"));
    }

    public void ApplyEffect(bool b)
    {
         
    }
}

public class breakShieldEffect : CardStatus
{
    public string Name { get { return "破盾"; } }
    public string Vow { get { return "剪"; } }
    public int Ep { get { return 1; } }
    private int count = 3;  // 私有字段
    public int Count { get { return count; } set { count = value; } }  // 公共屬性
    private int spcount = 3;  // 私有字段
    public int Count1 { get { return spcount; } set { spcount = value; } }  // 公共屬性
    public int Count2 { get { return count; } set { count = value; } }  // 公共屬性

    public void setStatus(data_card player)
    {
        count = (int)(player.Atk * 0.15f);
        spcount = (int)(player.Atk * 0.2f);
    }

    public void ApplyEffect()
    {

    }

    public void Action(data_card player)
    {
        int damage = Count;
        mora.inst.actionTest_D(Count1, 0, player);
        mora.inst.actionTest(Count, Ep, player);
        Debug.Log(string.Format($"{player} :{Vow} {Name}- ep:{Ep}, damage:{Count}"));
    }

    public void ApplyEffect(bool b)
    {
         
    }
}

public class attackToDefEffect : CardStatus
{
    public string Name { get { return "以攻作防"; } }
    public string Vow { get { return "剪"; } }
    public int Ep { get { return 1; } }
    private int count = 3;  // 私有字段
    public int Count { get { return count; } set { count = value; } }  // 公共屬性
    private int spcount = 3;  // 私有字段
    public int Count1 { get { return spcount; } set { spcount = value; } }  // 公共屬性
    public int Count2 { get { return count; } set { count = value; } }  // 公共屬性
    public bool follow;

    public void setStatus(data_card player)
    {
        count = (int)(player.Atk * 0.15f);
        spcount = (int)(player.Def * 0.15f);
    }

    public void ApplyEffect(bool b)
    {
        follow = b;
        if(follow)
            Debug.Log($"{Name}已觸發");
        else
            Debug.Log($"{Name}被取消");
    }

    public void Action(data_card player)
    {
        int damage = Count;
        mora.inst.actionTest(Count, Ep, player);
        if(follow)
            mora.inst.defTest(Count1, 0, player);
        Debug.Log(string.Format($"{player} :{Vow} {Name}- ep:{Ep}, damage:{Count}"));
        ApplyEffect(false);
    }

    public void ApplyEffect()
    {
         
    }
}

public class warMinePlusEffect : CardStatus
{
    public string Name { get { return "戰意疊加"; } }
    public string Vow { get { return "剪"; } }
    public int Ep { get { return 1; } }
    private int init_count = 3;  // 私有字段
    private int count = 3;  // 私有字段
    public int Count { get { return count; } set { count = value; } }  // 公共屬性
    private int spcount = 3;  // 私有字段
    public int Count1 { get { return spcount; } set { spcount = value; } }  // 公共屬性
    private int init_plusDValue = 1;
    private int plusDValue = 1;
    public int Count2 { get { return plusDValue; } set { plusDValue = value; } }
    public bool follow;

    public void setStatus(data_card player)
    {
        count = (int)(player.Atk * 0.2f);
        init_count = count;
        spcount = (int)(player.Atk * 0.15f);
        plusDValue = (int)(player.Def * 0.1f);
        init_plusDValue = plusDValue;
    }

    public void ApplyEffect()
    {

    }

    public void ApplyEffect(bool b)
    {
        follow = b;
        if (follow)
        {
            count += Count1;
            plusDValue += plusDValue;
            Debug.Log($"{Name}已觸發, A: {count}, D: {plusDValue}");
        }
        else
        {
            Debug.Log($"{Name}被取消");
            Count = init_count;
            Count2 = init_plusDValue;
        }
    }

    public void Action(data_card player)
    {
        int damage = Count;
        if (follow)
        {
            mora.inst.actionTest(Count, Ep, player);
            mora.inst.defTest(Count2, 0, player);
        }else
            mora.inst.actionTest(Count, Ep, player);
        Debug.Log(string.Format($"{player} :{Vow} {Name}- ep:{Ep}, damage:{Count}"));
        ApplyEffect(false);
    }
}

public class powerFeedbackEffect : CardStatus
{
    public string Name { get { return "動能反饋"; } }
    public string Vow { get { return "剪"; } }
    public int Ep { get { return 0; } }
    private int count = 3;  // 私有字段
    public int Count { get { return count; } set { count = value; } }  // 公共屬性
    public int Count1 { get { return count; } set { count = value; } }  // 公共屬性
    public int Count2 { get { return count; } set { count = value; } }  // 公共屬性
    public bool follow;

    public void setStatus(data_card player)
    {
        count = (int)(player.Atk * 0.1f);
    }

    public void ApplyEffect()
    {
         
    }

    public void ApplyEffect(bool b)
    {
        follow = b;
        if (follow)
            Debug.Log($"{Name}已觸發");
        else
            Debug.Log($"{Name}被取消");
    }

    public void Action(data_card player)
    {
        int damage = Count;
        mora.inst.actionTest(Count, Ep, player);
        if (follow)
            mora.inst.chargeTest(1, 0, player);
        Debug.Log(string.Format($"{player} :{Vow} {Name}- ep:{Ep}, damage:{Count}"));
        ApplyEffect(false);
    }
}
#endregion


#region 藍牌
public class derectDefenceEffect : CardStatus
{
    public string Name { get { return "架樁格擋"; } }
    public string Vow { get { return "石"; } }
    public int Ep { get { return 1; } }
    private int count = 2;  // 私有字段
    public int Count { get { return count; } set { count = value; } }  // 公共屬性
    public int Count1 { get { return count; } set { count = value; } }  // 公共屬性
    public int Count2 { get { return count; } set { count = value; } }  // 公共屬性

    public void setStatus(data_card player)
    {
        count = (int)(player.Def * 0.15f);
    }

    public void ApplyEffect()
    {

    }

    public void ApplyEffect(bool b)
    {

    }

    public void Action(data_card player)
    {
        int damage = Count;
        mora.inst.defTest(Count, Ep, player);
        Debug.Log(string.Format($"{player} :{Vow} {Name}- ep:{Ep}, damage:{Count}"));
    }
}

public class fastDefenceEffect : CardStatus
{
    public string Name { get { return "快速回防"; } }
    public string Vow { get { return "石"; } }
    public int Ep { get { return 0; } }
    private int count = 1;  // 私有字段
    public int Count { get { return count; } set { count = value; } }  // 公共屬性
    public int Count1 { get { return count; } set { count = value; } }  // 公共屬性
    public int Count2 { get { return count; } set { count = value; } }  // 公共屬性

    public void setStatus(data_card player)
    {
        count = (int)(player.Def * 0.1f);
    }

    public void ApplyEffect()
    {

    }

    public void ApplyEffect(bool b)
    {

    }

    public void Action(data_card player)
    {
        int damage = Count;
        mora.inst.defTest(Count, Ep, player);
        Debug.Log(string.Format($"{player} :{Vow} {Name}- ep:{Ep}, damage:{Count}"));
    }
}

public class chainDefenceEffect : CardStatus
{
    public string Name { get { return "連續防禦"; } }
    public string Vow { get { return "石"; } }
    public int Ep { get { return 1; } }
    private int count = 3;  // 私有字段
    public int Count { get { return count; } set { count = value; } }  // 公共屬性
    public int Count1 { get { return count; } set { count = value; } }  // 公共屬性
    public int Count2 { get { return count; } set { count = value; } }  // 公共屬性
    public bool follow;

    public void setStatus(data_card player)
    {
        count = (int)(player.Def * 0.15f);
    }

    public void ApplyEffect()
    {

    }

    public void ApplyEffect(bool b)
    {
        follow = b;
        if (follow)
            Debug.Log($"{Name}已觸發");
        else
            Debug.Log($"{Name}被取消");
    }

    public void Action(data_card player)
    {
        mora.inst.defTest(Count, Ep, player);
        if (follow)
            CardManager.inst.Dual(2, Mora.石);
        Debug.Log(string.Format($"{player} :{Vow} {Name}- ep:{Ep}, damage:{Count}"));
        ApplyEffect(false);
    }
}

public class backDefenceEffect : CardStatus
{
    public string Name { get { return "退步格架"; } }
    public string Vow { get { return "石"; } }
    public int Ep { get { return 2; } }
    private int count = 3;  // 私有字段
    public int Count { get { return count; } set { count = value; } }  // 公共屬性
    public int Count1 { get { return count; } set { count = value; } }  // 公共屬性
    public int Count2 { get { return count; } set { count = value; } }  // 公共屬性

    public void setStatus(data_card player)
    {
        count = (int)(player.Def * 0.2f);
    }

    public void ApplyEffect()
    {

    }

    public void ApplyEffect(bool b)
    {

    }

    public void Action(data_card player)
    {
        mora.inst.defTest(Count, Ep, player);
        if (CardManager.inst.myPanel.transform.childCount < 4)
            CardManager.inst.Dual(2);
        Debug.Log(string.Format($"{player} :{Vow} {Name}- ep:{Ep}, damage:{Count}"));
    }
}

public class returnDefenceEffect : CardStatus
{
    public string Name { get { return "回身格擋"; } }
    public string Vow { get { return "石"; } }
    public int Ep { get { return 1; } }
    private int count = 3;  // 私有字段
    public int Count { get { return count; } set { count = value; } }  // 公共屬性
    public int Count1 { get { return count; } set { count = value; } }  // 公共屬性
    public int Count2 { get { return count; } set { count = value; } }  // 公共屬性
    public bool follow;

    public void setStatus(data_card player)
    {
        count = (int)(player.Def * 0.15f);
    }

    public void ApplyEffect()
    {

    }

    public void ApplyEffect(bool b)
    {
        follow = b;
        if (follow)
            Debug.Log($"{Name}已觸發");
        else
            Debug.Log($"{Name}被取消");
    }

    public void Action(data_card player)
    {
        mora.inst.defTest(Count, Ep, player);
        if(follow)
            CardManager.inst.Dual(1);
        Debug.Log(string.Format($"{player} :{Vow} {Name}- ep:{Ep}, damage:{Count}"));
        ApplyEffect(false);
    }
}

public class train1000Effect : CardStatus
{
    public string Name { get { return "千錘百煉"; } }
    public string Vow { get { return "石"; } }
    public int Ep { get { return 1; } }
    private int init_count = 2;  
    private int count = 2;  // 私有字段
    public int Count { get { return count; } set { count = value; } }  // 公共屬性
    private int plusDValue = 3;
    public int Count1 { get { return plusDValue; } set { plusDValue = value; } }
    public int Count2 { get { return count; } set { count = value; } }  // 公共屬性
    public bool follow;

    public void setStatus(data_card player)
    {
        count = (int)(player.Def * 0.15f);
        init_count = count;
        plusDValue = (int)(player.Def * 0.2f);
    }

    public void ApplyEffect()
    {

    }

    public void ApplyEffect(bool b)
    {
        follow = b;
        if (follow)
        {
            count += Count1;
            Debug.Log($"{Name}已觸發, D: {count}");
        }
        else
        {
            Debug.Log($"{Name}被取消");
            Count = init_count;
        }
    }

    public void Action(data_card player)
    {
        mora.inst.defTest(Count, Ep, player);
        Debug.Log(string.Format($"{player} :{Vow} {Name}- ep:{Ep}, damage:{Count}"));
        ApplyEffect(false);
    }
}
#endregion


#region 綠牌
public class smallHealEffect : CardStatus
{
    public string Name { get { return "治癒.小"; } }
    public string Vow { get { return "布"; } }
    public int Ep { get { return 1; } }
    private int count = 1;  // 私有字段
    public int Count { get { return count; } set { count = value; } }  // 公共屬性
    public int Count1 { get { return count; } set { count = value; } }  // 公共屬性
    public int Count2 { get { return count; } set { count = value; } }  // 公共屬性

    public void setStatus(data_card player)
    {
        count = (int)(player.HP * 0.02f);
    }

    public void ApplyEffect()
    {

    }

    public void ApplyEffect(bool b)
    {

    }

    public void Action(data_card player)
    {
        mora.inst.healTest(Count, Ep, player);
        Debug.Log(string.Format($"{player} :{Vow} {Name}- ep:{Ep}, damage:{Count}"));
    }
}

public class HealEffect : CardStatus
{
    public string Name { get { return "治癒"; } }
    public string Vow { get { return "布"; } }
    public int Ep { get { return 2; } }
    private int count = 3;  // 私有字段
    public int Count { get { return count; } set { count = value; } }  // 公共屬性
    public int Count1 { get { return count; } set { count = value; } }  // 公共屬性
    public int Count2 { get { return count; } set { count = value; } }  // 公共屬性

    public void setStatus(data_card player)
    {
        count = (int)(player.HP * 0.05f);
    }

    public void ApplyEffect()
    {

    }

    public void ApplyEffect(bool b)
    {

    }

    public void Action(data_card player)
    {
        mora.inst.healTest(Count, Ep, player);
        Debug.Log(string.Format($"{player} :{Vow} {Name}- ep:{Ep}, damage:{Count}"));
    }
}

public class natureMageEffect : CardStatus
{
    public string Name { get { return "道法自然"; } }
    public string Vow { get { return "布"; } }
    public int Ep { get { return 0; } }
    private int count = 3;  // 私有字段
    public int Count { get { return count; } set { count = value; } }  // 公共屬性
    public int Count1 { get { return count; } set { count = value; } }  // 公共屬性
    public int Count2 { get { return count; } set { count = value; } }  // 公共屬性

    public void setStatus(data_card player)
    {
        count = (int)(player.HP * 0.01f);
    }

    public void ApplyEffect()
    {

    }

    public void ApplyEffect(bool b)
    {

    }

    public void Action(data_card player)
    {
        mora.inst.healTest(Count, Ep, player);
        mora.inst.chargeTest(1, Ep, player);
        Debug.Log(string.Format($"{player} :{Vow} {Name}- ep:{Ep}, damage:{Count}"));
    }
}

public class giveUp2ForceEffect : CardStatus
{
    public string Name { get { return "卸負回能"; } }
    public string Vow { get { return "布"; } }
    public int Ep { get { return 0; } }
    private int count = 3;  // 私有字段
    public int Count { get { return count; } set { count = value; } }  // 公共屬性
    public int Count1 { get { return count; } set { count = value; } }  // 公共屬性
    public int Count2 { get { return count; } set { count = value; } }  // 公共屬性

    public void setStatus(data_card player)
    {
        count = (int)(player.HP * 0.01f);
    }

    public void ApplyEffect()
    {

    }

    public void ApplyEffect(bool b)
    {

    }

    public void Action(data_card player)
    {
        mora.inst.healTest(Count, Ep, player);
        CardManager.inst.openTrowUI("throw");
        mora.inst.chargeTest(1, 0, player);
        Debug.Log(string.Format($"{player} :{Vow} {Name}- ep:{Ep}, damage:{Count}"));
    }
}

public class NapEffect : CardStatus
{
    public string Name { get { return "孤注一擲"; } }
    public string Vow { get { return "布"; } }
    public int Ep { get { return 2; } }
    private int count = 3;  // 私有字段
    public int Count { get { return count; } set { count = value; } }  // 公共屬性
    public int Count1 { get { return count; } set { count = value; } }  // 公共屬性
    public int Count2 { get { return count; } set { count = value; } }  // 公共屬性

    public void setStatus(data_card player)
    {
        count = (int)(player.HP * 0.01f);
    }

    public void ApplyEffect()
    {

    }

    public void ApplyEffect(bool b)
    {

    }

    public void Action(data_card player)
    {
        mora.inst.healTest(Count, Ep, player);
        CardManager.inst.throwAllCards();
        CardManager.inst.Dual(3);
        Debug.Log(string.Format($"{player} :{Vow} {Name}- ep:{Ep}, damage:{Count}"));
    }
}

public class flashInspirationEffect : CardStatus
{
    public string Name { get { return "福至心靈"; } }
    public string Vow { get { return "布"; } }
    public int Ep { get { return 1; } }
    private int count = 3;  // 私有字段
    public int Count { get { return count; } set { count = value; } }  // 公共屬性
    public int Count1 { get { return count; } set { count = value; } }  // 公共屬性
    public int Count2 { get { return count; } set { count = value; } }  // 公共屬性

    public void setStatus(data_card player)
    {
        count = (int)(player.HP * 0.01f);
    }

    public void ApplyEffect()
    {

    }

    public void ApplyEffect(bool b)
    {

    }

    public void Action(data_card player)
    {
        mora.inst.healTest(Count, Ep, player);
        CardManager.inst.Dual(2);
        Debug.Log(string.Format($"{player} :{Vow} {Name}- ep:{Ep}, damage:{Count}"));
    }
}

public class EnergeColapseEffect : CardStatus
{
    public string Name { get { return "能量坍縮"; } }
    public string Vow { get { return "布"; } }
    public int Ep { get { return 1; } }
    private int count = 3;  // 私有字段
    public int Count { get { return count; } set { count = value; } }  // 公共屬性
    public int Count1 { get { return count; } set { count = value; } }  // 公共屬性
    public int Count2 { get { return count; } set { count = value; } }  // 公共屬性

    public void setStatus(data_card player)
    {
        count = (int)(player.HP * 0.01f);
    }

    public void ApplyEffect()
    {

    }

    public void ApplyEffect(bool b)
    {

    }

    public void Action(data_card player)
    {
        mora.inst.healTest(Count, Ep, player);
        CardManager.inst.Dual(3, Mora.剪);
        Debug.Log(string.Format($"{player} :{Vow} {Name}- ep:{Ep}, damage:{Count}"));
    }
}

public class CalmEffect : CardStatus
{
    public string Name { get { return "處變不驚"; } }
    public string Vow { get { return "布"; } }
    public int Ep { get { return 0; } }
    private int count = 1;  // 私有字段
    public int Count { get { return count; } set { count = value; } }  // 公共屬性
    public int Count1 { get { return 1; } set { count = value; } }  // 公共屬性
    public int Count2 { get { return count; } set { count = value; } }  // 公共屬性
    bool follow;

    public void setStatus(data_card player)
    {
        //count = (int)(player.HP * 0.01f);
    }

    public void ApplyEffect()
    {

    }

    public void ApplyEffect(bool b)
    {
        follow = b;
        if (follow)
        {
            count += Count1;
            Debug.Log($"{Name}已觸發, D: {count}");
        }
        else
        {
            Debug.Log($"{Name}被取消");
            Count = 1;
        }
    }

    public void Action(data_card player)
    {
        CardManager.inst.Dual(Count);
        Debug.Log(string.Format($"{player} :{Vow} {Name}- ep:{Ep}, damage:{Count}"));
    }
}

public class powerChargeEffect : CardStatus
{
    public string Name { get { return "力量充能"; } }
    public string Vow { get { return "布"; } }
    public int Ep { get { return 1; } }
    private int count = 1;  // 私有字段
    public int Count { get { return count; } set { count = value; } }  // 公共屬性
    public int Count1 { get { return count; } set { count = value; } }  // 公共屬性
    public int Count2 { get { return count; } set { count = value; } }  // 公共屬性

    public void setStatus(data_card player)
    {
    }

    public void ApplyEffect()
    {

    }

    public void ApplyEffect(bool b)
    {

    }

    public void Action(data_card player)
    {
        Debug.Log(string.Format($"{player} :{Vow} {Name}- ep:{Ep}, damage:{Count}"));
    }
}

public class sentMallEffect : CardStatus
{
    public string Name { get { return "聖餐"; } }
    public string Vow { get { return "布"; } }
    public int Ep { get { return 2; } }
    public int Count
    {
        get { return 1; }
        set
        {
            Count = value;
        }
    }
    public int Count1 { get { return 0; } set { } }  // 公共屬性
    public int Count2 { get { return 0; } set { } }  // 公共屬性

    public void setStatus(data_card player)
    {
        //count = (int)(player.HP * 0.01f);
    }

    public void ApplyEffect()
    {

    }

    public void ApplyEffect(bool b)
    {

    }

    public void Action(data_card player)
    {
        Debug.Log(string.Format($"{player} :{Vow} {Name}- ep:{Ep}, damage:{Count}"));
    }
}
#endregion



#region 紫牌
public class HorrorEffect : CardStatus
{
    public string Name { get { return "威嚇"; } }
    public string Vow { get { return null; } }
    public int Ep { get { return 1; } }
    public int Count { get { return 5; }set { Count = value; } }
    public int Count1 { get { return 0; } set { } }  // 公共屬性
    public int Count2 { get { return 0; } set { } }  // 公共屬性

    public void setStatus(data_card player)
    {
    }

    public void ApplyEffect()
    {

    }

    public void ApplyEffect(bool b)
    {

    }

    public void Action(data_card player)
    {
        Debug.Log(string.Format($"{player} :{Vow} {Name}- ep:{Ep}, damage:{Count}"));
    }
}

public class hurtSelfEffect : CardStatus
{
    public string Name { get { return "自殘"; } }
    public string Vow { get { return null; } }
    public int Ep { get { return 0; } }
    private int count = 3;  // 私有字段
    public int Count { get { return count; } set { count = value; } }  // 公共屬性
    public int Count1 { get { return count; } set { count = value; } }  // 公共屬性
    public int Count2 { get { return count; } set { count = value; } }  // 公共屬性

    public void setStatus(data_card player)
    {
        count = (int)(player.HP * 0.01f);
    }

    public void ApplyEffect()
    {

    }

    public void ApplyEffect(bool b)
    {

    }

    public void Action(data_card player)
    {
        mora.inst.action_trueDamage(Count, Ep, player, true);
        CardManager.inst.Dual(1);
        Debug.Log(string.Format($"{player} :{Vow} {Name}- ep:{Ep}, damage:{Count}"));
    }
}

public class omniscientCurseEffect : CardStatus
{
    public string Name { get { return "全知詛咒"; } }
    public string Vow { get { return null; } }
    public int Ep { get { return 1; } }
    private int count = 3;  // 私有字段
    public int Count { get { return count; } set { count = value; } }  // 公共屬性
    public int Count1 { get { return count; } set { count = value; } }  // 公共屬性
    public int Count2 { get { return count; } set { count = value; } }  // 公共屬性

    public void setStatus(data_card player)
    {
        count = (int)(player.HP * 0.01f);
    }

    public void ApplyEffect()
    {

    }

    public void ApplyEffect(bool b)
    {

    }

    public void Action(data_card player)
    {
        mora.inst.action_trueDamage(Count, Ep, player, true);
        CardManager.inst.openTrowUI("copy");
        Debug.Log(string.Format($"{player} :{Vow} {Name}- ep:{Ep}, damage:{Count}"));
    }
}

public class weaknessNoticeEffect : CardStatus
{
    public string Name { get { return "弱點洞悉"; } }
    public string Vow { get { return null; } }
    public int Ep { get { return 1; } }
    public int Count { get { return 1; } set { Count = value; } }
    public int Count1 { get { return 0; } set { } }  // 公共屬性
    public int Count2 { get { return 0; } set { } }  // 公共屬性

    public void setStatus(data_card player)
    {
    }

    public void ApplyEffect()
    {

    }

    public void ApplyEffect(bool b)
    {

    }

    public void Action(data_card player)
    {
        mora.inst.effectTest(player, "Jakuten");
        Debug.Log(string.Format($"{player} :{Vow} {Name}- ep:{Ep}, damage:{Count}"));
    }
}

public class tearPreyEffect : CardStatus
{
    public string Name { get { return "撕扯獵物"; } }
    public string Vow { get { return null; } }
    public int Ep { get { return 2; } }
    public int Count { get { return 0; } set { Count = value; } }
    public int Count1 { get { return 0; } set { } }  // 公共屬性
    public int Count2 { get { return 0; } set { } }  // 公共屬性

    public void setStatus(data_card player)
    {
    }

    public void ApplyEffect()
    {

    }

    public void ApplyEffect(bool b)
    {

    }

    public void Action(data_card player)
    {
        Debug.Log(string.Format($"{player} :{Vow} {Name}- ep:{Ep}, damage:{Count}"));
    }
}

public class absorbArcaneEffect : CardStatus
{
    public string Name { get { return "汲能祕法"; } }
    public string Vow { get { return null; } }
    public int Ep { get { return 0; } }
    private int count = 3;  // 私有字段
    public int Count { get { return count; } set { count = value; } }  // 公共屬性
    public int Count1 { get { return count; } set { count = value; } }  // 公共屬性
    public int Count2 { get { return count; } set { count = value; } }  // 公共屬性

    public void setStatus(data_card player)
    {
        count = (int)(player.HP * 0.01f);
    }

    public void ApplyEffect()
    {

    }

    public void ApplyEffect(bool b)
    {

    }

    public void Action(data_card player)
    {
        mora.inst.action_trueDamage(Count, Ep, player, true);
        mora.inst.chargeTest(2, Ep, player);
        Debug.Log(string.Format($"{player} :{Vow} {Name}- ep:{Ep}, damage:{Count}"));
    }
}

public class WeakEffect : CardStatus
{
    public string Name { get { return "虛弱"; } }
    public string Vow { get { return null; } }
    public int Ep { get { return 1; } }
    public int Count { get { return 0; } set { Count = value; } }
    public int Count1 { get { return 0; } set { } }  // 公共屬性
    public int Count2 { get { return 0; } set { } }  // 公共屬性

    public void setStatus(data_card player)
    {
    }

    public void ApplyEffect()
    {

    }

    public void ApplyEffect(bool b)
    {

    }

    public void Action(data_card player)
    {
        Debug.Log(string.Format($"{player} :{Vow} {Name}- ep:{Ep}, damage:{Count}"));
    }
}

public class machineErosionEffect : CardStatus
{
    public string Name { get { return "機械侵蝕"; } }
    public string Vow { get { return null; } }
    public int Ep { get { return 1; } }
    public int Count { get { return 0; } set { Count = value; } }
    public int Count1 { get { return 0; } set { } }  // 公共屬性
    public int Count2 { get { return 0; } set { } }  // 公共屬性

    public void setStatus(data_card player)
    {
    }

    public void ApplyEffect()
    {

    }

    public void ApplyEffect(bool b)
    {

    }

    public void Action(data_card player)
    {
        Debug.Log(string.Format($"{player} :{Vow} {Name}- ep:{Ep}, damage:{Count}"));
    }
}

public class crimsonHumeEffect : CardStatus
{
    public string Name { get { return "深紅休謨"; } }
    public string Vow { get { return null; } }
    public int Ep { get { return 1; } }
    public int Count { get { return 0; } set { Count = value; } }
    public int Count1 { get { return 0; } set { } }  // 公共屬性
    public int Count2 { get { return 0; } set { } }  // 公共屬性

    public void setStatus(data_card player)
    {
    }

    public void ApplyEffect()
    {

    }

    public void ApplyEffect(bool b)
    {

    }

    public void Action(data_card player)
    {
        Debug.Log(string.Format($"{player} :{Vow} {Name}- ep:{Ep}, damage:{Count}"));
    }
}

public class UnamableEffect : CardStatus
{
    public string Name { get { return "不可名狀"; } }
    public string Vow { get { return null; } }
    public int Ep { get { return 1; } }
    public int Count { get { return 0; } set { Count = value; } }
    public int Count1 { get { return 0; } set { } }  // 公共屬性
    public int Count2 { get { return 0; } set { } }  // 公共屬性

    public void setStatus(data_card player)
    {
    }

    public void ApplyEffect()
    {

    }

    public void ApplyEffect(bool b)
    {

    }

    public void Action(data_card player)
    {
        Debug.Log(string.Format($"{player} :{Vow} 不可名狀- ep:{Ep}, damage:{Count}"));
    }
}

public class sentSealEffect : CardStatus
{
    public string Name { get { return "神聖戒護"; } }
    public string Vow { get { return null; } }
    public int Ep { get { return 1; } }
    public int Count { get { return 0; } set { Count = value; } }
    public int Count1 { get { return 0; } set { } }  // 公共屬性
    public int Count2 { get { return 0; } set { } }  // 公共屬性

    public void setStatus(data_card player)
    {
    }

    public void ApplyEffect()
    {

    }

    public void ApplyEffect(bool b)
    {

    }

    public void Action(data_card player)
    {
        int hanCard = CardManager.inst.enemyPanel.transform.childCount;
        int r = Random.Range(0, hanCard);
        Object.Destroy(CardManager.inst.enemyPanel.transform.GetChild(r).gameObject);

        Debug.Log(string.Format($"{player} :{Vow} 神聖戒護- ep:{Ep}, damage:{Count}"));
    }
}

public class hateFleshEffect : CardStatus
{
    public string Name { get { return "憎惡的血肉-"; } }
    public string Vow { get { return null; } }
    public int Ep { get { return 1; } }
    public int Count { get { return 0; } set { Count = value; } }
    public int Count1 { get { return 0; } set { } }  // 公共屬性
    public int Count2 { get { return 0; } set { } }  // 公共屬性

    public void setStatus(data_card player)
    {
    }

    public void ApplyEffect()
    {

    }

    public void ApplyEffect(bool b)
    {

    }

    public void Action(data_card player)
    {
        Debug.Log(string.Format($"{player} :{Vow} 憎惡的血肉- ep:{Ep}, damage:{Count}"));
    }
}
#endregion

#region 黑牌
public class ConfusionEffect : CardStatus
{
    public string Name { get { return "混亂"; } }
    public string Vow { get { return "黑"; } }
    public int Ep { get { return 1; } }
    public int Count { get { return 0; } set { Count = value; } }
    public int Count1 { get { return 0; } set { } }  // 公共屬性
    public int Count2 { get { return 0; } set { } }  // 公共屬性

    public void setStatus(data_card player)
    {
    }

    public void ApplyEffect()
    {

    }

    public void ApplyEffect(bool b)
    {

    }

    public void Action(data_card player)
    {
        Debug.Log(string.Format($"{player} :{Vow} 混亂- ep:{Ep}, damage:{Count}"));
    }
}

public class nanoBugEffect : CardStatus
{
    public string Name { get { return "奈米蟲"; } }
    public string Vow { get { return "黑"; } }
    public int Ep { get { return 1; } }
    public int Count { get { return 0; } set { Count = value; } }
    public int Count1 { get { return 0; } set { } }  // 公共屬性
    public int Count2 { get { return 0; } set { } }  // 公共屬性

    public void setStatus(data_card player)
    {
    }

    public void ApplyEffect()
    {

    }

    public void ApplyEffect(bool b)
    {

    }

    public void Action(data_card player)
    {
        Debug.Log(string.Format($"{player} :{Vow} 奈米蟲- ep:{Ep}, damage:{Count}"));
    }
}
#endregion