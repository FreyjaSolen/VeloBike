   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Client.ViewClient.View  5   	       Client.View.Registration   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Client.View     5   	   -   5          � Title$  Регистрация��5   	   $	��530��6   $	��350��6*      WindowStyleLogIn#��[  66    � Icon$' !/Client;component/Images/icon.ico��6`   .��5	      � .+�5
   
   �  � RowDefinitions 5      �� 5      $��0.07* �6    �� 5      $��0.08* �6    �� 5      $��* �6    .+�5      ]� $��0��6   .+�5      o� $	��130��6   $��25��6&   $	��Top=�66     MenuStyleMain#��[ 6N   .@�5      m� $��
Easy Bikes��6   .@�5      m� $/��)Войти в учётную запись��6#     MenuItemStyleMain#��[ 6b    m� Command 6C   �� *
LogCommand+6b   m� 5      $*��$Выход из приложения��6#   #��[ 6`    6@   �� *ExitCommand+6`   5      5      5      �� 5      $��1��6   $$��Заполните форму:��6%   $
��Wrap=�6=   $��Center=�6Q   $��24(�6n   $��0,0,10,0q�6|     TxtBlGen#��[ 6�   �� 5      $��2��6    �� Orientation$ Vertical=�6&   $��Center=�6=   .+�5      �  � ColumnDefinitions 5      �� 5      $
��226* �6+   �� 5      $
��143* �6+   �� 5       $	��45* �6+   .+�5"      �� $��0��6    $M��GВведите свой логин: (обязательное поле)��60   $
��Wrap=�6_   $
��Left=�6s   $��14(�6�   $��0,5,0,0q�6�   #��[ 6�   �� 5#      $��1��6   $��
0,15,15,15q�6H   $	��140��6\   $��Right=�6h   $��2��6�   ��6.   �� *
NickName+6�   5$      � 5%       5&      �� 5'      �� 5(      .+�5*      �� $��0��6    $%��Введите своё имя:��60   $
��Wrap=�6I   $
��Left=�6]   $��14(�6x   $��0,15,0,0q�6�   #��[ 6�   �� 5+      $��1��6   $��15q�6D   $	��140��6P   $��Right=�6\   ��6.   �� *Name+6\   5,      � 5-       5.      �� 5/      �� 50      .+�52      �� $��0��6    $-��'Введите свою фамилию:��60   $
��Wrap=�6M   $
��Left=�6a   $��14(�6|   $��0,15,0,0q�6�   #���  6�   �� 53      $��1��6   $��15q�6H   $	��140��6T   $��Right=�6`   ��6.   �� *
LastName+6`   54      � 55       56      �� 57      �� 58      .+�5:      �� $��0��6    $O��IВведите свой пароль: (обязательное поле)��60   $
��Wrap=�6`   $
��Left=�6t   $��14(�6�   $��0,15,0,0q�6�     TextBlockGeneral#���  6�   �� 5;      $��1��6   $��15q�6D   $	��140��6P   $��Right=�6\   ��6.   �� *Pass+6\   5<      �� 5>      $��Регистрация��6   $��0,40,0,0q�6Q     BtnLogIn#��[ 6c     
BtnGenTemp#��[ 6�   ��6/   �� *RegistCommand+6�   �� 5?      $(��"/Client;component/Images/Byke2.jpg��6   $	��250��6D   $	��250��6S   $
��0,10q�6c    J� Opacity$	 0.6Q�6q   5@      5A      5B      5C      