using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PhoneLockManager : MonoBehaviour
{
    [Header("Key Code Fields")]
    [SerializeField] private string phonePasscode;
    [SerializeField] private string wrongPasscodeMessage = "Wrong Passcode";

    [Header("Key Code Limits")]
    [SerializeField] private int characterLimit = 4;
    private int characterInputCount;

    [Header("UI Fields")]
    [SerializeField] TMP_InputField keyInputField;

    [Header("Event")]
    [SerializeField] private UnityEvent unlockEvent;
    private bool hasUnlocked;

    private void Start()
    {
        keyInputField.characterLimit = characterLimit;
    }

    public void KeyButton(string key)
    {
        if (characterInputCount < keyInputField.characterLimit)
        {
            keyInputField.text += key;
            characterInputCount++;
        }
    }

    public void EnterButton()
    {
        if (keyInputField.text.ToUpper() == phonePasscode)
        {
            hasUnlocked = true;
            unlockEvent.Invoke();
        }
        else
        {
            keyInputField.text = wrongPasscodeMessage;
        }
    }

    public void CancelButton()
    {
        ResetInputField();
    }

    void ResetInputField()
    {
        keyInputField.text = null;
        characterInputCount = 0;
    }

    public void CheckIsSolved()
    {
        if (hasUnlocked)
        {
            unlockEvent.Invoke();
        }
    }
}
