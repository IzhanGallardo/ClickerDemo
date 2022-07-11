using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadText : MonoBehaviour
{
    private string deadText;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("maxStage") || PlayerPrefs.GetInt("maxStage") < PlayerPrefs.GetInt("currentStage"))
        {
            PlayerPrefs.SetInt("maxStage", PlayerPrefs.GetInt("currentStage"));
        }
        deadText = "";
    }

    // Update is called once per frame
    void Update()
    {
        deadText = "You have been slain! Your max stage this run has been " + PlayerPrefs.GetInt("currentStage").ToString() + " and your all-time max stage is " + PlayerPrefs.GetInt("maxStage").ToString() + ".";
        if(PlayerPrefs.GetInt("maxStage") <= PlayerPrefs.GetInt("currentStage"))
        {
            deadText = deadText + "\n \n Congratulations! Your max stage this run has matched or surpassed your all-time max stage!";
        }
        gameObject.GetComponent<Text>().text = deadText;
    }
}
