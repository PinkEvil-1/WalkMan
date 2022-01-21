using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragTrap : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    private Transform myTransform;
    private RectTransform myRectTransform;
    // 用于event trigger对自身检测的开关
    private CanvasGroup canvasGroup;
    // 拖拽操作前的有效位置，拖拽到有效位置时更新
    public Vector3 originalPosition;
    // 记录上一帧所在物品格子
    private GameObject lastEnter = null;
    // 记录上一帧所在物品格子的正常颜色
    private Color lastEnterNormalColor;
    // 拖拽至新的物品格子时，该物品格子的高亮颜色
    private Color highLightColor = Color.cyan;

    //創造個透明的圖示
    public Image clone_photo;

    public trap_creat_manager trap_creat;

    public Transform originalParent;
    public Vector2 WL;
    public Vector3 creat;
    // Use this for initialization
    void Start () {
        myTransform = this.transform;
        myRectTransform = clone_photo.transform as RectTransform;
        canvasGroup = GetComponent<CanvasGroup>();
        originalPosition = myTransform.position;
        originalParent = myTransform.parent;
        clone_photo.transform.GetComponent<Image>().sprite = this.transform.GetComponent<Image>().sprite;
        WL = this.transform.GetComponent<RectTransform>().sizeDelta;
        trap_creat = this.transform.parent.parent.parent.GetComponent<trap_creat_manager>();
    }
	
	// Update is called once per frame
	void Update () {
	}
    public void OnBeginDrag(PointerEventData eventData)
    {
        /*GameObject obj = Instantiate(photo_clone);
        obj.transform.parent = transform;
        obj.name = "UI_ItemGrid";
        obj.transform.localScale = Vector3.one;*/
        canvasGroup.blocksRaycasts = false;//让event trigger忽略自身，这样才可以让event trigger检测到它下面一层的对象,如包裹或物品格子等
        lastEnter = eventData.pointerEnter;
        //lastEnterNormalColor = lastEnter.GetComponent<Image>().color;
        originalPosition = myTransform.position;//拖拽前记录起始位置
        gameObject.transform.SetAsLastSibling();//保证当前操作的对象能够优先渲染，即不会被其它对象遮挡住

        //originalParent = myTransform.parent;
        //clone_photo.transform.parent = originalParent.parent;
        //transform.parent = transform.parent.parent.parent;

        clone_photo.gameObject.SetActive(true); //把透明的圖片打開
        clone_photo.gameObject.transform.parent = clone_photo.gameObject.transform.parent.parent;

        //Debug.Log(eventData.pointerEnter.name);
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(myRectTransform, eventData.position, eventData.pressEventCamera, out globalMousePos))
        {
            myRectTransform.position = globalMousePos;
            creat = globalMousePos;
        }
        GameObject curEnter = eventData.pointerEnter;
        
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        GameObject curEnter = eventData.pointerEnter;
        Vector2 end_pos = Camera.main.ScreenToWorldPoint(creat);
        trap_creat.trap_creat(end_pos ,this.transform.parent.GetComponent<Grid>().id);
        Debug.Log(end_pos);


    canvasGroup.blocksRaycasts = true;//确保event trigger下次能检测到当前对象
        clone_photo.gameObject.SetActive(false); //把透明的圖片關閉
        clone_photo.gameObject.transform.parent = originalParent;
    }
    // 判断鼠标指针是否指向包裹中的物品格子
    // <param name="go">鼠标指向的对象</param>
    bool EnterItemGrid(GameObject go)
    {
        if (go == null)
        {
            return false;
        }
        return go.name == "UI_ItemGrid";
    }
}
