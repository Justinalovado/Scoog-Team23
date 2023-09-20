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

    private Dictionary<string, int> modeMap = new Dictionary<string, int>() 
    {
        {"natural", 0},
        {"classic", 1},
        {"bird", 2},
        {"lofi", 3},
        {"personalised",4}
    };
    
    /**
     * get a clip for a specific mode
     */
    public AudioClip getClip(int button, string mode) {
        switch (button) {
            case 0:
                return button0Clips[modeMap[mode]];
                break;
            case 1:
                return button1Clips[modeMap[mode]];
                break;
            case 2:
                return button2Clips[modeMap[mode]];
                break;
            case 3:
                return button3Clips[modeMap[mode]];
                break;
            case 4:
                return button4Clips[modeMap[mode]];
                break;
            default:
                Debug.Log("Cannot identify button");
                break;
        }

        return null;
    }
}
