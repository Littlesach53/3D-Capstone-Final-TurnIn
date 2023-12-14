using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Image Brightness;
    public Slider VolumeSlider;
    public Slider BrightnessSlider;
    public Button backBTN;
    public Toggle myToggle;
    public Dropdown myDropdown;

    private void Start()
    {
        backBTN.onClick.AddListener(() =>
        {
            MainMenuSaveManager.Instance.SaveAllSettings(
                VolumeSlider.value,
                BrightnessSlider.value,
                myToggle.isOn ? 1 : 0,
                myDropdown.value
            );
        });

        StartCoroutine(LoadAndApplySettings());
    }

    private IEnumerator LoadAndApplySettings()
    {
        float volume, brightness;
        int toggleState, dropdownIndex;

        MainMenuSaveManager.Instance.LoadAllSettings(out volume, out brightness, out toggleState, out dropdownIndex);

        VolumeSlider.value = volume;
        SetVolume(volume);

        BrightnessSlider.value = brightness;
        AdjustBrightness();

        myToggle.isOn = toggleState == 1;
        myDropdown.value = dropdownIndex;
        SetQuality(dropdownIndex);

        yield return new WaitForSeconds(0.1f);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("GameVolume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void AdjustBrightness()
    {
        Color tempColor = Brightness.color;
        tempColor.a = BrightnessSlider.value;
        Brightness.color = tempColor;
    }
}