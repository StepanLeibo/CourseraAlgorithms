using CA.Algorithms.Data.MergeSort;
using CA.Algorithms.Data.QuickSort;
using CA.Algorithms.Implementations.MergeSort;
using CA.Algorithms.Implementations.QuickSort;
using Ninject;
using GetDataFileSystem = CA.Algorithms.Data.QuickSort.GetDataFileSystem;

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

            NinjecKernel.Bind<IGetMergeSortData>().To<GetDataFileSystemMS>();

            NinjecKernel.Bind<MergeSort>().ToSelf();

            #endregion
        }
    }
}
