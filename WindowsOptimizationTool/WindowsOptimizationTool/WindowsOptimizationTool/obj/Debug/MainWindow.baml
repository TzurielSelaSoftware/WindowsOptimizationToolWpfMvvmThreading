   M S B A M L   `   `   `  ����R  NWindowsOptimizationTool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:WindowsOptimizationTool.ViewModels"WindowsOptimizationTool.ViewModels  5   	   (    "WindowsOptimizationTool.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?vm0clr-namespace:WindowsOptimizationTool.ViewModels     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � WindowStyle$
 None=�65   $��0q�6H    � 
ResizeMode$ NoResize=�6\    � WindowStartupLocation$ CenterScreen=�6r    � DataContext 5	      6  0WindowsOptimizationTool.ViewModels.MainViewModel  5
   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $
��0.5* �6    � ColumnDefinitions 5   
   �� 5      $
��0.3* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5!      $��* �6   �� 5"      $��* �6   �� 5#      $
��0.3* �6   .+�5&   
   �� $��Images\2.jpg��6   $��0��6&   $��0��66   $��7��6C   $��12��6W    J� Opacity$	 0.4Q�6i   $
��Fill=�6w   �� 5(   
    �� 
IsReadOnly . 	 �� 
IsEditable	 . 
 �� Text$	
 ...��67   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6B   $��6��6h   $��	-20,0,0,0q�6x   $��0��6�   
�������$	 0.7Q�6�    �� SelectedIndex 6�   �� *SelectedValue+.@�5)      �� 
�������$	 0.7Q�63   .��6A   Exit6G   �� 5*      
�������$	 0.7Q�63   .��6A   About6H   5+      �� 5-   
   $��1��6   $��5��6$   $��5��61   $��11(�6`   ��6E   �� *	SpaceInfo+6`   �� 5/   
   $��Remove trash��6   $��1��6'   $��1��67   $��18(�6D   $��Tempus Sans ITC)�6R   $
��Bold"�6o   $��5,0,0,0q�6�   �� 50   
   $��Freeing storage��6   $��3��6*   $��1��6:   $��18(�6G   $��Tempus Sans ITC)�6U   $
��Bold"�6r   $��5,0,0,0q�6�   �� 51   
   $��User preferences��6   $��5��6+   $��1��6;   $��18(�6H   $��Tempus Sans ITC)�6V   $
��Bold"�6s   $��5,0,0,0q�6�   �� 54   
   $��Empty Temp-Folder��61    � ToolTip$) #Clean up all unnecessary temp files��6M   $��1��6{   $��2��6�   $��7,7,7,7q�6�   
�������$	 0.7Q�6�   {�6   �� *	IsEnabled+��6�   �� *EmptyTempFolder+�� 55   
   $��Remove Empty-Folders��61   $' !Remove empty folders from drive C��6P   $��1��6|   $��3��6�   $��7,7,7,7q�6�   
�������$	 0.7Q�6�   {�6   �� *	IsEnabled+��6�   �� *RemoveEmptyFolders+�� 56   
   $��Activate Disk-Cleanup��61   $ Windows disk clean-up��6Q   $��1��6q   $��4��6�   $��7,7,7,7q�6�   
�������$	 0.7Q�6�   {�6   �� *	IsEnabled+��6�   �� *	CleanUp+�� 58   
   $��Disable Hibernation��61   $2 ,Disable pc Hibernation - save 7GB of storage��6O   $��3��6�   $��2��6�   $��7,7,7,7q�6�   
�������$	 0.7Q�6�   {�6   �� *	IsEnabled+��6�   �� *
CmdCommand+�� 59   
   $��Disable Restore-Point��61   $ Save space on you HDD��6Q   $��3��6q   $��3��6�   $��7,7,7,7q�6�   
�������$	 0.7Q�6�   {�6   �� *	IsEnabled+��6�   �� *RestorePoine+�� 5:   
   $��Disable Indexing��61   $ Increase performance��6L   $��3��6k   $��4��6{   $��7,7,7,7q�6�   
�������$	 0.7Q�6�   {�6   �� *	IsEnabled+��6�   �� *Index+�� 5<   
   $��Turn off UAC��61   $ User-account-control��6H   $��5��6g   $��2��6w   $��7,7,7,7q�6�   
�������$	 0.7Q�6�   {�6   �� *	IsEnabled+��6�   �� *UAC+�� 5=   
   $��Disable visual effects��61   $ Increase performance��6R   $��5��6q   $��3��6�   $��7,7,7,7q�6�   
�������$	 0.7Q�6�   {�6   �� *	IsEnabled+��6�   �� *Visual+�� 5>   
   $��
Disable WD��61   $ Windows Defender��6F   $��5��6a   $��4��6q   $��7,7,7,7q�6   
�������$	 0.7Q�6�   {�6   �� *	IsEnabled+��6�   �� *WD+�� 5@   
   $��6��67   $��1��6D   $��5��6T   $��4��6h   
����������	#FF000128$	 0.8Q�6�   ��6   �� *ConsoleData+6�   � 5B   
   $��1��6   $��10��6&    � Minimum$ 0Q�64   $��5��6b   
�������$��0,7,0,7q�6�   $	 0.7Q�6�    � Maximum 6@   �� *ProgBarLength+ � Value 6v   �� *ProgBarValue+6�   5D      5E      