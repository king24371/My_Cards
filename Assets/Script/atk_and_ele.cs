using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atk_and_ele : MonoBehaviour {

    public Model_script _ModelScript;

    public static atk_and_ele inst;

    public float atk,s_atk,def,hp , blk;
    public Element ele;


    void Awake()
    {
        if (inst = null)
            inst = this;
    }
    // Use this for initialization
    void Start()
    {

        F_I(ele, ele, out atk,
         out s_atk,
         out atk,
         out s_atk,
         atk, s_atk, atk, s_atk,
         def, def, blk, blk);

        T_M(ele, ele, out atk,
         out s_atk,
         out atk,
         out s_atk,
         atk, s_atk, atk, s_atk,
         def, def, blk, blk);

        A_Na(ele, ele, out atk,
         out s_atk,
         out atk,
         out s_atk,
         atk, s_atk, atk, s_atk,
         def, def, blk, blk);

        M_A(ele, ele, out atk,
         out s_atk,
         out atk,
         out s_atk,
         atk, s_atk, atk, s_atk,
         def, def, blk, blk);

        R_Nu(out atk,
         out s_atk,
         out atk,
         out s_atk,
         atk, s_atk, atk, s_atk,
         def, def, blk, blk);
    }

      

    public enum Element 
    {
        Fight_Ignis,
        Tech_Metal,
        Ability_Nature,
        Mage_Aqua,
        Rule_Null,
    }

    public void F_I
        (Element P,
        Element E,
        out float F_P_ad,
    out float F_P_adc,
    out float F_E_ad,
    out float F_E_adc,
    float P_ad,
    float P_adc,
    float E_ad,
    float E_adc,
    float P_def,
    float E_def,
    float P_blk,
    float E_blk
        )
    {
        //P = Element.Fight_Ignis;
        //E = Element.Fight_Ignis;
        if (P == Element.Tech_Metal)
        {
            F_P_ad = (E_ad - P_def) * (1 - P_blk) * 0.75f;
            F_E_ad = (P_ad - E_def) * (1 - E_blk) * 1.25f;
            F_P_adc = (E_adc - P_def) * (1 - P_blk) * 0.75f;
            F_E_adc = (P_adc - E_def) * (1 - E_blk) * 1.25f;
        }
        else
        {
            F_P_ad = (E_ad - P_def) * (1 - P_blk);
            F_E_ad = (P_ad - E_def) * (1 - E_blk);
            F_P_adc = (E_adc - P_def) * (1 - P_blk);
            F_E_adc = (P_adc - E_def) * (1 - E_blk);
        }
        if (E == Element.Tech_Metal)
        {
            F_P_ad = (E_ad - P_def) * (1 - P_blk) * 1.25f;
            F_E_ad = (P_ad - E_def) * (1 - E_blk) * 0.75f;
            F_P_adc = (E_adc - P_def) * (1 - P_blk) * 1.25f;
            F_E_adc = (P_adc - E_def) * (1 - E_blk) * 0.75f;
        }
        else
        {
            F_P_ad = (E_ad - P_def) * (1 - P_blk);
            F_E_ad = (P_ad - E_def) * (1 - E_blk);
            F_P_adc = (E_adc - P_def) * (1 - P_blk);
            F_E_adc = (P_adc - E_def) * (1 - E_blk);
        }
    }

    public void T_M
        (Element P,
        Element E,
        out float F_P_ad,
    out float F_P_adc,
    out float F_E_ad,
    out float F_E_adc,
    float P_ad,
    float P_adc,
    float E_ad,
    float E_adc,
    float P_def,
    float E_def,
    float P_blk,
    float E_blk
        )
    {
        //P = Element.Tech_Metal;
        //E = Element.Tech_Metal;
        if (P == Element.Ability_Nature)
        {
            F_P_ad = (E_ad - P_def) * (1 - P_blk) * 0.75f;
            F_E_ad = (P_ad - E_def) * (1 - E_blk) * 1.25f;
            F_P_adc = (E_adc - P_def) * (1 - P_blk) * 0.75f;
            F_E_adc = (P_adc - E_def) * (1 - E_blk) * 1.25f;
        }
        else
        {
            F_P_ad = (E_ad - P_def) * (1 - P_blk);
            F_E_ad = (P_ad - E_def) * (1 - E_blk);
            F_P_adc = (E_adc - P_def) * (1 - P_blk);
            F_E_adc = (P_adc - E_def) * (1 - E_blk);
        }
        if (E == Element.Ability_Nature)
        {
            F_P_ad = (E_ad - P_def) * (1 - P_blk) * 1.25f;
            F_E_ad = (P_ad - E_def) * (1 - E_blk) * 0.75f;
            F_P_adc = (E_adc - P_def) * (1 - P_blk) * 1.25f;
            F_E_adc = (P_adc - E_def) * (1 - E_blk) * 0.75f;
        }
        else
        {
            F_P_ad = (E_ad - P_def) * (1 - P_blk);
            F_E_ad = (P_ad - E_def) * (1 - E_blk);
            F_P_adc = (E_adc - P_def) * (1 - P_blk);
            F_E_adc = (P_adc - E_def) * (1 - E_blk);
        }
    }

    public void A_Na
        (Element P,
        Element E,
        out float F_P_ad,
    out float F_P_adc,
    out float F_E_ad,
    out float F_E_adc,
    float P_ad,
    float P_adc,
    float E_ad,
    float E_adc,
    float P_def,
    float E_def,
    float P_blk,
    float E_blk
        )
    {
        //P = Element.Ability_Nature;
        //E = Element.Ability_Nature;
        if (P == Element.Mage_Aqua)
        {
            F_P_ad = (E_ad - P_def) * (1 - P_blk) * 0.75f;
            F_E_ad = (P_ad - E_def) * (1 - E_blk) * 1.25f;
            F_P_adc = (E_adc - P_def) * (1 - P_blk) * 0.75f;
            F_E_adc = (P_adc - E_def) * (1 - E_blk) * 1.25f;
        }
        else
        {
            F_P_ad = (E_ad - P_def) * (1 - P_blk);
            F_E_ad = (P_ad - E_def) * (1 - E_blk);
            F_P_adc = (E_adc - P_def) * (1 - P_blk);
            F_E_adc = (P_adc - E_def) * (1 - E_blk);
        }
        if (E == Element.Mage_Aqua)
        {
            F_P_ad = (E_ad - P_def) * (1 - P_blk) * 1.25f;
            F_E_ad = (P_ad - E_def) * (1 - E_blk) * 0.75f;
            F_P_adc = (E_adc - P_def) * (1 - P_blk) * 1.25f;
            F_E_adc = (P_adc - E_def) * (1 - E_blk) * 0.75f;
        }
        else
        {
            F_P_ad = (E_ad - P_def) * (1 - P_blk);
            F_E_ad = (P_ad - E_def) * (1 - E_blk);
            F_P_adc = (E_adc - P_def) * (1 - P_blk);
            F_E_adc = (P_adc - E_def) * (1 - E_blk);
        }
    }

    public void M_A
        (Element P,
        Element E, 
        out float F_P_ad,
    out float F_P_adc,
    out float F_E_ad,
    out float F_E_adc,
    float P_ad,
    float P_adc,
    float E_ad,
    float E_adc,
    float P_def,
    float E_def,
    float P_blk,
    float E_blk
        )
    {
        //P = Element.Mage_Aqua;
        //E = Element.Mage_Aqua;
        if (P == Element.Fight_Ignis)
        {
            F_P_ad = (E_ad - P_def) * (1 - P_blk) * 0.75f;
            F_E_ad = (P_ad - E_def) * (1 - E_blk) * 1.25f;
            F_P_adc = (E_adc - P_def) * (1 - P_blk) * 0.75f;
            F_E_adc = (P_adc - E_def) * (1 - E_blk) * 1.25f;
        }
        else
        {
            F_P_ad = (E_ad - P_def) * (1 - P_blk);
            F_E_ad = (P_ad - E_def) * (1 - E_blk);
            F_P_adc = (E_adc - P_def) * (1 - P_blk);
            F_E_adc = (P_adc - E_def) * (1 - E_blk);
        }
        if (E == Element.Fight_Ignis)
        {
            F_P_ad = (E_ad - P_def) * (1 - P_blk) * 1.25f;
            F_E_ad = (P_ad - E_def) * (1 - E_blk) * 0.75f;
            F_P_adc = (E_adc - P_def) * (1 - P_blk) * 1.25f;
            F_E_adc = (P_adc - E_def) * (1 - E_blk) * 0.75f;
        }
        else
        {
            F_P_ad = (E_ad - P_def) * (1 - P_blk);
            F_E_ad = (P_ad - E_def) * (1 - E_blk);
            F_P_adc = (E_adc - P_def) * (1 - P_blk);
            F_E_adc = (P_adc - E_def) * (1 - E_blk);
        }
    }

    public void R_Nu(
        out float F_P_ad,
    out float F_P_adc,
    out float F_E_ad,
    out float F_E_adc,
    float P_ad,
    float P_adc,
    float E_ad,
    float E_adc,
    float P_def,
    float E_def,
    float P_blk,
    float E_blk
        )
    {
        F_P_ad = (E_ad - P_def) * (1 - P_blk) * 1.5f;
        F_E_ad = (P_ad - E_def) * (1 - E_blk) * 1.5f;
        F_P_adc = (E_adc - P_def) * (1 - P_blk) * 1.5f;
        F_E_adc = (P_adc - E_def) * (1 - E_blk) * 1.5f;
    }

}
