using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrateButton : MonoBehaviour
{
    public GameObject vibrateButtonOn;
    public GameObject vibrateButtonOff;

    private void Start()
    {
        if (PlayerPrefs.GetInt("VibrateOn", 1) == 1)
        {
            vibrateButtonOn.SetActive(true);
            vibrateButtonOff.SetActive(false);
            SoundManager.Ins.TurnVibrateOn();
        }
        else
        {
            vibrateButtonOn.SetActive(false);
            vibrateButtonOff.SetActive(true);
            SoundManager.Ins.TurnVibrateOff();
        }
    }

    public void SetOnOffVibrate()
    {
        var soundValue = PlayerPrefs.GetInt("VibrateOn");
        if (soundValue == 0)
        {
            PlayerPrefs.SetInt("VibrateOn", 1);
            vibrateButtonOn.SetActive(true);
            vibrateButtonOff.SetActive(false);
            SoundManager.Ins.TurnVibrateOn();
        }
        else if (soundValue == 1)
        {
            PlayerPrefs.SetInt("VibrateOn", 0);
            vibrateButtonOn.SetActive(false);
            vibrateButtonOff.SetActive(true);
            SoundManager.Ins.TurnVibrateOff();
        }
    }
}
