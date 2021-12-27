using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text numberOfGarbageText;
    [SerializeField] GarbageController garbageController;

    // Update is called once per frame
    void Update()
    {
        numberOfGarbageText.text = $"Number of garbage: {garbageController.GetNumberOfGarbage()}";
    }
}
