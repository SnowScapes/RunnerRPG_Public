using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Todo: rails는 map이 제작되고 나면 map에서 생성하고 가져오기
    [SerializeField] private List<GameObject> rails = new List<GameObject>();

    [SerializeField] private int railIndex;
    private Vector3 targetPosition;

    private void Start()
    {
        railIndex = rails.Count / 2; // 레일 - 홀수: 중앙, 짝수: 중앙에서 한 칸 오른쪽

        // 시작 지점 세팅
        targetPosition = rails[railIndex].transform.position;
        this.transform.position = targetPosition;
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void MovePosition(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();

        if (context.started)
        {
            if (input.x < -0.5f && railIndex > 0) // 왼
            {
                targetPosition = rails[--railIndex].transform.position;
            }
            else if(input.x > 0.5f && railIndex < rails.Count - 1) // 오
            {
                targetPosition = rails[++railIndex].transform.position;
            }
        }
    }

    public void Move()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, 0.2f);

        // Lerp 사용시 무한히 계산되므로 비슷한 지점에 도달 했을 시, 위치 고정
        if (Mathf.Abs(this.transform.position.x - targetPosition.x) < 0.05)
        {
            this.transform.position = targetPosition;
        }
    }
}
