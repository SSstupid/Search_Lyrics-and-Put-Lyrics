   M S B A M L   `   `   `  ����G  CManageLyrics, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ManageLyricsManageLyrics  5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source �� 
TargetType   
DarkButton �� BasedOn  DarkListViewItem �� Property �� Value �� 
TargetType ��Name �� Padding	 J� SnapsToDevicePixels
 � RowDefinitions � ColumnDefinitions j� Stretch �� ImageSource#    ManageLyrics.ItemImageConvert    Instance �� 	Converter �� Orientation �� Triggers ]� 
Conditions �� Property �� Value �� 
TargetName  ControlMouseOverBackground  ControlMouseOverBorderBrush  ControlDefaultBackground  ControlDefaultBorderBrush  ControlSelectedBackground  ControlSelectedBorderBrush P� Property P� Value  ControlDisabledGlythColour 	 
ButtonIcon 
 FontSizeRegular  FontAwesome�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      $localclr-namespace:ManageLyrics  5        5      �� 5   
   $ Colors.xaml?�6   �� 5	   
   $ 
Fonts.xaml?�6   %�  '��       7   '�� "     7  7  7  7  7  7  7  7  &		 �    7   7 
 7  �� 5      " ��6   8   6)   �� 5      " ��6   8   .�5   
   ��  � �� 5      �� 5      " ��6"   .R�5      �� $ Bd��6   $ 2q�5      #��z��5      #��z��5      #��z��5      $
	 true��5      ._�5      �� .+�5      � 
 5   "   �� 5   &   $
��Auto �64   �� 5   &   $
��Auto �64    5   "   �� 5   &   $
��Auto �67   �� 5    &   $��* �67   .+�5"   "   �� $��0��6-   $��2��6:   $��3q�6K   .+�5#   &   � $��50��6+   $��50��66   ��5$   *   �� 5&   .   $
 Fill=�69    6H   �� *Path+# Z 5(   '   5)   #   �� 5+   "   $��0��6,   $��1��5,   ,   $��Center=�5-   ,   $��15(�5.   F   
����ح���6,   �� *
FileName+6T   �� 50   "   $��1��6-   $��1��51   ,   $��Center=�6<   $ 
Horizontal=�6W   .+�53   &   �� $��2, 0, 10 ,0q�6H   ��60   �� *Artist+6H   �� 54   &   ��60   �� *Title+55   #   57      58      59       5;      ]� 5<       5=      �� 5>   "    �@J�IsMouseOver$
 True��6C   ./�5@      �� $ Bd��6%   8   � ��6K   �� 5A      $ Bd��6%   8   � ��6L   5B      ]� 5C       5D      �� 5E   "    �@��IsSelectionActive$ False��6R   �� 5F   "    �@��
IsSelected$
 True��6B   ./�5H      �� $ Bd��6%   8   � ��6K   �� 5I      $ Bd��6%   8   � ��6L   5J      ]� 5K       5L      �� 5M   "    �@��IsSelectionActive$
 True��6R   �� 5N   "    �@��
IsSelected$
 True��6B   ./�5P      �� $ Bd��6%   8   � ��6K   �� 5Q      $ Bd��6%   8   � ��6L   5R      P� 5S       � {�$ False��67   . �5T      �� $ Bd��6%   8   � ��6W   5U      5W      5Y      5Z      �� 5\      " ��6   8   .�5]   
   ��  � ��8  6%   �� 5^   
    � ��8  6'   �� 5_   
    � ��$ 40��6#   �� 5`   
    � ��$ 80��6"   5a      5c      