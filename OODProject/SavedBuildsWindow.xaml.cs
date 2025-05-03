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
using System.Windows.Shapes;
using System.IO;

namespace OODProject
{
    /// <summary>
    /// Interaction logic for SavedBuildsWindow.xaml
    /// </summary>
    public partial class SavedBuildsWindow : Window
    {
        public SavedBuildsWindow()
        {
            InitializeComponent();
            LoadSavedBuilds();
        }

        //Method to load any saved builds from the CSV file
        private void LoadSavedBuilds()
        {
            // Check if the file exists before trying to read it
            if (!File.Exists("savedbuilds.csv"))
                return;

            // Read all lines from the CSV file
            var lines = File.ReadAllLines("savedbuilds.csv");
            //Returns early if the file is empty
            if (lines.Length <= 1) return;

            int buildNumber = 1;

            // Skip the first line (header) and iterate through each line
            foreach (var line in lines.Skip(1))
            {
                // Split the line by commas
                var fields = line.Split(',');

                // Check if the line has enough fields
                if (fields.Length < 19) continue;

                // Create labels for each part and populate them with data
                string[] partLabels = new[]
                {
                    $"CPU: {fields[0].Trim('"')} - {fields[1].Trim('"')}",
                    $"CPU Cooler: {fields[2].Trim('"')} - {fields[3].Trim('"')}",
                    $"Motherboard: {fields[4].Trim('"')} - {fields[5].Trim('"')}",
                    $"RAM: {fields[6].Trim('"')} - {fields[7].Trim('"')}",
                    $"GPU: {fields[8].Trim('"')} - {fields[9].Trim('"')}",
                    $"PSU: {fields[10].Trim('"')} - {fields[11].Trim('"')}",
                    $"Case: {fields[12].Trim('"')} - {fields[13].Trim('"')}",
                    $"Storage 1: {fields[14].Trim('"')} - {fields[15].Trim('"')}",
                    $"Storage 2: {fields[16].Trim('"')} - {fields[17].Trim('"')}",
                    $"Total: {fields[18].Trim('"')}"
                };

                // Create a new TextBlock for the build number and details
                var title = new TextBlock
                {
                    Text = $"Build {buildNumber}",
                    FontSize = 18,
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(0, 10, 0, 5)
                };

                // Create a StackPanel to hold the details of the build
                var detailPanel = new StackPanel
                {
                    Margin = new Thickness(10, 0, 0, 20)
                };

                // Add each part label to the detail panel
                foreach (var part in partLabels)
                {
                    detailPanel.Children.Add(new TextBlock
                    {
                        Text = part,
                        FontSize = 14,
                        Margin = new Thickness(0, 2, 0, 2)
                    });
                }

                // Add the title and detail panel to the main Builds StackPanel
                Builds.Children.Add(title);
                Builds.Children.Add(detailPanel);

                buildNumber++;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            var startupWindow = new StartupWindow();
            startupWindow.Show();
            this.Close();
        }
    }
}
