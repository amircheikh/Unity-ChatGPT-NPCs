using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotKeywordListener : MonoBehaviour
{
    public string keyword;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.GetComponent<OpenAiTextChat>().enabled == true)
        {
            if (OpenAiTextChat.latestResponseMessage.Contains(keyword))
            {
                //Do things here 
                Debug.Log("cheesebuger");
                SceneManager.LoadScene(sceneBuildIndex:1);

            }
        }


    }
}
