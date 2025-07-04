using UnityEngine;
using UnityEngine.UI;
public class PVP_M : MonoBehaviour
{
    public DataBase dataBase;

    public void OnButtonClicked(Button clickedButton)
    {
        string buttonName = clickedButton.gameObject.name;
        switch (buttonName)
        {
            case "미드타운":
                countcheck(0);
                break;
            case "죽음의 절벽":
                countcheck(1);
                break;
            case "머나먼 해안":
                countcheck(2);
                break;
            case "깃발 내리기":
                countcheck(3);
                break;
            case "재블린":
                countcheck(4);
                break;
            case "환하게 빛나는 절벽":
                countcheck(5);
                break;
            case "녹슨땅":
                countcheck(6);
                break;
            case "영원":
                countcheck(7);
                break;
            case "이븐타이트 연구실":
                countcheck(8);
                break;
            case "권운광장":
                countcheck(9);
                break;
            case "소진":
                countcheck(10);
                break;
            case "끝없는계곡":
                countcheck(11);
                break;
            case "Start":
                dataBase.Panel.SetActive(true);
                dataBase.list.Clear(); //리스트 초기화
                dataBase.Re(); //랜덤 초기화
                break;
            default:
                break;
        }
    }
    private void countcheck(int x)
    {        
        if (dataBase.PVP_M_Colorcheck[x] == 1) //선택 해제
        {
            dataBase.PVP_M_img[x].GetComponent<Image>().sprite = dataBase.img[x];
            dataBase.PVP_M_Colorcheck[x] = 0; //0: 이미지 선택 안함, 1: 이미지 선택함
        }
        else //선택
        {
            dataBase.img[x] = dataBase.PVP_M_img[x].GetComponent<Image>().sprite; //기존것 저장
            dataBase.PVP_M_img[x].GetComponent<Image>().sprite = dataBase.Other[0]; //선택한 이미지 변경 
            dataBase.PVP_M_Colorcheck[x] = 1;
        }
    }
    private void OpenPanel()
    {
        GameObject panel = GameObject.Find("P_PVP_M");
        panel.SetActive(true);
    }
}
