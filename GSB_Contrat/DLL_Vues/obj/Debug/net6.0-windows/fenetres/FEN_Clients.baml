   M S B A M L   `   `   `  ????C  ?DLL_Vues, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:DLL_Vues.fenetresDLL_Vues.fenetres  5   	   #    DLL_Vues.fenetres.FEN_Clients   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:DLL_Vues.fenetres     5   	   -   5          ? Title$  FEN_Clients??5   	   $	??550??6   $
??1000??6*    ? WindowStartupLocation$ CenterScreen=?67    ? WindowStyle$
 None=?6\    ? 
ResizeMode$ NoResize=?6o    ? AllowsTransparency$
 True??6?   
?????? .??5	      ? .+?5
   
   ?? ???#234E70 ?? CornerRadius$ 25??6&   $??3q?68   
??????? ?? Padding$ 0q?6i   6w   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DTG_Clients??5      $??46,64,46,31q?6(      AutoGenerateColumns$ False??6U   	   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 * 6q   ??6=   ?? 
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Code Client??6D   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ?? *
CodeClient+6D     5      $ Raison Sociale??6G    6%   ?? *RaisonSociale+6G     5      $ Adresse??6A    6%   ?? *	Adresse+6A   5      ?? 5   
   -   5         ??Name$ BTN_Back??5      $
??Left=?6#   $??	16,13,0,0q?6>   $	??Top=?6Q   ???	#FFF95A4A$??27??6?   $??40??6?   6?   (? 5   
   $??18,15,945,510q?6   .??5      ?? $??24??6   $??24??6    .+?5      F? 
???   ??????@o@@o@?@f@o@?@f`?? ?@fP?? pq? ??? `?? ??? ??ا ??? ??ا ??? ? 	=  z ??ا ?? ??ا ??[ ?`?? ??[ ?@*??[ @o@?Ҏ @o@`?? ?@o@@o@	6$   5      5      ?? 5   
   -   5         ??Name$ LBL_Clients??5      $??Liste des clients??6%   $??Center=?6A   $??	0,-10,0,0q?6^   $	??Top=?6q   $??48(?6?   ???	#FFFBF8BE6?   5      5      