using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BotIdle : MonoBehaviour
{
    private GameObject player;
    private GameObject talkHint;
    public float talkRange;
    public int conversationMode = 0;    //Indicates which mode the player will be in for conversation. 0: Text chat, 1: TBD
    private bool playerInRange = false;




    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        talkHint = GameObject.FindGameObjectWithTag("TalkHint");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        bool playerInRangeNow = Physics.Raycast(transform.position, player.transform.position - transform.position, out hit, talkRange) && hit.transform.position == player.transform.position; //Checks if player is in the talkrange of bot
        
        if(playerInRange && !playerInRangeNow) talkHint.GetComponent<TMP_Text>().enabled = false;   //If statement checks when the player immedietly leaves the talk range. This will disable the talkhint

        playerInRange = playerInRangeNow;   //Updates playerInRange bool to current status of the range of the player 
        //*All this was done to avoid an else statement. This was required since multiple BotIdle scripts will be present in the scene. Ask Amir if you have any questions*


        if (playerInRange)
        {

            talkHint.GetComponent<TMP_Text>().enabled = true;   //Enables the talkhint
            if (conversationMode == 0 && Input.GetKeyUp(KeyCode.F)) {
                StartConversation();
            }

        }

    }


    void StartConversation()
    {
        if (conversationMode == 0)
        {
            gameObject.GetComponent<OpenAiTextChat>().enabled = true;
        }
        else Debug.LogError("Conversation mode is invalid!");
        this.enabled = false;

    }
}
