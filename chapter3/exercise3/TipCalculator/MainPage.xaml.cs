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
            var pct = Math.Round(e.NewValue);
            TipPercent.Text = pct + "%";
            CalculateTip(false, false);
        };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="roundUp"></param>
    /// <param name="roundDown"></param>
    private void CalculateTip(bool roundUp, bool roundDown)
    {
        if (double.TryParse(BillInput.Text, out var t) && t > 0)
        {
            var pct = Math.Round(TipPercentSlider.Value);
            var tip = Math.Round(t * (pct / 100.0), 2);

            var final = t + tip;

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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnNormalTip(object sender, EventArgs e)
    {
        TipPercentSlider.Value = 15;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnGenerousTip(object sender, EventArgs e)
    {
        TipPercentSlider.Value = 20;
    }
}