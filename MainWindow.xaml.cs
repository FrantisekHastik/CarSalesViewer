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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace CarSalesViewer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSelectXml_Click(object sender, RoutedEventArgs e)
        {
            tblErrorMessage.Text = "";
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files (*.xml)|*.xml;";            
            
            if(openFileDialog.ShowDialog() == true)
            { 
                using (var reader = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    try
                    {
                        var serializer = new XmlSerializer(typeof(SalesTable));
                        var salesTable = (SalesTable?)serializer.Deserialize(reader);

                        if (salesTable != null)
                        {
                            saleTableList.ItemsSource = salesTable.getVatPriceDictionary(rbtnWithoutVat.IsChecked ?? false);
                        }
                    }
                    catch(Exception ex)
                    {
                        tblErrorMessage.Text = $"Chyba: {ex.Message}";
                    }
                }
            }
        }
    }
}
