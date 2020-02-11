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
using Microsoft.EntityFrameworkCore;
using Parcial1_Maria.BLL;
using Parcial1_Maria.Entidades;

namespace Parcial1_Maria.UI.Registro
{
  
    public partial class RArticulos : Window
    {
        public RArticulos()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IdTextBox.Text =string.Empty;
            DescripcionTextBox.Text = string.Empty;
            ExistenciaTextBox.Text = string.Empty;
            CostoTextBox.Text = string.Empty;
            ValorTextBox.Text = string.Empty;

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private Articulos LlenaClases()
        { 
            Articulos articulos = new Articulos();
            if (string.IsNullOrWhiteSpace(IdTextBox.Text) || IdTextBox.Text == "0")
            {
                IdTextBox.Text = "0";
            }
            else articulos.ProductoId = Convert.ToInt32(IdTextBox.Text);
            articulos.Descripcion = DescripcionTextBox.Text;
            articulos.Existencia = Convert.ToInt32(ExistenciaTextBox.Text);
            articulos.Costo = Convert.ToInt32(CostoTextBox.Text);
            articulos.ValorInventario = Calcular();
            
            return articulos;
        }

        private void LlenaCampos(Articulos articulos)
        {
            IdTextBox.Text = Convert.ToString(articulos.ProductoId);
            DescripcionTextBox.Text = articulos.Descripcion;
            ExistenciaTextBox.Text = Convert.ToString(articulos.Existencia);
            CostoTextBox.Text = Convert.ToString(articulos.Costo);
            ValorTextBox.Text = Convert.ToString(Calcular());
        }

        private bool ExisteBd()
        {
            Articulos articulos = ArticulosBll.Buscar(Convert.ToInt32(IdTextBox.Text));
            return (articulos != null);
        }

        private bool Validar()
        {
            bool paso = true;

            if (DescripcionTextBox.Text == string.Empty)
            {
                MessageBox.Show(DescripcionTextBox.Text, "Descripcion no puede estar vacia");
                DescripcionTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(ExistenciaTextBox.Text))
            {
                MessageBox.Show(ExistenciaTextBox.Text, "No puede estar vacio");
                ExistenciaTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CostoTextBox.Text))
            {
                MessageBox.Show(CostoTextBox.Text, "No puede estar vacio el costo");
                CostoTextBox.Focus();
                paso = false;
            }
            return paso;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Articulos articulos;
            bool paso = false;

            if (!Validar())
                return;
            articulos = LlenaClases();
            if(string.IsNullOrWhiteSpace(IdTextBox.Text) || IdTextBox.Text == "0")
            {
                paso = ArticulosBll.Guardar(articulos);
            }
            else
            {
                if (!ExisteBd())
                {
                    MessageBox.Show("No se puede modificar porque no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = ArticulosBll.Modificar(articulos);
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!!", "Exito!!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Articulos articulos = new Articulos();
            int.TryParse(IdTextBox.Text, out id);

            articulos = ArticulosBll.Buscar(id);
            if (articulos != null)
            {
                MessageBox.Show("Persona Encontrada");
                LlenaCampos(articulos);
            }
            else
            {
                MessageBox.Show("Personas no Encontrada");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            id = Convert.ToInt32(IdTextBox.Text);
            Limpiar();
            if (ArticulosBll.Eliminar(id))
            {
                MessageBox.Show("Eliminado!!", "Exito!!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show(IdTextBox.Text, "No se pudo eliminar porque no existe");
            }
        }

        private void ExistenciaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Calcular();
        }

        private void CostoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Calcular();
        }

        private int Calcular()
        {
            int valor, existente, costo;
            if (string.IsNullOrWhiteSpace(ExistenciaTextBox.Text) || ExistenciaTextBox.Text == "0")
            {
                ExistenciaTextBox.Text = "0";
            }
            else existente = Convert.ToInt32(ExistenciaTextBox.Text);
            if (string.IsNullOrWhiteSpace(CostoTextBox.Text) || CostoTextBox.Text == "0")
            {
                CostoTextBox.Text = "0";
            }
            else costo = Convert.ToInt32(CostoTextBox.Text);
            valor = Convert.ToInt32(ExistenciaTextBox.Text) + Convert.ToInt32(CostoTextBox.Text);
            ValorTextBox.Text = Convert.ToString(valor);

            return valor;
        }
    }
}
