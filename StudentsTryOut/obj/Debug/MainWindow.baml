   M S B A M L   `   `   `  ����I  EStudentsTryOut, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:StudentsTryOutStudentsTryOut  5   	       StudentsTryOut.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:StudentsTryOut     5   	     � Title$  IBT College��5   	   $	��450��6   $	��800��6*    � WindowStartupLocation$ CenterScreen=�66    � 
ResizeMode$ NoResize=�6[   .��5	      � -   5         � RowDefinitions 5
   
   �� 5      $	��100 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��279.591 �6   .+�5   
   �� $��0��6   .+�5      �� $��Images\IBTLogo.jpg��6    �� Left$	 340��60   
 �� Top$ 10��6B   $	��110��6R   5      �� 5   
   $��1��6   
���   �.+�5      o� 
���   �$
��Bold"�6&   
�������.@�5      m� -   5        $��NewMenuItem��5      $��New Student��6.   
�������$��29��6V   6b   m� 5      -   5        $��AboutMenuItem��5      $��About��60   
�������$��29��6R   6^   m� 5      -   5        $��ExitMenuItem��5      $
��Exit��6/   
�������$��29��6P   6\   5      5      �� 5   
   $��2��6   
����  �.+�5      �� $��	Path File��6   $
��Left=�6(   $	��Top=�6C   $ 5��6[   $ 1��6k   
��� ���6z   �� 5      -   5        $��txtPathFile��5      $
��Left=�6)   $��23��6D    �� TextWrapping$
 Wrap=�6P   $	��Top=�6d   $	��436��6|   $ 66��6�   $ 3��6�   $
��Bold"�6�   �� 5      -   5        $��btnPathExport��5      $��Export��6*   $	 706��6;   $ 4��6M   $��75��6\   6g   �� 5      -   5        $��txtNameFile��5      $��23��6)   $	 575��65   $
 Wrap=�6G   $ 3��6[   $	��120��6j   �� 5      $��	Name File��6   $
��Left=�6(   $	��Top=�6C   $	 507��6[   $ 2��6m   
��� ���6|   5       �� 5!   
   $��Search��6   $
��Left=�6!   $	��Top=�6<   $ 13��6T   $ 54��6e   $��	11,24,0,0q�6u   $��3��6�   �� 5"   
   -   5        $��StudentList��5"      $
��Left=�6%   $	��186��6@   $��	15,58,0,0q�6M   $��3��6`   $	��Top=�6m   $	��759��6�   6�   �� 5#   
   -	   5        $��txtSerchStudent��5#      $
��Left=�6)   $��23��6D   $
 Wrap=�6P   $	��378��6e   $ 64��6q   $ 56��6�   $��66,25,0,232q�6�   $��3��6�   5$      5%      