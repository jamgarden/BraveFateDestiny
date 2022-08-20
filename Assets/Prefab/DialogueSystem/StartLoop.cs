using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLoop : MonoBehaviour
{
    public bool CG_Active = false;
    public float delayTimer = 5.0f;

    public GameObject Player;
    public GameObject Chalupagong;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CG_Active && delayTimer > 0)
        {
            delayTimer -= Time.deltaTime;
        }
        if(CG_Active && delayTimer < 0.01f)
        {
            Debug.Log("Beware the Chalupagong!");
            CG_Active = false;
            Chalupagong.SetActive(true);
            // 
        }
    }

    public void CountDown()
    {
        // Set timer to unleash chalupagong
        CG_Active = true;
        
        // Set player movement to true
        Player.GetComponent<firstPersonControl>().canMove = true;
        Player.GetComponent<firstPersonControl>().canJump = true;
        // Set player rotation to true
        Player.GetComponent<MouseLook>().canTurn = true;
    }
}
