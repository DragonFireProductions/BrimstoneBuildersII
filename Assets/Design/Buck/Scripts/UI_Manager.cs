using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This script will manage any elements that need to shown to the player
/// it will handle any button preses as well as input that interact with the UI directly
/// This includes keys such as I for inventory C for character sheet
/// </summary>

public class UI_Manager : MonoBehaviour
{

    [SerializeField]
    GameObject characterInv;

    [SerializeField]
    GameObject characterMenuSkills;

    [SerializeField]
    GameObject helpMenu;

    [SerializeField]
    GameObject NotificationArea;

    [SerializeField]
    GameObject BasicTextPrefab;

    void Start ()
    {

	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            WriteMessage("Message #1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            WriteMessage("Message #2");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            WriteMessage("Message #3");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            WriteMessage("Message #4");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {                                                                                                             
            WriteMessage("Message #6 Which is to test longer messages");
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (characterInv.activeSelf == false)
            {
                characterInv.SetActive(true);
            }

            else if (characterInv.activeSelf == true)
            {
                characterInv.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.K))
        {

        }
    }

    //--------------------------------Character Menus--------------------------------------------

    public void CharacterMenuInventory()
    {
        if (characterInv.activeSelf == false)
        {
            characterInv.SetActive(true);
        }

        else if (characterInv.activeSelf == true)
        {
            characterInv.SetActive(false);
        }
    }

    public void CharacterMenuSkills()
    {

    }

    //-------------------------------------------------------------------------------------------

    public void HelpMenu()
    {

    }

    public void WriteMessage(string Message)
    {
        TextMeshProUGUI NewText = Instantiate(BasicTextPrefab, NotificationArea.transform).GetComponent<TextMeshProUGUI>();
        NewText.text = Message;
    }
}