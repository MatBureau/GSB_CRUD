   M S B A M L   `   `   `  ????C  ?DLL_Vues, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:DLL_Vues.fenetresDLL_Vues.fenetres  5   	   *    $DLL_Vues.fenetres.FEN_Interlocuteurs   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:DLL_Vues.fenetres     5   	   -   5          ? Title$  FEN_Interlocuteurs??5   	   $	??550??6$   $
??1000??61    ? WindowStartupLocation$ CenterScreen=?6>    ? WindowStyle$
 None=?6c    ? 
ResizeMode$ NoResize=?6v   
??????  ? AllowsTransparency$
 True??6?   .??5	      ? .+?5
   
   ?? ???#234E70 ?? CornerRadius$ 25??6&   $??3q?68   
??????? ?? Padding$ 0q?6i   6w   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DTG_Interloc??5      $??46,64,46,31q?6)      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6>   	   AutoGenerateColumns$	 False??6f   ??6N   ?? 
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Code de l'interlocuteur??6K   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ?? *CodeInterlocuteur+6K     5      $ Nom de l'interlocuteur??6J    6%   ?? *NomInterlocuteur+6J   5      ?? 5   
   -   5         ??Name$ BTN_Back??5      $
??Left=?6#   $??	18,13,0,0q?6>   $	??Top=?6Q   ???	#FFF95A4A$??27??6?   $??40??6?   6?   (? 5   
   $??20,14,942,510q?6   .??5      ?? $??26??6   $??24??6    .+?5      F? 
???   ??????@o@@o@?@f@o@?@f`?? ?@fP?? pq? ??? `?? ??? ??ا ??? ??ا ??? ? 	=  z ??ا ?? ??ا ??[ ?`?? ??[ ?@*??[ @o@?Ҏ @o@`?? ?@o@@o@	6$   5      5      ?? 5   
   -   5         ??Name$ 
LBL_Bureau??5      $??Liste des interlocuteurs??6$   $??Center=?6G   $??	0,-10,0,0q?6d   $	??Top=?6w   $??48(?6?   ???	#FFFBF8BE6?   5      5      