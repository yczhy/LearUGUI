using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Slider))]
public class SliderToolkit : MonoBehaviour, UIInterface, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    public Slider mainSlider;
    
    [SerializeField, LabelText("鼠标移动过来整体的高亮")] private CanvasGroup highlightCG;
    [SerializeField, LabelText("slider值")] private TMP_InputField valueText;
    
    // 存档相关
    public bool invokeOnAwake = true;
    
    // 显示相关
    public bool useRoundValue = false;
    public bool usePercent = false;
    public bool showValue = true;
    
    public bool useSounds = true;
    public bool isInteractable = true;
    
    [System.Serializable] public class SliderEvent : UnityEvent<float> { }
    [SerializeField] public SliderEvent onValueChanged = new SliderEvent();

    public void OnRefresh()
    {
        Init();
        
        if (valueText == null) return;

        if (useRoundValue)
        {
            if (usePercent == true && valueText != null) { valueText.text = Mathf.Round(mainSlider.value * 1.0f).ToString() + "%"; }
            else if (valueText != null) { valueText.text = Mathf.Round(mainSlider.value * 1.0f).ToString(); }
        }
        else
        {
            if (usePercent == true && valueText != null) { valueText.text = mainSlider.value.ToString("F1") + "%"; }
            else if (valueText != null) { valueText.text = mainSlider.value.ToString("F1"); }
        }
    }

    public bool isInit { get; set; } = false;
    
    /// <summary>
    /// 只能初始化的时候使用
    /// </summary>
    public void Init()
    {
        if (isInit) return;
        isInit = true;

        if (mainSlider == null)
        {
            mainSlider = GetComponent<Slider>();
        }

        if (highlightCG == null)
        {
            highlightCG = new GameObject().AddComponent<CanvasGroup>();
            highlightCG.gameObject.AddComponent<RectTransform>();
            highlightCG.transform.SetParent(transform); 
            highlightCG.gameObject.name = "Highlight";
        }

        if (gameObject.GetComponent<Image>() == null)
        {
            Image raycastImg = gameObject.AddComponent<Image>();
            raycastImg.color = new Color(0, 0, 0, 0);
            raycastImg.raycastTarget = true;
        }
        
        highlightCG.alpha = 0;
        highlightCG.gameObject.SetActive(false);
        
        mainSlider.onValueChanged.AddListener(delegate
        {
            onValueChanged.Invoke(mainSlider.value);
            OnRefresh();
        });
        
        if (invokeOnAwake == true) { onValueChanged.Invoke(mainSlider.value); }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (useSounds)
        {
        }
        if (isInteractable == false) { return; }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnSelect(BaseEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnDeselect(BaseEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
