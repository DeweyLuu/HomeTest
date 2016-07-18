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

namespace HomeTest
{
    using System.IO;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<DataObject> lines = new List<DataObject>();

        public MainWindow()
        {
            this.InitializeComponent();

            var rawLines = File.ReadAllLines("data.csv").
                Skip(1).
                Where(x => !x.ToLower().
                    Contains("unknown")).ToList();

            // var types = new List<string>();

            this.lines.AddRange(rawLines.Select(line => new DataObject(line)));
            ////foreach (var newLine in readData.Skip(1).Select(i => new DataObject(i)))
            ////{
            ////    this.lines.Add(newLine);
            ////}

            foreach (var type in this.lines.Select(x=> x.Type).Distinct())
            {
                this.DataOptions.Items.Add(type);
            }
             

            ////foreach (var type in types)
            ////{
            ////    this.DataOptions.Items.Add(type);
            ////}
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // this.UpdatedText.Text = "hello there";
        }

        private void DataOptionsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedIndex = this.DataOptions.SelectedIndex;
            if (selectedIndex <0)
            {
                return;
            }
            var selectedItem = this.DataOptions.Items[selectedIndex];
            this.TheDataDump.Items.Clear();
            ////foreach (var line in this.lines)
            ////{
            ////    if (selectedItem.Equals(line.Type))
            ////    {
            ////        this.TheDataDump.Items.Add(line);
            ////    }
            ////}
            /// 
            foreach (var element in this.lines.Where(x => x.Type.Equals(selectedItem)))
            {
                this.TheDataDump.Items.Add(element);
            }
        }
    }
}
