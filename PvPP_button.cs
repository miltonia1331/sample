using UnityEngine;
using UnityEngine.UI;

public class PvPP_button : MonoBehaviour
{
    public DataBase dataBase;

    public void OnButtonClicked(UnityEngine.UI.Button clickedButton) //클릭했을 때
    {
        
        string buttonName = clickedButton.gameObject.name;        
        switch (buttonName)
        {
            case "1":
                chagne(0);
                break;
            case "2":
                chagne(1);
                break;
            case "3":
                chagne(2);
                break;
            case "4":
                chagne(3);
                break;
            case "5":
                chagne(4);
                break;
            case "6":
                chagne(5);
                break;
            case "7":
                chagne(6);
                break;
            case "8":
                chagne(7);
                break;
            case "9":
                chagne(8);
                break;
            case "10":
                chagne(9);
                break;
            default:
                break;
        }
    }

    private void chagne(int x) //메뉴 클릭 시 이미지 나오게
    { //랜덤으로 돌린 리스트 x번에 있는 이미지를 버튼 x번에 넣기
        dataBase.PVP_P_M[x].image.sprite = dataBase.PVP_M_img[dataBase.list[x]].GetComponent<Image>().sprite; //이미지 넣기
    }        
}
