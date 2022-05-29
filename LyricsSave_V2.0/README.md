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
