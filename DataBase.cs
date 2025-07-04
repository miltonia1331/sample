using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataBase : MonoBehaviour
{
    public int before = 12;
    public int[] Pick = { -1, -1 };
    public int[] PVP_M_Colorcheck = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public int[] PVP_W_check = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public Button[] PVP_P_M;//��ư �̸� ��������
    public Sprite[] Other, img, P_img; //0: �����̹���, 1: ��ư �̹���
    public GameObject[] TabButton, TabMenu, PVP_M_img, PVP_W_img, pvp_w;//0~3 : ��ư, 4~6 : show
    public GameObject Panel;
    public bool re = false, e_re = true, p_re = false;
    public List<int> list = new List<int>();
    
    private Image W_img;
    private void Start()
    {
        Panel.SetActive(false);
    }
    public void Reset() //pvp��, ���� �� �ʱ�ȭ
    {
        re = true;
        
        //���� �͵� �ʱ�ȭ       
        before = 12;
        for (int i = 0; i < Pick.Length; i++)
            Pick[i] = -1;

        for (int i = 0; i < PVP_M_Colorcheck.Length; i++) //pvp �� ���� Ȯ�ο� ���� �ʱ�ȭ
        {
            PVP_M_Colorcheck[i] = 0; //pvp �� ����
            PVP_W_check[i] = 0; //pvp ���� ����
            if (img[i] != null) //�̹��� ���� ���� �ִٸ�
            {
                PVP_M_img[i].GetComponent<Image>().sprite = img[i];
            }
            W_img = PVP_W_img[i].GetComponent<Image>();
            W_img.color = new Color32(255, 255, 255, 170); //���� ����
            pvp_w[i].SetActive(false); //x �̹��� ���� ��Ȱ��ȭ
        }
        re = false;
    }

    public void PVE_Reset()
    {
        e_re = false;
    }

    public void Re() //pvp�� �г� ���� ����
    {
        for (int i = 0; i < 10; i++)
        {
            PVP_P_M[i].name = (i+1).ToString(); //n�� ��ư �۾� �ʱ�ȭ
            PVP_P_M[i].image.sprite = Other[i + 1]; //�̹��� �ʱ�ȭ
        }

        for (int i = 0; i < 12; i++) //���� ���� �ֱ�
        {
            if (PVP_M_Colorcheck[i] == 0) //������ �� ����
            {
                list.Add(i);
            }
        }        

        for (int i = 0; i < list.Count; i++) //����
        {
            int rand = Random.Range(0, list.Count);
            if (rand != i)
                (list[i], list[rand]) = (list[rand], list[i]); //���� �ٲٱ�
        }                
    }
}
