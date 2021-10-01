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

    static class NativeMethods  //Listview icon 표시
    {
        #region NativeMethods
        public const uint LVM_GETIMAGELIST = 0x1000 + 2;
        public const uint LVM_SETIMAGELIST = 0x1000 + 3;
        public const uint LVM_SETITEMSTATE = 0x1000 + 43;
        public const uint LVIS_OVERLAYMASK = 0x0F00;
        public const uint LVSIL_SMALL = 1;
        public const uint SHGFI_ICON = 0x100;
        public const uint SHGFI_SMALLICON = 0x1;
        public const uint SHGFI_SHGFI_ICON = 0x100;
        public const uint SHGFI_SYSICONINDEX = 0x4000;
        public const uint SHGFI_SHGFI_OVERLAYINDEX = 0x40;
        [DllImport("user32")]
        public static extern IntPtr SendMessage(IntPtr hWnd,
                                                uint msg,
                                                uint wParam,
                                                IntPtr lParam);
        [StructLayout(LayoutKind.Sequential)]
        public struct LVITEM
        {
            public uint mask;
            public int iItem;
            public int iSubItem;
            public uint state;
            public uint stateMask;
            public string pszText;
            public int cchTextMax;
            public int iImage;
            public int lParam;
            public int iIndent;
            public int iGroupId;
            public uint cColumns;
            public uint puColumns;
        }
        [DllImport("user32")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, ref LVITEM lvi);
        [DllImport("User32.dll")]
        public static extern int DestroyIcon(IntPtr hIcon);
        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)] public string szTypeName;
        }
        [DllImport("shell32")]
        public static extern IntPtr SHGetFileInfo(string pszPath,
                                                  uint dwFileAttributes,
                                                  ref SHFILEINFO psfi,
                                                  uint cbSizeFileInfo,
                                                  uint uFlags);
        public static uint INDEXTOOVERLAYMASK(uint i)
        {
            return i << 8;
        }
        #endregion
    }
}