using System.Collections.ObjectModel;
using System.Windows;

namespace CricketTeamManager
{
    public partial class MainWindow : Window
    {
        // ObservableCollection to hold the list of players
        public ObservableCollection<string> Players { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // Initialize the ObservableCollection and bind it to the ListBox
            Players = new ObservableCollection<string>();
            PlayersListBox.ItemsSource = Players;
        }

        // Event handler for Add Player button
        private void AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            string playerName = PlayerNameTextBox.Text.Trim(); // Get and trim input

            // Validate input
            if (string.IsNullOrEmpty(playerName))
            {
                MessageBox.Show("Player name cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (Players.Contains(playerName))
            {
                MessageBox.Show("This player already exists in the roster.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Add player to the ObservableCollection
            Players.Add(playerName);
            MessageBox.Show($"Player '{playerName}' added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Clear the input TextBox
            PlayerNameTextBox.Clear();
        }

        // Event handler for Remove Player button
        private void RemovePlayer_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected player
            if (PlayersListBox.SelectedItem is string selectedPlayer)
            {
                // Remove player from the ObservableCollection
                Players.Remove(selectedPlayer);
                MessageBox.Show($"Player '{selectedPlayer}' removed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please select a player to remove.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
