# 콘솔창에서 즐기는 TextRPG!
- 중세 판타지 세계를 배경으로 몬스터를 물리치며 당신의 캐릭터를 키워보세요!



# 프로젝트 개요
- 프로젝트명 : TextRPG Fantasy
- 개발 환경 : C#
- 개발 기간 : 25.02.06 ~ 25.02.13 (7일)
- 팀원 : 강진규, 김주연, 김영환, 박승규, 천지훈

Fantasy 풍의 TextRPG 로 콘솔창을 통해 진행되며, 플레이어의 선택에 따라
화면이 전환되고 행동하며, 던전 진행을 통해 성장해 나갈 수 있다.



# 플레이 방법
보통의 TextRPG와 동일한 진행 방식을 가지고 있습니다.
플레이어는 이름과 종족을 선택할 수 있고, 던전에 들어가기전 마을에서 정비를 할 수 있습니다.
던전에서는 몬스터와의 전투가 벌어지는데, 플레이어는 일반 공격과 스킬을 선택하여 공격을 할 수 있고 도망칠 수도 있습니다.
전투의 흐름은 플레이어의 턴 > 몬스터의 턴 식으로 진행되며, 양쪽의 죽음을 기반으로 결과창이 생성됩니다.
전투 승리시 플레이어는 약간의 보상을 얻을 수 있고, 일정 확률로 던전에서만 드랍되는 아이템을 얻을 수 있습니다.
플레이어는 던전을 통해 성장해 나가며, 던전의 스테이지마다 더 강력해진 적들을 상대할 수 있게 됩니다.



# 팀원 소개 
![image](https://github.com/user-attachments/assets/96742a2f-13f7-46b1-b7b6-12a71b960c3f)



# 와이어프레임
![와이어프레임](https://github.com/user-attachments/assets/d44f02bd-272c-4d41-b9d5-09c73d0f21be)



# 구현한 추가 기능
- 이름, 전직(종족) 선택 - 플레이어의 입력을 받아 이름과 전직을 선택하게 구현
- 치명타, 회피 - 일정한 확률로 치명타와 회피를 발동하게 된다.
- 인벤토리, 상점 - 마을에서 정비를 하거나, 상점에서 구매를 통해 아이템을 구매할 수 있다.
- 플레이어 레벨 업, 던전 스테이지 - 던전 클리어 시 던전의 스테이지와 플레이어의 경험치가 증가하고, 일정치 도달 시 레벨업 한다.
- 던전 클리어 보상 - 일정한 확률로 던전 드랍 아이템을 획득할 수 있다. 상점의 아이템과는 별개이다.
- 스킬 - 플레이어가 공격 선택을 할때 스킬이 추가 된다. 스킬을 사용하면 확정으로 타격되고 마나를 소모해서 더 강한 공격을 한다.



# 시연

https://nbcamp2024.slack.com/archives/D08D0589X1A/p1739411916595109



# 발생한 문제점 및 해결
- 씬 전환 시 기존 데이터 전달이 안됨
  - 전체적인 구조를 갈아 엎었다.
    GameManager 클래스를 따로 만들어 이 곳을 통해 씬 전환과 데이터를 관리해주었다.
- 같은 종류의 몬스터 동시 타격됨
  - 위의 데이터 전달문제가 해결되어 몬스터가 증발하는 오류가 수정되었다.
- 공격 화면 종료 후 몬스터 증발
  - 얕은복사에서 생긴 문제여서, 새로운 객체를 생성하여 그곳에 데이터를 복사해 사용하는 방법으로 해결했다.
- 죽은 몬스터 공격됨
  -적절한 위치에 반복문과 조건문을 사용하여 조건에 만족할때만 가능하게 수정해주었더니 해결됬다.
