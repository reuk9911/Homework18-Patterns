using Homework18.Model;
using Homework18.Model.OpenSaveOperations;
using Skillbox_Homework17_Entity.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework18.Utils;
using System.ComponentModel;
using Homework18.Views;

namespace Homework18.ViewModels
{
    public class DataManageVM : INotifyPropertyChanged
    {
        #region Поля и свойства

        public List<string> AnimalTypes { get; }
        public string SelectedAnimalType { get; set; }


        private BaseVM selectedVM;

        public BaseVM SelectedVM
        {
            get 
            {
                return selectedVM; 
            }
            set 
            {
                selectedVM = value;
                RaisePropertyChangedEvent("SelectedVM");
            }
        }


        private ObservableCollection<IAnimal> allAnimals;
        public ObservableCollection<IAnimal> AllAnimals
        {
            get { return allAnimals; }
            set
            {
                if (allAnimals != value)
                {
                    allAnimals = value;
                    RaisePropertyChangedEvent("AllAnimals");
                }
            }
        }

        public IAnimal SelectedAnimal { get; set; }
        public FileWorker FileOperations { get; set; }

        public ObservableCollection<string> LoadFrom { get; set; }
        public ObservableCollection<string> SaveTo { get; set; }

        public string SelectedLoadFrom { get; set; }
        public string SelectedSaveTo { get; set; }

        #endregion

        #region Конструкторы

        public DataManageVM()
        {
            AllAnimals = new ObservableCollection<IAnimal>();

            //SelectedVM = new AddBirdVM();

            AnimalTypes = new List<string>() { "Bird", "Mammal", "Amphibian" };
            SelectedAnimalType = AnimalTypes[0];


            LoadFrom = new ObservableCollection<string>() { "JSon", "Xml" };
            SelectedLoadFrom = LoadFrom[0];

            SaveTo = new ObservableCollection<string>() { "JSon", "Xml" };
            SelectedSaveTo = SaveTo[0];

        }

        #endregion

        #region Методы
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChangedEvent(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        #endregion

        #region Команды


        private RelayCommand loadAnimals;
        public RelayCommand LoadAnimals
        {
            get
            {
                return loadAnimals ?? new RelayCommand(obj =>
                {
                    switch (SelectedLoadFrom)
                    {
                        case "JSon": FileOperations = new FileWorker(new JSonKeeper()); break;
                        case "Xml": FileOperations = new FileWorker(new XmlKeeper()); break;
                        default: return;
                    }

                    DefaultDialogService OpenDialog = new DefaultDialogService();
                    if (OpenDialog.OpenFileDialog())
                    {
                        AllAnimals = (ObservableCollection<IAnimal>) FileOperations.Load(OpenDialog.FilePath);
                    }
                });
            }
        }

        private RelayCommand saveAnimals;
        public RelayCommand SaveAnimals
        {
            get
            {
                return saveAnimals ?? new RelayCommand(obj =>
                {
                    switch (SelectedLoadFrom)
                    {
                        case "JSon": FileOperations = new FileWorker(new JSonKeeper()); break;
                        case "Xml": FileOperations = new FileWorker(new XmlKeeper()); break;
                        default: return;
                    }

                    DefaultDialogService SaveDialog = new DefaultDialogService();
                    if (SaveDialog.SaveFileDialog())
                    {
                        FileOperations.Save(allAnimals, SaveDialog.FilePath);
                    }
                });
            }
        }


        private RelayCommand addAnimalCommand;
        public RelayCommand AddAnimalCommand
        {
            get
            {
                return addAnimalCommand ?? new RelayCommand(obj =>
                {
                    switch (SelectedAnimalType)
                    {
                        //case "Bird":
                        //    Bird newBird = (Bird)AnimalFactory.GetNewAnimal("Homework18.Model.Bird");
                        //    SelectedVM = new EditBirdVM(newBird);
                        //    EditBirdWindow w = new EditBirdWindow();
                        //    w.DataContext = SelectedVM;
                        //    w.ShowDialog();
                        //    AllAnimals.Add(newBird);
                        //    break;

                        case "Bird":
                            Bird newBird = (Bird)AnimalFactory.GetNewAnimal("Homework18.Model.Bird");
                            SelectedVM = new EditBird2VM(newBird);
                            EditBird2Window w = new EditBird2Window();
                            w.DataContext = SelectedVM;
                            w.ShowDialog();
                            AllAnimals.Add(newBird);
                            break;

                        //case "Mammal":
                        //    Mammal newMammal = (Mammal)AnimalFactory.GetNewAnimal("Homework18.Model.Mammal");
                        //    SelectedVM = new AddMammalVM(newMammal);
                        //    AddMammalWindow w = new AddMammalWindow();
                        //    w.DataContext = SelectedVM;
                        //    w.ShowDialog();
                        //    AllAnimals.Add(newMammal);
                        //    break;
                        //case "Amphibian": SelectedVM = new EditAmphibianVM(); break;
                        default: return;
                    }
                    
                });
            }
        }

        private RelayCommand editAnimalCommand;
        public RelayCommand EditAnimalCommand
        {
            get
            {
                return editAnimalCommand ?? new RelayCommand(obj =>
                {
                    switch (SelectedAnimal.AnimalType)
                    {
                        case "Птица":
                            SelectedVM = new EditBird2VM(SelectedAnimal as Bird);
                            EditBird2Window w = new EditBird2Window();
                            w.DataContext = SelectedVM;
                            w.ShowDialog();
                            //AllAnimals.Add(newBird);
                            break;
                        default: return;
                    }

                });
            }
        }




        #endregion






    }
}
