﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : PersistantSingleton<OptionsManager>
{
    // the value of the master volume
    [HideInInspector]
    public float m_fMasterVolume = 100.0f;
    // the value of the music volume
    [HideInInspector]
    public float m_fMusicVolume = 100.0f;
    // the value of the sfx volume
    [HideInInspector]
    public float m_fSFXVolume = 100.0f;
    // determines if the vibration is on
    [HideInInspector]
    public bool m_bVibration = true;
    // determines if the wrecking ball will swing
    [HideInInspector]
    public bool m_bWreckingBall = true;
    // determines if the bombs will be dropped in
    [HideInInspector]
    public bool m_bBombs = true;
    // determines if the pickups will spawn
    [HideInInspector]
    public bool m_bPickups = true;
    // determines if the indicator will be shown
    [HideInInspector]
    public bool m_bIndicator = true;
    // the value of the dropdown
    [HideInInspector]
    public int m_iRound = 1;

    // reference to the game setup screen
    private GameObject m_gameSetup;
    // reference to the options screen
    private GameObject m_options;
    // references to the sliders
    private Slider[] m_sliders;
    // references to the toggles
    private Toggle[] m_toggles;
    // reference to the round dropdown
    private Dropdown m_dropdown;

    protected override void Awake()
    {
        base.Awake();

        m_sliders = Object.FindObjectsOfType<Slider>();
        m_toggles = Object.FindObjectsOfType<Toggle>();
        m_dropdown = Object.FindObjectOfType<Dropdown>();

        m_gameSetup = GameObject.Find("GameSetup");
        m_gameSetup.SetActive(false);
        m_options = GameObject.Find("Options");
        m_options.SetActive(false);
    }

    private void Update()
    {
        // gets the values from the sliders
        m_fMasterVolume = m_sliders[1].value;
        m_fMusicVolume = m_sliders[2].value;
        m_fSFXVolume = m_sliders[0].value;
        // gets the toggle status
        m_bWreckingBall = m_toggles[1].isOn;
        m_bBombs = m_toggles[0].isOn;
        m_bPickups = m_toggles[4].isOn;
        m_bIndicator = m_toggles[3].isOn;
        m_bVibration = m_toggles[2].isOn;
        // gets the value from the dropdown
        m_iRound = m_dropdown.value;
    }
}