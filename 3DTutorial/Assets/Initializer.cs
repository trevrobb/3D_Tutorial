using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField] RuntimeData _runtimeData;
    [SerializeField] Dialogue _starterDialogue;


     void Awake()
    {
        _runtimeData.CurrentFoodMouseOver = "";
        _runtimeData.CurrentGameplayState = GameplayState.InDialog;
        
    }

    private void Start()
    {
        GameEvents.InvokeDialogInitiated(_starterDialogue);
    }
}
