   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ThemaClient.Thema  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   WindowStyleUser  �� 
TargetType �� Property �� Value �� EndPoint �� 
StartPoint � Color � Offset  BtnOrder �� 
TargetType ��Name	 �� CornerRadius
 �� Triggers P� Property P� Value  CmbBoxGeneral d�Name �� 	ClickMode d� 	IsChecked �� Path �� Mode �� RelativeSource ��Name �� 
TargetName ��Name �� 
IsReadOnly �� 
IsReadOnly �Name �� IsDropDownOpen � AllowsTransparency �Name J� SnapsToDevicePixels � ActualWidth �� MaxDropDownHeight K� IsItemsHost-   'System.Windows.Input.KeyboardNavigation     DirectionalNavigation! ��Name" J� IsHitTestVisible# �� SelectionBoxItem$ �� SelectionBoxItemTemplate% P� 
SourceName  UserListBox& �� Color' �� Padding'  !System.Windows.VisualStateManager(   VisualStateGroups%  System.Windows.VisualStateGroup)   States   System.Windows.VisualState*   
Storyboard+ �� 
TargetName, �� TargetProperty8  2System.Windows.Media.Animation.EasingColorKeyFrame- �� KeyTime. �� Value�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      $localclr-namespace:Client.Thema  5      %e  &	        &	 8    &	 Y    &	 }    '�� �    �� 5      "  �6$   .�5   
   ��  � �� 5      �� 5	      $ 0.5,0.7&�6&   $ 0.5,0&�69   .��5
      � $ 	Gainsboro��6#   $ 1Q�65   � 5      $ 	#FFDFEA02��6#   $ 0Q�65   5      5      �� 5   
    � ��$	 450��6&   �� 5   
    � ��$	 600��6%   5      �� 5      "  ��6   .�5   
   ��  � �� �	#FF7FAE036'   �� 5   
    � ��
 �����6'   �� 5   
    � ��$ Verdana)�6'   �� 5   
    � ��$ 14(�6%   �� 5   
    � �� 5      �� 5      " ��6"   .R�5      �� $ buttonBorder��6   $	 5��63   #��z��5      #��z��5      #��z��5       #��z��5!      #��z��5"      ._�5#      �� #��z��6)   #��z��5$      #��z��5%      #��z��5&      5'      
 5(      P� 5)       �@J�IsMouseOver . . �5*      ��  � �� �	#FF7FAE036;   �� 5+       � ��
 �����6;   �� 5,       � ��$
 Bold"�6;   5-      P� 5.       � {� .  . �5/      ��  � ��
 �����6;   �� 50       � �� �	#FF4040406;   51      53      55      56      �� 59      "  ��6"   .�5:   
   ��  � ��$	 180��6%   �� 5;   
    � ��$ 30��6&   �� 5<   
    � ��$ Verdana)�64   �� 5=   
    � �� �	#FF00000064   �� 5>   
    � �� �	#FFE2FFA26'   �� 5?   
    � �� �	#FF3F83076(   �� 5@   
    � ��$ 1q�6,   �� 5A   
    � �� 5B      �� 5C      " ��6"   .R�5D      � .+�5E      d� $ CmbBoxGeneral��6'   |�.  $ Press=�6�    6P   �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+��5F      �� 5G   "   " d�62   .R�5H   &   � .+�5I   *   �� $ CmbBoxGeneralFullContent��64   $��0��6V   $��3��6f   ���	#FFD9E2146z   �� 5J   *   ��6;   �� $ Content�5K   '   
 5L   &   P� 5M   *    �@J�IsMouseOver . . �5N   .   �� $ CmbBoxGeneralFullContent��65    � �� �	#FFEDF35C6q   5O   +   5Q   #   5S      �� 5T      $# textBoxComboBoxInspectorStyle��6"   #��z��6I   $
��Left=�6}   $��Center=�6�   |�. 
������ $y�Hidden=�6�   # z 6�   ��6l   Z� .��6  ��5U      �� 5V   "   " ��62   .R�5W   &   �� $) #borderTextBoxComboBoxInspectorStyle��6-   |�.  #��z��6l   
 5X   &   P� 5Y   *    �@J�IsMouseOver . . �5Z   .   �� $) #borderTextBoxComboBoxInspectorStyle��65    � ��
 �����6|   5[   +   5]   #   .��5_   0   5`      � 5a      $! popupComboBoxInspectorStyle��6    $��Bottom=�6E   #��z 6X    . |�.  $��Slide=�6�   .��5b      � $% gridPopupComboBoxInspectorStyle��6#    . #��z 6g   #��z 6�   .+�5c   "   �� $' !borderPopupComboBoxInspectorStyle��6)   ���	#FFCCE62B$��1q�6k   ���	#FF3F83076   �� 5d   "   $��36, 10, 10, 10q�6/    . .��5e   &   ��  . $  	Contained=�6D   5f   #   5g      5h      �� 5i      $,! &contentPresenterComboBoxInspectorStyle��6+   $��0��6[   #��z��6k   " .  #��z# 6�   #��z$ 6�   #��z��6  $��Center=�6R  $
��Left=�6m  5j      
 5k      P� 5l       �@��HasItems .  . �5m      �� $' !borderPopupComboBoxInspectorStyle��6%    � ��$ 95��6i   5n      P� 5o       � {� .  . �5p      ��  � ��
 �   �6;   5q      P� 5r       �@��
IsGrouping . . �5s      ��  � �� .  6N   5t      P� 5u      $!% popupComboBoxInspectorStyle��6"    �@�AllowsTransparency . . �5v      �� $' !borderPopupComboBoxInspectorStyle��6%    � ��$ 0,0,0,0q�6f   5w      P� 5x       �@��
IsEditable . . �5y      ��  � �� .  6:   �� 5z      $# textBoxComboBoxInspectorStyle��6%    � y�$ Visible=�6i   �� 5{      $, &contentPresenterComboBoxInspectorStyle��6%    � y�$ Hidden=�6o   5|      P� 5}       �@J�IsMouseOver . . �5~      ��  � ��
 �����6;   5      5�      5�      5�      �� 5�      "  ��6    .�5�   
   ��  �@J�SnapsToDevicePixels . 5�      �� 5�   
    �@�OverridesDefaultStyle . 5�      �� 5�   
    � ��$
 Auto=�5�      �� 5�   
    � ��$
 Auto=�5�      �� 5�   
    � �� . 5�      �� 5�   
    � ��$	 120��5�      �� 5�   
    � ��$ 95��5�      �� 5�   
    � �� 5�      �� 5�      " ��6"   .R�5�      �� $��Border��6   $��1q�5�      $	 2��5�      ��5�      �� 5�      $& 	#7FF5F5DC��6.   ��5�      �� 5�      $& 	#FF7FAE03��6.   ._�5�      �� $��0q�6'   |�.  .��5�      �� $��2q�6)    . 5�      5�      5�      
 5�      P� 5�       � {� .  . �5�      �� $ Border��6%    � �� 5�   "   �� 5�   &   $& Black��66   5�      �� 5�      $ Border��6%    � �� 5�   "   �� 5�   &   $& Black��66   5�      5�      P� 5�       �@��
IsGrouping . . �5�      ��  � �� .  5�      5�      5�      5�      5�      �� 5�      "  ��5�      .�5�   
   ��  �@J�SnapsToDevicePixels . 5�      �� 5�   
    �@�OverridesDefaultStyle . 5�      �� 5�   
    � �� 5�      �� 5�      " ��6"   .R�5�      �� $ Border��6   $' 2q�5�       . ��5�      �� 5�      $& Transparent��6.   ( 5�        5�      SelectionStates��.) 5�   "     
Unselected��6.     5�   "   Selected��.* 5�   &   �� .��5�   *   �� $+ Border��6G   $E, ?(Panel.Background).                     (SolidColorBrush.Color)�5�   1   .g�5�   .     $- 0��6B   $. Beige��5�   *   5�   +   5�   '   5�   #     5�   "   SelectedUnfocused��.* 5�   &   �� .��5�   *   �� $+ Border��6G   $E, ?(Panel.Background).                     (SolidColorBrush.Color)�5�   1   .g�5�   .     $- 0��6B   $. Beige��5�   *   5�   +   5�   '   5�   #   5�      ._�5�      �� 5�      5�      5�      5�      5�      