# CheckOut-Run

## 📖 목차
1. [프로젝트 소개](#프로젝트-소개)
2. [팀소개](#팀소개)
3. [프로젝트 계기](#프로젝트-계기)
4. [주요기능](#주요기능)
5. [개발기간](#개발기간)
6. [기술스택](#기술스택)
7. [서비스 구조](#서비스-구조)
8. [와이어프레임](#와이어프레임)
    
## 👨‍🏫 프로젝트 소개
21시를 향해 달리자!
CheckOut-Run 퇴실런은 스파르타 부트캠프의 출석처리를 받기 위해 퇴실을 찍어야하는 모든 사람들의 고군분투를 담은 런 게임입니다.

## 팀소개
팀장 정순원 - UI 시스템, 사운드 시스템 구현
팀원 송제우 - 그래픽 리소스, 장애물 시스템, 엔딩 구현, 레벨 디자인
배경의 오브젝트들을 자동으로 배치하는 로직(InstancePrefabs.cs)
플레이어가 벽에 꼈을 때 빠져나오는 로직(PlayerMoveCheck.cs)
플레이어를 엔딩을 출력하는 공간으로 보내는 로직(ThrowPlayer.cs)
스케일이 서로 다른 발판들의 BoxCollider을 맞추는 로직(Platform_BoxCollider.cs)
플레이어와 장애물들의 다양한 애니메이션

팀원 김재민 - 버튼 시스템, UI 시스템, 레벨 디자인, 튜토리얼 구현
플레이어가 추락했을 때 추락판정 (FallCheck.cs)
각 버튼을 눌렀을 때 함수 실행 (ButtonHandler.cs)
플레이어 위치에 따라 시간이 출력되는 로직 (TimeManager.cs, GameUI.cs)
로딩씬 UI 코루틴 (LoadingUI.cs)
일시정지 눌렀을 때 계속하기/나가기 실행(PauseUI.cs)
게임설명 활성화됐을 때 UI 실행 로직 (DescriptionUI.cs)
게임설명 Canvas 안 내용들

팀원 박성주 - 전체 아이템 시스템, 데이터 관리 시스템 구현, 레벨 디자인
팀원 진희원 - 플레이어 시스템, 카메라 시스템, 각종 아이템 구현


## 프로젝트 계기
본 프로젝트는 스파르타 내일배움캠프의 Unity 입문 과정에서 진행된 프로젝트입니다.


## 💜 주요기능

- 점프와 슬라이드

- 각종 아이템

- 사운드 조절 기능

- 튜토리얼

- 엔딩


## ⏲️ 개발기간
- 2024.02.21(금) ~ 2024.02.28(금)

## 📚️ 기술스택

### ✔️ Language
C#

### ✔️ Version Control
Githup Desktop

### ✔️ IDE
Visual Studio

### ✔️ Framework
Unity Engine

### ✔️ Deploy
Windows, Android, WebGL

### ✔️  DBMS
PlayerPrefs

## 서비스 구조
클라이언트(Unity)
게임 실행 및 플레이어 입력 처리
UI 및 애니메이션 렌더링
데이터 저장 및 로드 (PlayerPrefs, JSON 등 활용)


## 와이어프레임
![image](https://github.com/user-attachments/assets/5fc52d6f-1831-4bbe-9dfa-2d3623fab6a6)
