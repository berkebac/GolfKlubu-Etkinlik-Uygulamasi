   M S B A M L   `   `   `  ����=  956, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:_56.Models
_56.Models  5          _56.Models.SorguListesi   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:_56.Models     5        N� Title$  SorguListesi��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   �� -   5         ��Name$ cmbsorgu��5      $��16(�6R   $
��Bold"�6`   .@�5      �� $)��#K Harfiyle başlıyan Golf Klupleri��6   �� 5      $D��>Kapasitesi 400'den Fazla Olan Golf Kluplerindeki Çalışanlar��6   �� 5      $0��*FAX numarası Girilmiş Kluplerin Üyeleri��6   �� 5      $D��>Yaş Sınırı 18 Olan Aktiviteler ve Yapıldığı Bölümler��6   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgList��5      $��1��6#      
IsReadOnly .    RowStyle 5      �� 5       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5      ��  �� Property � �� �� Value$ 20(�61   6>   �� 5       � ��$
 Bold"�63   6B   �� 5       � ��
 �   �6C   	 �� Triggers	 5      P� 5      
 P� Property
 �@J�IsMouseOver P� Value . . �5       ��  � �� �	#FF28AAAA6;   5!      5#      5%      5'      5(      