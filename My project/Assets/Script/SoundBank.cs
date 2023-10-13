using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBank : MonoBehaviour {
    // public List<List<AudioClip>> audioClipLists = new List<List<AudioClip>>();

    public List<AudioClip> button0Clips = new List<AudioClip>();
    public List<AudioClip> button1Clips = new List<AudioClip>();
    public List<AudioClip> button2Clips = new List<AudioClip>();
    public List<AudioClip> button3Clips = new List<AudioClip>();
    public List<AudioClip> button4Clips = new List<AudioClip>();

    public List<AudioSource> sources = new List<AudioSource>();
    
    private Dictionary<string, int> modeMap = new Dictionary<string, int>() 
    {
        {"natural", 4},
        {"classic", 3},
        {"bird", 2},
        {"lofi", 1},
        {"personalised",0}
    };
    
    /**
     * get a clip for a specific mode
     */
    public AudioClip getClip(int button, int mode) {
        switch (button) {
            case 0:
                return button0Clips[mode];
            case 1:
                return button1Clips[mode];
            case 2:
                return button2Clips[mode];
            case 3:
                return button3Clips[mode];
            case 4:
                return button4Clips[mode];
            default:
                // Debug.Log("Cannot identify button");
                break;
        }
        return null;
    }

    public void ReplaceAudio(int mode) {
        for (int i = 0; i < sources.Count; i++) {
            sources[i].clip = getClip(i, mode);
        }
    }
}
