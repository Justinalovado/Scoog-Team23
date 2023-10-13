using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ToggleButton : MonoBehaviour, IDropHandler {
    [SerializeField] private AnimationCurve blinkCurve = new AnimationCurve();

    private Toggle toggle;
    private Image toggleGraphic;
    private AudioSource audioSource;
    public Sprite onSprite;
    public Sprite offSprite;

    public GameObject Indicator;

    public SoundTrackManager Manager;

    public int ID;
    
    private void Start()
    {
        // Get the Toggle component attached to this GameObject
        toggle = GetComponent<Toggle>();
        toggleGraphic = toggle.GetComponent<Image>();
        audioSource = gameObject.GetComponent<AudioSource>();
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }
    
    private void OnToggleValueChanged(bool isOn)
    {
        toggleGraphic.sprite = isOn ? onSprite : offSprite;
        Manager.lodgeStateChange(isOn, this.ID);
        Indicator.GetComponent<CarveRing>().setRecordActive(isOn);
    }

    private IEnumerator BlinkCoroutine() {
        float duration = 1f; // Duration of the move
        float timePassed = 0f;
        Color startColor = toggleGraphic.color;

        while (timePassed < duration)
        {
            timePassed += Time.deltaTime;
            float normalizedTime = timePassed / duration;
            float curveValue = blinkCurve.Evaluate(normalizedTime);
            Color color = toggleGraphic.color;
            toggleGraphic.color = new Color(color.r, color.g, color.b, 1 - curveValue);
            yield return null;
        }

        toggleGraphic.color = startColor;
    }
    
    public void OnDrop(PointerEventData eventData) {
        Debug.Log("Drop detected");
        GameObject dropped = eventData.pointerDrag;
        AudioSource audioBox = dropped.GetComponent<AudioSource>();
        audioSource.clip = audioBox.clip;
        audioBox.clip = null;
        dropped.GetComponent<DraggableObject>().ResetPosition();
        dropped.SetActive(false);
        StartCoroutine(BlinkCoroutine());
        Manager.reloadAudio();
    }
}
