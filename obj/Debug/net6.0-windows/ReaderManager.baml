   M S B A M L   `   `   `  ����^  ZProject_Library_Management_FA23_BL5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:Project_Library_Management_FA23_BL5#Project_Library_Management_FA23_BL5  5      7    1Project_Library_Management_FA23_BL5.ReaderManager   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Clocal1clr-namespace:Project_Library_Management_FA23_BL5     5        N� Title$  ReaderManager��5	      $	��453��6   $	��977��6*   .��5      � 
�������.+�5   
   �� $��167,0,586,403q�6   $��Reader management��6'   $��15(�6C   $
��Bold"�6Q   
���  ��6c   � 5   
   $��
0,47,400,0q�6   .+�5      �� $��52��6   $	��267��6%    �� Orientation$ 
Horizontal=�61   .+�5      �� $��
Occupation��6   $	��106��6-   $��34��69   �� 5      -   5        $��txtOccupation��5   3   $	��151��6   $��22��6'    �� Text 6H   ��  �� Path$ 
Occupation� �� Mode$ OneWay=� � DataContext 6v   ��  �� ElementName$ 
listReader��$ SelectedItem�.@�5      �� $��Học viên��6#   69   �� 5      $��
Sinh viên��6#   6:   �� 5      $��Giáo viên��6#   6:   5      5      �� 5      $	��234��6   $ 
Horizontal=�6%   .+�5      �� $��Card number��6   $��86��6.   $��30��69   �� 5      -   5        $��txtCardNumber��5   @    �� TextWrapping$
 Wrap=�6    �� 
IsReadOnly$
 True��6.   $	��136��6U   $��26��6a   ��6m   �� $ 
CardNumber�$ OneWay=� 6�   �� $ 
listReader��$ SelectedItem�5      �� 5      $	��501��6   $��53��6%   $ 
Horizontal=�61   .+�5      �� $��	Full name��6   $	��115��6,   $��30��68   �� 5      -   5        $��txtFullName��5   2   $	��375��6   $��22��6&   ��6E   �� $ FullName�$ OneWay=� 6q   �� $ 
listReader��$ SelectedItem�5      �� 5      $	��501��6   $��53��6%   $ 
Horizontal=�61   .+�5       �� $��Date of birth��6   $	��115��60   $��30��6<   (  "System.Windows.Controls.DatePicker  5!      -   5        $��txtDob��5!   5   $	��375��6   $��22��6)   	   SelectedDate	 6C   �� $ DateOfBirth�$ OneWay=� 6z   �� $ 
listReader��$ SelectedItem�5"      �� 5#      $	��501��6   $��53��6%   $ 
Horizontal=�61   .+�5$      �� $��Card creation date��6   $	��115��65   $��30��6A     5%      -   5        $��txtCcd��5%   5   $	��375��6   $��22��6)   	 6C   �� $ CardCreationDate�$ OneWay=� 6   �� $ 
listReader��$ SelectedItem�5&      �� 5'      $	��501��6   $	��128��6%   $ 
Horizontal=�62   .+�5(      �� $��Address��6   $	��115��6*   $	��112��66   �� 5)      -   5        $��
txtAddress��5)   3   $	��375��6   $	��113��6&   
 �� MaxLines$
 30��6E   ��6S   �� $ Address�$ OneWay=� 6~   �� $ 
listReader��$ SelectedItem�5*      �� 5+      $	��501��6   $��27��6%   $ 
Horizontal=�61   .+�5,      �� -   5        $��Reresh��5,      $	��100��6*   $
��20 0q�66   6D   �� 5-      -   5         ��Name$ btn_Add��5-   A   $	��Add��6   $	��100��6'   $
��10 0q�63   6R   �� 5.      -	   5        $ btn_Edit��5.   B   $
��Edit��6   $	��100��6(   $
��10 0q�64   6T   �� 5/      -
   5        $ 
btn_Delete��5/   D   $��Delete��6   $	��100��6*   $
��10 0q�66   6X   50      53      �� 54   
   -   5         ��Name$ 
listReader��54   (   $��516,10,0,10q�6    �� View 55      �� 56      .P�57      �� $��Reder card number��6%    �� Width$	 150��6@    �� DisplayMemberBinding 6L   �� $ 
CardNumber��� 58      $��
Reder name��6%   $	 150��69    6E   �� $ FullName��� 59      $��
Occupation��6%   $	 150��69    6E   �� $ 
Occupation�5:      5<      5=      5>      