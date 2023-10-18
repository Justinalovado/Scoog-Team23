using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class SoundBank : MonoBehaviour {
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
        string filename = $"{button.ToString()}.wav";
        Debug.Log($"attempt to load audio: {filename}");
        AudioClip clip = LoadWavFile(filename);
        button_X_Clips[0] = clip;
    }
    public AudioClip LoadWavFile(string filename)
    {
        // string path = Path.Combine(Application.temporaryCachePath, filename);
        string path = Path.Combine(Application.persistentDataPath, filename);
        if (!File.Exists(path)) {
            Debug.Log($"Audio does not exist at: {path}");
            return CreateSilentClip(5);
        }
        AudioClip audioClip = WavUtility.ToAudioClip(path);
        if (audioClip != null) {
            return audioClip;
        } else {
            Debug.Log($"Failed to load audio at: {path}");
            return CreateSilentClip(5);
        }
    }
    
    AudioClip CreateSilentClip(float silenceLength)
    {
        int totalSamples = Mathf.FloorToInt(44100 * silenceLength);
        float[] audioData = new float[totalSamples];
        AudioClip silentClip = AudioClip.Create("SilentClip", totalSamples, 1, 44100, false);
        silentClip.SetData(audioData, 0);
        return silentClip;
    }
}
