// ---------- WpfTutorial ----------

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
    
    <!-- Create a menu bar Put _ before the shortcut key 
    which is triggered with Alt - Whatever -->
    <!-- 1. Get the Visual Studio Image Library if you want standard icons
	A. https://www.microsoft.com/en-us/download/details.aspx?id=35825
    B. I got VS2013 Image Library.zip 
    -->
    <DockPanel>
        <Menu DockPanel.Dock="Top">
            <MenuItem Header="_File">
                <MenuItem x:Name="menuNew" Header="_New" InputGestureText="Ctrl+N">
                    <MenuItem.Icon>
                        <Image Source="./Resources/New.bmp" />
                    </MenuItem.Icon>
                </MenuItem>
                <MenuItem x:Name="menuOpen" Header="_Open" InputGestureText="Ctrl+O" Click="MenuOpen_Click">
                    <MenuItem.Icon>
                        <Image Source="./Resources/Open.bmp" />
                    </MenuItem.Icon>
                </MenuItem>
                <MenuItem x:Name="menuSave" Header="_Save" InputGestureText="Ctrl+S" Click="MenuSave_Click">
                    <MenuItem.Icon>
                        <Image Source="./Resources/Save.bmp" />
                    </MenuItem.Icon>
                </MenuItem>
                <Separator />
                <MenuItem x:Name="menuExit" Header="Exit" InputGestureText="Ctrl+F4" Click="MenuExit_Click"/>
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
        <TextBox x:Name="txtBoxDoc" Height="290" Width="500"/>
    </DockPanel>

    <!-- You can create rows and columns in the Grid 
    layout by just clicking the borders -->

    <!-- You can drag a label in a cell, copy 
        and paste some more while changing the margins
        select them and Group Into -> ScrollViewer
        
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="153*"/>
            <ColumnDefinition Width="208*"/>
            <ColumnDefinition Width="156*"/>
        </Grid.ColumnDefinitions>
        <ScrollViewer Grid.Column="2" Margin="0,0,0,193">
            <Grid>
                <Label Content="Label" HorizontalAlignment="Left" VerticalAlignment="Top" Margin="0,0,-17,0"/>
                <Label Content="Label" HorizontalAlignment="Left" VerticalAlignment="Top" Margin="0,25,-17,0"/>
                <Label Content="Label" HorizontalAlignment="Left" VerticalAlignment="Top" Margin="0,50,-17,0"/>
                <Label Content="Label" HorizontalAlignment="Left" VerticalAlignment="Top" Margin="0,75,-17,0"/>
                <Label Content="Label" HorizontalAlignment="Left" VerticalAlignment="Top" Margin="0,100,-17,0"/>

            </Grid>
        </ScrollViewer>

    </Grid>
    -->

    <!-- A DockPanel is normally used as a container
    for other panels 
    <DockPanel>
        <Label x:Name="lblTop" DockPanel.Dock="Top" Content="TOP"/>
        <Label x:Name="lblLeft" DockPanel.Dock="Left" Content="LEFT"/>
        <Label x:Name="lblRight" DockPanel.Dock="Right" Content="RIGHT"/>
        <Label x:Name="lblBottom" DockPanel.Dock="Bottom" Content="BOTTOM"/>
        <Label x:Name="lblCenter" Content="CENTER"/>
    </DockPanel>
    
    -->
</Window>

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

        // Closes the app
        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Opens the open dialog
        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.ShowDialog();
        }

        // Opens the save dialog
        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.ShowDialog();
        }

        // Unchecks other fonts and changes font for the text box
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


    }
}
