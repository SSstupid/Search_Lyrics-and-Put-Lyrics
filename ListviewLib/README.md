# ListviewLib
drag and drop
 * Add items to the list and display icons.
 * Drag and move the item.
    
# Example
```
ListViewTool.ListViewFunction List = new ListViewTool.ListViewFunction();
  
List.ListViewSet(ListView);   //GetIconInfo, ListViewSet=> Detail....

private void listView_DragDrop(object sender, DragEventArgs e)
  {
    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
    List.GetFileInfo_Icon(files, ListView);     //ShowIcon
  }
  
private void listView_MouseUp(object sender, MouseEventArgs e) 
  {
    List.ListItemMove(listView, e);
  }

```

------------------------------------------------------------        
음.... 많이 부족한 느낌입니다.
Listview에 쓴 기능을 조금만 넣은거라... 이것만으로는 구동이 힘든 부분도 있거든요.       
List에 사용하는 기능들을 점차 추가해나가야 겠습니다.
