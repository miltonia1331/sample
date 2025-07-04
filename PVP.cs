using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PVP : MonoBehaviour
{
    public DataBase dataBase;
    public Button spinButton; //돌리기 버튼   
    private Color32 Be_color, Af_color;
    Image img;
    ColorBlock cb;

    private void Start()
    {
        Be_color = new Color32(255, 255, 255, 170); ; //원래 투명도
        Af_color = new Color32(255, 255, 255, 255); ; //선택 투명도
        spinButton = GetComponent<Button>();
    }
    public void OnButtonClicked(Button clickedButton)
    {
        string buttonName = clickedButton.gameObject.name;
        switch (buttonName)
        {
            case "융합 소총":
                countcheck(0, false);
                break;
            case "정찰 소총":
                countcheck(1, false);
                break;
            case "파동 소총":
                countcheck(2, false);
                break;
            case "보조무기":
                countcheck(3, false);
                break;
            case "저격총":
                countcheck(4, false);
                break;
            case "기관단총":
                countcheck(5, false);
                break;
            case "추적 소총":
                countcheck(6, false);
                break;
            case "샷건":
                countcheck(7, false);
                break;
            case "월도":
                countcheck(8, false);
                break;
            case "활":
                countcheck(9, false);
                break;
            case "유탄 발사기":
                countcheck(10, false);
                break;
            case "핸드캐논":
                countcheck(11, false);
                break;
            case "Start":
                Rand();
                break;
            default:
                break;
        }
    }

    private void countcheck(int x, bool y)
    {
        PlayerCheck(x);

        img = dataBase.PVP_W_img[x].GetComponent<Image>();
        if (dataBase.PVP_W_check[x] == 1) //선택 해제
        {
            img.color = Be_color; //투명도 조절
            dataBase.PVP_W_check[x] = 0; //0: 이미지 선택 안함, 1: 이미지 선택함
            dataBase.pvp_w[x].SetActive(false); //x 이미지 빼기
        }
        else //선택
        {
            img.color = Af_color;
            dataBase.PVP_W_check[x] = 1;
            if (y == false) //선택이 아니고 랜덤일 때
                dataBase.pvp_w[x].SetActive(true); //x 이미지 넣기
        }
    }
    private void PlayerCheck(int x) //직접 선택한 것 저장
    {
        if (dataBase.Pick[0] == -1) //첫번째 선택
        {
            dataBase.Pick[0] = x;
        }
        else if (dataBase.Pick[0] >= 0 && dataBase.Pick[0] != x && dataBase.Pick[1] != x) //두번째 선택
        {
            dataBase.Pick[1] = x;
        }
        else if(dataBase.Pick[0] == x) //선택 취소 시 초기화
        {
            dataBase.Pick[0] = -1;
        }
        else if (dataBase.Pick[1] == x) //선택 취소 시 초기화
        {
            dataBase.Pick[1] = -1;
        }
    }
    public void Rand()
    {
        StartCoroutine(RandomSelectCoroutine());
    }

    private IEnumerator RandomSelectCoroutine()
    {
        int random = 0;
        float i = 0, ran = 0;

        //시작버튼 색 바꾸기
        cb = spinButton.colors;
        cb.normalColor = UnityEngine.Color.red;
        cb.highlightedColor = UnityEngine.Color.red;
        cb.pressedColor = UnityEngine.Color.red;
        cb.selectedColor = UnityEngine.Color.red;
        spinButton.colors = cb;

        while (true)
        {
            if (i > 0.7f) //일정 시간 이후 멈추기
                break;
            ran = Random.Range(0.01f, 0.05f); //랜덤 시간 정하기
            i = i + ran; //천천히 돌아가게
            if (dataBase.before < 12) // 전에 선택된 것 강제 해제
            {
                countcheck(dataBase.before, true);
            }
            while(true)
            {
                random = Random.Range(0, 12); //랜덤 선택
                if (dataBase.PVP_W_check[random] == 0 && dataBase.Pick[0] != random && dataBase.Pick[1] != random && dataBase.before != random)  //선택이 안된것만 선택됨
                {                    
                    if (i > 0.7f) // 멈춘다면 마지막
                        countcheck(random, false);
                    else
                        countcheck(random, true);
                    dataBase.before = random;
                    break;
                }
            }
            yield return new WaitForSeconds(0.005f + i); // 대기
        }
        //시작버튼 다시 하얗게
        cb.normalColor = UnityEngine.Color.white;
        cb.highlightedColor = UnityEngine.Color.white;
        cb.pressedColor = UnityEngine.Color.white;
        cb.selectedColor = UnityEngine.Color.white;
        spinButton.colors = cb;
    }
}
