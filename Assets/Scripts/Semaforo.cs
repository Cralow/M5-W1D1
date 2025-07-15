using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Semaforo : MonoBehaviour
{
    public MeshRenderer redLight;
    public MeshRenderer yellowLight;
    public MeshRenderer greenLight;

    [Header("Timer")]
    [SerializeField] float totalCycleDuration = 12f;
    [SerializeField] Text uiCountDown;

    private void Start()
    {
        StartCoroutine(TrafficLightCycle());
    }

    IEnumerator TrafficLightCycle()
    {
        float phaseDuration = totalCycleDuration / 3f;

        while (true)
        {
            yield return StartCoroutine(LightTimer(phaseDuration, true, false, false));
            yield return StartCoroutine(LightTimer(phaseDuration, false, true, false));
            yield return StartCoroutine(LightTimer(phaseDuration, false, false, true));
        }
    }

    IEnumerator LightTimer(float duration, bool green, bool yellow, bool red)
    {
        LightState(green, yellow, red);
        float timer = duration;

        while (timer > 0f)
        {
            uiCountDown.text = "Il semaforo si aggiornerà in : " + timer.ToString() + " secondi :)";
            yield return null;
            timer -= Time.deltaTime;
        }
    }

    private void LightState(bool green, bool yellow, bool red)
    {
        greenLight.material.color = green ? Color.green : Color.black;
        yellowLight.material.color = yellow ? Color.yellow : Color.black;
        redLight.material.color = red ? Color.red : Color.black;
    }
}

