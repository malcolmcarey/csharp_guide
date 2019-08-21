// ---------- MainWindow.xaml ----------

<!-- We'll use the Document API layout managers to
            work with formatted documents using the XML
            Paper Specification (XPS) -->
            
            <!-- Different layout managers
            FlowDocumentReader : Read only with zoom, search
            RichTextBox : Displays editable data in a FlowDocument
            FlowDocumentPageViewer : Shows pages, but no zoom or search-->
            
            <TabItem Header="Flow Reader" HorizontalAlignment="Left" Height="20" VerticalAlignment="Top" Width="78">
                <Grid Background="#FFE5E5E5">

                    <!-- ViewingMode : Page, Scroll, TwoPage -->
                    <FlowDocumentReader ViewingMode="Page" IsFindEnabled="True" IsPageViewEnabled="True" IsScrollViewEnabled="True" IsTwoPageViewEnabled="True">
                        <FlowDocument>

                            <Paragraph>
                                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                            </Paragraph>
                            <List>
                                <ListItem>
                                    <Paragraph>Item 1</Paragraph>
                                </ListItem>
                                <ListItem>
                                    <Paragraph>Item 2</Paragraph>
                                </ListItem>
                            </List>
                            <BlockUIContainer>
                                <StackPanel>

                                    <Image Source=".\Resources\Turtle.png" Height="64"/>

                                    <Label Foreground="Blue">Favorite Phone :</Label>
                                    <ComboBox>
                                        <ComboBoxItem IsSelected="True">Android</ComboBoxItem>
                                        <ComboBoxItem>Apple</ComboBoxItem>
                                        <ComboBoxItem>Black Berry</ComboBoxItem>
                                    </ComboBox>
                                    <Label Foreground ="Red">Favorite Color:</Label>
                                    <StackPanel>
                                        <RadioButton>Red</RadioButton>
                                        <RadioButton>Green</RadioButton>
                                        <RadioButton>Blue</RadioButton>
                                    </StackPanel>
                                    <Label>Your Name:</Label>
                                    <TextBox>
                                        Name
                                    </TextBox>
                                </StackPanel>
                            </BlockUIContainer>

                            <!-- Put here to make an empty line -->
                            <Paragraph></Paragraph>

                                <Table>
                                <Table.Columns>
                                    <TableColumn />
                                    <TableColumn />
                                    <TableColumn />
                                </Table.Columns>
                                <TableRowGroup>
                                    <TableRow>
                                        <TableCell ColumnSpan="3" Background="Blue" Foreground="AliceBlue">
                                            <Paragraph Padding="10">Best Baseball Players</Paragraph>
                                        </TableCell>
                                    </TableRow>
                                    <TableRow>
                                        <TableCell Background="White">
                                            <Paragraph>Name</Paragraph>
                                        </TableCell>
                                        <TableCell Background="White">
                                            <Paragraph>Average</Paragraph>
                                        </TableCell>
                                        <TableCell Background="White">
                                            <Paragraph>HRs</Paragraph>
                                        </TableCell>
                                    </TableRow>
                                </TableRowGroup>
                            </Table>

                        </FlowDocument>
                    </FlowDocumentReader>

                </Grid>
            </TabItem>
            <TabItem Header="Page Viewer" HorizontalAlignment="Left" Height="20" VerticalAlignment="Top" Width="84">
                <StackPanel Background="#FFE5E5E5">
                    <FlowDocumentPageViewer Name="FdPageViewer" Height="291">
                        <FlowDocument>
                            <Paragraph>
                                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                            </Paragraph>
                            <Paragraph>
                                Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?
                            </Paragraph>
                        </FlowDocument>
                    </FlowDocumentPageViewer>

                </StackPanel>
            </TabItem>
            <TabItem Header="Scroll" HorizontalAlignment="Left" Height="20" VerticalAlignment="Top" Width="54">
                <Grid Background="#FFE5E5E5">

                    <FlowDocumentScrollViewer>
                        <FlowDocument>
                            <Paragraph>
                                Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur? Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur
                            </Paragraph>
                        </FlowDocument>
                    </FlowDocumentScrollViewer>

                </Grid>
            </TabItem>
            <TabItem Header="Generate" HorizontalAlignment="Left" Height="20" VerticalAlignment="Top" Width="64">
                <Grid Background="#FFE5E5E5">

                    <FlowDocumentScrollViewer Name="fdScrollViewer" />

                </Grid>
            </TabItem>
            <TabItem Header="Rich" HorizontalAlignment="Left" Height="20" VerticalAlignment="Top" Width="54">
                <!-- You place a FlowDocument in a RichTextBox
                and it can be edited. You can add spell
                checking and a menu for cut, copy and paste -->

                <StackPanel>

                    <RichTextBox Name="RichTB" Height="200" SpellCheck.IsEnabled="True" ContextMenuOpening="RichTB_ContextMenuOpening">
                        <FlowDocument>
                            <Paragraph>
                                You can edit me
                            </Paragraph>
                        </FlowDocument>
                    </RichTextBox>
                    <Button Click="SaveRTBContent">Save</Button>
                    <Button Click="LoadRTBContent">Open</Button>
                </StackPanel>
            </TabItem>


// ---------- MainWindow.xaml.cs ----------

private void GenerateDoc()
        {
            FlowDocument doc = new FlowDocument();

            Paragraph para = new Paragraph(new Run("Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?"));
            doc.Blocks.Add(para);

            para = new Paragraph(new Run("Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?"))
            {
                FontSize = 14,
                FontStyle = FontStyles.Italic,
                Foreground = Brushes.Green
            };
            doc.Blocks.Add(para);

            fdScrollViewer.Document = doc;
        }

        // A ContextMenu displays Cut, Copy and Paste commands
        private void RichTB_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            // Convert to a RichTextBox and check for null
            RichTextBox rtb = sender as RichTextBox;
            if (rtb == null) return;

            // Create ContextMenu
            ContextMenu contextMenu = rtb.ContextMenu;
            contextMenu.PlacementTarget = rtb;

            // This will place the menu at the point where 
            // it is right clicked
            contextMenu.Placement = PlacementMode.RelativePoint;

            // Place the menu to the right of the click
            TextPointer position = rtb.Selection.End;

            if (position == null) return;

            // Create the menu
            Rect positionRect = position.GetCharacterRect(LogicalDirection.Forward);
            contextMenu.HorizontalOffset = positionRect.X;
            contextMenu.VerticalOffset = positionRect.Y;

            // Finally, mark the event as handled
            contextMenu.IsOpen = true;
            e.Handled = true;
        }

        void SaveRTBContent(Object sender, RoutedEventArgs args)
        {
            // Defines the range of text to save
            TextRange range = new TextRange(RichTB.Document.ContentStart, RichTB.Document.ContentEnd);

            // Create a stream to write to the file
            FileStream fStream = new FileStream("C:\\Users\\derekbanas\\C#Data\\test.xaml", FileMode.Create);

            // Save the content
            range.Save(fStream, DataFormats.XamlPackage);
            fStream.Close();

        }

        // Load text into RichTextBox
        void LoadRTBContent(Object sender, RoutedEventArgs args)
        {
            TextRange range;
            FileStream fStream;
            if (File.Exists("C:\\Users\\derekbanas\\C#Data\\test.xaml"))
            {
                range = new TextRange(RichTB.Document.ContentStart, RichTB.Document.ContentEnd);
                fStream = new FileStream("C:\\Users\\derekbanas\\C#Data\\test.xaml", FileMode.OpenOrCreate);
                range.Load(fStream, DataFormats.XamlPackage);
                fStream.Close();
            }
        }
