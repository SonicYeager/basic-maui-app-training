using PartsClient.Data;
using PartsClient.ViewModels;

namespace PartsClient.Pages;

[QueryProperty("PartToDisplay", "part")]
public partial class AddPartPage : ContentPage
{
	private AddPartViewModel _viewModel;
	public AddPartPage()
	{
		InitializeComponent();

		_viewModel = new AddPartViewModel();
		BindingContext = _viewModel;
    }

	private Part _partToDisplay;
    public Part PartToDisplay {
		get => _partToDisplay;
		set
        {
			if (_partToDisplay == value)
				return;

			_partToDisplay = value;

			_viewModel.PartId = _partToDisplay.PartId;
			_viewModel.PartName = _partToDisplay.PartName;
			_viewModel.Suppliers = _partToDisplay.SupplierString;
			_viewModel.PartType = _partToDisplay.PartType;
        }
	}
}
