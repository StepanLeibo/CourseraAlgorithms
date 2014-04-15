using CA.Algorithms.Data.QuickSort;
using CA.Algorithms.Implementations.QuickSort;
using Ninject;

namespace CA.DI
{
    public class DependencyInjection
    {
        public IKernel NinjecKernel = new StandardKernel();

        public DependencyInjection()
        {
            #region Quick Sort

            NinjecKernel.Bind<IGetQuickSortData>().To<GetDataFileSystem>();
            NinjecKernel.Bind<IPivot>().To<PivotFirstElement>();

            NinjecKernel.Bind<QuickSort>().ToSelf();

            #endregion

            #region Merge Sort
            #endregion
        }
    }
}
