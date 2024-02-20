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

namespace DragDropTest
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

        private void MouseDown(object sender, MouseButtonEventArgs e)
        {
            Label lbl = (Label)sender;
            DragDrop.DoDragDrop(lbl, lbl.Content, DragDropEffects.Copy);
        }

        private void TargetDrop(object sender, DragEventArgs e)
        {
            ((Label)sender).Content = (string)e.Data.GetData(DataFormats.Text);
        }



        private void EllipseDrag(object sender, MouseButtonEventArgs e)
        {
            Ellipse elp = (Ellipse)sender;
            DragDrop.DoDragDrop(elp, elp, DragDropEffects.Move);
        }

        private void Dropellipse(object sender, DragEventArgs e)
        {
            Ellipse elp = (Ellipse)e.Data.GetData(typeof(Ellipse));
            var p = elp.Parent as Panel;
            Canvas newParent = (Canvas)sender;

            if (p == newParent)
            { 
                e.Handled = true;
                return;
            }
            p.Children.Remove(elp);

          

            var pos = e.GetPosition(newParent);

            Canvas.SetLeft(elp, pos.X);
            Canvas.SetTop(elp, pos.Y);

            elp.MouseDown += EllipseDrag;

            newParent.Children.Add(elp);
        }

        private void Canvas_DragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.None;
        }

        private void KillDrop(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
