using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterCreator : MonoBehaviour
{

    public GameObject[] characterPrefabs;   // length = careerNum;
    private GameObject[] characterGameObjects;
    public static string[] careerNames = { "Designer", "Artist", "Programmer" };

    [SerializeField][Range(0,2)] private int selectedIndex = 0;
    static int careerNum; // = 3 designer, artist, programmer

    public Transform characterParent;
    public TMP_Text characterText;

    public TMP_InputField inputName;
    public TMP_InputField inputAge;

    void Start()
    {
        // instanciate all characters
        careerNum = characterPrefabs.Length;
        characterGameObjects = new GameObject[careerNum];
        for(int i = 0;i<careerNum; i++)
        {
            characterGameObjects[i] = GameObject.Instantiate(characterPrefabs[i], characterParent) as GameObject;
        }

        UpdateCharacterDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateCharacterDisplay()
    {
        // hide unselected characters
        characterGameObjects[selectedIndex].SetActive(true);
        characterText.text = careerNames[selectedIndex];
        for (int i = 0; i < careerNum; i++)
        {
            if (i != selectedIndex)
            {
                characterGameObjects[i].SetActive(false);
            }
        }
    }

    public void OnNextButtonClick()
    {
        selectedIndex = (selectedIndex + 1) % careerNum;
        UpdateCharacterDisplay();
    }
    public void OnPrevButtonClick()
    {
        selectedIndex--;
        if (selectedIndex < 0)
        {
            selectedIndex += careerNum;
        }
        UpdateCharacterDisplay();
    }

    public void OnIconButtonClick(int selectId)
    {
        selectedIndex = selectId;
        UpdateCharacterDisplay();
    }

    // Save data
    public void OnConfirmButtonClick()
    {
        // name and career choise
        PlayerPrefs.SetInt("SelectedCharacterIndex", selectedIndex);
        PlayerPrefs.SetString("Name", inputName.text);
        //PlayerPrefs.SetInt("Age", int.Parse(inputAge.text));

        // skills
        PlayerPrefs.SetInt("Attribute_Body", AttribManager.m_Instance.m_Attribs[0].points);
        PlayerPrefs.SetInt("Attribute_Willpower", AttribManager.m_Instance.m_Attribs[1].points);
        PlayerPrefs.SetInt("Attribute_Mind", AttribManager.m_Instance.m_Attribs[2].points);
        PlayerPrefs.SetInt("Attribute_Knowledge", AttribManager.m_Instance.m_Attribs[3].points);
        PlayerPrefs.SetInt("Attribute_Practical", AttribManager.m_Instance.m_Attribs[4].points);

        // Load Next Scene
        SceneManager.LoadScene("2_Skillpoints");

    }
}
