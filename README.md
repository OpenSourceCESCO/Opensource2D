# Opensource2D

## 규칙
회의 후 추가할 예정

### commit 관련

* 커밋 메시지 기호 통일   
사용하지 않아도 무방하나, 사용시에는 아래의 규칙을 따를 것
```
추가 : +
삭제 : -
수정 : ^
```

* 이벤트 스크립트 관련
```
1. 가능하면 하나의 씬에서 SceneScriptManager Component를 생성하여 처리할 것
2. 데이터의 저장이 필요한 경우, 해당 데이터 타입을 담을 수 있는 클래스를 생성하여 Singletone 클래스 내부에 객체로 만들 것
```
> 싱글톤 사용 예제
```c#
// 싱글톤 클래스
// 프로그램 실행 중 단 하나만 
using UnityEngine;
using System.IO;

public class Singletone {

    private static Singletone instance;
    public SaveData saveData = new SaveData();
    public static Singletone Instance {
        get {
            if (instance == null) instance = new Singletone();
            return instance;
        }
    }
}
```
```c#
// 저장용 데이터를 선언한 클래스
using System;
using UnityEngine;

[Serializable] // 직렬화
public class SaveData {
    public float leftTime;
    public Vector2 playerPos;
    public string playerName;
    public string gender;
    public float initTime;
}
```

* * *
## 참고 문헌
* [Markdown 사용법](https://gist.github.com/ihoneymon/652be052a0727ad59601)
* [타이머 기능](https://youtu.be/9wAOJC6j1R4)
* [텔레포트 기능](https://youtu.be/9JvZwMmEydQ)
* [유니티 merge conflict 발생 시 시도해봄직함](https://cookiehcl.tistory.com/1)
    - .gitignore에 특정 문구 추가
    - .gitattributes 생성 후 특정 문구 추가
* [컨플릭트 났는데요? - 강제 pull](https://mosei.tistory.com/m/entry/GIT-git-pull-%EC%8B%9C-merge-%EC%98%A4%EB%A5%98%EA%B0%80-%EB%82%A0%EB%95%8C-%EA%B0%95%EC%A0%9C-git-pull-%EB%8D%AE%EC%96%B4%EC%93%B0%EA%B8%B0-%EB%B0%A9%EB%B2%95)
* [bolt 사용법](https://young-94.tistory.com/m/55)
* [unity 빌드 실패시 해결방법](https://citynetc.tistory.com/231)
* [GameObject는 비활성화된 object를 못찾는다](https://prosto.tistory.com/147)