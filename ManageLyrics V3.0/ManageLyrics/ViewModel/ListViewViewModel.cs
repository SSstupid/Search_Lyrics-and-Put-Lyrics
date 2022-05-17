using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace ManageLyrics
{
    public class ListViewViewModel : BaseViewModel
    {
          List<ListModel> _songList = new List<ListModel>();
        public List<ListModel> GetInfo
        {
            get { return _songList; }
            set { _songList = value; }
        }

        public void ListDragEnter(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Copy;
        }

        public void ListDrag(object sender, DragEventArgs e)
        {
            var AddItem = sender as ListView;
            string[] abc = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string fileName in abc)
            {
                _songList.Add(new ListModel() { files = fileName });
            }
            AddItem.ItemsSource = _songList;
            AddItem.Items.Refresh();
        }
    }
}
