   M S B A M L   `   `   `  ����^  ZProject_Library_Management_FA23_BL5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:Project_Library_Management_FA23_BL5#Project_Library_Management_FA23_BL5  5      2    ,Project_Library_Management_FA23_BL5.LendBook   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Clocal1clr-namespace:Project_Library_Management_FA23_BL5     5        N� Title$  LendBook��5      $	��439��6   $
��1104��6%   .��5
      � 
�������.+�5   
   �� -   5         ��Name$ 	lv_Reader��5   '   $��
0,51,696,0q�6    �� View 5      �� 5      .P�5      �� $��Reader card number��6%    �� Width$	 150��6A    �� DisplayMemberBinding 6M   ��  �� Path$ 
CardNumber��� 5      $��Reader name��6%   $	 150��6:    6F   �� $ FullName��� 5      $��
Occupation��6%   $	 100��69    6E   �� $ 
Occupation�5      5      �� 5   
   -   5        $ lv_BookInfo��5   )   $��413,51,341,0q�6    5      �� 5      .P�5      �� $��Title id��6%   $	 100��67    6C   �� $ TitleId��� 5      $��Title��6%   $	 100��64    6@   �� $ Title��� 5      $��Instock��6%   $	 100��66    6B   �� $ InStock��� 5      $��Number of page��6%   $	 100��6=    6I   �� $ NumberOfPages�5      5      � 5   
   $��	768,0,0,0q�6   .+�5       �� $��65��6   $	��326��6%    �� Orientation$ 
Horizontal=�61   .+�5!      �� $��Book id��6   $��85��6*   $��30��65   �� 5"      -   5         ��Name$ 
txt_BookId��5"   .    �� TextWrapping$
 Wrap=�6   $	��233��6B   $��29��6�   ��6N   �� $ BookId�	 �� Mode$	 OneWay=�
 � DataContext
 6x   ��  �� ElementName$ 
listReader��$ SelectedItem�6�   5#      �� 5$      $	��326��6   $��66��6%   $ 
Horizontal=�61   .+�5%      �� $��	Reader id��6   $��88��6,   $��30��67   �� 5&      -   5        $ txt_ReaderId��5&   .   $
 Wrap=�6   $	��228��6D   $��34��6�   ��6P   �� $ 
CardNumber�$	 OneWay=�
 6~   �� $ 
listReader��$ SelectedItem�6�   5'      �� 5(      $	��326��6   $��57��6%   $ 
Horizontal=�61   .+�5)      �� $��Expected return book��6   $	��125��67   $��31��6C   (  "System.Windows.Controls.DatePicker  5*      -   5          Name$ expect��5*      $	��190��6-   $��33��69   6G   5+      �� 5,      $	��326��6   $��43��6%   $ 
Horizontal=�61   .+�5-      �� -   5         ��Name$ btn_CreateTicker��5-   *   $��Create��6   $��80��6c   $��20��6n   $��70 0 0 0q�6z   �� 5.      $��Button��6   $��80��6+   $��20��66   $
��30 0q�6B   5/      50      �� 51   
   $��Lend book management��6   
���  ��$��15(�6@   $
��Bold"�6N   $
��Left=�6`   $��	10,10,0,0q�6{   $	��Top=�6�   53      54      