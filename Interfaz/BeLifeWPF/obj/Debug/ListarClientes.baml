   M S B A M L   `   `   `  ����D  @BeLifeWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:BeLifeWPF	BeLifeWPF  5      H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5          BeLifeWPF.ListarClientes   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:BeLifeWPF     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5        N� Title$  ListarClientes��5
      .��5      � .+�5   
   �� $&�� SEGUROS BELIFE - LISTAR CLIENTES��6   $��30(�6;   $��395,50,165,0q�6I   $	��Top=�6_   $
��Bold"�6w   �� 5   
   -   5         ��Name$ TxtRutFiltro��5      $
��Left=�6(   $��35��6C   $��230,125,0,0q�6O    �� TextWrapping$
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��150��6�   $��15(�6�   �� 5   
   $
��Rut:��6   $��15(�6   $
��Left=�6-   $��190,125,0,0q�6H   $	��Top=�6]   $��35��6u   $��40��6�   �� 5   
   $��Sexo:��6   $��15(�6    $
��Left=�6.   $��410,125,0,0q�6I   $	��Top=�6^   $��35��6v   $��45��6�   �� 5   
   -   5         ��Name$ ComboSexoFiltro��5      $
��Left=�6,   $��460,125,0,0q�6G   $	��Top=�6\   $	��135��6t   $��35��6�   �� 5   
   $��Estado Civil:��6   $��15(�6(   $
��Left=�66   $��645,125,0,0q�6Q   $	��Top=�6f   $��35��6~   $��90��6�   �� 5   
   -   5        $ ComboEstCivilFiltro��5      $
��Left=�60   $��735,125,0,0q�6K   $	��Top=�6`   $	��150��6x   $��35��6�    J� RenderTransformOrigin$ 0.633,0.429&�6�   �� 5   
   -   5         ��Name$ 
BtnFiltrar��5      $��Filtrar��6%   $
��Left=�67   $��935,125,0,0q�6R   $	��Top=�6g   $	��110��6   $��35��6�      AccentedSquareButtonStyle#��[  6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DtgClientes��5         AutoGenerateColumns .     
IsReadOnly . 	   CanUserReorderColumns	 .  
   CanUserResizeColumns
 .  $
��Left=�6�   $	��490��6�   $��190,205,0,0q�6�   $	��Top=�6�   $	��855��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	 Rut��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6J   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *Rut+6J     5      $ Nombres��6%   $	 150 6R    66   �� *	Nombres+6R     5      $ 	Apellidos��6%   $	 150 6V    68   �� *	Apellidos+6V     5      $ Fecha Nacimiento��6%    6?   �� *FechaNacimiento+ �� StringFormat$ d��4  .System.Windows.Controls.DataGridTemplateColumn  5      $
 Sexo��6)   $	 100 67      CellTemplate 5      �� 5      .R�5      �� ��5   "   �� 5    &    �� 
TargetType" ��6,   .�5!   *   ��  �� Property � �� �� Value$ Hombre��6A    �� Triggers 5"   *   �� 5#   .    �� Binding 6:   �� *IdSexo+ �� Value 26U   .a�5$   2   ��  � ��$ Mujer��6I   5%   /   5'   '   5)      5*      5,        5.      $ Estado Civil��6)   $	 100 6?    5/      �� 50      .R�51      �� ��52   "   �� 53   &   " ��6,   .�54   *   ��  � ��$ Soltero��6A    55   *   �� 56   .    6:   �� *IdEstadoCivil+ 26\   .a�57   2   ��  � ��$ Casado��6I   58   /   �� 5:   .    6:   �� *IdEstadoCivil+ 36\   .a�5;   2   ��  � ��$ 
Divorciado��6I   5<   /   �� 5>   .    6:   �� *IdEstadoCivil+ 46\   .a�5?   2   ��  � ��$ Viudo��6I   5@   /   5C   '   5E      5F      5H      5L      5M      5N      