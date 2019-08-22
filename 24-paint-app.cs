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
        <!-- Click the toolbar and select Common -> 
        Items -> ... Set Border Brush RGB to 150
        Height to 50 and Width to 80 Add a Content 
        name for Line, Ellipse and Rectangle for each 
        Select all radiobuttons and give the group name
        ShapeGroup -->
        <ToolBar Name="MyToolbar" DockPanel.Dock="Top" Height="50">
            <RadioButton Name="LineButton" BorderBrush="#FF969696" Content="Line" Height="50" Width="77" GroupName="ShapeGroup" Click="LineButton_Click" IsChecked="True"/>
            <RadioButton Name="EllipseButton" BorderBrush="#FF969696" Content="Ellipse" Height="50" Width="80" GroupName="ShapeGroup" Click="EllipseButton_Click"/>
            <RadioButton Name="RectangleButton" BorderBrush="#FF969696" Content="Rectangle" Height="50" Width="80" GroupName="ShapeGroup" Click="RectangleButton_Click"/>
        </ToolBar>
        <Canvas Name="MyCanvas" Background="AntiqueWhite" Height="300" Width="525" MouseDown="MyCanvas_MouseDown" MouseUp="MyCanvas_MouseUp" MouseMove="MyCanvas_MouseMove">

            <!-- Draw a line -->
            <Line X1="10" Y1="10" X2="50" Y2="50" Stroke="Black"
                  StrokeThickness="4" />
            
            <!-- Draw an Ellipse -->
            <Ellipse Fill="Yellow" Height="50" Width="100" StrokeThickness="2"
                     Stroke="Black" Canvas.Left="100" Canvas.Top="20"/>
            
            <!-- Draw a Rectangle -->
            <Rectangle Fill="Blue" Height="50" Width="100" Canvas.Left="240" Canvas.Top="20"/>
            

        </Canvas>

    </DockPanel>

</Window>


// ---------- MainWindow.xaml.cs ----------

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfTutorial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    // For generating a limited number of 2D
    // vector images you can use 
    // System.Windows.Shapes
    // Shapes created this way respond to
    // events like other WPF components

    public partial class MainWindow : Window
    {
        // Define enum for all 3 shapes
        private enum MyShape
        {
            Line, Ellipse, Rectangle
        }

        // Define the current shape used
        private MyShape currShape;

        public MainWindow()
        {
            InitializeComponent();


        }

        private void LineButton_Click(object sender, RoutedEventArgs e)
        {
            currShape = MyShape.Line;
        }

        private void EllipseButton_Click(object sender, RoutedEventArgs e)
        {
            currShape = MyShape.Ellipse;
        }

        private void RectangleButton_Click(object sender, RoutedEventArgs e)
        {
            currShape = MyShape.Rectangle;
        }

        Point start;
        Point end;

        private void MyCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Get the X & Y of where mouse is 1st clicked
            start = e.GetPosition(this);
        }

        private void MyCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // Draw the correct shape
            switch (currShape)
            {
                case MyShape.Line:
                    DrawLine();
                    break;

                case MyShape.Ellipse:
                    DrawEllipse();
                    break;

                case MyShape.Rectangle:
                    DrawRectangle();
                    break;

                default:
                    return;
            }
        }

        private void MyCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            // Update the X & Y as the mouse moves
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                end = e.GetPosition(this);
            }
        }

        // Sets and draws line after mouse is released
        private void DrawLine()
        {
            Line newLine = new Line()
            {
                Stroke = Brushes.Blue,
                X1 = start.X,
                Y1 = start.Y - 50,
                X2 = end.X,
                Y2 = end.Y - 50
            };
            MyCanvas.Children.Add(newLine);
        }

        // Sets and draws ellipse after mouse is released
        private void DrawEllipse()
        {
            Ellipse newEllipse = new Ellipse()
            {
                Stroke = Brushes.Green,
                Fill = Brushes.Red,
                StrokeThickness = 4,
                Height = 10,
                Width = 10
            };

            // If the user the user tries to draw from
            // any direction then down and to the right
            // you'll get an error unless you use if
            // to change Left & TopProperty and Height
            // and Width accordingly

            if (end.X >= start.X)
            {
                // Defines the left part of the ellipse
                newEllipse.SetValue(Canvas.LeftProperty, start.X);
                newEllipse.Width = end.X - start.X;
            }
            else
            {
                newEllipse.SetValue(Canvas.LeftProperty, end.X);
                newEllipse.Width = start.X - end.X;
            }

            if (end.Y >= start.Y)
            {
                // Defines the top part of the ellipse
                newEllipse.SetValue(Canvas.TopProperty, start.Y - 50);
                newEllipse.Height = end.Y - start.Y;
            }
            else
            {
                newEllipse.SetValue(Canvas.TopProperty, end.Y - 50);
                newEllipse.Height = start.Y - end.Y;
            }

            MyCanvas.Children.Add(newEllipse);
        }

        // Sets and draws rectangle after mouse is released
        private void DrawRectangle()
        {
            Rectangle newRectangle = new Rectangle()
            {
                Stroke = Brushes.Orange,
                Fill = Brushes.Blue,
                StrokeThickness = 4
            };

            if (end.X >= start.X)
            {
                // Defines the left part of the rectangle
                newRectangle.SetValue(Canvas.LeftProperty, start.X);
                newRectangle.Width = end.X - start.X;
            }
            else
            {
                newRectangle.SetValue(Canvas.LeftProperty, end.X);
                newRectangle.Width = start.X - end.X;
            }

            if (end.Y >= start.Y)
            {
                // Defines the top part of the rectangle
                newRectangle.SetValue(Canvas.TopProperty, start.Y - 50);
                newRectangle.Height = end.Y - start.Y;
            }
            else
            {
                newRectangle.SetValue(Canvas.TopProperty, end.Y - 50);
                newRectangle.Height = start.Y - end.Y;
            }

            MyCanvas.Children.Add(newRectangle);
        }
    }
}
