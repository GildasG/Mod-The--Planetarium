using Palmmedia.ReportGenerator.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI welcome;

    // Start is called before the first frame update
    void Start()
    {
        if (MainManager.Instance.yourName != null)
        {
            SetName(MainManager.Instance.yourName);
        }
    }

    // Update is called once per frame
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void SetName(string name)
    {
        welcome.text = "Bienvenue, " + name + " !";
    }
}
