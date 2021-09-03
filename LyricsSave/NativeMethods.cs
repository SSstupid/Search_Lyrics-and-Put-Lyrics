using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace LyricsSave
{
    static class NativeMethods  //Listview icon 표시
    {
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
    }
}
