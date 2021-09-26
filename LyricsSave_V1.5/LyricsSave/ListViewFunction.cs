using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LyricsSave
{
    public class ListViewFunction
    {
        public void ListViewSet(ListView ListName)
        {
            #region istViewSet
            //prepare listview
            ListName.View = View.Details;
            //ListName.Columns.Add("File name", 300);
            // get the handle to the system image list
            NativeMethods.SHFILEINFO shfi = new NativeMethods.SHFILEINFO();


            IntPtr hSysImgLst = NativeMethods.SHGetFileInfo("",
                                                                0,
                                                                ref shfi,
                                                                (uint)Marshal.SizeOf(shfi),
                                                                NativeMethods.SHGFI_SYSICONINDEX |
                                                                NativeMethods.SHGFI_SMALLICON);
            // send a message to ListView with handle to system image list
            NativeMethods.SendMessage(ListName.Handle,
                                      NativeMethods.LVM_SETIMAGELIST,
                                      NativeMethods.LVSIL_SMALL,
                                      hSysImgLst);
            #endregion
        }

        public void GetFileInfo_Icon(string[] files, ListView ListName)
        {
            #region GetFileInfo
            foreach (string fileName in files)
            {
                NativeMethods.SHFILEINFO shfi = new NativeMethods.SHFILEINFO();
                NativeMethods.SHGetFileInfo(fileName,
                                            0,
                                            ref shfi,
                                            (uint)Marshal.SizeOf(shfi),
                                            NativeMethods.SHGFI_SHGFI_ICON |
                                            NativeMethods.SHGFI_SHGFI_OVERLAYINDEX);
                //destroy icon object
                NativeMethods.DestroyIcon(shfi.hIcon);
                // insert item in ListView with filename and icon index
                ListViewItem it = ListName.Items.Add(fileName, shfi.iIcon & 0xFFFF);
                if (it != null)
                {
                    //prepare the LVITEM parameter
                    NativeMethods.LVITEM lvi = new NativeMethods.LVITEM();
                    lvi.iItem = it.Index;
                    lvi.stateMask = NativeMethods.LVIS_OVERLAYMASK;
                    uint overlayIndex = (uint)(shfi.iIcon & 0x0F000000) >> 24;
                    lvi.state = NativeMethods.INDEXTOOVERLAYMASK(overlayIndex);
                    //send the LVM_SETITEMSTATE message to enable overlay
                    NativeMethods.SendMessage(ListName.Handle,
                              NativeMethods.LVM_SETITEMSTATE,
                              (uint)it.Index,
                              ref lvi);
                }
            }
            #endregion
        }
        
        public void ListItemMove(ListView Item, MouseEventArgs e)
        {
            #region ItemMove
            bool bSamePosition = false;
            int i = 0;
            Item.Cursor = Cursors.Arrow;
            ListViewItem selected = Item.GetItemAt(e.X, e.Y);
            if (null != selected)
            {
                foreach (ListViewItem l in Item.SelectedItems)
                {
                    if (l.Index == selected.Index)
                    {
                        bSamePosition = true;
                        break;
                    }
                }
                if (!bSamePosition)
                {
                    foreach (ListViewItem l in Item.SelectedItems)  //need to improve the sauce.
                    {
                        if (l.Index == 0 || selected.Index == Item.Items.Count - 1) i = 1;
                        l.Remove();
                        Item.Items.Insert(selected.Index + i, l);
                    }
                }
            }
            #endregion
        }
    }
}
