   M S B A M L   `   `   `  ����B  >MazeGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:MazeGUIMazeGUI  5   	        MazeGUI.GameSettingswindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:MazeGUI     5   	     � Title$  GameSettingswindow��5   	   $	��210��6$   $	��600��61   ���#0f1a1e � WindowStartupLocation$ CenterScreen=�5	      .��5
      � $��10,10,10,10q�6   $��14(�6    $��Italic$�68   ��5   
   �� 5       �� Color$ #0f1a1e��6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� 
��� ���
Server IP:68   �� 5   
   -   5         ��Name$ txtIP��5      $��1��6!   
����������#0f1a1e��6_   ��  �� Path$ ServerIP� �� Mode$ TwoWay=�6�   �� 5   
   $��1��6   
��� ���Server Port:6F   �� 5   
   -   5        $ txtPort��5      $��1��6#   
����������#0f1a1e$��2��6^   ��6n   �� $ 
ServerPort�$ TwoWay=�6�   �� 5   
   $��2��6   
��� ���
Maze rows:6D   �� 5   
   -   5        $ txtRows��5      $��2��6#   
����������#0f1a1e$��2��6^   ��6n   �� $ MazeRows�$ TwoWay=�6�   �� 5    
   $��3��6   
��� ���Maze columns:6G   �� 5!   
   -   5        $ txtCols��5!      $��3��6#   
�������$��2��6I   ���#0f1a1e��6n   �� *
MazeCols+$ TwoWay=�6�   �� 5"   
   $��4��6   
��� ���Search algorithm:6K   �� 5#   
   -   5         ��Name$ cboSearchAlgo��5#      $��4��6*   $��1��67   $
��Left=�6G   
��� ���
�������	 �� 
IsEditable	 .  $��11,0,0,0q�5$   K   $	��125��6]   
 �� SelectedIndex
 6   �� *SearchAlgorithm+$ TwoWay=�.@�5%      �� .��6   BFS6    �� 5&      .��6   DFS6    5'      �� 5(   
   -   5         ��Name$ btnOk��5(      $��5��6    
��� ���$��Center=�6D   $��Italic$�6a   
��� ���
�������$��1��5)      $��5q�6)   $��5q�64   .��6@   OK6D   �� 5*   
   -   5        $ 	btnCancel��5*      $��5��6$   
��� ���$��Center=�6H   $��Italic$�6e   
��� ���
�������$��2��5+      $��5q�6-   $��5q�68   .��6D   Cancel6L   5,      5-      