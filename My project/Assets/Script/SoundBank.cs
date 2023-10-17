using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class SoundBank : MonoBehaviour {
    // public List<List<AudioClip>> audioClipLists = new List<List<AudioClip>>();

    public List<AudioClip> button0Clips = new List<AudioClip>();
    public List<AudioClip> button1Clips = new List<AudioClip>();
    public List<AudioClip> button2Clips = new List<AudioClip>();
    public List<AudioClip> button3Clips = new List<AudioClip>();
    public List<AudioClip> button4Clips = new List<AudioClip>();

    // public List<List<AudioClip>> buttonAudioList = new List<List<AudioClip>>();
    
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

    public void StoreAudio(int button, AudioClip clip) {
        switch (button) {
            case 0:
                button0Clips[0] = clip;
                break;
            case 1:
                button1Clips[0] = clip;
                break;
            case 2:
                button2Clips[0] = clip;
                break;
            case 3:
                button3Clips[0] = clip;
                break;
            case 4:
                button4Clips[0] = clip;
                break;
        }
        SavWav.Save(clip, button);
    }


    public void LoadAllPersonal() {
        LoadPersonalisedAudio(button0Clips, 0);
        LoadPersonalisedAudio(button1Clips, 1);
        LoadPersonalisedAudio(button2Clips, 2);
        LoadPersonalisedAudio(button3Clips, 3);
        LoadPersonalisedAudio(button4Clips, 4);
    }
    
    private void LoadPersonalisedAudio(List<AudioClip> button_X_Clips, int button){
        string path = Application.temporaryCachePath;
        string audiopath = Path.Combine(path,button.ToString());
        audiopath = $"{audiopath}.wav";
        Debug.Log($"audiopath: {audiopath}");
        AudioClip clip = LoadAudioClipFromPath(path);
        button_X_Clips[0] = clip;
    }
    private AudioClip LoadAudioClipFromPath(string path)
    {
        // WWW www = new WWW("file://" + path);
        // while (!www.isDone) { }
        // return www.GetAudioClip();
        return SavWav.LoadWavFile(path);
    }
}
