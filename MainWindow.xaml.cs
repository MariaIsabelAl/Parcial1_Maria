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
using Parcial1_Maria.UI.Registro;
using Parcial1_Maria.UI.Consulta;

namespace Parcial1_Maria
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegistroButton_Click(object sender, RoutedEventArgs e)
        {
            RArticulos rArticulos = new RArticulos();
            rArticulos.Show();
        }

        private void ConsultaButton_Click(object sender, RoutedEventArgs e)
        {
            RConsulta rConsulta = new RConsulta();
            rConsulta.Show();
        }
    }
}
