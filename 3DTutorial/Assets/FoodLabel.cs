using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FoodLabel : MonoBehaviour
{
    [SerializeField] RuntimeData _runtimeData;

    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = _runtimeData.CurrentFoodMouseOver;
    }
}
