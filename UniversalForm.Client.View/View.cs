namespace UniversalForm.Client.View;

public partial class View : Form
{
    private Model.Model _model;
    public View()
    {
        _model = new Model.Model(new Persistence.BinaryFileJsonPersistence(Model.Model.getQuestionTypes()));
        InitializeComponent();
    }
}
