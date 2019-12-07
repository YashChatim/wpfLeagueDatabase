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
using System.Diagnostics;
using System.Data.Objects;

namespace LeagueOfLegends
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Role> roleDetails = new List<Role>();
        List<Character> characterDetails = new List<Character>();

        Character character = new Character();

        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }

        private void Initialise()
        {
            using (var db = new LeagueOfLegendsDbEntities())
            {
                characterDetails = db.Characters.ToList();
                roleDetails = db.Roles.ToList();
            }

            ListViewCharacterDetails.ItemsSource = characterDetails;
        }

        private void ListViewCharacterDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Print details of selected item
            // instance = (convert to Character) the item selected in listbox by user
            character = (Character)ListViewCharacterDetails.SelectedItem;

            if (character != null)
            {
                SelectACharacter();
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e) 
        { 
            if (ButtonAdd.Content.ToString() == "Add")
            {
                ButtonAdd.Content = "Confirm";
                ButtonClick();
                ClearTextBox();
            }

            else
            {
                ButtonAdd.Content = "Add";
                ButtonDefault();
                ResetTextBoxColour();

                var addCharacter = new Character()
                {
                    CharacterName = TextBoxCharacterName.Text,
                    CharacterDescription = TextBoxCharacterDescription.Text
                };

                using (var db = new LeagueOfLegendsDbEntities())
                {
                    // Add to database
                    db.Characters.Add(addCharacter);
                    db.SaveChanges();

                    UpdateListView(db);
                }
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonEdit.Content.ToString() == "Edit")
            {
                ButtonEdit.Content = "Save";
                ButtonClick();
            }

            else
            {
                using (var db = new LeagueOfLegendsDbEntities())
                {
                    var characterToEdit = db.Characters.Find(character.CharacterID);

                    // Update name and description
                    characterToEdit.CharacterName = TextBoxCharacterName.Text;
                    characterToEdit.CharacterDescription = TextBoxCharacterDescription.Text;

                    // Update records to database
                    db.SaveChanges();

                    UpdateListView(db);
                }

                ButtonEdit.Content = "Edit";
                ButtonDefault();
                ResetTextBoxColour();
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonDelete.Content.ToString() == "Delete")
            {
                ButtonDelete.Content = "Sure?";
                TextBoxCharacterID.Background = Brushes.PaleVioletRed;
                TextBoxCharacterName.Background = Brushes.PaleVioletRed;
                TextBoxCharacterDescription.Background = Brushes.PaleVioletRed;
            }

            else
            {
                using (var db = new LeagueOfLegendsDbEntities())
                {
                    var characterToDelete = db.Characters.Find(character.CharacterID);
                    db.Characters.Remove(characterToDelete);

                    // Update records to database
                    db.SaveChanges();

                    UpdateListView(db);
                }

                ButtonDelete.Content = "Delete";
                ButtonDelete.IsEnabled = false;

                ClearTextBox();

                var brush = new BrushConverter();
                TextBoxCharacterID.Background = (Brush)brush.ConvertFrom("#B3A4C5");
                TextBoxCharacterName.Background = (Brush)brush.ConvertFrom("#B3A4C5");
                TextBoxCharacterDescription.Background = (Brush)brush.ConvertFrom("#B3A4C5");
            }
        }

        private void SelectACharacter()
        {
            TextBoxCharacterID.Text = character.CharacterID.ToString();
            TextBoxCharacterName.Text = character.CharacterName;
            TextBoxCharacterDescription.Text = character.CharacterDescription;
            ButtonEdit.IsEnabled = true;
            ButtonDelete.IsEnabled = true;
        }

        private void UpdateListView(LeagueOfLegendsDbEntities db)
        {
            ListViewCharacterDetails.ItemsSource = null; // Reset list view
            characterDetails = db.Characters.ToList(); // Get fresh list
            ListViewCharacterDetails.ItemsSource = characterDetails; // Relink
        }

        private void ResetTextBoxColour()
        {
            var brush = new BrushConverter();
            TextBoxCharacterName.Background = (Brush)brush.ConvertFrom("#B3A4C5");
            TextBoxCharacterDescription.Background = (Brush)brush.ConvertFrom("#B3A4C5");
        }

        private void ClearTextBox()
        {
            TextBoxCharacterID.Text = "";
            TextBoxCharacterName.Text = "";
            TextBoxCharacterDescription.Text = "";
        }

        private void ButtonDefault()
        {
            ButtonEdit.IsEnabled = false;
            TextBoxCharacterName.IsReadOnly = true;
            TextBoxCharacterDescription.IsReadOnly = true;
        }

        private void ButtonClick()
        {
            TextBoxCharacterName.IsReadOnly = false;
            TextBoxCharacterDescription.IsReadOnly = false;
            TextBoxCharacterName.Background = Brushes.White;
            TextBoxCharacterDescription.Background = Brushes.White;
        }
    }
}
