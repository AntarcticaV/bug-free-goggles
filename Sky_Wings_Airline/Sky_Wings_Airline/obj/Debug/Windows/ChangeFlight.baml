   M S B A M L   `   `   `  ����L  HSky_Wings_Airline, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Sky_Wings_Airline.WindowsSky_Wings_Airline.Windows  5   	   ,    &Sky_Wings_Airline.Windows.ChangeFlight   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Sky_Wings_Airline.Windows     5   	     � Title$#  Изменить запись��5   	   $	��584��6!   $	��439��6.    � 
ResizeMode$ NoResize=�6:   .��5	      � .+�5
   
   �� -   5         ��Name$ comboBoxDepartureAirport��5
      $
��Left=�65   $��
218,44,0,0q�6P   $	��Top=�6d   $	��190��6|   6�   �� 5   
   -   5        $ comboBoxArrivalAirport��5      $
��Left=�63   $��218,108,0,0q�6N   $	��Top=�6c   $	��190��6{   6�   �� 5   
   -   5        $ comboBoxPlane��5      $
��Left=�6*   $��218,300,0,0q�6E   $	��Top=�6Z   $	��190��6r   �� 5   
   -   5        $ comboBoxFirstPilot��5      $
��Left=�6/   $��218,364,0,0q�6J   $	��Top=�6_   $	��189��6w   6�   �� 5   
   -   5        $ comboBoxSecondPilot��5      $
��Left=�60   $��219,428,0,0q�6K   $	��Top=�6`   $	��189��6x   6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ datePickerDepartureDate��5      $
��Left=�66   $��218,172,0,0q�6Q   $	��Top=�6f   $	��190��6~    � 	Resources 5      :  4System.Windows.Controls.Primitives.DatePickerTextBox �� 
TargetType �� Property �� Value��%[   '        �� 5      "  6   .�5      ��  �@��
IsReadOnly . 63   5      5      5        5   
   -   5        $ datePickerArrivalDate��5      $
��Left=�64   $��218,236,0,0q�6O   $	��Top=�6d   $	��190��6|    5      ��%[   '        �� 5      "  6   .�5      ��  �@��
IsReadOnly . 63   5      5      5      �� 5   
   -   5         ��Name$ textBlockDepartureAirport��5      $
��Left=�67   $��	10,47,0,0q�6R   $
��Wrap=�6e   $'��!Аэропорт отправки��6y   $	��Top=�6�   �� 5   
   -	   5        $ textBlockArrivalAirport��5      $
��Left=�65   $��
10,111,0,0q�6P   $
��Wrap=�6d   $'��!Аэропорт прибытия��6x   $	��Top=�6�   �� 5   
   -
   5        $ textBlockDepartureDate��5      $
��Left=�64   $��
10,176,0,0q�6O   $
��Wrap=�6c   $!��Время отправки��6w   $	��Top=�6�   �� 5    
   -   5        $ textBlockArrivalDate��5       $
��Left=�62   $��
10,240,0,0q�6M   $
��Wrap=�6a   $!��Время прибытия��6u   $	��Top=�6�   �� 5!   
   -   5        $ textBlockPlane��5!      $
��Left=�6,   $��
10,303,0,0q�6G   $
��Wrap=�6[   $��Самалёт��6o   $	��Top=�6~   �� 5"   
   -   5        $ textBlockFirstPilot��5"      $
��Left=�61   $��
10,367,0,0q�6L   $
��Wrap=�6`   $��Первый пилот��6t   $	��Top=�6�   �� 5#   
   -   5        $ textBlockSecondPilot��5#      $
��Left=�62   $��
10,431,0,0q�6M   $
��Wrap=�6a   $��Второй пилот��6u   $	��Top=�6�   �� 5$   
   -   5        	 ��Name$	 
buttonSave��5$      $��Сохранить��6%   $
��Left=�69   $��	68,0,0,25q�6T   $��Bottom=�6g   $��34��6�   $��94��6�   6�   �� 5%   
   -   5        $	 
buttonBack��5%      $��
Назад��6%   $��	0,0,68,25q�65   $��Bottom=�6H   $��34��6c   $��94��6o   $��Right=�6�   5'      5(      