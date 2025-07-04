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
        if (buttonName == "B_PVP_��" || buttonName == "B_PVP_����") //��ư ������ �ʱ�ȭ
            dataBase.Reset();
        else if (buttonName == "B_PVE_��&�Ӽ�") //��ư ������ �ʱ�ȭ
            dataBase.PVE_Reset();
        switch (buttonName)
        {
            case "B_PVP_��":
                Active(0);                
                break;
            case "B_PVP_����":
                Active(1);
                break;
            case "B_PVE_��&�Ӽ�":
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
            if(i==x) //���� ������ â ���̱�
            {
                dataBase.TabButton[i].SetActive(true);
                dataBase.TabMenu[i+3].SetActive(true);
            }
            else //���� ���� â �����
            {
                dataBase.TabButton[i].SetActive(false);
                dataBase.TabMenu[i+3].SetActive(false);
            }
        }
    }
   
}
