using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Numerics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Vector2 = UnityEngine.Vector2;

public class MonoSceneScroll : MonoBehaviour {
    public GameObject scrollbarObject;
    private Scrollbar scrollbar;
    private float scroll_pos = 0;
    private float[] pos;
    void Start() {
        scrollbar = scrollbarObject.GetComponent<Scrollbar>();
    }

    // Update is called once per frame
    void Update() {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);
        float half_dist = distance / 2;
        for (int i = 0; i < pos.Length; i++) {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0)) {
            scroll_pos = scrollbar.value;

        } else {
            foreach (var t in pos) {
                if (scroll_pos < t + half_dist && scroll_pos > t - half_dist) {
                    scrollbar.value = Mathf.Lerp(scrollbar.value, t, 0.1f);
                }
            }
        }
        
        Vector2 end = new Vector2(1f, 1f);
        Vector2 shrinkEnd = new Vector2(0.8f, 0.8f);
        for (int i = 0; i< pos.Length; i++) {
            if (scroll_pos < pos[i] + half_dist && scroll_pos > pos[i] - half_dist) {
                Transform child = transform.GetChild(i);
                transform.GetChild(i).localScale = Vector2.Lerp(child.localScale, shrinkEnd, 0.1f);
                for (int j = 0; j < pos.Length; j++) {
                    if (j != i) {
                        Transform otherChild = transform.GetChild(j);
                        transform.GetChild(j).localScale = Vector2.Lerp(otherChild.localScale, end, 0.1f);
                    }
                }
            }
        }
    }
}
