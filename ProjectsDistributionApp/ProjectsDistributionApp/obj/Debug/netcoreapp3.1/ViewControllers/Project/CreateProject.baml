   M S B A M L   `   `   `  ����R  NProjectsDistributionApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:ProjectsDistributionApp.ViewControllers'ProjectsDistributionApp.ViewControllers  5   	   ;    5ProjectsDistributionApp.ViewControllers.CreateProject   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Glocal5clr-namespace:ProjectsDistributionApp.ViewControllers     5   	     � Title$  CreateProject��5   	   $	��650��6   $	��400��6,   .��5	      � .+�5
   
   �� .+�5      �� $��Название��6   $
��Left=�5      $	��Top=�5      $��10,5,0,0q�5      6,   �� 5      -   5         ��Name$ ProjectName��5      $
��Left=�5      $	��Top=�5      $��10,5,0,0q�5      $	��150��5      �� 5      $��Описание��6   $
��Left=�5      $	��Top=�5      $��10,5,0,0q�5      5      �� 5      -   5        $ Description��5      $
��Left=�5      $	��Top=�5      $��10,5,0,0q�5      $	��350��5      $	��100��5      �� 5      $��Статус��6   $
��Left=�5       $	��Top=�5!      $��10,5,0,0q�5"      6,   �� 5#      -   5        $ Status��5#      $
��Left=�5$      $	��Top=�5%      $��10,5,0,0q�5&      $��60��5'      �� 5(      $��Приоритет��6   $
��Left=�5)      $	��Top=�5*      $��10,5,0,0q�5+      �� 5,      -   5        $ Priority��5,      $
��Left=�5-      $	��Top=�5.      $��60��5/      $��10,5,0,0q�50      � 51      .+�52      �� $��Дата начала��6   $��Center=�53      $	��Top=�54      $��70,5,0,0q�55      �� 57      $��Дата конца��6   $��Center=�58      $	��Top=�59      $��	120,5,0,0q�5:      5<      � 5=      .+�5>      &   System.Windows.Controls.Calendar  -   5          Name$ Start��5>         SelectionMode$ 
SingleDate=�5?      $	��Top=�5@      $
��Left=�5A      $��10,5,0,0q�5B        5C      -   5        $	 End��5C      $ 
SingleDate=�5D      $	��Top=�5E      $
��Left=�5F      $��20,5,0,0q�5G      5H      �� 5I      -   5         ��Name$ 
SkillsList��5I      $	��Top=�5J      $
��Left=�5K      $��10,5,0,0q�5L      $	��380��5M      $	��100��5N      5O      �� 5P      -   5        $��Добавить роль��5P      $	��Top=�5Q      $
��Left=�5R      $��20,5,0,0q�5S      6'   � 5T      .+�5U      �� $��Создать��6   $	��Top=�5V      $��Center=�5W      $��80,5,0,0q�5X      �� 5Y      -	   5        $��Отмена��5Y      $	��Top=�5Z      $��Center=�5[      $��	120,5,0,0q�5\      5]      5^      5_      5`      5a      