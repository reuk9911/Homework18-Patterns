using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Homework18.Model;
using Homework18.Model.OpenSaveOperations;

namespace Homework18
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IAnimal ia = AnimalFactory.GetAnimal("Homework18.Model.Mammal", "Barsik", new DateTime(1998, 01, 02));
            IAnimal ia2 = AnimalFactory.GetAnimal("Homework18.Model.Bird", "Kesha", new DateTime(2023, 01, 02));

            ObservableCollection<IAnimal> animals = new ObservableCollection<IAnimal>();
            (ia as Mammal).Weight = 100;

            animals.Add(ia);
            animals.Add(ia2);


            JSonKeeper jsk = new JSonKeeper();
            FileWorker fwJSon = new FileWorker(jsk);
            string fName = @"Output\jsonSerialization.txt";
            fwJSon.Save(animals, fName);

            ObservableCollection<IAnimal> animalsDeser = new ObservableCollection<IAnimal>(fwJSon.Load(fName));
            bool b = animalsDeser[0] is Mammal ? true : false;


            XMLKeeper xmlk = new XMLKeeper();
            FileWorker fwXml = new FileWorker(xmlk);
            fName = @"Output\xmlSerialization2.txt";
            fwXml.Save(animals, fName);

            animalsDeser = new ObservableCollection<IAnimal>(fwXml.Load(fName));
            b = animalsDeser[0] is Mammal ? true : false;

        }
    }
}
