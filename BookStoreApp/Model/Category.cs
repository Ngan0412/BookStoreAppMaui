using DevExpress.Maui.Scheduler.Internal;

namespace BookStoreApp.Model;

public class Category : BindableBase
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public bool IsDeleted { get; set; }

}