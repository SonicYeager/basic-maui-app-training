namespace TipCalculator;

public partial class StandardTipPage : ContentPage
{
    private Color colorNavy = Colors.Navy;
    private Color colorSilver = Colors.Silver;

    public StandardTipPage()
    {
        InitializeComponent();
        BillInput.TextChanged += (s, e) => CalculateTip();
    }

    void CalculateTip()
    {
        double bill;

        if (Double.TryParse(BillInput.Text, out bill) && bill > 0)
        {
            double tip = Math.Round(bill * 0.15, 2);
            double final = bill + tip;

            TipOutput.Text = tip.ToString("C");
            TotalOutput.Text = final.ToString("C");
        }
    }

    void OnLight(object sender, EventArgs e)
    {
        LayoutRoot.BackgroundColor = colorSilver;

        TipLabel.TextColor = colorNavy;
        BillLabel.TextColor = colorNavy;
        TotalLabel.TextColor = colorNavy;
        TipOutput.TextColor = colorNavy;
        TotalOutput.TextColor = colorNavy;
    }

    void OnDark(object sender, EventArgs e)
    {
        LayoutRoot.BackgroundColor = colorNavy;

        TipLabel.TextColor = colorSilver;
        BillLabel.TextColor = colorSilver;
        TotalLabel.TextColor = colorSilver;
        TipOutput.TextColor = colorSilver;
        TotalOutput.TextColor = colorSilver;
    }

    async void GotoCustom(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(CustomTipPage));
    }
}