using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mora : MonoBehaviour
{
    public static mora inst;
    public Final final;
    public CardManager cardManager;

    void Awake()
    {
        inst = this;
    } 

    public int win_fre; //贏的次數
    public int ran;
    int i,c,y;
    int i_player;
    int ene_num;

    public float wait_time;

    public bool Ischoose;
    public bool Istime;
    //public bool red;

    public static bool Isanswer_y;

    public Mora player;
    public Mora enemy;
    Mora _vow;

    //public Sprite[] 剪刀;
    //public Sprite[] 石頭;

    public Image Win;
    public Image Lost;
    public Image WinLost;

    public Button re_btn;
    public Button overRound;

    //血條
    public float max_player;
    public float max_enemy;
    public float hp_player;
    public float hp_enemy;

    public Slider blood_player;
    public Slider blood_enemy;
    public Text blood_playerTxt;
    public Text blood_enemyTxt;

    // 創建 BuffManager 物件
    BuffManager buffManagerPlayer;
    BuffManager buffManagerEnemy;

    //創建Buff
    PowerBuff powerBuffP;
    PowerBuff powerBuffE;

    JakutenBuff jakutenBuffP;
    JakutenBuff jakutenBuffE;

    // Use this for initialization
    void Start()
    {
        final = GetComponent<Final>();
        cardManager = GetComponent<CardManager>();

        re_btn.gameObject.SetActive(false);

        WinLost.gameObject.SetActive(false);

        overRound.onClick.AddListener(OverRound);
    }

    // Update is called once per frame
    void Update()
    {
        hp_enemy = final.dataEnemy.HP;
        hp_player = final.dataPlayer.HP;

        blood_playerTxt.text = $"{hp_player}/{max_player}";
        blood_enemyTxt.text = $"{hp_enemy}/{max_enemy}";
        blood_player.value = 100 * (hp_player / max_player);
        blood_enemy.value = 100 * (hp_enemy / max_enemy);

        if (hp_player <= 0.0f || max_player <= 0.0f)
        {
            //AudioManager.Lost();

            //re_btn.gameObject.SetActive(true);
            //WinLost.gameObject.SetActive(true);
            //Lost.gameObject.SetActive(true);
            //print("Game over");
        }
        else if (hp_enemy <= 0.0f || max_enemy <= 0.0f)
        {
            AudioManager.current.Win();

            re_btn.gameObject.SetActive(true);
            WinLost.gameObject.SetActive(true);
            Win.gameObject.SetActive(true);
            print("Claear");
        }
        else if (hp_player <= 0.0f || max_player <= 0.0f && hp_enemy <= 0 || max_enemy <= 0) {
            //AudioManager.Lost();

            //re_btn.gameObject.SetActive(true);
            //WinLost.gameObject.SetActive(true);
            //Lost.gameObject.SetActive(true);
            //print("Game over");
        }
        else
        {
            re_btn.gameObject.SetActive(false);
            WinLost.gameObject.SetActive(false);
        }

        if (final.dataPlayer.Def > 0)
        {
            blood_player.fillRect.transform.GetComponent<Image>().color = Color.blue;
        } else
            blood_player.fillRect.transform.GetComponent<Image>().color = Color.green;
        if (final.dataEnemy.Def > 0)
        {
            blood_enemy.fillRect.transform.GetComponent<Image>().color = Color.blue;
        } else
            blood_enemy.fillRect.transform.GetComponent<Image>().color = Color.red;
    


        if (Istime)
            wait_time += Time.deltaTime;

        if (wait_time > 0.1)
        {
            wait_time = 0.0f;

            Ischoose = false;
            Istime = false;

            Debug.Log("player: " + player);

            if (y == 1)
            {
                winlost_ad();
            }else if (y == 2)
            {
                winlost_adc();
            }
        }        
    }

    //創建Buff
    public void buildBuff()
    {
        buffManagerPlayer = new BuffManager(final.dataPlayer);
        buffManagerEnemy = new BuffManager(final.dataEnemy);

        powerBuffP = new PowerBuff(final.dataPlayer, 1);
        powerBuffE = new PowerBuff(final.dataEnemy, 1);

        jakutenBuffP = new JakutenBuff(final.dataPlayer, 1);
        jakutenBuffE = new JakutenBuff(final.dataEnemy, 1);
    }

    public void actionTest(int plus, int ep, data_card player)
    {
        //print("mora:" + player.Name);
        if (player.Name == final.dataPlayer.Name)
        {
            if (final.dataEnemy.Def == 0)
            {
                final.dataEnemy.HP -= plus;
            }
            else if (plus > final.dataEnemy.Def)
            {
                int 差值 = plus - final.dataEnemy.Def;
                final.dataEnemy.Def = 0;
                final.dataEnemy.HP -= 差值;
            }
            else
            {
                final.dataEnemy.Def -= plus;
            }

            final.dataPlayer.EP -= ep;
        }
        else
        {
            if (final.dataPlayer.Def == 0)
            {
                final.dataPlayer.HP -= plus;
            }
            else if (plus > final.dataPlayer.Def)
            {
                int 差值 = plus - final.dataPlayer.Def;
                final.dataPlayer.Def = 0;
                final.dataPlayer.HP -= 差值;
            }
            else
            {
                final.dataPlayer.Def -= plus;
            }

            final.dataEnemy.EP -= ep;
            print(string.Format($"{player.Name}- EP: {player.EP}"));
        }
        
    }
    public void actionTest_D(int plus, int ep, data_card player)
    {
        //print("mora:" + player.Name);
        if (player.Name == final.dataPlayer.Name)
        {
            if (final.dataEnemy.Def == 0)
            {
                return;
            }
            else if (plus > final.dataEnemy.Def)
            {
                final.dataEnemy.Def = 0;
            }
            else
            {
                final.dataEnemy.Def -= plus;
            }
        }
    }
    public void action_trueDamage(int plus, int ep, data_card player, bool self)
    {
        //print("mora:" + player.Name);
        if (player.Name == final.dataPlayer.Name)
        {
            if(self)
                final.dataPlayer.HP -= plus;
            else
                final.dataEnemy.HP -= plus;

            final.dataPlayer.EP -= ep;
        }
        else
        {
            final.dataPlayer.HP -= plus;
            final.dataEnemy.EP -= ep;
        }
    }

    public void defTest(int plus, int ep, data_card player)
    {
        if(player.Name == final.dataPlayer.Name)
        {
            final.dataPlayer.Def += plus;
            final.dataPlayer.EP -= ep;
        }
        else
        {
            final.dataEnemy.Def += plus;
            final.dataEnemy.EP -= ep;

            print(string.Format($"{player.Name}- EP: {player.EP}"));
        }
        
    }

    public void healTest(int plus, int ep, data_card player)
    {
        if(player.Name == final.dataPlayer.Name)
        {
            final.dataPlayer.HP += plus;
            if (final.dataPlayer.HP > max_player)
                final.dataPlayer.HP = (int)max_player;
            final.dataPlayer.EP -= ep;
        }
        else
        {
            final.dataEnemy.HP += plus;
            if (final.dataEnemy.HP > max_enemy)
                final.dataEnemy.HP = (int)max_enemy;
            final.dataEnemy.EP -= ep;

            print(string.Format($"{player.Name}- EP: {player.EP}"));
        }
        
    }

    public void chargeTest(int plus, int ep, data_card player)
    {
        if(player.Name == final.dataPlayer.Name)
        {
            final.dataPlayer.EP += plus;
            final.dataPlayer.EP -= ep;
        }
        else
        {
            final.dataEnemy.EP += plus;
            final.dataEnemy.EP -= ep;

            print(string.Format($"{player.Name}- EP: {player.EP}"));
        }
        
    }

    public void effectTest(data_card player, string buff)
    {
        if (player.Name == final.dataPlayer.Name)
        {
            switch (buff)
            {
                case "Power":
                    buffManagerPlayer.AddBuff(powerBuffP);
                    Debug.Log($"Player Attack: {player.Atk}");
                    break;
                case "Jakuten":
                    buffManagerPlayer.AddBuff(jakutenBuffP);
                    Debug.Log($"Player Attack: {player.Def}");
                    break;
            }
        }
        else
        {
            switch (buff)
            {
                case "Power":
                    buffManagerEnemy.AddBuff(powerBuffE);
                    Debug.Log($"Player Attack: {player.Atk}");
                    break;
                case "Jakuten":
                    buffManagerEnemy.AddBuff(jakutenBuffE);
                    Debug.Log($"Player Attack: {player.Def}");
                    break;
            }
        }
    }

    public void lastIsRed(data_card player, string skill)
    {
        if (cardManager.isRed)
            {
                print("紅牌判定: " + skill);
                switch (skill)
                {
                    case "以攻作防":
                        defTest(2, 0, player);
                        break;
                    case "戰意疊加":
                        actionTest((2 * cardManager.redCount)-2, 0, player);
                        defTest((2 * cardManager.redCount) - 2, 0, player);
                        break;
                    case "動能反饋":
                        chargeTest(1, 0, player);
                        break;
                }
            }
            else
                return;
    }

    public void sheidEvent(int count, data_card player)
    {
        if (player.Name == final.dataPlayer.Name)
        {
            final.dataPlayer.Def += count;
        }
        else
        {
            final.dataEnemy.Def += count;
        }
    }

    void OverRound()
    {
        print(final.dataEnemy.Name + ": " + final.dataEnemy.EP);
        cardManager.throwAllCards();

        for (int i = 0; i < 2; i++)
        {
            cardManager.Dual_E();
        }
        cardManager.enemyTurn();
        nextRound();
    }

    void nextRound()
    {
        print(final.dataEnemy.Name + ": " + final.dataEnemy.EP + "End");
        final.dataPlayer.EP = final.initPlayreEP;
        final.dataPlayer.Def = final.initPlayreDEF;
        final.dataEnemy.EP = final.initEnemyEP;
        final.dataEnemy.Def = final.initEnemyDEF;

        cardManager.Refresh();

        cardManager.Dual(5);

        cardManager.cardFresh();
    }


    void winlost_ad()
    {
        if (i_player == 0 && i == 2)
        {
            //t_player.gameObject.SetActive(true);
            Isanswer_y = true;
            //hp_enemy -= Final.inst.data_rider0.atk;
            Debug.Log("玩家贏");
        }
        else if (i_player == 2 && i == 0)
        {
           // t_enemy.gameObject.SetActive(true);
            Isanswer_y = true;
            //blood_player.value -= 10;
            //hp_player -= Final.inst.data_enemy0.atk;
            Debug.Log("電腦贏");
        }
        else if (i_player > i)
        {
          //t_player.gameObject.SetActive(true);
            Isanswer_y = true;
            //blood_enemy.value -= 10;
            //hp_enemy -= Final.inst.data_rider0.atk;
            Debug.Log("玩家贏");
        }
        else if (i_player < i)
        {
           //t_enemy.gameObject.SetActive(true);
            Isanswer_y = true;
            //blood_player.value -= 10;
            //hp_player -= Final.inst.data_enemy0.atk;
            Debug.Log("電腦贏");
        }
        else if (i_player == i)
        {
            //td_player.gameObject.SetActive(true);
            //td_enemy.gameObject.SetActive(true);

            Debug.Log("雙方平手");
        }

        Debug.Log("玩家:" + i_player + " 電腦:" + i);
        y = 0;
    }


    void winlost_adc()
    {
        if (i_player == 0 && i == 2)
        {
            //t_player.gameObject.SetActive(true);
            Isanswer_y = true;
            //blood_enemy.value -= 10;
            //hp_enemy -= Final.inst.data_rider0.s_atk;
            Debug.Log("玩家贏");
        }
        else if (i_player == 2 && i == 0)
        {
            // t_enemy.gameObject.SetActive(true);
            Isanswer_y = true;
            //blood_player.value -= 10;
           // hp_player -= Final.inst.data_enemy0.s_atk;
            Debug.Log("電腦贏");
        }
        else if (i_player > i)
        {
            //t_player.gameObject.SetActive(true);
            Isanswer_y = true;
            //blood_enemy.value -= 10;
            //hp_enemy -= Final.inst.data_rider0.s_atk;
            Debug.Log("玩家贏");
        }
        else if (i_player < i)
        {
            //t_enemy.gameObject.SetActive(true);
            Isanswer_y = true;
            //blood_player.value -= 10;
            //hp_player -= Final.inst.data_enemy0.s_atk;
            Debug.Log("電腦贏");
        }
        else if (i_player == i)
        {
            //td_player.gameObject.SetActive(true);
            //td_enemy.gameObject.SetActive(true);

            Debug.Log("雙方平手");
        }

        Debug.Log("玩家:" + i_player + " 電腦:" + i);
        y = 0;
    }



    void computer()
    {
        //t_player.gameObject.SetActive(false);
        //t_enemy.gameObject.SetActive(false);
        //td_player.gameObject.SetActive(false);
        //td_enemy.gameObject.SetActive(false);

        _vow = (Mora)i;

        ran = Random.Range(0, 3);
        i = ran;

        if (Ischoose)
        {
            Debug.Log("Computer: " + _vow);
        }
    }

    public void 剪()
    {
        player = Mora.剪;
        i_player = (int)player;//列舉轉數字

        Ischoose = true;
        Istime = true;

        AudioManager.Playtrigger();

      

        computer();
    }

    public void 石()
    {
        player = Mora.石;
        i_player = (int)player;//列舉轉數字

        Ischoose = true;
        Istime = true;

        AudioManager.Playtrigger();

        computer();
    }

    public void 布()
    {
        player = Mora.布;
        i_player = (int)player;//列舉轉數字

        Ischoose = true;
        Istime = true;

        AudioManager.Playtrigger();

        computer();
    }
}

public enum Winmethod
{
    Null,
    First, //先贏?次者獲勝
    Continuous //連贏?次者獲勝
}

public enum Mora
{
    //移到文字時會出現數字，相當於[0]
    剪,
    石,
    布, //如果給於數字的話會變成[10],下一個會接著下一個數字
    紫,
    黑
}
