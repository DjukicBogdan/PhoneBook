   M S B A M L   `   `   `  ���� D  @PhoneBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:PhoneBook	PhoneBook      PhoneBook.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:PhoneBook       � Title$  
Phone book��$	��465��$	��800�� � Icon$ phone_book.ico��.��� 
�������$��Stretch=�$��Stretch=�.+�&   System.Windows.Controls.DataGrid  -     Name$ DatagridList��   HeadersVisibility$ Column=�   CanUserAddRows .     AutoGenerateColumns .     AlternatingRowBackground
 ����� �� AlternationCount$ 2��$
��Left=�$	��356��$��	10,10,0,0q�$	��Top=�$	��772������ *	Persons+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn	   Header$	 Id��1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 �� *Id+  $
	 Name��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 
 �� *Name+  $	 Phone��$ * 
 �� *Phone+  $	 Mobile��$ * 
 �� *Mobile+  $	 Email��$ * 
 �� *Email+  $	 Address��$ * 
 �� *	Address+�� -    ��Name$ 	ButtonNew��$	��New��
���/���$
��Left=�$��492,391,0,0q�$	��Top=�$��75���� -   $ ButtonDelete��$��Delete��
���  ��$
��Left=�$��694,391,0,0q�$	��Top=�$��75���� -    ��Name$ TextBoxSearch��$
��Left=�$��20��$��
22,391,0,0q� �� TextWrapping$
 Wrap=�$��	Search...��$	��Top=�$	��215���� -   $ 
ButtonEdit��$
��Edit��
��� ���$
��Left=�$��597,391,0,0q�$	��Top=�$��75��