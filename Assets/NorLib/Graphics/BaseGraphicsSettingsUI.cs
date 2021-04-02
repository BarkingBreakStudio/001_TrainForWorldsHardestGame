using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class BaseGraphicsSettingsUI : MonoBehaviour
{

    public Toggle toggleFullscreen;
    public Dropdown dropdownQuality;
    public Slider sliderVolumeMaster;
    public AudioMixer AudioMix;

    private BaseGraphicsSettings graphicSettings;


    private void Awake()
    {
        graphicSettings = gameObject.AddComponent<BaseGraphicsSettings>();
    }


    // Start is called before the first frame update
    void Start()
    {
        toggleFullscreen.isOn = graphicSettings.IsFullscreen();
        toggleFullscreen.onValueChanged.AddListener(fullscreenValueChanged);

        List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();
        foreach (var qualityName in graphicSettings.GetQualitySettingNames())
        {
            options.Add(new Dropdown.OptionData(qualityName));
        }
        dropdownQuality.options = options;
        dropdownQuality.value = graphicSettings.GetQualitySettingLevel();
        dropdownQuality.onValueChanged.AddListener(qualitySettingsChanged);

        float volume;
        if(AudioMix.GetFloat("Master_Volume",out volume))
        {
            sliderVolumeMaster.value = Mathf.Pow(10, volume / 20) ;
        }
        sliderVolumeMaster.onValueChanged.AddListener(masterVolumeValueChnaged);
    }

    private void masterVolumeValueChnaged(float value)
    {
        AudioMix.SetFloat("Master_Volume", Mathf.Log10(value) * 20);
    }

    private void qualitySettingsChanged(int value)
    {
        graphicSettings.SetQualitySettingLevel(value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void fullscreenValueChanged(bool value)
    {
        graphicSettings.SetFullscreen(value);
    }
}
