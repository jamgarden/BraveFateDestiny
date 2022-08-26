using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class AudioLineView : VoiceOverView
{



    public override void RunLine(LocalizedLine dialogueLine, Action onDialogueLineFinished)
    {

        // dialogueLine.
        Debug.Log(dialogueLine.CharacterName);
        Debug.Log(dialogueLine.Text.ToString());
        // Debug.Log(dialogueLine.)
        // VoiceOverView
        base.RunLine(dialogueLine, onDialogueLineFinished);

    }

    // public override void

    public override void InterruptLine(LocalizedLine dialogueLine, Action onDialogueLineFinished)
    {
        base.InterruptLine(dialogueLine, onDialogueLineFinished);
    }

    public override void DismissLine(Action onDismissalComplete)
    {
        base.DismissLine(onDismissalComplete);
    }

    public override void 
}
