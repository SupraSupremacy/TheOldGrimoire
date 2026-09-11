using CommunityToolkit.Mvvm.ComponentModel;
using TheOldGrimoire.Models;
using TheOldGrimoire.Services;

namespace TheOldGrimoire.ViewModels;

[QueryProperty(nameof(Historia), "Historia")]
public partial class DetailViewModel : ObservableObject
{
    [ObservableProperty]
    public partial Historia? Historia { get; set; }

    public double TamanioLetra => ConfiguracionService.Instance.ObtenerTamanoFuente();

    public DetailViewModel()
    {
    }
}