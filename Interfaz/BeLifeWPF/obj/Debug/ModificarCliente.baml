   M S B A M L   `   `   `  ����D  @BeLifeWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:BeLifeWPF	BeLifeWPF  5      H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5           BeLifeWPF.ModificarCliente   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:BeLifeWPF     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5        N� Title$  ModificarCliente��5
      .��5      � .+�5   
   �� $)��#SEGUROS BELIFE - MODIFICAR CLIENTES��6   $��30(�6>   $��395,50,100,0q�6L   $	��Top=�6b   $
��Bold"�6z   �� 5   
   -   5         ��Name$ TxtRut��5      $
��Left=�6"   $��36��6=   $��250,159,0,0q�6I    �� TextWrapping$
 Wrap=�6^   $	��Top=�6r   $	��165��6�   �� 5   
   -   5        $ 	TxtNombre��5      $
��Left=�6%   $��36��6@   $��250,241,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $	��240��6�   �� 5   
   -   5        $ TxtApellidos��5      $
��Left=�6(   $��36��6C   $��250,324,0,0q�6O   $
 Wrap=�6d   $	��Top=�6x   $	��240��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 
DtFechaNac��5      $
��Left=�6)   $��250,409,0,0q�6D   $	��Top=�6Y   $	��165��6q   $��36��6}    J� RenderTransformOrigin$ 0.484,0.972&�6�   �� 5   
   -   5         ��Name$ 	ComboSexo��5      $
��Left=�6&   $��250,489,0,0q�6A   $	��Top=�6V   $	��135��6n   $��36��6z   �� 5   
   -   5        $ ComboEstCivil��5      $
��Left=�6*   $��415,489,0,0q�6E   $	��Top=�6Z   $	��135��6r   $��36��6~   �� 5   
   $
��Rut:��6   $
��Left=�6   $��15(�6:   $��250,128,0,0q�6H   $	��Top=�6]   $��40��6u   �� 5   
   $��Nombres:��6   $
��Left=�6#   $��15(�6>   $��250,211,0,0q�6L   $	��Top=�6a   $��80��6y   �� 5   
   $��
Apellidos:��6   $
��Left=�6%   $��15(�6@   $��250,294,0,0q�6N   $	��Top=�6c   $��80��6{   �� 5   
   $��Fecha de Nacimiento:��6   $
��Left=�6/   $��15(�6J   $��250,379,0,0q�6X   $	��Top=�6m   $	��155��6�   �� 5   
   $��Sexo:��6   $
��Left=�6    $��15(�6;   $��250,459,0,0q�6I   $	��Top=�6^   $��80��6v   �� 5   
   $��Estado Civil:��6   $
��Left=�6(   $��15(�6C   $��415,459,0,0q�6Q   $	��Top=�6f   $��90��6~   �� 5   
   -   5         ��Name$ BtnModificar��5      $��	Modificar��6'   $
��Left=�6;   $��250,568,0,0q�6V   $	��Top=�6k   $	��120��6�      AccentedSquareButtonStyle#��[  6�   $��34��6�   6�   �� 5   
   -   5        $ BtnBuscarCliente��5      $��Buscar Cliente��6+   $
��Left=�6D   $��495,159,0,0q�6_   $	��Top=�6t   $	��120��6�   #��[  6�   $��36��6�   6�   #  MahApps.Metro.Controls.Flyout  5   
   -	   5          Name$ FlyBuscarCliente��5   2   $��Buscar Cliente��6   $��	80,25,0,0q�6L      Position$ Right=�6_   .��5      � .+�5      �� -
   5        $ TxtRutBuscar��5      $
��Left=�60   $��36��6K   $��	65,65,0,0q�6W   $
 Wrap=�6j   $�� ��6~   $	��Top=�6�   $	��150��6�   $��15(�6�   �� 5       $	��Rut��6   $
��Left=�6&   $��	27,65,0,0q�6A   $	��Top=�6T   $��15(�6l   $ 0.545,0.533&�6z   �� 5!      $
��Sexo��6   $
��Left=�6'   $��
250,65,0,0q�6B   $	��Top=�6V   $��15(�6n   $ 0.545,0.533&�6|   �� 5"      -   5        $ ComboSexoBuscar��5"      $
��Left=�64   $��
296,65,0,0q�6O   $	��Top=�6c   $	��120��6{   $��30��6�   �� 5#      $��Estado Civil��6   $
��Left=�6/   $��
459,65,0,0q�6J   $	��Top=�6^   $��15(�6v   $ 0.545,0.533&�6�   �� 5$      -   5        $ ComboEstCivilBuscar��5$      $
��Left=�68   $��
550,65,0,0q�6S   $	��Top=�6g   $	��129��6   $��30��6�   �� 5%      -   5        $ 
BtnFiltrar��5%      $��Filtrar��6-   $
��Left=�6?   $��
740,65,0,0q�6Z   $	��Top=�6n   $	��100��6�   $��30��6�   $ 0.467,0.367&�6�   #��[  6�   6�   &   System.Windows.Controls.DataGrid  5&      -   5        	  Name$	 DtgClientes��5&      
   AutoGenerateColumns
 .     
IsReadOnly . $
��Left=�6^   $	��420��6y   $��
27,165,0,0q�6�   $	��Top=�6�   $	��813��6�      CanUserReorderColumns .     Columns 5'      4  .System.Windows.Controls.DataGridTemplateColumn  5(         CellTemplate 5)      �� 5*   "   .R�5+   &   �� -   5        .��5+   J   Seleccionar6W   5,   #   5.      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn   Header$	 Rut��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *Rut+6R     50      $ Nombres��6-   $	 150 6Z    6>   �� *	Nombres+6Z     51      $ 	Apellidos��6-   $	 150 6^    6@   �� *	Apellidos+6^     52      $ Fecha Nacimiento��6-    6G   �� *FechaNacimiento+ �� StringFormat$ d��  53      $
 Sexo��61   $	 100 6?    54      �� 55   "   .R�56   &   �� ��57   *   �� 58   .    �� 
TargetType" ��64   .�59   2   ��  �� Property � �� �� Value$ Hombre��6I    �� Triggers 5:   2   �� 5;   6    �� Binding 6B   �� *IdSexo+ �� Value 26]   .a�5<   :   ��  � ��$ Mujer��6Q   5=   7   5?   /   5A   '   5B   #   5D        5F      $ Estado Civil��61   $	 100 6G    5G      �� 5H   "   .R�5I   &   �� ��5J   *   �� 5K   .   " ��64   .�5L   2   ��  � ��$ Soltero��6I    5M   2   �� 5N   6    6B   �� *IdEstadoCivil+ 26d   .a�5O   :   ��  � ��$ Casado��6Q   5P   7   �� 5R   6    6B   �� *IdEstadoCivil+ 36d   .a�5S   :   ��  � ��$ 
Divorciado��6Q   5T   7   �� 5V   6    6B   �� *IdEstadoCivil+ 46d   .a�5W   :   ��  � ��$ Viudo��6Q   5X   7   5[   /   5]   '   5^   #   5`      5d      5h      5i      5j      5k      