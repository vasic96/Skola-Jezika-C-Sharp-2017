   M S B A M L   `   `   `  ����@  <SJWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SJWPFSJWPF  5   	       SJWPF.KursIzmena   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:SJWPF     5   	     � Title$
  Kurs��5   	   $	��300��6   $��348.936��6#   .��5	      � .+�5
   
   �� -   5         ��Name$ label��5
      $��Jezik��6   $
��Left=�6/   $��	10,10,0,0q�6J   $	��Top=�6]   $��77��6u   �� 5   
   -   5        $ 
label_Copy��5      $��Datum zavrsetka��6$   $
��Left=�6>   $��
10,134,0,0q�6Y   $	��Top=�6m   $	��108��6�   �� 5   
   -   5        $ label_Copy1��5      $��Datum pocetka��6%   $
��Left=�6=   $��
10,103,0,0q�6X   $	��Top=�6l   $��96��6�   �� 5   
   -   5        $ label_Copy2��5      $
��Cena��6%   $
��Left=�64   $��	10,72,0,0q�6O   $	��Top=�6b   $��77��6z   �� 5   
   -   5        $ label_Copy3��5      $
��Nivo��6%   $
��Left=�64   $��	10,41,0,0q�6O   $	��Top=�6b   $��77��6z   �� 5   
   -   5         ��Name$ cbJezik��5      $
��Left=�6I   $��
165,14,0,0q�6d   $	��Top=�6x   $	��166��6�    �� SelectedItem 6$   ��  �� Path$ Jezik�6�   �� 5   
   -   5        $ cbTip��5      $
��Left=�6I   $��
165,45,0,0q�6d   $	��Top=�6x   $	��166��6�    6"   �� $ TipKursa�6�   �� 5   
   -   5         ��Name$ tbCena��5      $
��Left=�6"   $��23��6=   $��
165,75,0,0q�6I    �� TextWrapping$
 Wrap=�6]   $	��Top=�6�   $	��166��6�   ��6q   �� $
 Cena�6�   (  "System.Windows.Controls.DatePicker  5   
   -	   5          Name$ dpDatumPocetak��5      $
��Left=�6X   $��165,105,0,0q�6s   $	��Top=�6�   $	��170��6�      SelectedDate 6-   �� $ DatumPocetak�6�     5   
   -
   5        $ dpDatumKraj��5      $
��Left=�6S   $��165,136,0,0q�6n   $	��Top=�6�   $	��170��6�    6+   �� $ 	DatumKraj�6�   �� 5   
   -   5        	 ��Name$	 cbStatus��5      $��Aktivan��6%   $
��Left=�6Y   $��
10,184,0,0q�6t   $	��Top=�6�   $��28��6�   
 d� 	IsChecked
 67   �� $ Status�6�   �� 5   
   -   5         ��Name$ btnSave��5      $��Sacuvaj��6"   $
��Left=�64   $��
31,239,0,0q�6O   $	��Top=�6c   $��75��6{   6�   5      5      