using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Stint : MonoBehaviour
{

    public GameObject Mubazir;
    public GameObject Steve;
    public DialogueRunner dialogueRunner;
    public GameObject Backdrop;
    public LoopTracker loopTracker;


    private float looped;

    public InMemoryVariableStorage variableStorage;

    public void Awake() {
        variableStorage.SetValue("$looped", loopTracker.Loops);
        dialogueRunner.AddCommandHandler("stop_talk", stopBoth);
        dialogueRunner.AddCommandHandler("Mub_talk", MoveMub);
        dialogueRunner.AddCommandHandler("Steve_talk", MoveSteve);
        dialogueRunner.AddCommandHandler("Both_talk", MoveBoth);
        dialogueRunner.AddCommandHandler("BumpLoop", BumpLoop);
    }

    void stopBoth()
    {
        Debug.Log("Both stopped");
        Mubazir.GetComponent<Animator>().SetInteger("Bounces", 0);
        Steve.GetComponent<Animator>().SetInteger("Bounces", 0);
        // Steve.GetComponent<Animator>().SetInteger("Bounces", 1);

    }
    void MoveMub()
    {
        Mubazir.GetComponent<Animator>().SetInteger("Bounces", 1);
        Steve.GetComponent<Animator>().SetInteger("Bounces", 0);
        Debug.Log("Mubazir moving, Steve stop");
    }
    void MoveSteve()
    {
        Mubazir.GetComponent<Animator>().SetInteger("Bounces", 0);
        Steve.GetComponent<Animator>().SetInteger("Bounces", 1);
        Debug.Log("Steve moving, Mubazir stop");
    }
    void MoveBoth()
    {
        Mubazir.GetComponent<Animator>().SetInteger("Bounces", 1);
        Steve.GetComponent<Animator>().SetInteger("Bounces", 1);
        Debug.Log("Both moving");
    }

    public void ClearScreen()
    {
        Mubazir.SetActive(false);
        Steve.SetActive(false);
        Backdrop.SetActive(false);
    }

    
    public void BumpLoop()
    {
        loopTracker.Loops += 1;
        if(loopTracker.Loops > 8){
            loopTracker.Loops = 1;
        }
        variableStorage.TryGetValue("$looped", out looped);
        variableStorage.SetValue("$looped", loopTracker.Loops);
        Debug.Log("Loop bumped");
    }

}
