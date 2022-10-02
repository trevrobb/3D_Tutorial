using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Food : MonoBehaviour
   
{
    float _rotationSpeed = 180f;
    [SerializeField] RuntimeData _runtimeData;
    [SerializeField] GameObject _parentQuiz;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void OnMouseEnter()
    {
        
        transform.Find("Spot Light").gameObject.SetActive(true);
        _runtimeData.CurrentFoodMouseOver = name;
        
    }

    void OnMouseExit()
    {
        transform.Find("Spot Light").gameObject.SetActive(false);
        _runtimeData.CurrentFoodMouseOver = "";
    }

    void OnMouseOver()
    {
        transform.Find("Food Mesh").Rotate( Vector3.up, _rotationSpeed *Time.deltaTime);
    }

    void OnMouseDown()
    {
            if (_runtimeData.CurrentGameplayState != GameplayState.InDialog)
        {
            StartCoroutine(_parentQuiz.GetComponent<FoodQuiz>().FoodSelected(gameObject));
            _runtimeData.CurrentFoodMouseOver = "";
        }
                
                
        
        
    }
}
