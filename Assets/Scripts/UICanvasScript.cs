using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class UICanvasScript : MonoBehaviour
{
    private Singleton _singletonManager;
    // public APIManager _apiManager;
    // private AudioSource audioSource;
    // public AudioClip[] audioClips;

    [Header("Panels")]
    public GameObject _titlePanel;
    public GameObject _gamePanel;

    // public TMP_Text biocreditsText;
    // public TMP_Text shotsRemText;
    public GameObject _scorePanel;

    [Header("Player Prefab")]
    public GameObject playerPrefab;
    private GameObject player;

    

    void Start() {
        _singletonManager = Singleton.Instance;

        PanelState(0);
        _singletonManager.tapEnabled = true;
    } //-- start end


    void Update() {
        // shotsRemText.text = _singletonManager.shotsRemaining.ToString();
        // biocreditsText.text = _singletonManager.currentScore.ToString();

        /*
        if (_singletonManager.gameState == Singleton.GameState.TitleState) {
            if (Input.GetKeyUp(KeyCode.Space)) {
                // StartCoroutine(CountdownTimer());
            }
            /*
            if (_singletonManager.tapEnabled) {
                if (!_singletonManager.isLoggedIn) {
                    StartCoroutine(_apiManager.StationLogIn_Coroutine());
                }
            }
            
        }
        
        else if (_singletonManager.gameState == Singleton.GameState.PlayState) {


        }
        
        else if (_singletonManager.gameState == Singleton.GameState.ScoreState) {
            if (Input.GetKeyUp(KeyCode.Space)) {
                // StartCoroutine(CountdownTimer());
            }
            /*
            if (_singletonManager.tapEnabled) {
                if (!_singletonManager.isLoggedIn) {
                    StartCoroutine(_apiManager.StationLogIn_Coroutine());
                }
            }
            

        }
        */
    } //-- Update end


    void FixedUpdate() {
        // if (_singletonManager.gameState == Singleton.GameState.PlayState) {

        // }
    } //-- FixedUpdate end

    public void PanelState(int currentState) {
        switch(currentState) {
            case 0:
                _titlePanel.SetActive(true);
                _gamePanel.SetActive(false);
                _scorePanel.SetActive(false);
                break;
            case 1:
                _titlePanel.SetActive(false);
                _gamePanel.SetActive(true);
                _scorePanel.SetActive(false);
                break;
            case 2:
                _titlePanel.SetActive(false);
                _gamePanel.SetActive(false);
                _scorePanel.SetActive(true);
                break;
            default:
                break;
        }
    } //-- PanelState end
} //-- class end


/*
Project: 
Made by: 
*/