   M S B A M L   `   `   `  ����B  >MazeGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:MazeGUIMazeGUI  5   	   !clr-namespace:MazeGUIMazeGUI  5   	        MazeGUI.SinglePlayerWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:MazeGUI     5   	   *Controlsclr-namespace:MazeGUI     5   	   -   5        $	��600��5	   '   $	��600��64     � WindowStartupLocation$  CenterScreen=�6@   ���#0f1a1e � Title 6	   �� *VM_MazeName+.��5
      �� .+�5   
   �� -   5         �� Left$	 180��5      
 �� Top$ 20��6#   $��Restart game��63   $��Italic$�6J   
��� ���
��� ���
�������6�   �� 5   
   -   5        $	 265��5      $ 20��6#   $��
Solve maze��63   $��Italic$�6I   
��� ���
��� ���
�������6�   �� 5   
   -   5        $	 340��5      $ 20��6#   $��	Main menu��63   $��Italic$�6G   
��� ���
��� ���
�������6�   �� 5   
    �� Orientation$ 
Horizontal=�6   .+�5         MazeGUI.TheMazeBoard  -   5          Name$ mySingleGame��5   $      MazeGUI.TheMazeBoard   Loaded$ singleGame_Loaded��6T   $	��400��6;   $	��400��6H   $��Center=�5      $��Center=�6A   $��0,0,0,0q�6c   $��
94,65,40,0q�6u      MazeName 5      �� *VM_MazeName+   MazeRows 6>   �� *VM_MazeRows+	   MazeCols	 6_   �� *VM_MazeCols+
   
InitialPos
 5      �� *VM_InitialPos+   GoalPos 6B   �� *
VM_GoalPos+5      5      5      