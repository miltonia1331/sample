using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PVP : MonoBehaviour
{
    public DataBase dataBase;
    public Button spinButton; //������ ��ư   
    private Color32 Be_color, Af_color;
    Image img;
    ColorBlock cb;

    private void Start()
    {
        Be_color = new Color32(255, 255, 255, 170); ; //���� ����
        Af_color = new Color32(255, 255, 255, 255); ; //���� ����
        spinButton = GetComponent<Button>();
    }
    public void OnButtonClicked(Button clickedButton)
    {
        string buttonName = clickedButton.gameObject.name;
        switch (buttonName)
        {
            case "���� ����":
                countcheck(0, false);
                break;
            case "���� ����":
                countcheck(1, false);
                break;
            case "�ĵ� ����":
                countcheck(2, false);
                break;
            case "��������":
                countcheck(3, false);
                break;
            case "������":
                countcheck(4, false);
                break;
            case "�������":
                countcheck(5, false);
                break;
            case "���� ����":
                countcheck(6, false);
                break;
            case "����":
                countcheck(7, false);
                break;
            case "����":
                countcheck(8, false);
                break;
            case "Ȱ":
                countcheck(9, false);
                break;
            case "��ź �߻��":
                countcheck(10, false);
                break;
            case "�ڵ�ĳ��":
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
        if (dataBase.PVP_W_check[x] == 1) //���� ����
        {
            img.color = Be_color; //���� ����
            dataBase.PVP_W_check[x] = 0; //0: �̹��� ���� ����, 1: �̹��� ������
            dataBase.pvp_w[x].SetActive(false); //x �̹��� ����
        }
        else //����
        {
            img.color = Af_color;
            dataBase.PVP_W_check[x] = 1;
            if (y == false) //������ �ƴϰ� ������ ��
                dataBase.pvp_w[x].SetActive(true); //x �̹��� �ֱ�
        }
    }
    private void PlayerCheck(int x) //���� ������ �� ����
    {
        if (dataBase.Pick[0] == -1) //ù��° ����
        {
            dataBase.Pick[0] = x;
        }
        else if (dataBase.Pick[0] >= 0 && dataBase.Pick[0] != x && dataBase.Pick[1] != x) //�ι�° ����
        {
            dataBase.Pick[1] = x;
        }
        else if(dataBase.Pick[0] == x) //���� ��� �� �ʱ�ȭ
        {
            dataBase.Pick[0] = -1;
        }
        else if (dataBase.Pick[1] == x) //���� ��� �� �ʱ�ȭ
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

        //���۹�ư �� �ٲٱ�
        cb = spinButton.colors;
        cb.normalColor = UnityEngine.Color.red;
        cb.highlightedColor = UnityEngine.Color.red;
        cb.pressedColor = UnityEngine.Color.red;
        cb.selectedColor = UnityEngine.Color.red;
        spinButton.colors = cb;

        while (true)
        {
            if (i > 0.7f) //���� �ð� ���� ���߱�
                break;
            ran = Random.Range(0.01f, 0.05f); //���� �ð� ���ϱ�
            i = i + ran; //õõ�� ���ư���
            if (dataBase.before < 12) // ���� ���õ� �� ���� ����
            {
                countcheck(dataBase.before, true);
            }
            while(true)
            {
                random = Random.Range(0, 12); //���� ����
                if (dataBase.PVP_W_check[random] == 0 && dataBase.Pick[0] != random && dataBase.Pick[1] != random && dataBase.before != random)  //������ �ȵȰ͸� ���õ�
                {                    
                    if (i > 0.7f) // ����ٸ� ������
                        countcheck(random, false);
                    else
                        countcheck(random, true);
                    dataBase.before = random;
                    break;
                }
            }
            yield return new WaitForSeconds(0.005f + i); // ���
        }
        //���۹�ư �ٽ� �Ͼ��
        cb.normalColor = UnityEngine.Color.white;
        cb.highlightedColor = UnityEngine.Color.white;
        cb.pressedColor = UnityEngine.Color.white;
        cb.selectedColor = UnityEngine.Color.white;
        spinButton.colors = cb;
    }
}
