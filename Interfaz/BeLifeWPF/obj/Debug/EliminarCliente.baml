   M S B A M L   `   `   `  ����D  @BeLifeWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:BeLifeWPF	BeLifeWPF  5      H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5          BeLifeWPF.EliminarCliente   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:BeLifeWPF     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5        N� Title$  EliminarCliente��5
      .��5      � .+�5   
   �� $(��"SEGUROS BELIFE - ELIMINAR CLIENTES��6   $��30(�6=   $��395,50,120,0q�6K   $	��Top=�6a   $
��Bold"�6y   �� 5   
   -   5         ��Name$ TxtRut��5      $��15(�6"   $
��Left=�60   $��35��6K   $��325,285,0,0q�6W    �� TextWrapping$
 Wrap=�6l   $�� ��6�   $	��Top=�6�   $	��170��6�   �� 5   
   $��Rut Cliente��6   $��15(�6&   $
��Left=�64   $��240,285,0,0q�6O   $	��Top=�6d   $��35��6|   �� 5   
   -   5         ��Name$ BtnEliminarCliente��5      $��Eliminar��6-   $��15(�6@   $
��Left=�6N   $��240,380,0,0q�6i   $	��Top=�6~   $	��115��6�   $��35��6�      AccentedSquareButtonStyle#��[  6�   6�   �� 5   
   -   5        $ BtnBuscarCliente��5      $��Buscar Cliente��6+   $��15(�6D   $
��Left=�6R   $��380,380,0,0q�6m   $	��Top=�6�   $	��115��6�   $��35��6�   #��[  6�   #  MahApps.Metro.Controls.Flyout  5   
   -   5          Name$ FlyBuscarCliente��5   2   $��Buscar Cliente��6   $��	80,25,0,0q�6L      Position$ Right=�6_   .��5      � .+�5      �� -   5        $ TxtRutBuscar��5      $
��Left=�60   $��36��6K   $��	65,65,0,0q�6W   $
 Wrap=�6j   $�� ��6~   $	��Top=�6�   $	��150��6�   $��15(�6�   �� 5      $	��Rut��6   $
��Left=�6&   $��	27,65,0,0q�6A   $	��Top=�6T   $��15(�6l    J� RenderTransformOrigin$ 0.545,0.533&�6z   �� 5      $
��Sexo��6   $
��Left=�6'   $��
250,65,0,0q�6B   $	��Top=�6V   $��15(�6n   $ 0.545,0.533&�6|   �� 5      -   5         ��Name$ ComboSexoBuscar��5      $
��Left=�64   $��
296,65,0,0q�6O   $	��Top=�6c   $	��120��6{   $��30��6�   �� 5      $��Estado Civil��6   $
��Left=�6/   $��
459,65,0,0q�6J   $	��Top=�6^   $��15(�6v   $ 0.545,0.533&�6�   �� 5      -   5        $ ComboEstCivilBuscar��5      $
��Left=�68   $��
550,65,0,0q�6S   $	��Top=�6g   $	��129��6   $��30��6�   �� 5      -   5        $ 
BtnFiltrar��5      $��Filtrar��6-   $
��Left=�6?   $��
740,65,0,0q�6Z   $	��Top=�6n   $	��100��6�   $��30��6�   $ 0.467,0.367&�6�   #��[  6�   &   System.Windows.Controls.DataGrid  5      -	   5          Name$ DtgClientes��5      	   CanUserReorderColumns	 .  $
��Left=�6N   $	��420��6i   $��
27,165,0,0q�6v   $	��Top=�6�   $	��813��6�   
   
IsReadOnly
 .    Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5         CellTemplate 5       �� 5!   "   .R�5"   &   �� -
   5        .��5"   J   Seleccionar6W   5#   #   5%      0  *System.Windows.Controls.DataGridTextColumn  5&      ,  &System.Windows.Controls.DataGridColumn   Header$	 Rut��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *Rut+6R     5'      $ Nombres��6-   $	 150 6Z    6>   �� *	Nombres+6Z     5(      $ 	Apellidos��6-   $	 150 6^    6@   �� *	Apellidos+6^     5)      $ Fecha Nacimiento��6-    6G   �� *FechaNacimiento+ �� StringFormat$ d��  5*      $
 Sexo��61   $	 100 6?    5+      �� 5,   "   .R�5-   &   �� ��5.   *   �� 5/   .    �� 
TargetType" ��64   .�50   2   ��  �� Property � �� �� Value$ Hombre��6I    �� Triggers 51   2   �� 52   6    �� Binding 6B   �� *IdSexo+ �� Value 26]   .a�53   :   ��  � ��$ Mujer��6Q   54   7   56   /   58   '   59   #   5;        5=      $ Estado Civil��61   $	 100 6G    5>      �� 5?   "   .R�5@   &   �� ��5A   *   �� 5B   .   " ��64   .�5C   2   ��  � ��$ Soltero��6I    5D   2   �� 5E   6    6B   �� *IdEstadoCivil+ 26d   .a�5F   :   ��  � ��$ Casado��6Q   5G   7   �� 5I   6    6B   �� *IdEstadoCivil+ 36d   .a�5J   :   ��  � ��$ 
Divorciado��6Q   5K   7   �� 5M   6    6B   �� *IdEstadoCivil+ 46d   .a�5N   :   ��  � ��$ Viudo��6Q   5O   7   5R   /   5T   '   5U   #   5W      5\      5^      5_      5`      5a      