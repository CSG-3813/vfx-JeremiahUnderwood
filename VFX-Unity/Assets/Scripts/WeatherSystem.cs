/***
 * 
 * Author: Jeremiah Underwood
 * Created: 11-2-22
 * Lat modified 11-2-22 by Jeremiah Underwood
 * Description: Controls le weather
 * 
***/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class WeatherSystem : MonoBehaviour
{
    public Volume RainProcess;

    public GameObject rainGO;
    ParticleSystem rainPS;
    public float rainTime = 10;
    public AudioMixerSnapshot raining;
    public AudioMixerSnapshot sunny;

    float timerTime;
    bool startTime;
    AudioSource audioSrc;

    bool isRaining;

    float lerpValue;
    float lerpDurration = 10;
    float transitionTime;

    public bool IsRaining { get { return isRaining; } }

    // Start is called before the first frame update
    void Start()
    {
        rainPS = rainGO.GetComponent<ParticleSystem>();
        audioSrc = rainGO.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime && timerTime > 0)
        {
            timerTime -= Time.deltaTime;
            TintSky();
          
        }
        else EndRain();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("GOTEEEEEEEEE");

        if (other.tag == "Player")
        {
            if (!startTime)
            {
                timerTime = rainTime;
                startTime = true;
                isRaining = true;
                rainPS.Play();
                audioSrc.Play();
                raining.TransitionTo(2.0f);
            }
        }
    }

    public void EndRain()
    {
        isRaining = false;
        startTime = false;
        rainPS.Stop();
        audioSrc.Stop();
        sunny.TransitionTo(2.0f);
    }

    void TintSky()
    {
        if (transitionTime < lerpDurration)
        {
            lerpValue = Mathf.Lerp(0, 1, transitionTime / lerpDurration);
            transitionTime += Time.deltaTime;
            RainProcess.weight = lerpValue;
        }
    }
}
