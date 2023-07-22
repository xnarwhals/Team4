using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketManager : MonoBehaviour
{
    public Image MarketImage;
    public Sprite[] marketSprites;
    public MarketDialogue[] dialogueLines;

    int currentIndex = 0;
    bool dialogueOpen;

    // Start is called before the first frame update
    void Start()
    {
        EvtSystem.EventDispatcher.AddListener<GameEvents.EndDialogue>(CloseDialogue);
    }

    // Update is called once per frame
    void Update()
    {
        if (!dialogueOpen)
        {
            if (Input.GetKeyUp(KeyCode.Joystick1Button0) || Input.GetKeyUp(KeyCode.Return)) 
            {
                OpenDialogue(dialogueLines[currentIndex]);
            }
            else if (Input.GetKeyUp(KeyCode.Joystick1Button1) || Input.GetKeyUp(KeyCode.D))//right
            {
                currentIndex++;
                if (currentIndex > marketSprites.Length - 1) currentIndex = 0;
                UpdateBackground();
            }
            else if (Input.GetKeyUp(KeyCode.Joystick1Button2) || Input.GetKeyUp(KeyCode.A))//right
            {
                currentIndex--;
                if (currentIndex < 0) currentIndex = marketSprites.Length - 1;
                UpdateBackground();
            }
        }
    }

    void OpenDialogue(MarketDialogue dialogueLine)
    {
        GameEvents.StartDialogue evt = new GameEvents.StartDialogue();
        evt.dialogueLine = dialogueLine;

        EvtSystem.EventDispatcher.Raise(evt);
        dialogueOpen = true;
    }

    void CloseDialogue(GameEvents.EndDialogue evt)
    {
        dialogueOpen = false;
    }

    void UpdateBackground()
    {
        MarketImage.sprite = marketSprites[currentIndex];
    }
}
