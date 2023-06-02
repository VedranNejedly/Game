using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public PauseMenu pauseMenu;
    // Start is called before the first frame update
    void Awake()
    {
        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.soundLength = s.clip.length;
            s.source.outputAudioMixerGroup = s.mixerGroup;
        }
    }

    void Start(){
        this.playSound("BackgroundMusic");
    }
    void Update()
    {      
        if(pauseMenu.gameIsPaused){
            pauseAllSound();
        }else{
            resumeAllSound();
        }
    }
    // Update is called once per frame

    public void playSound(string soundName){
        Sound s = Array.Find(sounds,sound=> sound.name == soundName);
        if(s == null){
            return;
        }
        s.source.Play();
    }
    public void stopSound(string soundName){
        Sound s = Array.Find(sounds,sound=> sound.name == soundName);
        if(s == null){
            return;
        }
        s.source.Stop();
    }

    public float getSoundLength(string soundName){
        Sound s = Array.Find(sounds,sound=> sound.name == soundName);
        if(s == null){
            return 0;
        }
        return (float)s.soundLength;
    }

    public void pauseAllSound(){
       foreach(Sound s in sounds){
        s.source.Pause();
       }
    }
    public void resumeAllSound(){
       foreach(Sound s in sounds){
        s.source.UnPause();
       }
    }
}
