using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class BaseGraphicsSettingsUI : MonoBehaviour
{

    public Button Refresh;
    public Toggle toggleFullscreen;
    public Dropdown dropdownQuality;
    public Slider sliderVolumeMaster;
    public AudioMixer AudioMix;
    public Dropdown dropdownResolutions;
    public Dropdown dropdownVSyncCount;
    public InputField inputFieldFpsLimit;

    private BaseGraphicsSettings graphicSettings;


    private Vector2Int[] ScreenResolutions;

    private void Awake()
    {
        graphicSettings = gameObject.AddComponent<BaseGraphicsSettings>();
    }


    // Start is called before the first frame update
    void Start()
    {
        RefreshOptions();
        InitCallBacks();
    }

    public void RefreshOptions()
    {
        toggleFullscreen.isOn = graphicSettings.IsFullscreen();

        List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();
        foreach (var qualityName in graphicSettings.GetQualitySettingNames())
        {
            options.Add(new Dropdown.OptionData(qualityName));
        }
        dropdownQuality.options = options;
        dropdownQuality.value = graphicSettings.GetQualitySettingLevel();
     

        float volume;
        if (AudioMix.GetFloat("Master_Volume", out volume))
        {
            sliderVolumeMaster.value = Mathf.Pow(10, volume / 20);
        }

        options = new List<Dropdown.OptionData>();
        var resolutions = new List<Vector2Int>(graphicSettings.GetScreenResolutions());
        foreach (var resolution in resolutions)
        {
            options.Add(new Dropdown.OptionData(Rest2String(resolution)));
        }
        Vector2Int curResolution = graphicSettings.GetCurrentScreen();
        Dropdown.OptionData curOption = new Dropdown.OptionData(Rest2String(curResolution));
        int index = resolutions.IndexOf(curResolution);
        if (index == -1)
        {
            options.Add(curOption);
            resolutions.Add(curResolution);
            index = options.Count - 1;
        }
        dropdownResolutions.options = options;
        ScreenResolutions = resolutions.ToArray();
        dropdownResolutions.value = index;

        options = new List<Dropdown.OptionData>();
        for (int i = 0; i <= 4; i++)
        {
            options.Add(new Dropdown.OptionData("Vsync " + i));
        }
        dropdownVSyncCount.options = options;
        dropdownVSyncCount.value = QualitySettings.vSyncCount;

        inputFieldFpsLimit.text = graphicSettings.GetFrameLimit().ToString();
    }

    private void resolutionValueChanged(int index)
    {
        //RemoveCallbacks();
        graphicSettings.SetCurrentScreen(ScreenResolutions[index]);
        //InitCallBacks();
    }

    private void RefreshButtonPressed()
    {
        RemoveCallbacks();
        RefreshOptions();
        InitCallBacks();
    }

    public void InitCallBacks()
    {
        toggleFullscreen.onValueChanged.AddListener(fullscreenValueChanged);
        dropdownQuality.onValueChanged.AddListener(qualitySettingsChanged);
        sliderVolumeMaster.onValueChanged.AddListener(masterVolumeValueChnaged);
        dropdownResolutions.onValueChanged.AddListener(resolutionValueChanged);
        dropdownVSyncCount.onValueChanged.AddListener(vSyncValueChanged);
        inputFieldFpsLimit.onValueChanged.AddListener(fpsLimitValueChanged);
        Refresh.onClick.AddListener(RefreshButtonPressed);
    }

    private void fpsLimitValueChanged(string text)
    {
        int limit;
        if(!int.TryParse(text, out limit))
        {
            limit = -1;
        }
        graphicSettings.SetFrameLimit(limit);
    }

    private void vSyncValueChanged(int value)
    {
        QualitySettings.vSyncCount = value;
    }

    public void RemoveCallbacks()
    {
        toggleFullscreen.onValueChanged.RemoveListener(fullscreenValueChanged);
        dropdownQuality.onValueChanged.RemoveListener(qualitySettingsChanged);
        sliderVolumeMaster.onValueChanged.RemoveListener(masterVolumeValueChnaged);
        dropdownResolutions.onValueChanged.RemoveListener(resolutionValueChanged);
        dropdownVSyncCount.onValueChanged.RemoveListener(vSyncValueChanged);
        inputFieldFpsLimit.onValueChanged.RemoveListener(fpsLimitValueChanged);
        Refresh.onClick.RemoveListener(RefreshButtonPressed);
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


    private string Rest2String(Vector2Int vec)
    {
        return vec.x + " x " + vec.y;
    }
}
