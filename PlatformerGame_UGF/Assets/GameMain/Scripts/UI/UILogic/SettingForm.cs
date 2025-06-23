using GameFramework.Localization;
using PlatformerGame;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingForm : UGuiForm
{
    [Serializable]
    public class ToggleLanguage
    {
        public Language language;
        public Toggle toggle;
    }

    public Slider masterVolumeSlider;
    public Slider sFXVolumeSlider;
    public Slider musicVolumeSlider;

    public ToggleLanguage[] languageToggle;

    public GameObject tipsGO;

    private Language currentLanguage;
    private Language selectLanguage;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        foreach(var item in languageToggle)
        {
            item.toggle.onValueChanged.AddListener((isOn) => OnLanguageToggleChange(isOn, item.language));
        }
    }

    protected override void OnClose(bool isShutdown, object userData)
    {
        base.OnClose(isShutdown, userData);
    }

    public void OnBackButtonClick()
    {
        Close();
    } 



    private void OnLanguageToggleChange(bool isOn, Language language)
    {
        throw new NotImplementedException();
    }
}
