   M S B A M L   `   `   `  ����B  >MazeGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:MazeGUIMazeGUI  5   	   !clr-namespace:MazeGUIMazeGUI  5   	       MazeGUI.MultiPlayerWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:MazeGUI     5   	   *Controlsclr-namespace:MazeGUI     5   	   -   5        $	��600��5	   (   $	��900��65     � WindowStartupLocation$  CenterScreen=�6A   ���#0f1a1e � Title 6	   �� *VM_MazeName+.��5
      � .+�5   
   �� $��401,-29,-401,29q�6   .+�5      �� -   5        
 �� Top$ 82��5      $��Back to main menu��6%   $��Italic$�6A   
��� ���
��� ���
������� �� Left$ -7��6�   5      �� 5   
    �� Orientation$ 
Horizontal=�6   .+�5         MazeGUI.TheMazeBoard  -   5          Name$ myGame��5   $      MazeGUI.TheMazeBoard   Loaded$ myGame_Loaded��6N   $	��400��65   $	��400��6B   $��Center=�5      $��Center=�6A   $��0,0,0,0q�6c   $��45,105,40,52q�6u      MazeName 5      �� *VM_MazeName+   MazeRows 6>   �� *VM_MazeRows+	   MazeCols	 6_   �� *VM_MazeCols+
   
InitialPos
 5      �� *VM_InitialPos+   GoalPos 6B   �� *
VM_GoalPos+   CurPos 6a   �� *	VM_CurPos+5      �� 5   
   $ 
Horizontal=�6   .+�5        -   5        $ yourGame��5   $   $ yourGame_Loaded��6P   $	��400��67   $	��400��6D   $��Center=�5      $��Center=�6A   $��0,0,0,0q�6c   $��446,105,40,52q�6u    5      �� *VM_MazeName+ 6>   �� *VM_MazeRows+	 6_   �� *VM_MazeCols+
 5      �� *VM_InitialPos+ 6B   �� *
VM_GoalPos+ 6a   �� *	VM_OppPos+5      5      5      