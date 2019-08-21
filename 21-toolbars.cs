// ---------- WpfTutorial ----------

// ---------- MainWindow.xaml.cs ----------

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTutorial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.ShowDialog();
        }

        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.ShowDialog();
        }

        private void MenuFontTimes_Click(object sender, RoutedEventArgs e)
        {
            menuFontCourier.IsChecked = false;
            menuFontArial.IsChecked = false;
            txtBoxDoc.FontFamily = new FontFamily("Times New Roman");
        }

        private void MenuFontCourier_Click(object sender, RoutedEventArgs e)
        {
            menuFontTimes.IsChecked = false;
            menuFontArial.IsChecked = false;
            txtBoxDoc.FontFamily = new FontFamily("Courier");
        }

        private void MenuFontArial_Click(object sender, RoutedEventArgs e)
        {
            menuFontCourier.IsChecked = false;
            menuFontTimes.IsChecked = false;
            txtBoxDoc.FontFamily = new FontFamily("Arial");
        }

		// ---------- NEW STUFF ----------

        // Used to track if font size combobox is closed
        private bool comboFSClosed = true;

        // Change font size of text box after combo is closed
        private void ComboFontSize_DropDownClosed(object sender, EventArgs e)
        {
            if (comboFSClosed) ChangeTBFontSize();
            comboFSClosed = true;
        }

        // Verify combo is closed and call for font size change
        private void ComboFontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combobox = sender as ComboBox;
            comboFSClosed = !combobox.IsDropDownOpen;
            ChangeTBFontSize();
        }

        private void ChangeTBFontSize()
        {
            // Convert combo font size data to string
            string fontsize = comboFontSize.SelectedItem.ToString();

            // Get the last 2 numbers
            fontsize = fontsize.Substring(fontsize.Length - 2);

            switch (fontsize)
            {
                case "10":
                    txtBoxDoc.FontSize = 10;
                    break;
                case "12":
                    txtBoxDoc.FontSize = 12;
                    break;
                case "14":
                    txtBoxDoc.FontSize = 14;
                    break;
                case "16":
                    txtBoxDoc.FontSize = 16;
                    break;
            }

        }

    }
}


// ---------- MainWindow.xaml ----------

<Window x:Class="WpfTutorial.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfTutorial"
        xmlns:sys="clr-namespace:System;assembly=mscorlib"
        mc:Ignorable="d"
        Title="MainWindow" Height="350" Width="525"  SizeToContent="WidthAndHeight" Topmost="False" WindowState="Normal" Icon="./Resources/favicon.ico">

    <DockPanel>
        <Menu DockPanel.Dock="Top">
            <MenuItem Header="_File">
                <MenuItem x:Name="menuNew" Header="_New" InputGestureText="Ctrl+N">
                    <MenuItem.Icon>
                        <Image Source="./Resources/New.bmp"/>
                    </MenuItem.Icon>
                </MenuItem>
                <MenuItem x:Name="menuOpen" Header="_Open" InputGestureText="Ctrl+O" Click="MenuOpen_Click">
                    <MenuItem.Icon>
                        <Image Source="./Resources/Open.bmp"/>
                    </MenuItem.Icon>
                </MenuItem>
                <MenuItem x:Name="menuSave" Header="_Save" InputGestureText="Ctrl+S" Click="MenuSave_Click">
                    <MenuItem.Icon>
                        <Image Source="./Resources/Save.bmp"/>
                    </MenuItem.Icon>
                </MenuItem>
                <MenuItem x:Name="menuExit" Header="Exit" Click="MenuExit_Click">
                </MenuItem>
                
            </MenuItem>

            <MenuItem Header="_Edit">
                <MenuItem x:Name="menuCut" Header="Cut" Command="ApplicationCommands.Cut" InputGestureText="Ctrl+X"/>
                <MenuItem x:Name="menuCopy" Header="Copy" Command="ApplicationCommands.Copy" InputGestureText="Ctrl+C"/>
                <MenuItem x:Name="menuPaste" Header="Paste" Command="ApplicationCommands.Paste" InputGestureText="Ctrl+V"/>
                <Separator />
                <MenuItem Header="_Font" InputGestureText="Ctrl+F">
                    <MenuItem x:Name="menuFontTimes" Header="Times" IsCheckable="True" StaysOpenOnClick="True" Click="MenuFontTimes_Click"/>
                    <MenuItem x:Name="menuFontCourier" Header="Courier" IsCheckable="True" StaysOpenOnClick="True" Click="MenuFontCourier_Click"/>
                    <MenuItem x:Name="menuFontArial" Header="Arial" IsCheckable="True" StaysOpenOnClick="True" Click="MenuFontArial_Click"/>
                </MenuItem>
                
            </MenuItem>
            
        </Menu>
        
        <!-- ---------- NEW STUFF ---------- -->
        
        <!-- A toolbar provides quick access to tools -->
        <!-- You can also dock on the left or right
        DockPanel.Dock="Right" Orientation="Vertical" -->
        <ToolBarTray DockPanel.Dock="Top">
            <ToolBar>
                <Button x:Name="tbOpen" ToolTip="Open File" Click="MenuOpen_Click">
                    <Image Source="./Resources/Open.bmp"></Image>
                </Button>
                <Button x:Name="tbSave" ToolTip="Save File" Click="MenuSave_Click">
                    <Image Source="./Resources/Save.bmp"></Image>
                </Button>
                <Button x:Name="tbCut" Command="ApplicationCommands.Cut">
                    <Image Source="./Resources/Cut.bmp"></Image>
                </Button>
                <Button x:Name="tbCopy" Command="ApplicationCommands.Copy">
                    <Image Source="./Resources/Copy.bmp"></Image>
                </Button>
                <Button x:Name="tbPaste" Command="ApplicationCommands.Paste">
                    <Image Source="./Resources/Paste.bmp"></Image>
                </Button>
                <Separator />
                <Label>Font size:</Label>
                <ComboBox x:Name="comboFontSize" SelectionChanged="ComboFontSize_SelectionChanged"
                          DropDownClosed="ComboFontSize_DropDownClosed">
                    <ComboBoxItem>10</ComboBoxItem>
                    <ComboBoxItem IsSelected="True">12</ComboBoxItem>
                    <ComboBoxItem>14</ComboBoxItem>
                    <ComboBoxItem>16</ComboBoxItem>
                </ComboBox>

            </ToolBar>
        </ToolBarTray>
        
        
        <TextBox x:Name="txtBoxDoc" Height="290" Width="500" FontSize="12"/>
    </DockPanel>


</Window>
