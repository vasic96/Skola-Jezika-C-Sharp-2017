   M S B A M L   `   `   `  ����@  <SJWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SJWPFSJWPF  5   	       SJWPF.KorisniciDIB   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:SJWPF     5   	     � Title$  	Korisnici��5   	   $��411.538��6   $��562.128��6,   .��5	      � $��0,0,2,0q�6    � ColumnDefinitions 5
   
   �� 5      $
��382* �6   �� 5      $
��163* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgKorisnici��5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6(   $
��Left=�69   $��	10,10,0,0q�6T   $	��Top=�6g   $	��211��6   $	��525��6�   $��2��6�   �� 5   
   -   5         ��Name$ label��5      $��Pretraga��6!   $
��Left=�64   $��218,226,0,0q�6O   $	��Top=�6d   $��94��6|   $
��Bold"�6�   �� 5   
   -   5        $ label1��5      $
��Ime:��6    $
��Left=�6/   $��
10,252,0,0q�6J   $	��Top=�6^   $��60��6v   �� 5   
   -   5         ��Name$ tbIme��5      $
��Left=�6!   $��23��6<   $��
75,256,0,0q�6H    �� TextWrapping$
 Wrap=�6\   $�� ��6p   $	��Top=�6x   $	��171��6�   6�   �� 5   
   -   5        $ label2��5      $��Prezime:��6    $
��Left=�63   $��265,257,0,0q�6N   $	��Top=�6c   $��61��6{   �� 5   
   -   5        $ 	tbPrezime��5      $
��Left=�6%   $��23��6@   $��343,256,0,0q�6L   $
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��192��6�   $��2��6�   	� 5   
   -   5         	�Name$ 	rbAktivni��5      $��Aktivni��6)   $
��Left=�6;   $��
10,284,0,0q�6V   $	��Top=�6j   $��27��6�   6�   	� 5   
   -   5        $ 
rbObrisani��5      $��Obrisani��6*   $
��Left=�6=   $��241,284,0,0q�6X   $	��Top=�6m   $��27��6�   6�   	� 5   
   -	   5        $ rbSvi��5      $��Svi korisnici��6%   $
��Left=�6=   $��
25,287,0,0q�6X   $	��Top=�6l   $��24��6�   $	��128��6�   $��1��6�   �� 5   
   -
   5         ��Name$ btnDodavanje��5      $��Dodaj ��6'   $
��Left=�5      $��
10,336,0,0q�6   $	��Top=�62   $��75��6J   6U   �� 5   
   -   5        $ 	btnIzmena��5      $��Izmena��6$   $
��Left=�65   $��229,336,0,0q�6P   $	��Top=�6e   $��75��6}   6�   �� 5   
   -   5        $ btnBrisanje��5      $��Izbrisi��6&   $
��Left=�68   $��
78,336,0,0q�6S   $	��Top=�6g   $��75��6   $��1��6�   5      5      