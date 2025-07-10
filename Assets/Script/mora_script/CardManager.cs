using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public static CardManager inst;
    public Final final;

    public Mora vow;
    public Button btn;
    public Image imgE;
    public Button dual_btn;
    public List<Sprite> Cards;
    public List<Sprite> Cards_E;
    public GameObject myPanel;
    public GameObject enemyPanel;

    public GameObject chooseUI;
    public GameObject targetObj;
    public Transform throwUI;
    public Button throwCheck;
    public Button copyCheck;
    string targetCard;

    public Button areaDual;
    public Button areaDual_E;
    public Image areaCoffin;
    public int handCard;
    public bool isRed;
    public int redCount;

    // 宣告卡牌對應表
    private Dictionary<string, CardStatus> cardMap = new Dictionary<string, CardStatus>();

    private void Awake()
    {
        inst = this;
    }

    // 在 Start 方法中初始化卡牌對應表
    void Start()
    {
        buildAndAdd();

        final = GetComponent<Final>();

        print("start to dual");
        Cards = Resources.LoadAll(("UI_card"), typeof(Sprite)).Cast<Sprite>().ToList();
        Cards_E = Resources.LoadAll(("UI_card_E"), typeof(Sprite)).Cast<Sprite>().ToList();

        throwCheck.onClick.AddListener(() =>
        {
            foreach (cardObj card in myPanel.GetComponentsInChildren<cardObj>())
            {
                if (card.cardName == targetCard.Substring(3))
                {
                    card.transform.SetParent(areaCoffin.transform);
                    card.transform.localPosition = btn.transform.localPosition;
                }
            }

            closeTrowUI();
        });
        copyCheck.onClick.AddListener(() =>
        {
            foreach (cardObj card in myPanel.GetComponentsInChildren<cardObj>())
            {
                if (card.cardName == targetCard.Substring(3))
                {
                    Instantiate(card.gameObject, myPanel.transform);
                }
            }
            cardFresh();

            closeTrowUI();
        });
    }

    // Update is called once per frame
    void Update()
    {
        stopAction();
    }

    void buildAndAdd()
    {
        // 建立紅牌
        CardStatus red1 = new derectAttackEffect();
        CardStatus red2 = new firstAttackEffect();
        CardStatus red3 = new breakShieldEffect();
        CardStatus red4 = new attackToDefEffect();
        CardStatus red5 = new warMinePlusEffect();
        CardStatus red6 = new powerFeedbackEffect();

        // 建立藍牌
        CardStatus blue1 = new derectDefenceEffect();
        CardStatus blue2 = new fastDefenceEffect();
        CardStatus blue3 = new chainDefenceEffect();
        CardStatus blue4 = new backDefenceEffect();
        CardStatus blue5 = new returnDefenceEffect();
        CardStatus blue6 = new train1000Effect();

        // 建立綠牌
        CardStatus green1 = new smallHealEffect();
        CardStatus green2 = new HealEffect();
        CardStatus green3 = new giveUp2ForceEffect();
        CardStatus green4 = new natureMageEffect();
        CardStatus green5 = new NapEffect();
        CardStatus green6 = new flashInspirationEffect();
        CardStatus green7 = new EnergeColapseEffect();
        CardStatus green8 = new CalmEffect();
        CardStatus green9 = new powerChargeEffect();
        CardStatus green10 = new sentMallEffect();

        // 建立紫牌
        CardStatus purple1 = new HorrorEffect();
        CardStatus purple2 = new weaknessNoticeEffect();
        CardStatus purple3 = new hurtSelfEffect();
        CardStatus purple4 = new omniscientCurseEffect();
        CardStatus purple5 = new absorbArcaneEffect();
        CardStatus purple6 = new tearPreyEffect();
        CardStatus purple7 = new UnamableEffect();
        CardStatus purple8 = new machineErosionEffect();
        CardStatus purple9 = new hateFleshEffect();
        CardStatus purple10 = new crimsonHumeEffect();
        CardStatus purple11 = new sentSealEffect();
        CardStatus purple12 = new WeakEffect();

        //建立黑牌
        CardStatus black1 = new ConfusionEffect();
        CardStatus black2 = new nanoBugEffect();

        // 將卡牌加入對應表
        //red
        cardMap.Add(red1.Name, red1);
        cardMap.Add(red2.Name, red2);
        cardMap.Add(red3.Name, red3);
        cardMap.Add(red4.Name, red4);
        cardMap.Add(red5.Name, red5);
        cardMap.Add(red6.Name, red6);

        //blue
        cardMap.Add(blue1.Name, blue1);
        cardMap.Add(blue2.Name, blue2);
        cardMap.Add(blue3.Name, blue3);
        cardMap.Add(blue4.Name, blue4);
        cardMap.Add(blue5.Name, blue5);
        cardMap.Add(blue6.Name, blue6);

        //green
        cardMap.Add(green1.Name, green1);
        cardMap.Add(green2.Name, green2);
        cardMap.Add(green3.Name, green3);
        cardMap.Add(green4.Name, green4);
        cardMap.Add(green5.Name, green5);
        cardMap.Add(green6.Name, green6);
        cardMap.Add(green7.Name, green7);
        cardMap.Add(green8.Name, green8);
        cardMap.Add(green9.Name, green9);
        cardMap.Add(green10.Name, green10);

        //purple
        cardMap.Add(purple1.Name, purple1);
        cardMap.Add(purple2.Name, purple2);
        cardMap.Add(purple3.Name, purple3);
        cardMap.Add(purple4.Name, purple4);
        cardMap.Add(purple5.Name, purple5);
        cardMap.Add(purple6.Name, purple6);
        cardMap.Add(purple7.Name, purple7);
        cardMap.Add(purple8.Name, purple8);
        cardMap.Add(purple9.Name, purple9);
        cardMap.Add(purple10.Name, purple10);
        cardMap.Add(purple11.Name, purple11);
        cardMap.Add(purple12.Name, purple12);

        //black
        cardMap.Add(black1.Name, black1);
        cardMap.Add(black2.Name, black2);
    }

    public void UseCard(string cardName, data_card player)
    {
        // 查找卡牌對應表，如果找不到就回傳 null
        CardStatus card;
        if (!cardMap.TryGetValue(cardName, out card))
        {
            print("no card");
            return;
        }

        if (player.HP <= 0)
        {
            return;
        }

        if (card.Ep > player.EP)
        {
            return;
        }
        
        card.ApplyEffect();
        card.Action(player);
    }

    public CardStatus card_status(string cardName)
    {
        //print(cardName);
        CardStatus card;
        if (!cardMap.TryGetValue(cardName, out card))
        {
            print("no card");
            return null;
        }
        else
            return card;
    }

    string Trim(int color, string text)
    {
        string res;

        switch (color)
        {
            case 0:
                res = text.TrimStart("紅牌_".ToCharArray());
                return res;
            case 1:
                res = text.TrimStart("藍牌_".ToCharArray());
                return res;
            case 2:
                res = text.TrimStart("綠牌_".ToCharArray());
                return res;
            case 3:
                res = text.TrimStart("紫牌_".ToCharArray());
                return res;
            case 4:
                res = text.TrimStart("黑牌_".ToCharArray());
                return res;
        }

        return null;
    }

    #region old Action method
    void Action_R(string cardName, data_card player)
    {
        RedCard rd;
        switch (cardName)
        {
            case "直接攻擊":
                rd = new RedCard(cardName, 1, 2, Mora.剪.ToString());
                rd.derectAttack(player);
                break;
            case "先手攻擊":
                rd = new RedCard(cardName, 0, 2, Mora.剪.ToString());
                rd.firstAttack(player);
                break;
            case "破盾":
                rd = new RedCard(cardName, 1, 2, Mora.剪.ToString());
                rd.breakShiled(player);
                break;
            case "以攻作防":
                rd = new RedCard(cardName, 1, 2, Mora.剪.ToString());
                rd.attackToDef(player);
                break;
            case "戰意疊加":
                rd = new RedCard(cardName, 1, 2, Mora.剪.ToString());
                rd.warMinePlus(player);
                break;
            case "動能反饋":
                rd = new RedCard(cardName, 0, 0, Mora.剪.ToString());
                rd.powerFeedback(player);
                break;
        }
    }

    void Action_B(string cardName, data_card player)
    {
        BlueCard bl;

        switch (cardName)
        {
            case "架樁格擋":
                bl = new BlueCard(cardName, 1, 2, Mora.石.ToString());
                bl.derectDefense(player);
                break;
            case "快速回防":
                bl = new BlueCard(cardName, 0, 2, Mora.石.ToString());
                bl.fastDefense(player);
                break;
            case "連續防禦":
                bl = new BlueCard(cardName, 1, 2, Mora.石.ToString());
                bl.chainDefense(player);
                break;
            case "退步格架":
                bl = new BlueCard(cardName, 2, 3, Mora.石.ToString());
                bl.backDefense(player);
                break;
            case "千錘百煉":
                bl = new BlueCard(cardName, 1, 2, Mora.石.ToString());
                bl.train1000(player);
                break;
            case "回身格擋":
                bl = new BlueCard(cardName, 1, 2, Mora.石.ToString());
                bl.returnDefense(player);
                break;
        }
    }

    void Action_G(string cardName, data_card player)
    {
        GreenCard gr;

        switch (cardName)
        {
            case "治癒.小":
                gr = new GreenCard(cardName, 1, 2, Mora.布.ToString());
                gr.heal_Small(player);
                break;
            case "治癒":
                gr = new GreenCard(cardName, 2, 4, Mora.布.ToString());
                gr.heal(player);
                break;
            case "道法自然":
                gr = new GreenCard(cardName, 0, 1, Mora.布.ToString());
                gr.natureMage(player);
                break;
            case "卸負回能":
                gr = new GreenCard(cardName, 1, 0, Mora.布.ToString());
                gr.giveUp2Force(player);
                break;
            case "孤注一擲":
                gr = new GreenCard(cardName, 1, 0, Mora.布.ToString());
                gr.Nap(player);
                break;
            case "福至心靈":
                gr = new GreenCard(cardName, 1, 0, Mora.布.ToString());
                gr.flashInspiration(player);
                break;
            case "能量坍縮":
                gr = new GreenCard(cardName, 1, 0, Mora.布.ToString());
                gr.energyColapse(player);
                break;
            case "處變不驚":
                gr = new GreenCard(cardName, 0, 0, Mora.布.ToString());
                gr.Calm(player);
                break;
        }
    }

    void Action_P(string cardName, data_card player)
    {
        PurpleCard pr;

        switch (cardName)
        {
            case "威嚇":
                pr = new PurpleCard(cardName, 1, 3,null);
                pr.horror();
                break;
            case "自殘":
                pr = new PurpleCard(cardName, 0, 2,null);
                pr.hurtSelf();
                break;
            case "全知詛咒":
                pr = new PurpleCard(cardName, 1, 2,null);
                pr.omniscientCurse();
                break;
            case "弱點洞悉":
                pr = new PurpleCard(cardName, 1, 1,null);
                pr.weaknessNotice();
                break;
            case "撕扯獵物":
                pr = new PurpleCard(cardName, 2, 0,null);
                pr.tearPrey();
                break;
            case "汲能祕法":
                pr = new PurpleCard(cardName, 0, 2,null);
                pr.absorbArcane();
                break;
        }
    }
#endregion

    public void loadActive()
    {
        Cards.Add(final.dataPlayer.Effect);
        Cards.Add(final.dataPlayer.Active);
        Cards_E.Add(final.dataEnemy.Effect);
        if (final.dataEnemy.Active != null)
        {
            Cards_E.Add(final.dataEnemy.Active);
        }

        //for (int i = 0; i < Cards.Count; i++)
        //{
        //    Button b = Instantiate(btn, areaDual.transform);
        //    b.image.sprite = Cards[i];
        //    b.name = Cards[i].name;
        //}

        Dual(5);

        for (int i = 0; i < 3; i++)
        {
            Dual_E();
        }

        cardFresh();
    }

    //public void Dual()
    //{
    //    int duals = areaDual.transform.childCount;
    //    int r = Random.Range(1, duals);
    //    print("r:"+r);
    //    GameObject obj = areaDual.transform.GetChild(r).gameObject;
    //    obj.transform.parent = myPanel.transform;
    //}
    public void Dual_E()
    {
        int r_e = Random.Range(0, Cards_E.Count);
        print("r_e:" +r_e);
        Image c = Instantiate(imgE, enemyPanel.transform);
        //c.transform.parent = enemyPanel.transform;
        c.sprite = Cards_E[r_e];
        c.name = Cards_E[r_e].name;
    }
    public void Dual(int time)
    {
        for (int i = 0; i < time; i++)
        {
            int duals = areaDual.transform.childCount;
            int r = Random.Range(1, duals);
            print("r:" + r);
            GameObject obj = areaDual.transform.GetChild(r).gameObject;
            obj.transform.parent = myPanel.transform;
        }

        cardFresh();
    }
    public void Dual(int time, Mora vow)
    {
        //int cardC = 0;
        List<cardObj> cards = new List<cardObj>();
        foreach (cardObj card in areaDual.transform.GetComponentsInChildren<cardObj>())
        {
            if (card.vow == vow)
            {
                cards.Add(card);
            }
        }
        foreach (cardObj card in areaCoffin.transform.GetComponentsInChildren<cardObj>())
        {
            if (card.vow == vow)
            {
                cards.Add(card);
            }
        }

        for (int i = 0; i < time; i++)
        {
            int duals = cards.Count;
            int r = Random.Range(0, duals);
            print("r:" + r);
            if (r == 0)
            {
                return;
            }
            GameObject obj = cards[r].gameObject;
            obj.transform.parent = myPanel.transform;
        }

        cardFresh();
    }

    public void cardFresh()
    {
        foreach (cardObj card in myPanel.GetComponentsInChildren<cardObj>())
        {
            card.refreshStatus();
        }
    }

    public void openTrowUI(string key)
    {
        chooseUI.SetActive(true);
        targetObj.SetActive(false);
        if(key == "throw")
        {
            throwCheck.gameObject.SetActive(true);
            foreach(cardObj card in myPanel.GetComponentsInChildren<cardObj>())
            {
                if(card.cardName=="卸負回能")
                    card.transform.SetParent(areaCoffin.transform);
            }
        }else
        {
            copyCheck.gameObject.SetActive(true);
            foreach (cardObj card in myPanel.GetComponentsInChildren<cardObj>())
            {
                if (card.cardName == "全知詛咒")
                    card.transform.SetParent(areaCoffin.transform);
            }
        }

        foreach (Image cardImg in myPanel.GetComponentsInChildren<Image>())
        {
            //print(cardImg.sprite.name);
            for (int i = 0; i<throwUI.childCount;i++)
            {
                if (throwUI.GetChild(i).GetComponent<Image>().sprite.name == cardImg.sprite.name)
                    throwUI.GetChild(i).gameObject.SetActive(true);
            }
        }

        foreach (Button card in throwUI.GetComponentsInChildren<Button>())
        {
            card.onClick.AddListener(() =>
            {
                clickEvent(card.gameObject);
            });
           // card.transform.SetParent(throwUI);
        }
    }
    public void closeTrowUI()
    {
        foreach (cardLight Card in throwUI.GetComponentsInChildren<cardLight>())
        {
            Card.Light(false);
        }
        for (int i = 0; i < throwUI.childCount; i++)
        {
            throwUI.GetChild(i).gameObject.SetActive(false);
        }

        chooseUI.SetActive(false);
        targetObj.SetActive(true);
        copyCheck.gameObject.SetActive(false);
        throwCheck.gameObject.SetActive(false);
    }
    void clickEvent(GameObject card)
    {
        print("選擇" + card.GetComponent<Image>().sprite.name);

        foreach (cardLight Card in throwUI.GetComponentsInChildren<cardLight>())
        {
            Card.Light(false);
        }
        card.GetComponent<cardLight>().Light(true);
        
        targetCard = card.GetComponent<Image>().sprite.name;
    }

    void cardPlay(GameObject card, data_card player)
    {
        //print(player.Name);

        //string first = card.GetComponent<Image>().sprite.name.Substring(0, 1);
        string first = card.name.Substring(0, 1);
        string res;
        if (player.Name == final.dataPlayer.Name){
            switch (first)
            {
                case "紅":
                    res = Trim(0, card.GetComponent<Image>().sprite.name);
                    print(res);
                    isRed = true;
                    redCount++;
                    //Action_R(res, final.dataPlayer);
                    UseCard(res, player);
                    break;
                case "藍":
                    res = Trim(1, card.GetComponent<Image>().sprite.name);
                    print(res);
                    UseCard(res, player);
                    break;
                case "綠":
                    res = Trim(2, card.GetComponent<Image>().sprite.name);
                    print(res);
                    UseCard(res, player);
                    break;
                case "紫":
                    res = Trim(3, card.GetComponent<Image>().sprite.name);
                    print(res);
                    UseCard(res, player);
                    break;
                case "黑":
                    res = Trim(4, card.GetComponent<Image>().sprite.name);
                    print(res);
                    UseCard(res, player);
                    break;
            }

            card.transform.parent = areaCoffin.transform;
            card.transform.localPosition = btn.transform.localPosition;
        }
        else
        {
            switch (first)
            {
                case "紅":
                    res = Trim(0, card.GetComponent<Image>().sprite.name);
                    print(res);
                    UseCard(res, player);
                    break;
                case "藍":
                    res = Trim(1, card.GetComponent<Image>().sprite.name);
                    print(res);
                    UseCard(res, player);
                    break;
                case "綠":
                    res = Trim(2, card.GetComponent<Image>().sprite.name);
                    print(res);
                    UseCard(res, player);
                    break;
                case "紫":
                    res = Trim(3, card.GetComponent<Image>().sprite.name);
                    print(res);
                    UseCard(res, player);
                    break;
            }
        }
        

       
    }

    void stopAction()
    {
        foreach (UI_Drag card in myPanel.GetComponentsInChildren<UI_Drag>())
        {
            cardObj cardEp = card.GetComponent<cardObj>();
            if(int.Parse(cardEp.epTxt.text) > final.dataPlayer.EP)
            {
                card.enabled = false;
                card.GetComponent<Button>().interactable = false;
            }
            else
            {
                card.enabled = true;
                card.GetComponent<Button>().interactable = true;
            }
        }
    }

    public void Refresh()
    {
        print("refresh over");
        foreach(Button obj in areaCoffin.gameObject.GetComponentsInChildren<Button>())
        {
            obj.transform.parent = areaDual.transform;
        }

        foreach (UI_Drag card in areaDual.GetComponentsInChildren<UI_Drag>())
        {
            card.enabled = true;
            card.GetComponent<Button>().interactable = true;
        }
    }

    public void throwAllCards()
    {
        foreach (cardObj card in myPanel.GetComponentsInChildren<cardObj>())
        {
            card.cancelFollow();
            card.transform.SetParent(areaCoffin.transform);
            card.transform.localPosition = btn.transform.localPosition;
        }
        foreach (cardObj card in areaCoffin.GetComponentsInChildren<cardObj>())
        {
            if (card.followBG != null)
                card.followBG.SetActive(false);
        }
    }

    public void enemyTurn()
    {
        print("Enemy turn");
        int hanCard = enemyPanel.transform.childCount;
        for(int h=0; h < hanCard; h++)
        {
            if (final.dataEnemy.EP == 0)
            {
                break;
            }
            else if(final.dataEnemy.EP > 0)
            {
                int r = Random.Range(0, hanCard);
                cardPlay(enemyPanel.transform.GetChild(r).gameObject, final.dataEnemy);
                //string cName = enemyPanel.transform.GetChild(r).gameObject.name;
                //UseCard(cName, final.dataEnemy);
                Destroy(enemyPanel.transform.GetChild(r).gameObject);
            }
        }
    }
}