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
    GameObject characterMenu;

    [SerializeField]
    GameObject characterMenuInv;

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
            characterMenu.SetActive(true);

            if (characterMenuInv.activeSelf == false)
            {
                characterMenuInv.SetActive(true);
                characterMenuSkills.SetActive(false);
            }
            else if (characterMenuInv.activeSelf == true && Input.GetKeyDown(KeyCode.I))
            {
                characterMenu.SetActive(false);
                characterMenuInv.SetActive(false);
                characterMenuSkills.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            characterMenu.SetActive(true);

            if (characterMenuSkills.activeSelf == false)
            {
                characterMenuInv.SetActive(false);
                characterMenuSkills.SetActive(true);
            }
            else if (characterMenuSkills.activeSelf == true && Input.GetKeyDown(KeyCode.K))
            {
                characterMenu.SetActive(false);
                characterMenuInv.SetActive(false);
                characterMenuSkills.SetActive(false);
            }
        }
    }

    //--------------------------------Character Menus--------------------------------------------

    public void CharacterMenu()
    {
        if (characterMenu.activeSelf == false)
        {
            characterMenu.SetActive(true);
            helpMenu.SetActive(false);
        }
        else
        {
            characterMenu.SetActive(false);
            helpMenu.SetActive(false);
        }
    }

    public void CharacterMenuInventory()
    {
        if (characterMenu.activeSelf == true)
        {
            characterMenuInv.SetActive(true);
            characterMenuSkills.SetActive(false);
        }
        else
        {
            characterMenuInv.SetActive(false);
            characterMenuSkills.SetActive(false);
        }
    }

    public void CharacterMenuSkills()
    {
        if (characterMenu.activeSelf == true)
        {
            characterMenuSkills.SetActive(true);
            characterMenuInv.SetActive(false);
        }
        else
        {
            characterMenuInv.SetActive(false);
            characterMenuSkills.SetActive(false);
        }
    }

    //-------------------------------------------------------------------------------------------

    public void HelpMenu()
    {
        if (helpMenu.activeSelf == false)
        {
            characterMenu.SetActive(false);
            helpMenu.SetActive(true);
        }
        else
        {
            characterMenu.SetActive(false);
            helpMenu.SetActive(false);
        }
    }

    public void WriteMessage(string Message)
    {
        TextMeshProUGUI NewText = Instantiate(BasicTextPrefab, NotificationArea.transform).GetComponent<TextMeshProUGUI>();
        NewText.text = Message;
    }
}