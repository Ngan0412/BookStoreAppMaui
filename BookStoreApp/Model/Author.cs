using DevExpress.Maui.Scheduler.Internal;

namespace BookStoreApp.Model;

public class Author : BindableBase
{
    public Guid id { get; set; }
    public string name;
    public string Name
    {
        get => name;
        set
        {
            name = value;
            RaisePropertyChanged();
        }
    }
    public bool IsDeleted { get; set; } = false;
}