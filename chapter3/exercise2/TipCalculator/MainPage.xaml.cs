namespace TipCalculator;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        BillInput.TextChanged += (s, e) => CalculateTip(false, false);
        RoundDown.Clicked += (s, e) => CalculateTip(false, true);
        RoundUp.Clicked += (s, e) => CalculateTip(true, false);

        TipPercentSlider.ValueChanged += (s, e) =>
        {
            double pct = Math.Round(e.NewValue);
            TipPercent.Text = pct + "%";
            CalculateTip(false, false);
        };
    }

    void CalculateTip(bool roundUp, bool roundDown)
    {
        double t;
        if (Double.TryParse(BillInput.Text, out t) && t > 0)
        {
            double pct = Math.Round(TipPercentSlider.Value);
            double tip = Math.Round(t * (pct / 100.0), 2);

            double final = t + tip;

            if (roundUp)
            {
                final = Math.Ceiling(final);
                tip = final - t;
            }
            else if (roundDown)
            {
                final = Math.Floor(final);
                tip = final - t;
            }

            TipOutput.Text = tip.ToString("C");
            TotalOutput.Text = final.ToString("C");
        }
    }

    void OnNormalTip(object sender, EventArgs e) { TipPercentSlider.Value = 15; }
    void OnGenerousTip(object sender, EventArgs e) { TipPercentSlider.Value = 20; }
}
