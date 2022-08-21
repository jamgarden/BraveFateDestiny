using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Stint : MonoBehaviour
{

    public GameObject Mubazir;
    public GameObject Steve;
    public DialogueRunner dialogueRunner;


    public void Awake() {
        dialogueRunner.AddCommandHandler("stop_talk", stopBoth);
        dialogueRunner.AddCommandHandler("Mub_talk", MoveMub);
        dialogueRunner.AddCommandHandler("Steve_talk", MoveSteve);
        dialogueRunner.AddCommandHandler("Both_talk", MoveBoth);
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

}
