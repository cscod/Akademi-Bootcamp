using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PuzzleManager : MonoBehaviour
{
    [Header("Event")]
    [SerializeField] private UnityEvent unlockEvent;
    private bool hasUnlocked;
    int puzzleCounter = 0;
    int totalPuzzleCount = 16;

    public void IncreaseCounter()
    {
        puzzleCounter++;

        if(puzzleCounter == totalPuzzleCount)
        {
            Debug.Log("Puzzle is solved.");
            hasUnlocked = true;
            unlockEvent.Invoke();
        }
    }

    public void CheckIsSolved()
    {
        if (hasUnlocked)
        {
            unlockEvent.Invoke();
        }
    }
}
