
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pokemon
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        public ObservableCollection<Pokemon> PokemonList { get; set; }

        public MainPage()
        {
            InitializeComponent();
            this.PokemonList = new ObservableCollection<Pokemon>
            {
                new Pokemon{Name = "This", Url = "https://robohash.org/test.png"}
            };
            BindingContext = this;
        }

        void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null; // de-select the row
            Navigation.PushModalAsync(new Details());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var pokemonList = this.GetPokemonList().Result;
            this.PokemonList = pokemonList;

        }

        private async Task<ObservableCollection<Pokemon>> GetPokemonList()
        {
            var response = await client.GetAsync("https://pokeapi.co/api/v2/pokemon");
            var pokemonList = new ObservableCollection<Pokemon>();

            if (response.IsSuccessStatusCode)
            {
                var stream = await response.Content.ReadAsStreamAsync();
                pokemonList = await JsonSerializer.DeserializeAsync<ObservableCollection<Pokemon>>(stream);
                
            }

            return pokemonList;
        }
    }
}
