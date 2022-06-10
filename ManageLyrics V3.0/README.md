WPF로 전환중입니다.   
Winform Vs WPF에 대한 말이 많지만    
혼자 개발하고 있는 저에게 와닿는 WPF장점은 'GUI를 만들때 Winform보다 간편하다' 입니다.   
조금 더 깔끔한 GUI를 만들고 (동일한 기능구현) 성능비교에 중점을 두겠습니다.     
      <img src=https://user-images.githubusercontent.com/90036120/168419610-414e26d9-e756-44f9-ba55-3eca4965f889.png width="600" height="380"/>       
* 14/05/2022 초기 디자인 완료         
* 14/05/2022 ListView -dragdrop 구현완료.          
    현재 이미지컨버터 구현중 (파일앨범에 저장된 사진을 받을 예정, 이미지가 없을 시 윈도우 기본 이미지 사용 )       
* 18/05/2022 ListView Template 추가 시 테마 Template와 충돌로 이미지 랜더링 실패 현상 발견       
        
  <img src=https://user-images.githubusercontent.com/90036120/168966070-c1afc4b0-f86b-4516-83fc-0f5b582bf5a8.png width="300" height="300">
  <img src=https://user-images.githubusercontent.com/90036120/168965992-4845293c-089b-40a4-ab9f-b3a63ef61798.png width="300" height="300">          
               Before                           After                
     
  => 현재 해결완료 참조 : [링크](https://forum.dotnetdev.kr/t/wpf-listview-template-template/3599)         
    
* 19/05/2022 ListView Template (디자인)변경 => 가수, 노래제목 표시, 앨범 이미지를 TagLib를 이용하여 바로 가져오는 것이 아닌
  Converter를 통해 String Path에서 이미지로 변환 후 받아옴, 앨범 이미지가 없을 시 윈도우 기본 아이콘을 가져옴.       
           
  <img src=https://user-images.githubusercontent.com/90036120/169240811-ba1d7080-e446-4be3-8f3a-0849b7892ebe.png width="600" height="300">     
        
        
* 20/05/2022 검색 및 파일 정보 가져오기' 구현 중, Item 선택 시 item의 Artist, Title, Lyrics 정보를 가져 옴, 현재 콤보박스, 검색 기능 테스트 중 입니다.   
* 21/05/22 콤보박스 바인딩 테스트 완료 --> 콤보 박스 아이템 추가 성공 , 검색 기능 테스트 중    
* 22/05/22 저장 버튼 클릭 시TextBox.Text를 파일에 저장, 콤보 박스 아이템 선택 시 가사를 가져옴, 정보를 입력 후 버튼 클릭시 검색(검색 기능)      
* 23/05/22 검색에 필요한 대부분의 기능 구현 완료 --> item 추가 및 삭제, 검색, 저장 등 구현 완료 ( 프로토 타입완성 )       
       버그 픽스 : ListView에 아이템 추가, 가사 검색 등 동작 시 Throw되는 현상 수정   
       ViewModel의 View 관련된 요소 일부 제거 --> ListView, ComboBox의 SelectedItem 바인딩으로 해결   
* 24/05/22 일부 (Throw)버그 수정, ListView 아이템 다중 삭제 기능 추가.       
       (Artist)(Title)TextBox 바인딩 변경 --> ComboBox 아이템 클릭시 Text(Artist, Title, Lyrics) 출력 됨,     
       저장 클릭 시 가사, 가수, 제목 같이 저장 됨.   
* 25/05/22 View의 일부 StackPaenel을 Grid로 변환 => 가사 출력 부 TextBox가 윈도우 크기에 따라 반응 함.       
       테마 버튼 구현 --> 버튼 클릭 시 Dark, Light 테마로 전환 됨.    

   <img src=https://user-images.githubusercontent.com/90036120/170242136-bf50e025-84a9-4b92-ae5e-a21eb282aea6.gif width="600" height="300">      

* 26/05/22 **테마 관련 업데이트**
  * 테마원본 유지,    
  * 테마 ViewModel 분리   
 이전엔 필요한 컨트롤 Style을 테마에서 x:Key을 설정하고 받아왔습니다.    
 현재 x:Key를 삭제(테마 원본 유지), 필요한 컨트롤 타입을 상속 받아 Style을 지정합니다. => [링크](https://forum.dotnetdev.kr/t/resource-style/3681/7)     
 테마 전환 기능은 View에 해당하는 것으로 기존 ViewModel에서 사용 할시 MVVM에 위반되는 것을 확인했습니다.     
 테마 관련된 .CS를 분리하고 IoC, Ninject를 활용하여 사용했습니다. => [링크](https://forum.dotnetdev.kr/t/wpf/3677/6)          
           
* 27/05/22 **MesaageBoxService 및 Contact 버튼 업데이트**     
  * Contact 버튼 =>Contact를 IoC와 MessageBoxSerivce.cs로 구현, Window로 바꿀예정     
  * 기존에 있는 MessageBox를 MessageBoxService로 구현 --> View 모델 요소 제거 중    
* 28/05/22 **Contact 변경 및 Help 버튼 구현**
  * Contact => MessageBox에서 interface를 이용하여 Window 창으로 변경 => 하이퍼링크 추가 됨
  * Help => 동작 영상을 실행 함. 사용 가이드 영상(영상을 보고 어떻게 사용하는지 알 수 있슴.) => [링크](https://forum.dotnetdev.kr/t/wpf-gif-15/3690)  
* 29/05/22 **코드 주석 및 포맷팅 진행**
  * 코드에 주석 추가, 코드 정렬 진행      
* 10/06/22 **버튼 툴팁 추가**   
  * 버튼에 해당하는 기능을 이해하기 쉽게 동작에 대한 텍스트를 추가 했습니다.
  
과제 : RelayCommand 이해, 코드 규칙에 맞게 수정, 메모리누수, 버그로 튕김, TimeStamp 옵션으로 넣기, ListViewViewModel 로직 분할 하기, IoC 이해, Core분리


------------------
깃허브를 개인적으로 사용 중이라 그동안 공유 => 업로드, 다운로드 보다는 편의성의 의미를 두었습니다.    
--> 여러 버전이 나오니 용량이 늘어나고 다운로드 시간 길어집니다.
V3.0이 완성하고나서 Readme와 저장소를 손 봐야겠습니다.
