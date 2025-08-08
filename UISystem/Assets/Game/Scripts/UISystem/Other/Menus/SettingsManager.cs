using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    #region Proporties

    #region Singleton

    static SettingsManager _instance;

    public static SettingsManager Instance => _instance;

    #endregion

    #region UI
    #region Screen

    [Header("Screen")]
    public TMP_Dropdown resolution;
    public Toggle _fullScreenMode;
    public TMP_Dropdown graphicQuality;

    #endregion


    #region Audio

    [Header("Audio")]
    public AudioMixer audioMixer;

    Resolution[] resolutions;

    #endregion
    #endregion

    #region Proporties

    [SerializeField] List<string> _audioNames = new List<string>();

    #endregion

    #endregion

    #region Methods

    #region Unity methods

    private void Awake()
    {
        if (_instance)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        resolution.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }

        resolution.AddOptions(options);
        resolution.RefreshShownValue();
        LoadSettings(currentResolutionIndex);
    }

    #endregion

    #region Settings methods

    #region Screen
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {

        QualitySettings.SetQualityLevel(qualityIndex);

    }

    #endregion

    #region Audio
    public bool SetVolume(string name, float volume)
    {
        float dB = Mathf.Log10(Mathf.Max(volume, 0.0001f)) * 20f;
        return audioMixer.SetFloat(name, dB);
    }
    void SaveVolume(string name, float volume)
    {
        PlayerPrefs.SetFloat(name, volume);
    }
    public float GetVolume(string name)
    {
        return PlayerPrefs.GetFloat(name, 1f);
    }

    #endregion

    #region Load Save

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("QualitySettingPreference",
                   graphicQuality.value);
        PlayerPrefs.SetInt("ResolutionPreference",
                   resolution.value);
        PlayerPrefs.SetInt("FullscreenPreference",
                   System.Convert.ToInt32(Screen.fullScreen));

        SetResolution(PlayerPrefs.GetInt("ResolutionPreference"));
        SetQuality(PlayerPrefs.GetInt("QualitySettingPreference"));
        Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));

        SaveAudioSettings();
    }
    #region Audio
    void SaveAudioSettings()
    {
        foreach (var name in _audioNames)
        {
            if (audioMixer.GetFloat(name, out float db))
            {
                float linear = Mathf.Pow(10f, db / 20f);
                SaveVolume(name, linear);
            }
        }
    }
    void LoadAudioSettings()
    {
        foreach (var name in _audioNames)
        {
            SetVolume(name, GetVolume(name));
        }
    }
    #endregion

    public void LoadSettings(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey("QualitySettingPreference"))
            graphicQuality.value = PlayerPrefs.GetInt("QualitySettingPreference");
        else
            graphicQuality.value = 3;
        if (PlayerPrefs.HasKey("ResolutionPreference"))
            resolution.value = PlayerPrefs.GetInt("ResolutionPreference");
        else
            resolution.value = currentResolutionIndex;
        if (PlayerPrefs.HasKey("FullscreenPreference"))
            Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));

        LoadAudioSettings();
    }

    #endregion

    #endregion

    #endregion
}
