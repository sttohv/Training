using Training.Core;

namespace Training.Facade.Common
{
    public abstract class BaseView : UniqueItem, IBaseEntityView
    {
        public byte[] RowVersion { get; set; }
    }
}
