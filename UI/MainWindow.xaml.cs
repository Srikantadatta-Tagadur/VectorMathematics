using System;
using System.Windows;
using Vector = Library.Vector;

namespace WPF
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

        /// <summary>
        /// The validated user input is parsed as a double to the cross product method and the resulting vector components
        /// are displayed as output. Exception handling is also implemented to prevent the application from crashing.
        /// </summary>
        private void CrossProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Vector vector1 = new Vector(double.Parse(v1_x_value.Text), double.Parse(v1_y_value.Text), double.Parse(v1_z_value.Text));
                Vector vector2 = new Vector(double.Parse(v2_x_value.Text), double.Parse(v2_y_value.Text), double.Parse(v2_z_value.Text));
                v3_x_value.Text = Library.VectorOperations.CrossProduct(vector1, vector2).X.ToString();
                v3_y_value.Text = Library.VectorOperations.CrossProduct(vector1, vector2).Y.ToString();
                v3_z_value.Text = Library.VectorOperations.CrossProduct(vector1, vector2).Z.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        /// <summary>
        /// Creates a new instance of the main window and closes the old window
        /// </summary>
        private void ClearTextAndRestart_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newWindow = new MainWindow();
            newWindow.Show();
            this.Close();
        }

    }

}
