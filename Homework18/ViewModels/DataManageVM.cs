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

        /// <summary>
        /// Типы животных
        /// </summary>
        public List<string> AnimalTypes { get; }
        /// <summary>
        /// Выбранный тип животного для добавления в коллекцию
        /// </summary>
        public string SelectedAnimalType { get; set; }

        
        private BaseVM selectedVM;
        /// <summary>
        /// Какую viewmodel будем открывать
        /// </summary>
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
        /// <summary>
        /// Коллекция животных
        /// </summary>
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


        private IAnimal selectedAnimal;
        /// <summary>
        /// Выбранное животное из коллекции
        /// </summary>
        public IAnimal SelectedAnimal
        {
            get { return selectedAnimal; }
            set
            {
                if (selectedAnimal != value)
                {
                    selectedAnimal = value;
                    RaisePropertyChangedEvent("SelectedAnimal");
                }
            }
        }


        private FileWorker FileOperations { get; set; }

        /// <summary>
        /// Из какого формата загружаться
        /// </summary>
        public ObservableCollection<string> LoadFrom { get; set; }
        
        /// <summary>
        /// В какой формат сохраняться
        /// </summary>
        public ObservableCollection<string> SaveTo { get; set; }

        /// <summary>
        /// Загружаться из JSon или Xml 
        /// </summary>
        public string SelectedLoadFrom { get; set; }
        /// <summary>
        /// Мохраняться в JSon или Xml 
        /// </summary>
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

        /// <summary>
        /// Загружаемся из файла
        /// </summary>
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
        /// <summary>
        /// Сохраняемся в файл
        /// </summary>
        public RelayCommand SaveAnimals
        {
            get
            {
                return saveAnimals ?? new RelayCommand(obj =>
                {
                    switch (SelectedSaveTo)
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
        /// <summary>
        /// Добавляет новое животное в коллекцию
        /// </summary>
        public RelayCommand AddAnimalCommand
        {
            get
            {
                return addAnimalCommand ?? new RelayCommand(obj =>
                {
                    switch (SelectedAnimalType)
                    {
                        case "Bird":
                            Bird newBird = (Bird)AnimalFactory.GetNewAnimal("Homework18.Model.Bird");
                            SelectedVM = new EditBird2VM(newBird);
                            EditBird2Window wBird = new EditBird2Window();
                            wBird.DataContext = SelectedVM;
                            wBird.ShowDialog();
                            AllAnimals.Add(newBird);
                            break;

                        case "Mammal":
                            Mammal newMammal = (Mammal)AnimalFactory.GetNewAnimal("Homework18.Model.Mammal");
                            SelectedVM = new EditMammalVM(newMammal);
                            EditMammalWindow wMammal = new EditMammalWindow();
                            wMammal.DataContext = SelectedVM;
                            wMammal.ShowDialog();
                            AllAnimals.Add(newMammal);
                            break;
                        case "Amphibian":
                            Amphibian newAmphibian = (Amphibian)AnimalFactory.GetNewAnimal("Homework18.Model.Amphibian");
                            SelectedVM = new EditAmphibianVM(newAmphibian);
                            EditAmphibianWindow wAmphibian = new EditAmphibianWindow();
                            wAmphibian.DataContext = SelectedVM;
                            wAmphibian.ShowDialog();
                            AllAnimals.Add(newAmphibian);
                            break;

                        default: return;
                    }
                    
                });
            }
        }

        private RelayCommand editAnimalCommand;

        /// <summary>
        /// Редактирует животное из коллекции
        /// </summary>
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
                            EditBird2Window wBird = new EditBird2Window();
                            wBird.DataContext = SelectedVM;
                            wBird.ShowDialog();
                            break;
                        case "Млекопитающее":
                            SelectedVM = new EditMammalVM(SelectedAnimal as Mammal);
                            EditMammalWindow wMammal = new EditMammalWindow();
                            wMammal.DataContext = SelectedVM;
                            wMammal.ShowDialog();
                            break;
                        case "Земноводное":
                            SelectedVM = new EditAmphibianVM(SelectedAnimal as Amphibian);
                            EditAmphibianWindow wAmphibian = new EditAmphibianWindow();
                            wAmphibian.DataContext = SelectedVM;
                            wAmphibian.ShowDialog();
                            break;
                        default: return;
                    
                    }
                },
            (obj) => obj != null);
            }
        }

        #endregion


    }
}
