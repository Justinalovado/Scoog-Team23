using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class SoundTrackManager : MonoBehaviour
{
    // public TextMeshProUGUI clockDisp;
    public List<AudioSource> audioSources;
    // public List<TextMeshProUGUI> counters; //TODO:replace with circle bars
    public List<Image> bars;
    private double clock = 0.0;
    private int curTick = 0;
    private List<int> nextTick = new List<int>();
    private float[] audioLens = new float[5];
    private int[] audioUnitLenEquiv = new int[5];
    private float unitLen;

    public SoundBank sb;
    /**
     * on load, calibrate audio length
     */
    public void reloadAudio(){
        sb.LoadAllPersonal();
        for (int i = 0; i < 5; i++){
            audioLens[i] = audioSources[i].clip.length;
        }
        // minimal section = length of shortest audio
        // => each audio set should include 1 base length audio && need to be longer than multiple
        this.unitLen = audioLens.Min();
        for (int i = 0; i < 5; i++){
            audioUnitLenEquiv[i] = (int)Math.Round(audioLens[i] / unitLen);
        }
    }
    
    /**
     * start is called on load
     */
    void Start() {
        reloadAudio();
        this.nextTick = new List<int> { -1, -1, -1, -1, -1 };
    }
    
    /**
     * Check if this.nextTick are all -1(idle)
     */
    private bool isQuiet() {
        foreach (int i in this.nextTick) {
            if (i > -1) {
                return false;
            }
        }
        return true;
    }
    
    /**
     * used by buttons, on state change
     */
    public void lodgeStateChange(bool isOn, int Button){
        int wait = isQuiet() ? 0 : 1;
        //change button state in this.state, Button identifier need consideration
        if (isOn) {
            this.nextTick[Button] = this.curTick + wait;
        }
        else {
            this.audioSources[Button].Stop();
            this.nextTick[Button] = -1;
        }
        
        //if in the end nothing is playing, clear clock
        if (isQuiet()) {
            resetClock();
        }
    }
    
    /**
     * nothing is playing, make clock, curTick, nextTick to default
     */
    public void resetClock() {
        this.clock = 0.0;
        this.curTick = 0;
        this.nextTick = new List<int> {-1, -1 , -1, -1, -1};
    }
    

    /**
     * Update is called once per frame
     */
    public void Update() {
        // this.clockDisp.text = $"Clock: {this.clock}\nTick: {this.curTick}";
        // run progress bar
        for (int i = 0; i < 5; i++){
            // this.counters[i].text = this.audioSources[i].time.ToString();
            this.bars[i].fillAmount = this.audioSources[i].time / this.audioLens[i];
        }
        //if nothing is playing skip
        if (isQuiet()){return;}
        this.tick();
        // if any track=nextTick -> schedule play & renew nextTick
        for (int i = 0; i < 5; i++) {
            if (this.nextTick[i] == curTick) {
                this.audioSources[i].Play();
                this.nextTick[i] = curTick + audioUnitLenEquiv[i];
            }
        }
        
    }
    
    /**
     * increment clock and curTick
     */
    public void tick(){
        this.clock += Time.deltaTime;
        int tick = (int)Math.Floor(this.clock/this.unitLen);
        this.curTick = tick>this.curTick ? tick : this.curTick;
    }
    
    
}
