using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class cardObj : UI_Drag
{
    CardStatus card;

    public string cardName;
    public Mora vow;
    public Text epTxt;
    public Text pointTxt;
    public Text plusTxt;
    public Text plus2Txt;
    public Button btn;
    public GameObject followBG;
    public Transform affixArea;
    public bool isCanFollow;
    public Mora vowF;
    public bool isDispear, isPecular;

    // Start is called before the first frame update
    void Start()
    {
        parentTrans = CardManager.inst.myPanel.transform;

        btn = GetComponent<Button>();
        btn.onClick.AddListener(() =>
        {
            
        });
    }

    public void refreshStatus()
    {
        Final final = FindObjectOfType<Final>();
        if (card == null)
        {
            card = CardManager.inst.card_status(cardName);
            card.setStatus(final.playerPFB);
        }
        epTxt.text = card.Ep.ToString();
        pointTxt.text = card.Count.ToString();
        if (plusTxt != null)
            plusTxt.text = card.Count1.ToString();
        if (plus2Txt != null)
            plus2Txt.text = card.Count2.ToString();
    }

    void cardPlay()
    {
        Final final = FindObjectOfType<Final>();

        if (vow != Mora.紫)
            card.Action(final.dataPlayer);
        else
            card.Action(final.dataEnemy);

        followJudge();

        transform.SetParent(CardManager.inst.areaCoffin.transform);
        transform.localPosition = CardManager.inst.btn.transform.localPosition;
    }

    void followJudge()
    {
        foreach(cardObj card in transform.parent.GetComponentsInChildren<cardObj>())
        {
            if(card!=this && card != null)
                card.follow(vow);
        }
    }
    public void follow(Mora vow)
    {
        if (isCanFollow)
        {
            card.ApplyEffect(vow == vowF);
            refreshStatus();
            if(followBG!=null)
                followBG.SetActive(vow == vowF);
        }        
    }

    public void cancelFollow()
    {
        card.ApplyEffect(false);
        if (followBG != null)
            followBG.SetActive(false);
    }

    //發牌
    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);
    }
    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
    }
    public override void OnEndDrag(PointerEventData eventData)
    {
        List<RaycastResult> hits = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, hits);
        for (int i = 0; i < hits.Count; i++)
        {
            if (hits[i].gameObject.tag == "Target")
            {
                //print($"打出 {cardName}");
                cardPlay();
                return;
            }
        }
        PointerOn();
    }

    public override void PointerOn()
    {
        base.PointerOn();
    }
}
