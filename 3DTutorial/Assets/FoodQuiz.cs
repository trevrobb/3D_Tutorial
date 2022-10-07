using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodQuiz : MonoBehaviour
{
    [SerializeField] Dialogue _dialog;

    [SerializeField] Dialogue _correctChoiceDialogue;

    [SerializeField] Dialogue _incorrectChoiceDialogue;

    [SerializeField] Dialogue _tooPoor;

    [SerializeField] GameObject _correctFood;
    [SerializeField] Player _player;
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
        if (food == _correctFood && Player.instance.playerMoney >= 50)
        {
            GameEvents.InvokeDialogInitiated(_correctChoiceDialogue);
            Player.instance.playerMoney -= 50;
            Destroy(food);
        }
        else if (Player.instance.playerMoney >= 10 && food != _correctFood)
        {
            GameEvents.InvokeDialogInitiated(_incorrectChoiceDialogue);
            Player.instance.playerMoney -= 10;
            Destroy(food);
        }
        else if (Player.instance.playerMoney >= 10 && food == _correctFood)
        {
            GameEvents.InvokeDialogInitiated(_tooPoor);
        }
        else if (Player.instance.playerMoney < 10)
        {
            GameEvents.InvokeDialogInitiated(_tooPoor);
        }

        
        
    }
}
