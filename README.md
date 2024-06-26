# 프로젝트 이름
**RUNNER RPG**

## 📖 목차
1. [프로젝트 소개](#프로젝트-소개)
2. [개발기간](#개발기간)
3. [와이어프레임](#와이어프레임)
4. [프로젝트 수행절차](#프로젝트-수행절차)
5. [주요기능](#주요기능)
6. [Trouble Shooting](#trouble-shooting)

## 👨‍🏫 프로젝트 소개
1. 단순하지만 게이머들이 오랫동안 즐길 수 있는 캐쥬얼 싱글 플레이 게임
2. 순간적인 판단력을 요구하는 약간의 전략적인 요소가 가미

## ⏲️ 개발기간
- 2024.06.19(수) ~ 2024.06.25(화)

## 와이어프레임
- 초기 구상 로직</br>
[기초 화면 및 로직 구상]![게임로직](https://github.com/SnowScapes/RunnerRPG/assets/167234182/94921cb7-e58d-4012-a33d-eb32362fa058)</br>
![UML](https://github.com/SnowScapes/RunnerRPG/assets/167234182/eec22cc8-c972-4ae0-930e-3b86e9418ced)

## 프로젝트 수행절차
|구분|기간|활동|
|:---|:---|:---|
사전기획|6/19|프로젝트 기획 및 UML설계
기본구현|6/20|플레이어 이동 및 테스트 스테이지 구현
기능구현|6/20 ~ 6/24|몬스터, 애니메이션, 버프시스템, 사운드, UI, 시스템 전반 구현 및 병합
QA|6/24 ~ 6/25|정상 작동 테스트 및 버그 수정

## 🕹주요기능

1.화면구성 및 UI
  - 인트로씬
    ![인트로](https://github.com/SnowScapes/RunnerRPG/assets/167234182/6783fc74-3e3d-4028-9bcf-4d0283e83dc8) </br>
    
  - 인게임 UI
    ![인게임](https://github.com/SnowScapes/RunnerRPG/assets/167234182/c1218a8b-ff95-4133-9888-f55787e97a2d) </br>
    
  - 오디오 설정
    ![오디오설정](https://github.com/SnowScapes/RunnerRPG/assets/167234182/9cfc09b6-acc9-467c-aafb-deb7de644721) </br>
    
  - 튜토리얼
    ![튜토리얼](https://github.com/SnowScapes/RunnerRPG/assets/167234182/6c2dc37a-1017-40f3-ad5d-ff4be3150899) </br>
    
  - 최고점수
    ![최고점수저장](https://github.com/SnowScapes/RunnerRPG/assets/167234182/c3a0faf5-b883-4596-b2ac-2ef6f9e40261) </br>
    
  - 스테이지 게이지 / 점수
    ![리드미 게이지 UI](https://github.com/SnowScapes/RunnerRPG/assets/167234182/6ad33af5-e010-4169-b304-b629cd81c522) </br>
    ![리드미 점수](https://github.com/SnowScapes/RunnerRPG/assets/167234182/4ea186a0-efb1-4afb-81d1-9de51122bd3b) </br>

2.스테이지
  - Forest
    ![리드미 포레스트](https://github.com/SnowScapes/RunnerRPG/assets/167234182/a0fb608a-beec-4020-973a-b6ec13a754c5) </br>

  - Desert
    ![리드미 사막](https://github.com/SnowScapes/RunnerRPG/assets/167234182/4c09051d-c8f3-44b9-9396-7b7a0f3a34b0) </br>
  
  - Wild
    ![고원](https://github.com/SnowScapes/RunnerRPG/assets/167234182/760d201d-7921-4290-9438-af1411aab3ff) </br>

3.플레이어 & 몬스터    
  - 플레이어
    ![이동 와리가리](https://github.com/SnowScapes/RunnerRPG/assets/167234182/2132822b-077a-4082-a05d-2416742254a3) </br>

  - 몬스터 종류
    ![몬스터 종류](https://github.com/SnowScapes/RunnerRPG/assets/167234182/7b79bd01-6bd8-4bd1-9e80-81c984e6e063) </br>

  - 몬스터 다수 출현

    ![3마리](https://github.com/SnowScapes/RunnerRPG/assets/167234182/201c95d8-707a-4ea3-8dab-5002cd0eaabc) </br>    

  - 보스 몬스터

    ![보스](https://github.com/SnowScapes/RunnerRPG/assets/167234182/fb0b99dd-9860-402a-86ed-96064cd91b7f) </br>

4.버프 시스템

  -버프 종류
    ![버프 종류](https://github.com/SnowScapes/RunnerRPG/assets/167234182/a6d7d0e1-a58e-4190-a42c-2fae7a993826) </br>

  -버프 UI
    ![버프UI](https://github.com/SnowScapes/RunnerRPG/assets/167234182/9522bb3c-843d-4122-a906-63b78499452c) </br>

## 🛠Trouble Shooting
1. 무한 맵 타일 생성
 </br>🐛문제발생
  </br>-무한 맵 타일 생성시 오브젝트 풀에 반환이 제대로 되지 않는 문제
 </br>💡해결
  </br>-List 형식으로 관리하는 방법을 맵 타일의 종류에 따라 Dictionary<int,Queue<GameObject>>로 관리하여 해결

![리드미 맵타일생성](https://github.com/SnowScapes/RunnerRPG/assets/167234182/8491f777-c639-46b2-a57e-4dace5d6aa9a) </br>
  
 2. 플레이어 이동
  </br>🐛문제발생
   </br>-캐릭터 이동시 반대키를 누르면 조금씩 위치가 틀어지는 문제
  </br>💡해결
   </br>-Velocity 대신 Position으로 대체. 추가로 빈 객체를 설치하고 해당 위치로 플레이어의 포지션 값이 변경되도록 수정하여 원하는 이동이 가능하게 됨

![이동 와리가리](https://github.com/SnowScapes/RunnerRPG/assets/167234182/5a0faab5-4bc2-4ab4-b108-1e2619b56c6e) </br>

 3. 몬스터 애니메이션
  </br>🐛문제발생
   </br>-몬스터 사망 직후 StateMachineBehavior를 활용하여 풀에 반환시키는 도중 사망 애니메이션이 처음으로 돌아가는 등 의도하지 않은 현상이 발생
  </br>💡해결
   </br>-사망 애니메이션의 마지막 프레임을 복사하여 새로운 애니메이션으로 만들어주고 State를 추가하는 것으로 해결

![몬스터애니메이션 트러블슈팅](https://github.com/SnowScapes/RunnerRPG/assets/167234182/019ba904-5b6c-4b4d-a910-867135930316) </br>

 4. 오디오
  </br>🐛문제발생
   </br>-서로 다른 씬에 동일한 음량을 설정하고자 했지만 슬라이더 오브젝트가 삭제되어 불가능한 문제
  </br>💡해결
   </br>-오디오 믹서로 게임전체를 관리하는 사운드를 조절하고, 각 씬마다 존재하는 슬라이더들을 믹서에 연결하여 모든 씬의 음량을 통일시킴
   
![오디오 믹서](https://github.com/SnowScapes/RunnerRPG/assets/167234182/3cbdb351-c031-45e4-bbac-ce158cca0b2c)
