   M S B A M L   `   `   `  ����K  GEisenhowerMatrix, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:EisenhowerMatrixEisenhowerMatrix  5   	   !    EisenhowerMatrix.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:EisenhowerMatrix     5   	     � Title$  Support matrix��5   	   $	��450��6    $
��1200��6-   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $
��4.5* �6   �� 5      $��4* �6   �� 5      $��4* �6   .+�5   
   �� -   5        $��	ListView1��5      $��0��6$   $��1��64   ��6A   �� *	TaskList1+ �� View 5      �� 5      .P�5      �� $��1) Urgent and important��6%    �� DisplayMemberBinding 6F   �� *Task+�� 5      $��Feature��6%    66   �� *FeatureOfTask+5      5      �� 5   
   -   5        $��	ListView2��5      $��1��6$   $��1��64   ��6A   �� *	TaskList2+ 5      �� 5      .P�5      ��  �� Width$	 200��6%   $��2) Important��61    6G   �� *Task+�� 5       $��Feature��6%    66   �� *FeatureOfTask+5!      5#      �� 5$   
   -   5        $��	ListView3��5$      $��0��6$   $��2��64   ��6A   �� *	TaskList3+ 5%      �� 5&      .P�5'      �� $!��3) Urgent and not important��6%    6J   �� *Task+�� 5(      $��Feature��6%    66   �� *FeatureOfTask+5)      5+      �� 5,   
   -   5        $��	ListView4��5,      $��1��6$   $��2��64   ��6A   �� *	TaskList4+ 5-      �� 5.      .P�5/      �� $	 200��6%   $��4) Less important��61    6L   �� *Task+�� 50      $��Feature��6%    66   �� *FeatureOfTask+51      53      �� 54   
   $��0��6   $��0��6%   .+�55      ��  �� Orientation$ 
Horizontal=�6   $
��10,5q�62   .+�56      �� $��Enter the task��6   �� 57      -   5        $��TaskTextBox��57      $	��120��6-   $
��10,5q�69   �� 58      $��Save or load your matrix��6   $��	100,0,0,0q�6;   �� 59      -   5        $��
SaveButton��59   (   $
��Save��6   $��	10,0,10,5q�6:   6M   �� 5:      -   5        $��
LoadButton��5:   (   $
��Load��6   $��	10,0,10,5q�6:   6M   5;      �� 5<      $ 
Horizontal=�6   $
��10,5q�62   .+�5=      �� $#��Select the number of quarters��6   �� 5>      -   5        $��NumberComboBox��5>      5?      �� 5@      $ 
Horizontal=�6   $
��10,5q�62   .+�5A      �� $ ��Select the feature of task��6   �� 5B      -	   5        $��FOTComboBox��5B   &   $��70��6   6&   5C      �� 5D      $ 
Horizontal=�6   $
��10,5q�62   .+�5E      �� $ ��Click the key and add task��6   �� 5F      -
   5        $��	AddButton��5F   '   $	��Add��6   68   5G      5H      �� 5I   
   $��1��6   $��0��6%   .+�5J      �� $
��10,5q�6   .+�5K      �� $ 
Horizontal=�6   $
��10,5q�66   .+�5L      �� $A��;If you want delete task select task in quarts and click key��6   �� 5M      -   5        $��DeleteButton��5M   .   $��Delete��6   6B   5N      �� 5O      $ 
Horizontal=�6   $
��10,5q�66   .+�5P      �� $0��*If you want to delete all tasks click key ��6   �� 5Q      -   5        $��ClearButton��5Q   2   $��	Clear all��6   $��50��6E   6P   5R      �� 5S      $ 
Horizontal=�6   $
��10,5q�66   .+�5T      �� $��Set your age��6   �� 5U      -   5        $��20��5U      $��-��6(   64   �� 5V      -   5        $��
AgeTextBox��5V      $��50��60   ��6;   ��  �� Path$	 Age��� 5W      -   5        $��20��5W      $��+��6(   64   �� 5X      $�� and click key��6   �� 5Y      -   5        $��YearsButton��5Y   3   $��Count years��6   6F   �� 5Z      $'��! if you want check your odd Time.��6   5[      �� 5\      $ 
Horizontal=�6   $
��10,5q�66   .+�5]      �� $ ��Select color of this panel��6   �� 5^      -   5        $��	RedButton��5^   +   $	��Red��6   $
��10,5q�6<   6J   �� 5_      -   5        $��
BlueButton��5_   ,   $
��Blue��6   $
��10,5q�6>   6L   �� 5`      -   5        $��GreenButton��5`   -   $��Green��6   $
��10,5q�6@   6N   �� 5a      -   5        $��WhiteButton��5a   -   $��White��6   $
��10,5q�6@   6N   5b      5c      5d      5e      5f      