using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Profiling;
using UnityEngine.UI;
using UnityEditor.PackageManager;
using System;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] Dialogue _currentDialogue;
    int _currentSlideIndex = 0;
    [SerializeField] RuntimeData _runtimeData;
    void Start()
    {
        
    }

    private void Awake()
    {
        GameEvents.DialogFinished += onDialogFinished;
        GameEvents.DialogInitiated += OnDialogInitiated;
    }

    void OnDialogInitiated(object sender, DialogueEventArgs args)
    {
        _currentDialogue = args.dialogPayload;
        _currentSlideIndex = 0;
        ShowSlide();
        LoadAvatar();
        GetComponent<Canvas>().enabled = true;
        _runtimeData.CurrentGameplayState = GameplayState.InDialog;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (_currentSlideIndex < _currentDialogue.DialogSlides.Length - 1) {
                _currentSlideIndex++;
                ShowSlide();

            } else
            {
                GameEvents.InvokeDialogFinished();

            }
            
        }
    }

    void onDialogFinished(object sender, EventArgs args)
    {
        gameObject.GetComponent<Canvas>().enabled = false;
        _runtimeData.CurrentGameplayState = GameplayState.FreeWalk;
    }

    void ShowSlide()
    {
        GameObject textObj = transform.Find("DialogText").gameObject;
        TextMeshProUGUI textComponent = textObj.GetComponent<TextMeshProUGUI>();
        textComponent.text = _currentDialogue.DialogSlides[_currentSlideIndex];

    }
    void LoadAvatar()
    {
        GameObject avatarObj = transform.Find("Avatar").gameObject;
        avatarObj.GetComponent<RawImage>().texture = _currentDialogue.NPCAvatar;

    }
}
