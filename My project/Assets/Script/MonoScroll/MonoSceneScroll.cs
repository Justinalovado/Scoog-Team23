using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UIElements.Image;
using Vector2 = UnityEngine.Vector2;

public class MonoSceneScroll : MonoBehaviour {
    public GameObject scrollbarObject;
    private Scrollbar scrollbar;
    private float scroll_pos = 0;
    private float[] pos;

    public List<Texture2D> bgImages;
    public RawImage bgObject;
    
    private Coroutine snapCoroutine;
    private bool functionTriggered = false;
    private int lastOption = -1;
    public GameObject overlay;

    public SoundBank bank;

    public GameObject recordButton;
    
    void Start() {
        scrollbar = scrollbarObject.GetComponent<Scrollbar>();
    }
    
    void Update() {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);
        float half_dist = distance / 2;
        for (int i = 0; i < pos.Length; i++) {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0)) {
            scroll_pos = scrollbar.value;
            functionTriggered = false;
        } else {
            if (snapCoroutine == null) {
                snapCoroutine = StartCoroutine(HandleSnapping(half_dist));
            }
        }

        Vector2 targetScale;
        for (int i = 0; i < pos.Length; i++) {
            Transform child = transform.GetChild(i);
            if (scroll_pos < pos[i] + half_dist && scroll_pos > pos[i] - half_dist) {
                targetScale = new Vector2(1f, 1f);
            } else {
                targetScale = new Vector2(0.8f, 0.8f);
            }
            child.localScale = Vector2.Lerp(child.localScale, targetScale, 0.1f);
        }
    }
    
    int GetClosestIndex() {
        int closestIndex = -1;
        float minDistance = float.MaxValue;
        for (int i = 0; i < pos.Length; i++) {
            float dist = Mathf.Abs(scroll_pos - pos[i]);
            if (dist < minDistance) {
                closestIndex = i;
                minDistance = dist;
            }
        }
        return closestIndex;
    }
    IEnumerator HandleSnapping(float half_dist) {
        while (!Input.GetMouseButton(0)) {
            int closestIndex = GetClosestIndex();
            if (closestIndex != lastOption && !functionTriggered && Mathf.Abs(scroll_pos - pos[closestIndex]) <= half_dist) {
                SwitchMode(closestIndex);
                functionTriggered = true;
                lastOption = closestIndex; // Update the lastSnappedIndex once we've snapped
            }
            scrollbar.value = Mathf.Lerp(scrollbar.value, pos[closestIndex], 0.1f);
            yield return null;
        }
        snapCoroutine = null;
    }

    void SwitchMode(int mode) {
        overlay.SetActive(true);
        bgObject.texture = bgImages[mode];
        bank.ReplaceAudio(mode);
        recordButton.SetActive(mode==0);
        // toggleRecordButton(mode);
    }

    // public void toggleRecordButton(int mode) {
    //     if (mode == 0) {
    //         recordButton.SetActive(false);
    //     } else {
    //         recordButton  
    //     }
    // }
    
}
