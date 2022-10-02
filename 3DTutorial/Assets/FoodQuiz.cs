using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodQuiz : MonoBehaviour
{
    [SerializeField] Dialogue _dialog;

    [SerializeField] Dialogue _correctChoiceDialogue;

    [SerializeField] Dialogue _incorrectChoiceDialogue;

    [SerializeField] GameObject _correctFood;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter()
    {
        GameEvents.InvokeDialogInitiated(_dialog); 
    }

    public IEnumerator FoodSelected(GameObject food)
    {
        yield return new WaitForEndOfFrame();
        if (food == _correctFood)
        {
            GameEvents.InvokeDialogInitiated(_correctChoiceDialogue);
        }
        else
        {
            GameEvents.InvokeDialogInitiated(_incorrectChoiceDialogue);
        }

        Destroy(food);
        
    }
}
