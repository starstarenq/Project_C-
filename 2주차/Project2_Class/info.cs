﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Class
{

    /*
     * 지난주 복습, 변수 - 함수
     * 변수 : 컴퓨터에게 어떠한 타입으로 데이터를 저장할지 기억하게 하는 방법. Int, float, string, char, + 이름
     * 함수 : 반복적으로 사용되는 코드 뭉치를 하나의 이름으로 사용할 수 있도록 하는 방법
     * Plus(int a , int b)
     * 처음부터 다시 만들까? 이미 있는 내용에서 추가. 코드 뭉치 만들었다 가정.
     * 4곳. 5줄짜리 코드를 복사 붙여넣기로 구현을 했습니다. 5번 연속으로 수정을 해야 합니다.
     * 5개 중복된 코드를 하나의 코드로 만드는 것. 반복을 어떻게 없앨 것인가?
     * 
     */



    /*
     * 클래스는 무엇인가? 변수와 변수를 사용하는 함수로 묶여진 데이터.
     * 
     * 클래스 문법
     * (1) 멤버 변수, 멤버 함수 (메소드 method) 이루어져 있다. - 변수와 함수를 선언해야 한다.
     *
     * (2) 멤버 변수를 선언을 할 때 (접근 지정자) + (변수 타입) + (변수 이름)
     * 
     * 접근 지정자 무엇인가? 어떻게 접근을 할 수 있는가?
     * - 공유 가능 public
     * - 외부에 사용하지 마세요 private
     * - 외부로 사용을 보호, 자식은 허용 protected
     * 
     * (3) 문법이 어렵다? 접근 지정자를 전부다 public 선언을 해도 코드는 작성 가능.
     * 
     * (4) 코드를 작성 권장사항에서는 최대한 public을 사용하지 마세요. 스파게티 코드.
     * 
     * (5) 생성자. 변수. 데이터를 저장하는 비어있는 공간.
     * -클래스의 이름과 똑같은 이름으로 함수를 만들어준다.
     */


    // 정보를 추상적으로 표현한 데이터다. => class 이름, (변수,함수) 스코프 연산자 { }

    /*
     * 아무 클래스를 직접 만들어 봅니다.
     * AI의 힘을 빌리지 않고만듭니다.
     * 
     * (1) Coin 클래스. 코인 증가하는 양, 코인의 크기 사이즈, 코인 색깔 (string) 변수와 함수
     * (2) Item 클래스. 이름, 가격, 아이템 타입
     * (3) Player 클래스. 이동속도, 점프 크기...... -> 함수
     * 
     * {1} Enemy 클래스. 체력, 이름, 공격력, 기술
     * 
     */

     class info
    {

        // 멤버 변수
        public string name;
        public int publishDay;

        public info(string name, int publishDay)
        {
            this.name = name;
            this.publishDay = publishDay;
        }

        // 멤버 함수


        public void SetName(string _name)
        {


            name = _name;

        }



    }



}
