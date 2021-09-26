# Search_Lyrics and Put_Lyrics V1.0

주요 기능  (★영문으로만 검색가능합니다. 다른 언어로 검색시 에러 발생.)
* 가사를 검색하고 저장할 수 있습니다.
* 가사를 음악(mp3)에 넣을 수 있습니다..

# 기능 1 => 가사 검색 및 저장
1. 텍스트창에 검색할 노래를 입력하고 Search 버튼을 클릭합니다.       
    * 자동으로 가사를 검색하고 오른쪽 텍스트 창에 출력됩니다.

<img src=https://user-images.githubusercontent.com/90036120/131990580-58979912-e462-49f8-a2cb-8bc7b1308758.png/>

2.경로를 설정하고 Save 버튼을 누르면 Txt파일이 생성됩니다.  
![Step2](https://user-images.githubusercontent.com/90036120/131992771-f22d16b3-ab1b-4c81-a9e8-34e87e573632.png)

# 기능 2 => 음악(mp3)에 가사 넣기  
1.왼쪽 위 Put_Lyrics를 클릭하세요.   
2.왼쪽창에 음악 파일을 오른쪽 창에 가사 파일을 드래그하여 올립니다.   
   * 오른쪽 아래 PutLyrics 버튼을 클릭하면 음악파일에 가사가 넣어집니다.  
      
![F2Step1](https://user-images.githubusercontent.com/90036120/132012576-23236a96-26c1-4358-8337-16af7aa93a26.png)


++ 드래그하여 파일순서를 바꿀 수 있습니다.   
   현재 한국어 변역을 자동으로 지원합니다. 옵션사항이 아닙니다.

# 추후 업데이트 예정                                                        
1.Listview에 mp3파일 업로드시 가사 자동검색 후 저장   
2.mp3파일과 가사 자동 매치후 가사 넣기            
  (현재 mp3와 가사파일 인덱스 값 순서로 가사가 들어갑니다.ex) 가사.ItemIndex[0] 넣기 => mp3.ItemIndex[0])                    
3.listview에서 Item 클릭 시 오픈     
4.예외처리 - 현재 많은 예외사항이 필요합니다.     

현재 Selenium을 통해 가사를 긁어 옵니다.(연습하기 위해서 사용 했습니다.)    
크롤링 속도, 예외처리, 크롬과 Cmd창이 뜨는 등 제가 생각하기에 불편한 것이 많아서 추후 크롤링 방식이 바뀔수도 있습니다.    
(현재 크롬창을 숨길려고 시도 했으나 에러가 떠서 실패했습니다.)    

하드코딩했습니다. 처음 생각한 프로그램과는 다른 것을 만들어졌네요.   
이것저것 기대하고 제작을 시작했는데 시간이 너무 오래 걸리더군요.    
그래서 간단한 토대부터 만들고 차근차근 업그레이드하는 방향으로 바꿧습니다.(슈퍼카를 만들려고 했는데 허름한 자동차를 만든 기분입니다 ㅎㅎ;;)   

            
---------------------------------------
---------------------------------------
---------------------------------------
         

# English

Functions
1. You can search and save the lyrics.
2. You can put the lyrics into the Song


# Function 1 => Lyrics Search and Save   
In the text box, type the song you want to search for and click the Search button.    
It automatically searches the lyrics and outputs them in the right-hand text box.     
![Step1](https://user-images.githubusercontent.com/90036120/131990580-58979912-e462-49f8-a2cb-8bc7b1308758.png)

Set the path and press the Save button to create a Txt file.  
![Step2](https://user-images.githubusercontent.com/90036120/131992771-f22d16b3-ab1b-4c81-a9e8-34e87e573632.png)

# Function 2 => Put lyrics into music(mp3)    
Click Put_Lyrics in the upper left corner.    
Drag the music file in the left box and upload the lyrics file in the right box.    
When you click the PutLyrics button in the lower right corner, the lyrics are put into the music file.      
![F2Step1](https://user-images.githubusercontent.com/90036120/132012576-23236a96-26c1-4358-8337-16af7aa93a26.png)

++ You can drag files to change the order of the files.   
   It automatically supports Korean translation. This is not an option now.   

# Will be updated later                                                                                          
1. Automatically search and save lyrics when uploading mp3 files to Listview        
2. Auto match lyrics with mp3 file (Lyrics are included in the order of current mp3 and lyrics file index values). ex) Lyrics.ItemIndex[0] Put => mp3.ItemIndex[0])   
3. Open when you click an item in listview                                    
4.Exception Processing - Many exceptions are currently required.                             

Currently, I scratch the lyrics through Selenium. (I used it to practice.)    
There are many inconveniences such as crawl speed, exception handling, chrome and Cmd windows, so the crawling method may be changed later.   
(The current attempt to hide the chrome window failed with an error.)   

I hard coded it. It's different from the program I first thought of.   
I started production with this and that in mind, but it took too long.    
So I'm going to start with a simple foundation and upgrade it step by step. (I was going to make a supercar, but I think I made a shabby car.)
