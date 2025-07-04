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
            case "�̵�Ÿ��":
                countcheck(0);
                break;
            case "������ ����":
                countcheck(1);
                break;
            case "�ӳ��� �ؾ�":
                countcheck(2);
                break;
            case "��� ������":
                countcheck(3);
                break;
            case "���":
                countcheck(4);
                break;
            case "ȯ�ϰ� ������ ����":
                countcheck(5);
                break;
            case "�콼��":
                countcheck(6);
                break;
            case "����":
                countcheck(7);
                break;
            case "�̺�Ÿ��Ʈ ������":
                countcheck(8);
                break;
            case "�ǿ��":
                countcheck(9);
                break;
            case "����":
                countcheck(10);
                break;
            case "�����°��":
                countcheck(11);
                break;
            case "Start":
                dataBase.Panel.SetActive(true);
                dataBase.list.Clear(); //����Ʈ �ʱ�ȭ
                dataBase.Re(); //���� �ʱ�ȭ
                break;
            default:
                break;
        }
    }
    private void countcheck(int x)
    {        
        if (dataBase.PVP_M_Colorcheck[x] == 1) //���� ����
        {
            dataBase.PVP_M_img[x].GetComponent<Image>().sprite = dataBase.img[x];
            dataBase.PVP_M_Colorcheck[x] = 0; //0: �̹��� ���� ����, 1: �̹��� ������
        }
        else //����
        {
            dataBase.img[x] = dataBase.PVP_M_img[x].GetComponent<Image>().sprite; //������ ����
            dataBase.PVP_M_img[x].GetComponent<Image>().sprite = dataBase.Other[0]; //������ �̹��� ���� 
            dataBase.PVP_M_Colorcheck[x] = 1;
        }
    }
    private void OpenPanel()
    {
        GameObject panel = GameObject.Find("P_PVP_M");
        panel.SetActive(true);
    }
}
