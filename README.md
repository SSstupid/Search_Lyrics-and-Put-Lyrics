# LyricsSave_V2.0
### Main function.
You can search and save the lyrics.         
Then you can put the lyrics in the mp3.

# Patch Notes
#### 1.Changing crawling.
 * Selenium => Https
 * Google   => ESTsoft

#### 2.UI changed.
 * MenuStrip : PutLyrics, SearchLyrics ==> Contact
 * Add some Controls(ComboBox, CheckBox...)
 * Change the position to look good.


### Update History
 1.Organized the source.  
 * Made the source simple.
 * Listview Event Integration Completed (Functionalization of Listview)
 * Additional exception processing completed.     
 
 2.Improve UI.
 * Recommend a search word when you choosing a song.

#### V1.0 Search and Put Screen (Selenum)
.<img src=https://user-images.githubusercontent.com/90036120/135824372-55e84976-fc75-4931-826d-f4ce77328f83.JPG width="470" height="370"/>.
 <img src=https://user-images.githubusercontent.com/90036120/135824374-8b7daf88-f357-4433-9b5c-3b1a3c73b319.JPG width="470" height="370"/>   
#### V1.5   
<img src=https://user-images.githubusercontent.com/90036120/135824388-1fb7fc1b-beff-4979-b034-6595b55f3c7a.jpg width="600" height="380"/> 

#### V2.0 (Https)
<img src=https://user-images.githubusercontent.com/90036120/135643439-648c2140-8a40-4778-991f-92cbb0a76aa6.JPG width="600" height="380"/> 
  
  ------------------------------------------------
  
# Img 
<img src=https://user-images.githubusercontent.com/90036120/135643430-62daece9-44d0-45f4-8adb-8d28d01c653d.JPG width="600" height="380"/>
    

### Patch Notes
 * 07/10/2021 (2021/10/07_Kor) fix : RemoveTime, PutLyrics-Button
 * 13/05/2022 (2021/10/07_Kor) fix : get lyrics from a file(Mp3)

--------------------------------
V1.0에서는 Selenum을 사용했습니다.(Selenum 테스트용)    
+ 속도는 나쁘진 않지만 체감상 Https보다 느립니다.  
+ (사용자가 1. 인터넷 열기 2. 가사 검색 3. 가사 복사 과정을 자동으로 하는것에 불과합니다.)        
가사를 못받거나, 다른 가사를 받아오는 경우도 있었습니다.   

이를 개선하기위해 알송에서 제공하는 가사 서비스를 활용했습니다.    
Https로 요청해서 가사를 받아오고 가사 목록이 콤보박스에 아이템으로 추가됩니다.   
(Selenum처럼 가사를 한개 받아오는데 반면에)    
추가된 여러 아이템을 확인하고 선택 할 수 있습니다.   
(속도 및 정확도 개선)    

---------------

WPF로 전환중입니다.   
Winform Vs WPF에 대한 말이 많지만    
혼자 개발하고 있는 저에게 와닿는 WPF장점은 'GUI를 만들때 Winform보다 간편하다' 입니다.   
조금 더 깔끔한 GUI를 만들고 (동일한 기능구현) 성능비교에 중점을 두겠습니다.   
<img src=https://user-images.githubusercontent.com/90036120/168419610-414e26d9-e756-44f9-ba55-3eca4965f889.png width="600" height="380"/>       
* 14/05/2022 초기 디자인 완료         
* 14/05/2022 ListView -dragdrop 구현완료.       
    현재 이미지컨버터 구현중 (파일앨범에 저장된 사진을 받을 예정, 이미지가 없을 시 윈도우 기본 이미지 사용 )
------------------
깃허브를 개인적으로 사용 중이라 그동안 공유 => 업로드, 다운로드 보다는 편의성의 이미를 두었습니다.    
여러 버전이 나오니 용량이 많이 늘어나서 다운로드시 시간이 많이 걸릴 수 있습니다.
V4.0이 완료되고나서 Readme와 저장소를 손 봐야겠습니다.
