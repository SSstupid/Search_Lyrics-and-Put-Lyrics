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
 * 07/10/2021 (2021/10/07_Kor) fix to RemoveTime, PutLyrics-Button

--------------------------------
V1.0에서는 Selenum을 사용했습니다.
Selenum을 테스트하기 위해 사용했구요.
Selenum을 사용해 가사를 모아 올시 인터넷 창이 뜨는데 이게 좀 거슬리더군요.
인터넷 창을 가렸을 시 가사를 받아 오질 못 했구요(테스트 당시)
방법을 찾아보았지만 실패를 했습니다.
거기에 가사를 못받거나, 다른 가사를 받아오는 경우도 있었습니다.

이를 개선하기위해 알송에서 제공하는 가사 서비스를 활용했습니다.
Https로 요청해서 가사를 받아오는데
Selenum처럼 가사를 한개 받아오는 것이 아닌 
