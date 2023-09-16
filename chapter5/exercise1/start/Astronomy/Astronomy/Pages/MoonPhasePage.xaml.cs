using Astronomy.Data;

namespace Astronomy.Pages;

public sealed partial class MoonPhasePage : ContentPage
{
    public MoonPhasePage()
    {
        InitializeComponent();

        InitializeUi();
    }

    /// <summary>
    /// 
    /// </summary>
    private void InitializeUi()
    {
        var phase = MoonPhaseCalculator.GetPhase(DateTime.Now);

        lblDate.Text = DateTime.Today.ToString("D");
        lblMoonPhaseIcon.Text = MoonPhaseEmojis[phase];
        lblMoonPhaseText.Text = phase.ToString();

        SetMoonPhaseLabels(lblPhaseIcon1, lblPhaseText1, 1);
        SetMoonPhaseLabels(lblPhaseIcon2, lblPhaseText2, 2);
        SetMoonPhaseLabels(lblPhaseIcon3, lblPhaseText3, 3);
        SetMoonPhaseLabels(lblPhaseIcon4, lblPhaseText4, 4);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="lblIcon"></param>
    /// <param name="lblText"></param>
    /// <param name="dayOffset"></param>
    private static void SetMoonPhaseLabels(Label lblIcon, Label lblText, int dayOffset)
    {
        var phase = MoonPhaseCalculator.GetPhase(DateTime.Now.AddDays(dayOffset));
        lblIcon.Text = MoonPhaseEmojis[phase];
        lblText.Text = DateTime.Now.AddDays(dayOffset).DayOfWeek.ToString();
    }

    /// <summary>
    /// 
    /// </summary>
    private static readonly Dictionary<MoonPhaseCalculator.Phase, string> MoonPhaseEmojis = new Dictionary<MoonPhaseCalculator.Phase, string>
    {
        {
            MoonPhaseCalculator.Phase.New, "🌑"
        },
        {
            MoonPhaseCalculator.Phase.WaxingCrescent, "🌒"
        },
        {
            MoonPhaseCalculator.Phase.FirstQuarter, "🌓"
        },
        {
            MoonPhaseCalculator.Phase.WaxingGibbous, "🌔"
        },
        {
            MoonPhaseCalculator.Phase.Full, "🌕"
        },
        {
            MoonPhaseCalculator.Phase.WaningGibbous, "🌖"
        },
        {
            MoonPhaseCalculator.Phase.LastQuarter, "🌗"
        },
        {
            MoonPhaseCalculator.Phase.WaningCrescent, "🌘"
        },
    };
}