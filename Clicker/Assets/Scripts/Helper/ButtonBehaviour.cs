using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void mainMenu()
    {
        //Load the MainMenu
        SceneManager.LoadScene("MainMenu");
    }

    public void playScene()
    {
        if(SceneManager.GetActiveScene().name == "Inventory")
        {
            FindObjectOfType<InventoryBehaviour>().inventoryNotFull();
        }
        SceneManager.LoadScene("Gameplay");
    }

    public void inventoryScene()
    {
        SceneManager.LoadScene("Inventory");
    }

    public void lootCollect()
    {
        SceneManager.LoadScene("LootCollect");
    }

    public void howToPlayScene()
    {
        SceneManager.LoadScene("HowToPlay");
    }
}
