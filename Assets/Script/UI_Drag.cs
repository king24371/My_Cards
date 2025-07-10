using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    /// <summary>
    /// ��l������(Back�^�k���U)
    /// </summary>
    protected Transform parentTrans;
    /// <summary>
    /// ��l������U����m
    /// </summary>
    Vector3 orginPos;
    bool canDrag = true;
    public bool CanDrag { get { return canDrag; } set { canDrag = value; } }
    [Header("�ण���I���^����I")]
    [SerializeField]
    bool cantPoint = false;
    public bool CantPoint { get { return cantPoint; } set { cantPoint = value; } }
    [Header("�즲�n���n�ƻs����")]
    [SerializeField]
    bool cloneSelf = false;
    /// <summary>
    /// �O�_���ƻs��
    /// </summary>
    bool isClone = false;
    /// <summary>
    /// �ƻs��
    /// </summary>
    protected GameObject cloneGo;
    /// <summary>
    /// �ƻs�M��
    /// </summary>
    protected List<GameObject> cloneGos = new List<GameObject>();
    [Header("���ʪ��󤤤�")]
    [SerializeField]
    bool centerMove = true;
    Vector2 offset = new Vector2();

    void Awake()
    {
        Init();
    }
    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        if (!canDrag) return;
        //�p�G�i�H�ƻs
        if (cloneSelf)
        {
            cloneGo = null;
            //�ƻs�M�欰�s��
            if (cloneGos.Count == 0)
            {
                cloneGo = CreateClone();
            }
            else
            {
                //�j�M�M�榳�S���i�Ϊ�(���ê�)
                for (int i = 0; i < cloneGos.Count; i++)
                {
                    if (!cloneGos[i].activeSelf)
                    {
                        cloneGo = cloneGos[i];
                        cloneGo.SetActive(true);
                        break;
                    }
                }
                //�S���i�Ϊ� �Ы�
                if (cloneGo == null)
                {
                    cloneGo = CreateClone();
                }
            }
            cloneGo.GetComponent<UI_Drag>().isClone = true;
            if (!centerMove)
                offset = new Vector2(transform.position.x, transform.position.y) - eventData.position;
        }
        else
        {
            //transform.SetParent(parentTrans.parent.parent);
            if (!centerMove)
                offset = new Vector2(transform.position.x, transform.position.y) - eventData.position;
        }
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        if (!canDrag) return;
        if (cloneSelf)
        {
            cloneGo.transform.position = eventData.position + offset;
        }
        else
            transform.position = eventData.position + offset;
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        if (!canDrag) return;
        if (cloneSelf)
        {
            List<RaycastResult> hits = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, hits);
            for (int i = 0; i < hits.Count; i++)
            {
                if (hits[i].gameObject.tag == "Target")
                {
                    cloneGo.transform.SetParent(hits[i].gameObject.transform);
                    if(!cantPoint)
                        cloneGo.GetComponent<UI_Drag>().canDrag = false;
                    cloneGo.GetComponent<UI_Drag>().MoveOn();
                    return;
                }
            }
            cloneGo.GetComponent<UI_Drag>().PointerOn();
        }
        else
        {
            List<RaycastResult> hits = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, hits);
            for (int i = 0; i < hits.Count; i++)
            {
                if (hits[i].gameObject.tag == "Target")
                {
                    transform.SetParent(hits[i].gameObject.transform);
                    if (!cantPoint)
                        canDrag = false;
                    MoveOn();
                    return;
                }
            }
            PointerOn();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (canDrag || cantPoint) return;
        PointerOn();
    }

    public virtual void Back()
    {
        if (cloneSelf)
        {
            for (int i = 0; i < cloneGos.Count; i++)
                cloneGos[i].GetComponent<UI_Drag>().Back();
        }
        else
        {
            if (parentTrans == null) return;
            canDrag = true;
            transform.SetParent(null);
            transform.SetParent(parentTrans);
            //transform.localPosition = orginPos;
            if (isClone)
                gameObject.SetActive(false);
        }
    }
    public virtual void Init(Sprite sprite)
    {
        GetComponent<Image>().sprite = sprite;
    }
    public void Init()
    {
        parentTrans = transform.parent;
        orginPos = transform.position;
    }
    public virtual void MoveOn()
    {

    }
    public virtual void PointerOn()
    {
        Back();
    }
    public GameObject CreateClone()
    {
        GameObject go = Instantiate(gameObject, parentTrans);
        go.GetComponent<UI_Drag>().parentTrans = parentTrans;
        go.GetComponent<UI_Drag>().cloneSelf = false;
        cloneGos.Add(go);
        return go;
    }
}
