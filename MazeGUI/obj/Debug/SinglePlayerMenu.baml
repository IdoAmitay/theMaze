   M S B A M L   `   `   `  ����B  >MazeGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:MazeGUIMazeGUI  5   	       MazeGUI.SinglePlayerMenu   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:MazeGUI     5   	     � Title$  SinglePlayerMenu��5   	   $	��210��6"   $	��600��6/   ���#0f1a1e � WindowStartupLocation$ CenterScreen=�5	      .��5
      � $��30,20,40,40q�6   $��14(�6     � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� 
��� ���
Maze name:67   �� 5   
   -   5         ��Name$ txtName��5      $��1��6#   
����������#0f1a1e��6a   ��  �� Path$
 Name� �� Mode$ TwoWay=�6�   �� 5   
   $��2��6   
��� ���
Maze rows:6D   �� 5   
   -   5        $ txtRows��5      
�������$��2��6<   ���#0f1a1e$��2��6^   ��6n   �� *DefaultRows+$ TwoWay=�6�   �� 5   
   $��3��6   
��� ���Maze columns:6G   �� 5   
   -   5        $ txtCols��5      
����������#0f1a1e$��3��6Q   $��2��6^   ��6n   �� *DefaultCols+$ TwoWay=�6�   �� 5   
   -   5         ��Name$ btnOk��5      
��� ���
�������
��� ���$��4��6j   $��Center=�6w   $��2��5      $��5q�6*   $��5q�65   .��6A   OK6E   5      5      