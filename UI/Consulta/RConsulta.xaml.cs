using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Parcial1_Maria.BLL;
using System.Linq;
using Parcial1_Maria.Entidades;

namespace Parcial1_Maria.UI.Consulta
{
   
    public partial class RConsulta : Window
    {
        public RConsulta()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Articulos>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = ArticulosBll.GetList(p => true);
                        break;
                    case 1:
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = ArticulosBll.GetList(p => p.ProductoId == id);
                        break;
                    case 2:
                        listado = ArticulosBll.GetList(p => p.Descripcion.Contains(CriterioTextBox.Text));
                        break;

                }
            }
            else
            {
                listado= ArticulosBll.GetList(p => true);
            }

            ConsultaDataGrid.ItemsSource = null;
            ConsultaDataGrid.ItemsSource = listado;
        }
    }
}
