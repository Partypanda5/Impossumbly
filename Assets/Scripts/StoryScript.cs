using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;

public class StoryScript : MonoBehaviour
{
    public TextAsset inkAsset;
    public TMP_Text dialogueText;
    public string storyKnot;

    Story inkStory;

    // Start is called before the first frame update
    void Start()
    {
        inkStory = new Story(inkAsset.text);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Reveal story text");
            inkStory.ChoosePathString(storyKnot);
            dialogueText.text = inkStory.Continue();
        }
    }
}
