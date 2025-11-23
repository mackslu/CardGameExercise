using System.Text;

namespace CardGameExercise.GUI;

public partial class CardGameWindow : Form
{
    public CardGameWindow()
    {
        InitializeComponent();
    }

    private async void btnLoadFromFile_Click(object sender, EventArgs e)
    {
        OpenFileDialog ofdCsvFileDialog;
        try
        {
            ofdCsvFileDialog = new OpenFileDialog()
            {
                FileName = "Select a CSV file",
                Filter = "CSV files (*.csv)|*.csv",
                Title = "Open CSV file",
            };

            if (ofdCsvFileDialog.ShowDialog() != DialogResult.OK) return;
            if (Path.GetExtension(ofdCsvFileDialog.FileName) != ".csv")
            {
                MessageBox.Show("Please only select valid CSV files");
                return;
            }

            if (!File.Exists(ofdCsvFileDialog.FileName))
            {
                MessageBox.Show("The selected file does not exist");
                return;
            }
            
            LoadCardsData(await File.ReadAllTextAsync(ofdCsvFileDialog.FileName));
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Catch all error handling
        }
    }
    
    private void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(txtRawCards.Text))
            {
                MessageBox.Show("Please enter data for the playing cards and try again");
                return;
            }

            LoadCardsData(txtRawCards.Text);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Catch all error handling
        }
    }

    private void LoadCardsData(string strRawCardsData)
    {
        CardManager cardManager;
        string strCalculatedResult;
        StringBuilder stringBuilder;
        try
        {
            if (string.IsNullOrWhiteSpace(strRawCardsData))
                return;
            
            cardManager = CardManager.Parse(strRawCardsData);
            strCalculatedResult = cardManager.Calculate();
            if (int.TryParse(strCalculatedResult, out int intScore)) // The result was not an error message if it can be cast to an int
            {
                lblScore.Text = $"Current score: {intScore.ToString()}";
                lblErrorMessage.Text = "No errors";
                lblErrorMessage.ForeColor = Color.Black;
                
                txtCardOverview.Clear();
                stringBuilder = new StringBuilder();
                foreach (Card card in cardManager.lstCards.Where(card => !card.blnJoker))
                {
                    stringBuilder.AppendLine($"{card.chrCardValue}{card.chrSuit} is worth {card.Calculate()}");
                }
                txtCardOverview.Text = stringBuilder.ToString();
                txtCardOverview.Text += $"{cardManager.intAmountOfJokers} joker(s) doubled the overall score from {cardManager.Calculate(false)} to {cardManager.Calculate()}";
            }
            else
            {
                lblScore.Text = $"Could not calculate a score";
                lblErrorMessage.Text = strCalculatedResult;
                lblErrorMessage.ForeColor = Color.Red;
                txtCardOverview.Clear();
            }
        }        
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Catch all error handling
        }
    }
}