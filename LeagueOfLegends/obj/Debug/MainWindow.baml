   M S B A M L   `   `   `  ����J  FLeagueOfLegends, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:LeagueOfLegendsLeagueOfLegends  5   	        LeagueOfLegends.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:LeagueOfLegends     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   
����p��.��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5       $��* �6   .+�5#   
   �� $��2��6   $��6��6    $)��#My Top League Of Legends Characters��64   $��Center=�6b   $��Center=�6�   $��20(�6�   $
��Bold"�6�   �� 5%   
   $��2��6   $��0��6   $��3��6-   $��Character Information��6A   $��Center=�6a   $��Center=�6�   $��15(�6�   $
��Bold"�6�   �� 5'   
   -   5         ��Name$ LabelCharacterID��5'      $��ID��6*   $��3��67   $��0��6D   $��Center=�6T   $��Center=�6x   �� 5(   
   -   5        $ LabelCharacterName��5(      $
��Name��6,   $��4��6;   $��0��6H   $��Center=�6X   $��Center=�6|   �� 5)   
   -   5        $ LabelCharacterDescription��5)      $��Description��63   $��5��6I   $��0��6V   $��Center=�6f   $��Center=�6�   �� 5+   
   -   5         ��Name$ TextBoxCharacterID��5+      $��3��6.   $��1��6;   $��2��6K   $��25��6_   $��Center=�6k   $��Center=�6�    �� 
IsReadOnly . 
�������6�   �� 5,   
   -   5        $ TextBoxCharacterName��5,      $��4��60   $��1��6=   $��2��6M   $��25��6a   $��Center=�6m   $��Center=�6�    . 
�������6�   �� 5-   
   -   5        $! TextBoxCharacterDescription��5-      $��5��67   $��1��6D   $��2��6T   $��25��6h   $��Center=�6t   $��Center=�6�    . 
�������6�   �� 5/   
   -   5         ��Name$ 	ButtonAdd��5/      $	��Add��6$   $��7��62   $��0��6?   {�. 
���� ��6t   �� 50   
   -   5        $ 
ButtonEdit��50      $
��Edit��6%   $��7��64   $��1��6A   {�.  
���� ��6w   �� 51   
   -	   5        $ ButtonDelete��51      $��Delete��6'   $��7��68   $��2��6E   {�.  
���� ��6{   �� 53   
   -
   5         ��Name$ ListViewCharacterDetails��53      $��3��65   $��5��6B   $��4��6S   $��6��6c    �� View 54      �� 55      .P�56      �� $��ID��6%   	 �� Width$	 40��61   
 �� DisplayMemberBinding
 6<   �� *CharacterID+�� 57      $
��Name��6%   $		 100��63   
 6?   �� *CharacterName+�� 58      $��Description��6%   $		 300��6:   
 6F   �� *CharacterDescription+59      5;      5>      5?      