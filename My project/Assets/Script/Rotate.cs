using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    private float timer = 0;

    private float maxTime = 0.5f;
    private void OnEnable() {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0, 5);
        timer += Time.deltaTime;
        if (timer >= maxTime) {
            transform.parent.gameObject.SetActive(false);
            // gameObject.SetActive(false);
        }
    }
}
