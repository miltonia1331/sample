using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataBase : MonoBehaviour
{
    public int before = 12;
    public int[] Pick = { -1, -1 };
    public int[] PVP_M_Colorcheck = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public int[] PVP_W_check = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public Button[] PVP_P_M;//버튼 이름 가져오기
    public Sprite[] Other, img, P_img; //0: 선택이미지, 1: 버튼 이미지
    public GameObject[] TabButton, TabMenu, PVP_M_img, PVP_W_img, pvp_w;//0~3 : 버튼, 4~6 : show
    public GameObject Panel;
    public bool re = false, e_re = true, p_re = false;
    public List<int> list = new List<int>();
    
    private Image W_img;
    private void Start()
    {
        Panel.SetActive(false);
    }
    public void Reset() //pvp맵, 무기 탭 초기화
    {
        re = true;
        
        //전에 것도 초기화       
        before = 12;
        for (int i = 0; i < Pick.Length; i++)
            Pick[i] = -1;

        for (int i = 0; i < PVP_M_Colorcheck.Length; i++) //pvp 맵 색깔 확인용 변수 초기화
        {
            PVP_M_Colorcheck[i] = 0; //pvp 맵 변수
            PVP_W_check[i] = 0; //pvp 무기 변수
            if (img[i] != null) //이미지 변한 것이 있다면
            {
                PVP_M_img[i].GetComponent<Image>().sprite = img[i];
            }
            W_img = PVP_W_img[i].GetComponent<Image>();
            W_img.color = new Color32(255, 255, 255, 170); //투명도 조절
            pvp_w[i].SetActive(false); //x 이미지 전부 비활성화
        }
        re = false;
    }

    public void PVE_Reset()
    {
        e_re = false;
    }

    public void Re() //pvp맵 패널 랜덤 선택
    {
        for (int i = 0; i < 10; i++)
        {
            PVP_P_M[i].name = (i+1).ToString(); //n번 버튼 글씨 초기화
            PVP_P_M[i].image.sprite = Other[i + 1]; //이미지 초기화
        }

        for (int i = 0; i < 12; i++) //섞을 숫자 넣기
        {
            if (PVP_M_Colorcheck[i] == 0) //선택한 것 제외
            {
                list.Add(i);
            }
        }        

        for (int i = 0; i < list.Count; i++) //섞기
        {
            int rand = Random.Range(0, list.Count);
            if (rand != i)
                (list[i], list[rand]) = (list[rand], list[i]); //순서 바꾸기
        }                
    }
}
