using UnityEngine;
using UnityEngine.UI;

public class TabButton : MonoBehaviour
{
    public DataBase dataBase;
        public void Start()
    {
        Active(0);
    }

    public void OnButtonClicked(Button clickedButton)
    {
        string buttonName = clickedButton.gameObject.name;
        if (buttonName == "B_PVP_맵" || buttonName == "B_PVP_무기") //버튼 누르면 초기화
            dataBase.Reset();
        else if (buttonName == "B_PVE_맵&속성") //버튼 누르면 초기화
            dataBase.PVE_Reset();
        switch (buttonName)
        {
            case "B_PVP_맵":
                Active(0);                
                break;
            case "B_PVP_무기":
                Active(1);
                break;
            case "B_PVE_맵&속성":
                Active(2);
                break;
            default:
                break;
        }
    }
    private void Active(int x)
    {
        for (int i = 0; i < 3; i++)
        {
            if(i==x) //내가 선택한 창 보이기
            {
                dataBase.TabButton[i].SetActive(true);
                dataBase.TabMenu[i+3].SetActive(true);
            }
            else //선택 안한 창 숨기기
            {
                dataBase.TabButton[i].SetActive(false);
                dataBase.TabMenu[i+3].SetActive(false);
            }
        }
    }
   
}
