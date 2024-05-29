using Enquete.Extensions;
using Enquete.Helpers;
using Enquete.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Printing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Enquete
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int[,] _enqueteArray = new int[5, 4];
        private List<EnqueteEntity> _enquetes = new List<EnqueteEntity>();
  

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7252/Enquete/");
                var response = await client.GetAsync("GetEnquetesAsync");

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Failed to open!");
                    return;
                }

                var result = await response.Content.ReadAsStringAsync();
                _enquetes = JsonConvert.DeserializeObject<List<EnqueteEntity>>(result);
            }
            
        }

        private void btnVerwerken_Click(object sender, RoutedEventArgs e)
        {
            Array.Clear(_enqueteArray,0, _enqueteArray.Length);
          
                foreach (var enquete in _enquetes)
                {

                    if (enquete.GeboorteJaar < 1960)
                    {
                        ArrayHelper.PopulateEnqueteArray(_enqueteArray,0, enquete.VervoersMiddel);
                    }
                    else if (enquete.GeboorteJaar < 1970)
                    {
                        ArrayHelper.PopulateEnqueteArray(_enqueteArray, 1, enquete.VervoersMiddel);
                    }
                    else if (enquete.GeboorteJaar < 1980)
                    {
                        ArrayHelper.PopulateEnqueteArray(_enqueteArray, 2, enquete.VervoersMiddel);
                    }
                    else if (enquete.GeboorteJaar < 1990)
                    {
                        ArrayHelper.PopulateEnqueteArray(_enqueteArray, 3, enquete.VervoersMiddel);
                    }
                    else
                    {
                        ArrayHelper.PopulateEnqueteArray(_enqueteArray, 4, enquete.VervoersMiddel);
                    }
                }
         
            txtEnquete.PopulateTextBlock(_enqueteArray);
        }

        

        private void btnSluiten_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

      
    }
}