   M S B A M L   `   `   `  ????C  ?DLL_Vues, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:DLL_Vues.fenetresDLL_Vues.fenetres  5   	   $    DLL_Vues.fenetres.FEN_Contrats   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:DLL_Vues.fenetres     5   	   -   5          ? Title$  FEN_Contrats??5   	   $	??550??6   $
??1000??6+    ? WindowStartupLocation$ CenterScreen=?68    ? WindowStyle$
 None=?6]    ? 
ResizeMode$ NoResize=?6p   
??????  ? AllowsTransparency$
 True??6?   .??5	      ? .+?5
   
   ?? ???#234E70 ?? CornerRadius$ 25??6&   $??3q?68   
??????? ?? Padding$ 0q?6i   6w   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DTG_Contrats??5      $??46,64,46,31q?6)      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6>   	   AutoGenerateColumns$	 False??6f   ??6N   ?? 
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Reférence du contrat??6D   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ?? *
RefContrat+6D     5      $ Objet??6F    6%   ?? *ObjetContrat+6F     5      $
 Date??6E    6%   ?? *DateContrat+6E     5      $ Taux de commission??6H    6%   ?? *TauxCommission+6H     5      $ Montant du contrat??6H    6%   ?? *MontantContrat+6H     5      $ Code Bureau??6D    6%   ?? *
CodeBureau+6D     5      $ Code interlocuteur??6K    6%   ?? *CodeInterlocuteur+6K     5      $ Code client??6D    6%   ?? *
CodeClient+6D   5      ?? 5   
   -   5         ??Name$ BTN_Back??5      $
??Left=?6#   $??	18,13,0,0q?6>   $	??Top=?6Q   ???	#FFF95A4A$??27??6?   $??40??6?   6?   (? 5   
   $??20,14,943,510q?6   .??5      ?? $??26??6   $??24??6    .+?5      F? 
???   ??????@o@@o@?@f@o@?@f`?? ?@fP?? pq? ??? `?? ??? ??ا ??? ??ا ??? ? 	=  z ??ا ?? ??ا ??[ ?`?? ??[ ?@*??[ @o@?Ҏ @o@`?? ?@o@@o@	6$   5      5      ?? 5   
   -   5         ??Name$ 
LBL_Bureau??5      $??Liste des contrats??6$   $??Center=?6A   $??	0,-10,0,0q?6^   $	??Top=?6q   $??48(?6?   ???	#FFFBF8BE6?   5      5       