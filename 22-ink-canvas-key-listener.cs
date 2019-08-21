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

    <Grid>
        <!-- You can add more tabs by right clicking
        the top of the tabs and select Add Tab -->

        <TabControl Height="319" VerticalAlignment="Top" Width="515">
            <TabItem Header="Calendar">
                <Grid Background="#FFE5E5E5">
                    <!-- Drag a Calendar and TextBox on a tab
                    You can customize the calendar -->

                    <Calendar Name="MyCalendar" HorizontalAlignment="Left" Margin="10,10,0,0" VerticalAlignment="Top" Height="171" Width="184"
                      Background="AliceBlue" DisplayMode="Month" DisplayDateStart="3/1/2017" DisplayDateEnd="3/31/2017" FirstDayOfWeek="Monday" IsTodayHighlighted="True" SelectedDatesChanged="MyCalendar_SelectedDatesChanged" >

                        <!-- You can X out date ranges -->
                        <Calendar.BlackoutDates>
                            <CalendarDateRange Start="3/1/2017" End="3/8/2017"/>
                        </Calendar.BlackoutDates>

                        <Calendar.SelectedDates>
                            <sys:DateTime>3/25/2017</sys:DateTime>
                        </Calendar.SelectedDates>
                    </Calendar>
                    <TextBox Name="tbDateSelected" HorizontalAlignment="Left" Height="23" Margin="227,14,0,0" TextWrapping="Wrap" VerticalAlignment="Top" Width="120"/>
                </Grid>
            </TabItem>
            <TabItem Header="Draw" KeyUp="DrawPanel_KeyUp">
                <!-- Open your Document outline on the left 
                and change the tab layout type from Grid
                to StackPanel -->

                <StackPanel Background="#FFE5E5E5" Margin="0,-2,0,2">
                    <!-- Click toolbar and in Properties 
                    -> Common -> Items and add 3 radio buttons
                    for Common -> Content name them Draw,
                    Erase, and Select Set border brush RGB
                    to 210 each and change width to 80 and height
                    to 50 
                    Select all buttons with Shift and then change
                    the GroupName in properties to DrawGroup 
                    Right click the Toolbox -> Choose Items ->
                    put a check in InkCanvas 
                    Drag an InkCanvas on your tab 
                    Add the same click event name to buttons
                    DrawButton_Click -->

                    <ToolBar Name="drawingToolbar" Height="50">
                        <RadioButton Name="DrawButton" Click="DrawButton_Click" BorderBrush="#FFD2D2D2" Content="Draw" Height="50" Width="80" GroupName="DrawGroup"/>
                        <RadioButton Name="EraseButton" Click="DrawButton_Click" BorderBrush="#FFD2D2D2" Content="Erase" Height="50" Width="80" GroupName="DrawGroup"/>
                        <RadioButton Name="SelectButton" Click="DrawButton_Click" BorderBrush="#FFD2D2D2" Content="Select" Height="50" Width="80" GroupName="DrawGroup"/>
                        <Button BorderBrush="#FFD2D2D2" Content="Save" Height="50" Width="80" Click="SaveButton_Click"/>
                        <Button BorderBrush="#FFD2D2D2" Content="Open" Height="50" Width="80" Click="OpenButton_Click"/>

                    </ToolBar>
                    <InkCanvas Name="DrawingCanvas" Height="241">
                        <InkCanvas.DefaultDrawingAttributes>
                            <DrawingAttributes x:Name="strokeAttr" Width="3" Height="3" Color="black"/>
                        </InkCanvas.DefaultDrawingAttributes>
                    </InkCanvas>
                </StackPanel>
            </TabItem>
            <TabItem Header="TabItem" HorizontalAlignment="Left" Height="20" VerticalAlignment="Top" Width="54">
                <Grid Background="#FFE5E5E5"/>
            </TabItem>
            <TabItem Header="TabItem" HorizontalAlignment="Left" Height="20" VerticalAlignment="Top" Width="54">
                <Grid Background="#FFE5E5E5"/>
            </TabItem>
        </TabControl>

    </Grid>


</Window>


// ---------- MainWindow.xaml.cs ----------

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
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

        private void MyCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get a reference to the calendar
            var calendar = sender as Calendar;

            // Check that it has a value 
            if (calendar.SelectedDate.HasValue)
            {
                // Display the date
                DateTime date = calendar.SelectedDate.Value;
                try { 
                tbDateSelected.Text = date.ToShortDateString();
                }
                catch (NullReferenceException)
                {
                    // Needed for a bug that is triggered during
                    // initialization
                }
            }
            
        }

        private void DrawButton_Click(object sender, RoutedEventArgs e)
        {
            // Get a reference to the radiobutton
            var radiobutton = sender as RadioButton;

            // Get the radiobutton pressed
            string radioBPressed = radiobutton.Content.ToString();

            // Change settings based on button
            if(radioBPressed == "Draw")
            {
                this.DrawingCanvas.EditingMode = InkCanvasEditingMode.Ink;
            } else if(radioBPressed == "Erase")
            {
                this.DrawingCanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
            } else if(radioBPressed == "Select")
            {
                this.DrawingCanvas.EditingMode = InkCanvasEditingMode.Select;
            }
        }

        private void DrawPanel_KeyUp(object sender, KeyEventArgs e)
        {
            if ((int)e.Key >= 35 && (int)e.Key <= 68)
            {
                switch ((int)e.Key)
                {
                    case 35:
                        strokeAttr.Width = 2;
                        strokeAttr.Height = 2;
                        break;
                    case 36:
                        strokeAttr.Width = 4;
                        strokeAttr.Height = 4;
                        break;
                    case 37:
                        strokeAttr.Width = 6;
                        strokeAttr.Height = 6;
                        break;
                    case 38:
                        strokeAttr.Width = 8;
                        strokeAttr.Height = 8;
                        break;
                    case 39:
                        strokeAttr.Width = 10;
                        strokeAttr.Height = 10;
                        break;
                    case 40:
                        strokeAttr.Width = 12;
                        strokeAttr.Height = 12;
                        break;
                    case 41:
                        strokeAttr.Width = 14;
                        strokeAttr.Height = 14;
                        break;
                    case 42:
                        strokeAttr.Width = 16;
                        strokeAttr.Height = 16;
                        break;
                    case 43:
                        strokeAttr.Width = 18;
                        strokeAttr.Height = 18;
                        break;
                    case 45:
                        strokeAttr.Color = (Color)ColorConverter.ConvertFromString("Blue");
                        break;
                    case 50:
                        strokeAttr.Color = (Color)ColorConverter.ConvertFromString("Green");
                        break;
                    case 68:
                        strokeAttr.Color = (Color)ColorConverter.ConvertFromString("Yellow");
                        break;
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using(FileStream fs = new FileStream("MyPicture.bin", FileMode.Create))
            {
                this.DrawingCanvas.Strokes.Save(fs);
            }
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = new FileStream("MyPicture.bin", FileMode.Open, FileAccess.Read))
            {
                StrokeCollection sc = new StrokeCollection(fs);
                this.DrawingCanvas.Strokes = sc;
            }
        }
    }
}
