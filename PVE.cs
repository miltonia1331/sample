using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PVE : MonoBehaviour
{    
    public RectTransform rouletteImage; //룰렛 이미지를 담을 RectTransform (UI에서 돌릴 원판)
    public Button spinButton; //돌리기 버튼    
    private bool isSpinning = false; //현재 룰렛이 돌고 있는지 여부 체크용

    void Start()
    {
        //버튼에 StartSpin 함수를 클릭 이벤트로 연결
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
    void StartSpin() //버튼을 눌렀을 때 실행될 함수
    {
        isSpinning = false; // 돌기 종료
        if (!isSpinning) //만약 현재 돌고 있지 않다면 코루틴 실행
            StartCoroutine(SpinRoulette());
    }

    IEnumerator SpinRoulette() //룰렛 돌리기
    {
        isSpinning = true; // 돌고 있다고 표시

        float speed = Random.Range(700f, 1200f); // 초기 회전 속도 (deg/sec)
        float deceleration = Random.Range(50f, 250f);  // 초당 감속량
        float currentSpeed = speed; // 현재 속도 변수

        
        // 속도가 0이 될 때까지 반복
        while (currentSpeed > 0)
        {
            // Z축을 기준으로 시계 반대방향(-)으로 회전
            rouletteImage.Rotate(0f, 0f, -currentSpeed * Time.deltaTime);

            // 속도를 조금씩 줄임
            deceleration = Random.Range(80f, 220f);
            currentSpeed -= deceleration * Time.deltaTime;

            // 다음 프레임까지 대기
            yield return null;
        }
        float finalAngle = rouletteImage.eulerAngles.z % 360f; // 멈출 때 각도를 0~360 범위로 맞춤 (정렬용)
        isSpinning = false; // 돌기 종료
    }
}