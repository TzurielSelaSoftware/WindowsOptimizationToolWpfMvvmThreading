   M S B A M L   `   `   `  ���� R  NWindowsOptimizationTool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:WindowsOptimizationTool.ViewModels"WindowsOptimizationTool.ViewModels  (    "WindowsOptimizationTool.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ?vm0clr-namespace:WindowsOptimizationTool.ViewModels       � Title$  
MainWindow��$	��450��$	��800�� � WindowStyle$
 None=�$��0q� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � DataContext 6  0WindowsOptimizationTool.ViewModels.MainViewModel  .���  � RowDefinitions �� $
��0.5* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $
��0.5* � � ColumnDefinitions �� $
��0.3* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $
��0.3* �.+��� $��Images\2.jpg��$��0��$��0��$��7��$��12�� J� Opacity$	 0.4Q�$
��Fill=���  �� 
IsReadOnly . 	 �� 
IsEditable	 . 
 �� Text$	
 ...��$ �� IsSynchronizedWithCurrentItem$
 TrueY�$��6��$��	-20,0,0,0q�$��0��
�������$	 0.7Q� �� SelectedIndex �� *SelectedValue+.@��� 
�������$	 0.7Q�.��Exit�� 
�������$	 0.7Q�.��About�� $��1��$��5��$��5��$��11(����� *	SpaceInfo+�� $��Remove trash��$��1��$��1��$��18(�$��Tempus Sans ITC)�$
��Bold"�$��5,0,0,0q��� $��Freeing storage��$��3��$��1��$��18(�$��Tempus Sans ITC)�$
��Bold"�$��5,0,0,0q��� $��User preferences��$��5��$��1��$��18(�$��Tempus Sans ITC)�$
��Bold"�$��5,0,0,0q��� $��Empty Temp-Folder�� � ToolTip$) #Clean up all unnecessary temp files��$��1��$��2��$��7,7,7,7q�
�������$	 0.7Q�{��� *	IsEnabled+���� *EmptyTempFolder+�� $��Remove Empty-Folders��$' !Remove empty folders from drive C��$��1��$��3��$��7,7,7,7q�
�������$	 0.7Q�{��� *	IsEnabled+���� *RemoveEmptyFolders+�� $��Activate Disk-Cleanup��$ Windows disk clean-up��$��1��$��4��$��7,7,7,7q�
�������$	 0.7Q�{��� *	IsEnabled+���� *	CleanUp+�� $��Disable Hibernation��$2 ,Disable pc Hibernation - save 7GB of storage��$��3��$��2��$��7,7,7,7q�
�������$	 0.7Q�{��� *	IsEnabled+���� *
CmdCommand+�� $��Disable Restore-Point��$ Save space on you HDD��$��3��$��3��$��7,7,7,7q�
�������$	 0.7Q�{��� *	IsEnabled+���� *RestorePoine+�� $��Disable Indexing��$ Increase performance��$��3��$��4��$��7,7,7,7q�
�������$	 0.7Q�{��� *	IsEnabled+���� *Index+�� $��Turn off UAC��$ User-account-control��$��5��$��2��$��7,7,7,7q�
�������$	 0.7Q�{��� *	IsEnabled+���� *UAC+�� $��Disable visual effects��$ Increase performance��$��5��$��3��$��7,7,7,7q�
�������$	 0.7Q�{��� *	IsEnabled+���� *Visual+�� $��
Disable WD��$ Windows Defender��$��5��$��4��$��7,7,7,7q�
�������$	 0.7Q�{��� *	IsEnabled+���� *WD+�� $��6��$��1��$��5��$��4��
����������	#FF000128$	 0.8Q����� *ConsoleData+� $��1��$��10�� � Minimum$ 0Q�$��5��
�������$��0,7,0,7q�$	 0.7Q� � Maximum �� *ProgBarLength+ � Value �� *ProgBarValue+