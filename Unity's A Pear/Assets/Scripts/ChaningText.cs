using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChaningText : MonoBehaviour
{
    public Text pair;
    public bool spellingPair;
    public bool isTyping;
    public float timeSinceLastChange;
    public float inbetweenTime;
    public string pairWord = "Pair";
    public string pearWord = "Pear";
    public int currentLetter;

    // Update is called once per frame
    void Start()
    {
        currentLetter = 0;
        spellingPair = false;
        isTyping = false;
    }

    void Update()
    {
        timeSinceLastChange+=Time.deltaTime;

        if(spellingPair)
        {
            if(timeSinceLastChange>inbetweenTime)
            {
                if(isTyping)
                {
                    AddCharacter(currentLetter, spellingPair);
                }else{
                    Delete();
                }

                timeSinceLastChange = 0;
            }
        }else{
            if(timeSinceLastChange>inbetweenTime)
            {
                if(isTyping)
                {
                    AddCharacter(currentLetter, spellingPair);
                }else{
                    Delete();
                }

                timeSinceLastChange = 0;
            }
        }

        if(currentLetter == pairWord.Length)
        {
            currentLetter = 0;
            spellingPair = !spellingPair;
            timeSinceLastChange = -2;
            isTyping = false;
        }
    }

    void AddCharacter(int currentLetterIn, bool spellingPairIn)
    {
        if(spellingPairIn)
        {
            pair.text = pair.text + pairWord[currentLetterIn];
        }else{
            pair.text = pair.text + pearWord[currentLetterIn];
        }
        currentLetter++;

    }
    void Delete()
    {
        pair.text = pair.text.Substring(0, pair.text.Length-1);

        if(pair.text.Length<=8)
        {
            isTyping = true;
        }
    }
}
