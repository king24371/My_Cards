using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

//Battle Scene
public class BattleState : SceneState
{
    public BattleState(SceneStateController Controller) : base(Controller) {
        this.stateName = "BattleState";
    }

    public override void StateBegin()
    {
        base.StateBegin();
    }

    public override void StateEnd()
    {
        base.StateEnd();
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
    }
}

public class Final : MonoBehaviour
{
    public CardManager cardManager;
    public Model_script model;
    public Model_script model_E;
    public data_card[] playerParty;
    public data_card playerPFB;
    public data_card dataPlayer;
    public data_card dataEnemy;
    public int firstRoll, enemyRoll;
    public int initPlayreEP, initPlayreDEF, initEnemyEP, initEnemyDEF;

    public Text Atk_P;
    public Text Def_P;
    public Text Ep_P;
    public Text Atk_E;
    public Text Def_E;
    public Image playerHP;
    public Image enemyHP;
    public int Ep_E;

    public Text Dual;
    public Text Coffin;

    //void Awake()
    //{
    //    inst = this;
    //}


    // use this for initialization
    void Start()
    {
        cardManager = GetComponent<CardManager>();
        Init();

        Atk_P.text = dataPlayer.Atk.ToString();
        Def_P.text = 0.ToString();
        Ep_P.text = dataPlayer.EP.ToString();

        Atk_E.text = dataEnemy.Atk.ToString();
        Def_E.text = 0.ToString();
        Ep_E = dataEnemy.EP;
        initPlayreEP = int.Parse(Ep_P.text);
        initPlayreDEF = int.Parse(Def_P.text);
        initEnemyEP = Ep_E;
        initEnemyDEF = int.Parse(Def_E.text);
        int d = cardManager.areaDual.transform.childCount;
        int c = cardManager.areaCoffin.transform.childCount;
        Dual.text = (d-1).ToString();
        Coffin.text = c.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (dataPlayer.Atk != int.Parse(Atk_P.text) || dataPlayer.Def != int.Parse(Def_P.text) || dataPlayer.EP != int.Parse(Ep_P.text))
            statusFresh();

        if (cardManager.areaCoffin.transform.childCount != int.Parse(Coffin.text) || cardManager.areaDual.transform.childCount != int.Parse(Dual.text)) 
            baseFresh();
    }

    public void Init()
    {
        //firstRoll = PlayerPrefs.GetInt("First roll");
        //Debug.Log("First roll:" + firstRoll);
        enemyRoll = PlayerPrefs.GetInt("enemy roll");
        Debug.Log("Enemy roll:" + enemyRoll);

        playerPFB.HP = playerParty.Sum(data_card => data_card.HP);
        playerPFB.EP = playerParty.Sum(data_card => data_card.EP);
        playerPFB.Atk = playerParty.Sum(data_card => data_card.Atk);
        playerPFB.Def = playerParty.Sum(data_card => data_card.Def);

        dataPlayer = Instantiate(playerPFB);
        dataEnemy = Instantiate(model_E.listCard[enemyRoll]);

        Player_hp();
        Enemy_hp();

        Catch_rider2.inst.loadPIC(playerParty.Length);

        cardManager.loadActive();

        mora.inst.buildBuff();
    }

    public void Player_hp()
    {
        mora.inst.max_player = mora.inst.hp_player = dataPlayer.HP;
        //return dataPlayer.hp;
    }

    public void Enemy_hp()
    {
        mora.inst.max_enemy = mora.inst.hp_enemy = dataEnemy.HP;
        //return dataEnemy.hp;
    }

    void statusFresh()
    {
        Atk_P.text = dataPlayer.Atk.ToString();
        Def_P.text = dataPlayer.Def.ToString();
        Ep_P.text = dataPlayer.EP.ToString();

        Atk_E.text = dataEnemy.Atk.ToString();
        Def_E.text = dataEnemy.Def.ToString();
        //Ep_E.text = dataEnemy.EP.ToString();
    }

    void baseFresh()
    {
        int d = cardManager.areaDual.transform.childCount;
        int c = cardManager.areaCoffin.transform.childCount;
        Dual.text = (d - 1).ToString();
        Coffin.text = c .ToString();
    }

   
    //public void Hisastu()
    //{
    //    if (PlayerPrefs.GetInt("henshin press") > 1)
    //    {
    //        mora.inst.hp_enemy -= dataPlayer.atk * 2.5f;
    //    }

    //    if (PlayerPrefs.GetInt("henshin press") >= 1)
    //    {
    //        if (firstRoll == 0)
    //        {
    //            StartCoroutine(ReturnScene.inst.PlayDenO_A());
    //        }

    //        if (firstRoll == 1)
    //        {
    //            StartCoroutine(ReturnScene.inst.PlayGhost_B_A());
    //        }

    //        if (firstRoll == 2 && PlayerPrefs.GetInt("harzard") == 4)
    //        {
    //            StartCoroutine(ReturnScene.inst.PlayBuild_RR_A());
    //        }
    //        if (firstRoll == 2 && PlayerPrefs.GetInt("harzard") == 5)
    //        {
    //            StartCoroutine(ReturnScene.inst.PlayBiuld_TT_A());
    //        }

    //        if (firstRoll == 3)
    //        {
    //            StartCoroutine(ReturnScene.inst.PlaySaber_C_A());
    //        }

    //        mora.inst.hp_enemy -= dataPlayer.atk * 3;
    //    }
    //    if (PlayerPrefs.GetInt("henshin press") >= 2)
    //    {
    //        if (firstRoll == 0)
    //        {
    //            StartCoroutine(ReturnScene.inst.PlayDenO_S_A());
    //        }

    //        if (firstRoll == 1)
    //        {
    //            StartCoroutine(ReturnScene.inst.PlayGhost_M_A());
    //        }

    //        if (firstRoll == 2)
    //            StartCoroutine(ReturnScene.inst.PlayBuild_G_A());

    //        if (firstRoll == 3)
    //        {
    //            StartCoroutine(ReturnScene.inst.PlaySaber_DK_A());
    //        }

    //        mora.inst.hp_enemy -= dataPlayer.atk * 4;
    //    }
    //}

    //public void E_Hisastu()
    //{
    //    mora.inst.mp_enemy -= 100;

    //    if (dataEnemy.hp == 100)
    //    {
    //        mora.inst.hp_player -= dataEnemy.atk * 2.5f;
    //        Debug.Log("eh1");
    //    }
    //    if (dataEnemy.hp == 150)
    //    {
    //        if (enemyRoll == 3)
    //        {
    //            StartCoroutine(ReturnScene.inst.PlayEvol_A());
    //        }

    //        mora.inst.hp_player -= dataEnemy.atk * 3;
    //        Debug.Log("eh2");
    //    }
    //    if (dataEnemy.hp == 250)
    //    {
    //        if (enemyRoll == 3)
    //        {
    //            StartCoroutine(ReturnScene.inst.PlayEvol_M_A());
    //        }
    //        if (enemyRoll == 4)
    //        {
    //            StartCoroutine(ReturnScene.inst.PlayJadrg_A());
    //        }

    //        mora.inst.hp_player -= dataEnemy.atk * 4;
    //        Debug.Log("eh3");
    //    }
    //}


    
    
}
