using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ToggleButton : MonoBehaviour, IDropHandler {
    [SerializeField] private AnimationCurve blinkCurve = new AnimationCurve();
    // Reference to the Toggle component
    private Toggle toggle;

    // Reference to the Toggle's graphic (the sprite renderer)
    private Image toggleGraphic;
    private AudioSource audioSource;
    // The sprites for the "On" and "Off" states
    public Sprite onSprite;
    public Sprite offSprite;

    public SoundTrackManager Manager;

    public int ID;
    
    // Start is called before the first frame update
    private void Start()
    {
        // Get the Toggle component attached to this GameObject
        toggle = GetComponent<Toggle>();

        // Get the Toggle's graphic (the sprite renderer)
        toggleGraphic = toggle.GetComponent<Image>();
        audioSource = gameObject.GetComponent<AudioSource>();
        // Register a listener for the Toggle's state change event
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }
    
    private void OnToggleValueChanged(bool isOn)
    {
        // Update the sprite based on the Toggle's state
        toggleGraphic.sprite = isOn ? onSprite : offSprite;
        // on change, register state in SoundTrackManger
        this.Manager.lodgeStateChange(isOn, this.ID);
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
        this.Manager.reloadAudio();
    }
}
