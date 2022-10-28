using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class InputName : MonoBehaviour
{
    [SerializeField]
    private LetterInput[] _letters;

    private int _focusLetter = 0;

    public string RetrieveName()
    {
        return "" + _letters[0].Value + _letters[1].Value + _letters[2].Value;
    }

    private int _horizontalInput = 0;
    private int _lastHorizontalInput = 0;
    private bool _horizontalInputPressed = false;

    public void Reset() 
    {
        _focusLetter = 0;

        foreach(var l in _letters)
        {
            l.Reset();
        }

        _letters[0].Focus();
    }   

    void Update()
    {
        int _newFocusLetter = GetNewFocusLetter();
        if(_focusLetter != _newFocusLetter)
        {
            _letters[_focusLetter].Unfocus();
            _letters[_newFocusLetter].Focus();

            _focusLetter = _newFocusLetter;
        }
    }

    private int GetNewFocusLetter()
    {
        _horizontalInput = (int) Input.GetAxisRaw("Horizontal");
        if(_horizontalInput != 0) _horizontalInputPressed = true;
        else _horizontalInputPressed = false;

        if(_horizontalInputPressed && _lastHorizontalInput == _horizontalInput) _horizontalInput = 0;
        else _lastHorizontalInput = _horizontalInput;
        
        return Mod((_focusLetter + _horizontalInput), _letters.Length);
    }

    int Mod(int a, int n) => (a % n + n) % n;
}
