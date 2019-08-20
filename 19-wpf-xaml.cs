// ---------- WpfTutorial ----------

// ---------- MainWindow.xaml.cs ----------

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
using Microsoft.Win32;

// Windows Presentation Foundation (WPF)
// is used to create graphical user interfaces
// of a traditional format or within a
// browser (XAML Browser Based App / XBAP)

// Using XAML eXtensible Application Markup Language
// you can create the UI using XML
// XAML allows you to define buttons, boxes,
// animations, 2d / 3d graphics and more

// Create a New Project -> Visual C# -> Windows
// Classic Desktop -> WPF App

namespace WpfTut
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string usersName = "";

        public MainWindow()
        {
            // Initializes and displays the window
            InitializeComponent();

            // You can set window properties in code
            this.Title = "Hello World";
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        // When the button is clicked it closes the window
        private void Button1Clicked(object sender, RoutedEventArgs e)
        {
            // Opens a message box
            MessageBox.Show("The App is Closing");

            // Closes the app
            this.Close();
        }

        // Event handling that posts the mouse x, y position in title
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Title = e.GetPosition(this).ToString();
        }

        private void BtnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            // Opens an open file dialog
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.ShowDialog();
        }

        private void BtnSaveFile_Click(object sender, RoutedEventArgs e)
        {
            // Opens a save file dialog
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.ShowDialog();
        }

        private void Send_Button_Click(object sender, RoutedEventArgs e)
        {
            //usersName = UsersName.Text;

            //MessageBox.Show($"Hello {usersName}");
        }
    }
}

// ---------- MainWindow.xaml ----------

<!-- x:Class defines what code handles events -->
<!-- You can define the title, size, whether it can resize,
    Whether it automatically resizes for content, whether
    it stays on top, whether it starts minimized or maximized,
    and an icon -->
<Window x:Class="WpfTut.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfTut"
        xmlns:sys="clr-namespace:System;assembly=mscorlib"
        mc:Ignorable="d"
        Title="Hello WPF" Height="350" Width="525" ResizeMode="NoResize" SizeToContent="WidthAndHeight" Topmost="False" WindowState="Normal"
        Icon="./Resources/favicon.ico" MouseMove="Window_MouseMove">

    <!-- You can store data as a resource and reuse it by adding this
    xmlns:sys="clr-namespace:System;assembly=mscorlib" -->
    <Window.Resources>
        <sys:String x:Key="strHelloAgain">Hello Again</sys:String>
        
        <!-- You can define default styling of
        components -->
        <Style TargetType="Button">
            <Setter Property="Margin" Value="1"/>
            <Setter Property="FontSize" Value="20"/>
            <Setter Property="VerticalContentAlignment" Value="Center"/>
            <Setter Property="FontFamily" Value="Consolas"/>
        </Style>
    </Window.Resources>

    <!-- This is the layout manager of which
    there are many including Grid, Canvas,
    and DockPanel -->
    <StackPanel Orientation="Vertical">
        <!-- This is where your content goes -->
        <TextBlock HorizontalAlignment="Center" TextWrapping="Wrap" Text="Hello World" VerticalAlignment="Top" FontSize="40"/>
        
        <!-- Resource used here -->
        <TextBlock Text="{StaticResource strHelloAgain}" FontSize="40" HorizontalAlignment="Center"/>

        <!-- This creates a button and calls an event handler -->
        <!-- You can see a list of all events by clicking the
        lightning bolt in properties -->
        <Button x:Name="Button1" Height="40" Width="90" HorizontalAlignment="Center" Content="Close Window" Click="Button1Clicked" />

        <!-- Opens the open file dialog -->
        <Button x:Name="BtnOpenFile" Height="40" Width="90" HorizontalAlignment="Center" Content="Open File" Click="BtnOpenFile_Click" />

        <!-- Opens the save file dialog -->
        <Button x:Name="BtnSaveFile" Height="40" Width="90" HorizontalAlignment="Center" Content="Save File" Click="BtnSaveFile_Click" />
    </StackPanel>
</Window>

// ---------- Using Canvas ----------

<!-- This is the Canvas layout manager and it allows
    you to place components absolutely and they don't
    dynamically resize -->
    <Canvas Background="Gray" Height="350" Width="525">
            <Label Content="Name" Canvas.Left="10" Canvas.Top="10"/>
            <TextBox Name="UsersName" Height="23" Canvas.Left="66" TextWrapping="Wrap" Text="Enter name" Canvas.Top="12" Width="159"/>
            <Button Content="Send" Canvas.Left="242" Canvas.Top="13" Width="75" Click="Send_Button_Click"/>

    </Canvas>
    
// ---------- Using WrapPanel ----------

<!-- A WrapPanel allows components to flow
    as the window is resized (Most times a 
    WrapPanel is only used as a subelement
    <WrapPanel Background="Gray" Orientation="Horizontal">
        <Label Content="Name"/>
        <TextBox Name="UsersName" Text="Enter Name" Width="159"/>
        <Button Content="Send" Width="75" Click="Send_Button_Click"/>
    </WrapPanel>
    -->
    
// ---------- Using Grid ----------

<!-- A Grid Panels are very flexible because
    everything is placed in a cell in columns
    and rows 
    You add rows and columns by adding RowDefinitions
    and ColumnDefinitions that have heights that
    are fixed, Auto (Takes space needed by component),
    or * (Takes space available)-->
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="*" />
            <RowDefinition Height="*" />
            <RowDefinition Height="*" />
            <RowDefinition Height="*" />
            <RowDefinition Height="*" />
            <RowDefinition Height="*" />
        </Grid.RowDefinitions>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*" />
            <ColumnDefinition Width="*" />
            <ColumnDefinition Width="*" />
            <ColumnDefinition Width="*" />
        </Grid.ColumnDefinitions>
        <!-- Define where component starts and the 
        number of columns it spans -->
        <TextBox Grid.Row="0" Grid.Column="0" Margin="2,5" Grid.ColumnSpan="4"/>
        <Button Content="7" HorizontalAlignment="Left" Grid.Row="1" VerticalAlignment="Top" Width="131" Height="51"/>
        <Button Content="8" Grid.Column="1" HorizontalAlignment="Left" Grid.Row="1" VerticalAlignment="Top" Width="131" Height="51"/>
        <Button Content="9" Grid.Column="2" HorizontalAlignment="Left" Grid.Row="1" VerticalAlignment="Top" Width="131" Height="51"/>
        <Button Content="+" Grid.Column="3" HorizontalAlignment="Left" Grid.Row="1" VerticalAlignment="Top" Width="131" Height="51"/>

        <Button Content="4" Grid.Column="0" HorizontalAlignment="Left" Grid.Row="2" VerticalAlignment="Top" Width="131" Height="51"/>
        <Button Content="5" Grid.Column="1" HorizontalAlignment="Left" Grid.Row="2" VerticalAlignment="Top" Width="131" Height="51"/>
        <Button Content="6" Grid.Column="2" HorizontalAlignment="Left" Grid.Row="2" VerticalAlignment="Top" Width="131" Height="51"/>
        <Button Content="-" Grid.Column="3" HorizontalAlignment="Left" Grid.Row="2" VerticalAlignment="Top" Width="131" Height="51"/>

        <Button Content="1" Grid.Column="0" HorizontalAlignment="Left" Grid.Row="3" VerticalAlignment="Top" Width="131" Height="51"/>
        <Button Content="2" Grid.Column="1" HorizontalAlignment="Left" Grid.Row="3" VerticalAlignment="Top" Width="131" Height="51"/>
        <Button Content="3" Grid.Column="2" HorizontalAlignment="Left" Grid.Row="3" VerticalAlignment="Top" Width="131" Height="51"/>
        <Button Content="*" Grid.Column="3" HorizontalAlignment="Left" Grid.Row="3" VerticalAlignment="Top" Width="131" Height="51"/>

        <Button Content="C" Grid.Column="0" HorizontalAlignment="Left" Grid.Row="4" VerticalAlignment="Top" Width="131" Height="51"/>
        <Button Content="0" Grid.Column="1" HorizontalAlignment="Left" Grid.Row="4" VerticalAlignment="Top" Width="131" Height="51"/>
        <Button Content="=" Grid.Column="2" HorizontalAlignment="Left" Grid.Row="4" VerticalAlignment="Top" Width="131" Height="51"/>
        <Button Content="/" Grid.Column="3" HorizontalAlignment="Left" Grid.Row="4" VerticalAlignment="Top" Width="131" Height="51"/>
    </Grid>
