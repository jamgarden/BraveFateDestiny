using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CommandTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [YarnCommand("testing_command")]
    public static void TestingCommand()
    {
        Debug.Log("The chalupagong cometh!");
    }
}
