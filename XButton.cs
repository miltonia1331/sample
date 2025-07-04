using UnityEngine;
using UnityEngine.UI;

public class XButton : MonoBehaviour
{
    public DataBase dataBase;

    public void OnButtonClicked(Button clickedButton)
    {
        string buttonName = clickedButton.gameObject.name;
        switch (buttonName)
        {
            case "X":
                dataBase.Panel.SetActive(false);
                break;
            default:
                break;
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
