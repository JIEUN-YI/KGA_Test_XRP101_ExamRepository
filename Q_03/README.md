# 3번 문제

주어진 프로젝트 는 다음의 기능을 구현하고자 생성한 프로젝트이다.

### 1. Turret
- Trigger 범위 내로 플레이어가 들어왔을 때 1.5초에 한번씩 플레이어를 바라보면서 총알을 발사한다
- Trigger 범위 바깥으로 플레이어가 나가면 발사를 중지한다.
- 오브젝트 풀을 사용해 총알을 관리한다.

### 2. Bullet :
- 20만큼의 힘으로 전방을 향해 발사된다
- 발사 후 5초 경과 시 비활성화 처리된다
- 플레이어를 가격했을 경우 2의 데미지를 준다

### 3. Player
- 총알과 충돌했을 때, 데미지를 입는다
- 체력이 0 이하가 될 경우 효과음을 재생하며 비활성화된다.
- 플레이어의 이동은 씬 뷰를 사용해 이동하도록 한다.

위 기능들을 구현하고자 할 때
제시된 프로젝트에서 발생하는 `문제들을 모두 서술`하고 올바르게 동작하도록 `소스코드를 개선`하시오.

## 답안
1. Turret의 Trigger범위 내로 플레이어가 들어온 경우 플레어를 바라보고 총알 발사하는 것이 제대로 작동하지 않는 것을 확인하였습니다.
- 플레이어의 Trigger와의 상호작용이 제대로 발생하지 않는 것을 확인하였습니다
    + Collider의 발생을 위해서 Turret에 Rigidbody를 추가하고 중력을 사용하지 않도록 설정하여 플레이어와의 Trigger가 작동하도록 수정하였습니다.

2. 총알이 제대로 발사되지 않고, 특정 간격의 시간으로 발사되지 않는 것을 확인하였습니다.
- Rigidbody의 기능을 사용하여 총알이 발사되도록 구현되어있는데 Bullet프리팹에 Rigidbody가 없는 것을 확인하였습니다.
    + Rigidbody를 추가하고, 중력을 사용하지 않도록 설정하였습니다.
- 특정시간 간격으로 발사되는 것은 구현되어있으나, 일정 범위를 벗어나도 계속해서 총알이 발사되는 것을 확인하였습니다.
    + TurretController.cs에 OnTriggerExit를 구현하여 플레이어가 특정 범위를 벗어나는 경우 발사 코루틴이 멈추도록 수정하였습니다.

3. 총알과 플레이어가 충돌하는 경우 총알이 비활성화 되지 않고 남아있는 것을 확인하였습니다.
- 총알이 플레이어와의 충돌이 발생하여도 반환되는 함수가 실행되지 않았음을 확인하였습니다.
    + OnTirggerEnter에서 총알을 반환하도록 수정하였습니다.

4. 총알과 플레이어가 충돌하는 경우 플레이어의 체력이 감소하지 않는 것을 발견하였습니다. 
- 기존의 소스코드에서 충돌체(플레이어)가 가지고 있는 PlayerController의 TakeHit함수를 참조하려고 하였으나 NullRefernce가 발생하는 것을 확인하였습니다.
    + BulletController.cs에서 충돌을 확인하는 경우 충돌체의 PlayerController를 가져옴과 동시에 총알 반환되기때문에 NullRefernce가 발생하는 것으로 인지하였습니다.
    + PlayerController에서 충돌을 확인하고 TakeHit함수를 진행하는 방식으로 수정해보려고 하였으나, 실패하였습니다.
    + 자동적으로 충돌 발생 시 PlayerController를 참조하는 것에 실패하여 임의로 BulletController에 인스펙터 창에서 설정하는 방식으로 수정하였습니다.
    + 체력의 감소가 발생하는 것 같았으나, 인스펙터 창에서 확인이 되지 않고 체력이 0이 된 경우 Die()함수 출력으로 넘어가는 것을 디버그로 확인하였습니다.
- 체력의 감소가 발생하는 것은 맞으나 체력 변수가 원하는데로 실행되지 않는 것을 확인하였습니다.
    + 기존의 Hp를 전체 체력 Hp로 저장하여 현재 체력 curHp를 바꾸는 형식으로 수정하였습니다.
    + 그러나 curHp가 인스펙터창에서는 제대로 수정되어 장면이 실행되는 것이 확인 가능한데 디버그로 실행 중 확인하는 경우 이전의 데이터가 그대로 남아있고, curHp가 제대로 설정되지 않았음을 확인할 수 있었습니다.
        * 어떤 이유로 이러한 에러가 발생하는지 시간내로 확인할 수 없어서 수정에 실패하였습니다.

5. 플레이어의 Die()함수가 발생하는 경우 오디오가 실행되지 않는 것을 확인하였습니다.
- ArgumentNullException이 발생하였는데, 왜 발생하였는지 시간내로 확인하지 못하여 수정에 실패하였습니다.





    