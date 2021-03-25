using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Brusher.Models;
using Xamarin.Forms;

namespace Brusher.ViewModels
{
    public class PalettesViewModel: INotifyPropertyChanged
    {
        readonly IList<Palettes> source;
        
        public ObservableCollection<Palettes> Palettes { get; private set; }
        public IList<Palettes> EmptyPalettes { get; private set; }

        public Palettes PreviousPalette { get; set; }
        public Palettes CurrentPalette { get; set; }
        public Palettes CurrentItem { get; set; }
        public int PreviousPosition { get; set; }
        public int CurrentPosition { get; set; }
        public int Position { get; set; }

        public ICommand FilterCommand => new Command<string>(FilterItems);
        public ICommand ItemChangedCommand => new Command<Palettes>(ItemChanged);
        public ICommand PositionChangedCommand => new Command<int>(PositionChanged);
        public ICommand DeleteCommand => new Command<Palettes>(RemovePalette);
        public ICommand FavoriteCommand => new Command<Palettes>(FavoritePalette);

        public PalettesViewModel()
        {
            source = new List<Palettes>();
            CreatePaletteCollection();
            CurrentItem = Palettes.Skip(3).FirstOrDefault();
            OnPropertyChanged("CurrentItem");
            Position = 3;
            OnPropertyChanged("Position");
        }

        void CreatePaletteCollection()
        {
            source.Add(new Palettes
            {
                Name = "Drive In",
                Location = "Unkown",
                Details = "Description",
                ImageUrl = "drawable/uno.png"
            });

            source.Add(new Palettes
            {
                Name = "On the beach",
                Location = "Unkown",
                Details = "Description",
                ImageUrl = "drawable/dos.png"
            });

            source.Add(new Palettes
            {
                Name = "Cloudy Day",
                Location = "Unkown",
                Details = "Description",
                ImageUrl = "drawable/tres.png"
            });

            source.Add(new Palettes
            {
                Name = "Flowers",
                Location = "Unkown",
                Details = "Description",
                ImageUrl = "drawable/cuatro.png"
            });

            source.Add(new Palettes
            {
                Name = "Sunshine",
                Location = "Unkown",
                Details = "Description",
                ImageUrl = "drawable/cinco.png"
            });

            source.Add(new Palettes
            {
                Name = "sea breeze",
                Location = "Unkown",
                Details = "Description",
                ImageUrl = "drawable/seis.png"
            });

            source.Add(new Palettes
            {
                Name = "Cowboys",
                Location = "Unkown",
                Details = "Description",
                ImageUrl = "drawable/siete.png"
            });

            source.Add(new Palettes
            {
                Name = "Bowling!",
                Location = "Unkown",
                Details = "Description",
                ImageUrl = "drawable/ocho.png"
            });

            source.Add(new Palettes
            {
                Name = "Sunny montains",
                Location = "Unkown",
                Details = "Description",
                ImageUrl = "drawable/nueve.png"
            });

            source.Add(new Palettes
            {
                Name = "Motel 66",
                Location = "Unkown",
                Details = "Description",
                ImageUrl = "drawable/diez.png"
            });

           

            Palettes = new ObservableCollection<Palettes>(source);
        }

        void FilterItems(string filter)
        {
            var filteredItems = source.Where(Palette => Palette.Name.ToLower().Contains(filter.ToLower())).ToList();
            foreach (var Palette in source)
            {
                if (!filteredItems.Contains(Palette))
                {
                    Palettes.Remove(Palette);
                }
                else
                {
                    if (!Palettes.Contains(Palette))
                    {
                        Palettes.Add(Palette);
                    }
                }
            }
        }

        void ItemChanged(Palettes item)
        {
            PreviousPalette = CurrentPalette;
            CurrentPalette = item;
            OnPropertyChanged("PreviousPalette");
            OnPropertyChanged("CurrentPalette");
        }

        void PositionChanged(int position)
        {
            PreviousPosition = CurrentPosition;
            CurrentPosition = position;
            OnPropertyChanged("PreviousPosition");
            OnPropertyChanged("CurrentPosition");
        }

        void RemovePalette(Palettes Palette)
        {
            if (Palettes.Contains(Palette))
            {
                Palettes.Remove(Palette);
            }
        }

        void FavoritePalette(Palettes Palette)
        {
            Palette.IsFavorite = !Palette.IsFavorite;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

}
