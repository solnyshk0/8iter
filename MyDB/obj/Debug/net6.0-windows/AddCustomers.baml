   M S B A M L   `   `   `  ����?  ;MyDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MyDBMyDB  5   	       MyDB.AddCustomers   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:MyDB     5   	     � Title$  AddCustomers��5   	   $	��450��6   $	��800��6+   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��71* �6   �� 5      $
��129* �6    � RowDefinitions 5   
   �� 5      $	��45* �6   �� 5      $	��45* �6   �� 5      $	��45* �6   �� 5      $	��45* �6   .+�5   
   �� $#��Контактное лицо��6   $
��Left=�6*   $��82,0,0,0q�6E   $��Center=�6W   $��47��6r   $	��158��6~   $��18(�6�   �� 5   
   $��Телефон��6   $
��Left=�6"   $��Center=�6=   $��47��6X   $	��108��6d   $��1��6p   $��82,0,0,0q�6}   $��18(�6�   �� 5   
   $��
Адрес��6   $
��Left=�6    $	��Top=�6;   $��47��6S   $	��108��6_   $��2��6k   $��	82,36,0,0q�6x   $��18(�6�   �� 5   
   -   5         ��Name$ tbContactPerson��5      $��1��6+   $
��Left=�6;   $��
190,54,0,0q�6V    �� TextWrapping$
 Wrap=�6j   $	��Top=�6~   $	��120��6�   �� 5   
   -   5        $ tbPhone��5      $��1��6#   $
��Left=�63   $��	190,0,0,0q�6N   $
 Wrap=�6a   $��Center=�6u   $	��120��6�   $��1��6�   �� 5   
   -   5        $ 	tbAddress��5      $��1��6%   $
��Left=�65   $��	190,0,0,0q�6P   $
 Wrap=�6c   $��Center=�6w   $	��120��6�   $��2��6�   �� 5   
   -   5         ��Name$ btSave��5      $��Сохранить��6!   $
��Left=�65   $��
120,54,0,0q�6P   $��3��6d   $	��Top=�6q   $��18(�6�   6�   �� 5   
   -   5        $��1��5      $��Закрыть��6!   $
��Left=�63   $��
151,54,0,0q�6N   $��3��6b   $	��Top=�6o   $��18(�6�   $��37��6�   $��87��6�   6�   5      5      