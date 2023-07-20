using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameField;
    public TextMeshProUGUI warning;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    public void StorePlayerName(string inputName)
    {
        MainManager.Instance.yourName = inputName;
    }
    public void StartScene()
    {
        if (MainManager.Instance.yourName == "")
        {
            StartCoroutine(Warning()); 
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
    public void QuitApp()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); //Original code to quit Unity player
#endif
    }
    IEnumerator Warning()
    {
        warning.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        warning.gameObject.SetActive(false);
    }
}
