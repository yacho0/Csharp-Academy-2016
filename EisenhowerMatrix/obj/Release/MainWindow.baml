   M S B A M L   `   `   `  ���� K  GEisenhowerMatrix, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:EisenhowerMatrixEisenhowerMatrix  !    EisenhowerMatrix.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:EisenhowerMatrix       � Title$  Support matrix��$	��450��$
��1200��.���  � ColumnDefinitions �� $��1* ��� $��1* � � RowDefinitions �� $
��4.5* ��� $��4* ��� $��4* �.+��� -   $��	ListView1��$��0��$��1������ *	TaskList1+ �� View �� .P��� $��1) Urgent and important�� �� DisplayMemberBinding �� *Task+�� $��Feature�� �� *FeatureOfTask+�� -   $��	ListView2��$��1��$��1������ *	TaskList2+ �� .P���  �� Width$	 150��$$��2) Important                  �� �� *Task+�� $��Feature�� �� *FeatureOfTask+�� -   $��	ListView3��$��0��$��2������ *	TaskList3+ �� .P��� $!��3) Urgent and not important�� �� *Task+�� $��Feature�� �� *FeatureOfTask+�� -   $��	ListView4��$��1��$��2������ *	TaskList4+ �� .P��� $	 150��$$��4) Less important             �� �� *Task+�� $��Feature�� �� *FeatureOfTask+�� $��0��$��0��.+���  �� Orientation$ 
Horizontal=�$
��10,5q�.+��� $��Enter the task���� -   $��TaskTextBox��$	��120��$
��10,5q��� $��Save or load your matrix��$��	100,0,0,0q��� -   $��
SaveButton��$
��Save��$��	10,0,10,5q��� -   $��
LoadButton��$
��Load��$��	10,0,10,5q��� $ 
Horizontal=�$
��10,5q�.+��� $#��Select the number of quarters���� -   $��NumberComboBox���� $ 
Horizontal=�$
��10,5q�.+��� $ ��Select the feature of task���� -	   $��FOTComboBox��$��70���� $ 
Horizontal=�$
��10,5q�.+��� $ ��Click the key and add task���� -
   $��	AddButton��$	��Add���� $��1��$��0��.+��� $
��10,5q�.+��� $ 
Horizontal=�$
��10,5q�.+��� $A��;If you want delete task select task in quarts and click key���� -   $��DeleteButton��$��Delete���� $ 
Horizontal=�$
��10,5q�.+��� $0��*If you want to delete all tasks click key ���� -   $��ClearButton��$��	Clear all��$��50���� $ 
Horizontal=�$
��10,5q�.+��� $��Set your age���� -   $��20��$��-���� -   $��
AgeTextBox��$��50������  �� Path$	 Age��� -   $��20��$��+���� $�� and click key���� -   $��YearsButton��$��Count years���� $'��! if you want check your odd Time.���� $ 
Horizontal=�$
��10,5q�.+��� $ ��Select color of this panel���� -   $��	RedButton��$	��Red��$
��10,5q��� -   $��
BlueButton��$
��Blue��$
��10,5q��� -   $��GreenButton��$��Green��$
��10,5q��� -   $��WhiteButton��$��White��$
��10,5q�