using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PVE : MonoBehaviour
{    
    public RectTransform rouletteImage; //�귿 �̹����� ���� RectTransform (UI���� ���� ����)
    public Button spinButton; //������ ��ư    
    private bool isSpinning = false; //���� �귿�� ���� �ִ��� ���� üũ��

    void Start()
    {
        //��ư�� StartSpin �Լ��� Ŭ�� �̺�Ʈ�� ����
        spinButton.onClick.AddListener(StartSpin);
    }
    public void Update()
    {
        if (isSpinning)
        {
            ColorBlock cb = spinButton.colors;
            cb.normalColor = Color.yellow;
            cb.highlightedColor = Color.yellow;
            cb.pressedColor = Color.yellow;
            cb.selectedColor = Color.yellow;
            spinButton.colors = cb;
        }
        else
        {
            ColorBlock cb = spinButton.colors;
            cb.normalColor = Color.white;
            cb.highlightedColor = Color.white;
            cb.pressedColor = Color.white;
            cb.selectedColor = Color.white;
            spinButton.colors = cb;
        }
    }
    void StartSpin() //��ư�� ������ �� ����� �Լ�
    {
        isSpinning = false; // ���� ����
        if (!isSpinning) //���� ���� ���� ���� �ʴٸ� �ڷ�ƾ ����
            StartCoroutine(SpinRoulette());
    }

    IEnumerator SpinRoulette() //�귿 ������
    {
        isSpinning = true; // ���� �ִٰ� ǥ��

        float speed = Random.Range(700f, 1200f); // �ʱ� ȸ�� �ӵ� (deg/sec)
        float deceleration = Random.Range(50f, 250f);  // �ʴ� ���ӷ�
        float currentSpeed = speed; // ���� �ӵ� ����

        
        // �ӵ��� 0�� �� ������ �ݺ�
        while (currentSpeed > 0)
        {
            // Z���� �������� �ð� �ݴ����(-)���� ȸ��
            rouletteImage.Rotate(0f, 0f, -currentSpeed * Time.deltaTime);

            // �ӵ��� ���ݾ� ����
            deceleration = Random.Range(80f, 220f);
            currentSpeed -= deceleration * Time.deltaTime;

            // ���� �����ӱ��� ���
            yield return null;
        }
        float finalAngle = rouletteImage.eulerAngles.z % 360f; // ���� �� ������ 0~360 ������ ���� (���Ŀ�)
        isSpinning = false; // ���� ����
    }
}