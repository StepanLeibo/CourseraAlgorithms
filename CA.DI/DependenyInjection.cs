using CA.Algorithms.Data.KargerMinCut;
using CA.Algorithms.Data.MergeSort;
using CA.Algorithms.Data.QuickSort;
using CA.Algorithms.Implementations.MergeSort;
using CA.Algorithms.Implementations.QuickSort;
using CA.Algorithms.Implementations.KargerMinKut;
using Ninject;
using GetDataFileSystem = CA.Algorithms.Data.QuickSort.GetDataFileSystem;

namespace CA.DI
{
    public class DependencyInjection
    {
        public IKernel NinjectKernel = new StandardKernel();

        public DependencyInjection()
        {
            #region Quick Sort

            NinjectKernel.Bind<IGetQuickSortData>().To<GetDataFileSystem>();
            NinjectKernel.Bind<IPivot>().To<PivotFirstElement>();

            NinjectKernel.Bind<QuickSort>().ToSelf();

            #endregion

            #region Merge Sort

            NinjectKernel.Bind<IGetMergeSortData>().To<GetDataFileSystemMS>();

            NinjectKernel.Bind<MergeSort>().ToSelf();

            #endregion

            #region Karger Min Cut

            NinjectKernel.Bind<IGetGraphKarger>().To<GetGraphFS>();

            NinjectKernel.Bind<IKargerMinCut>().To<KargerMinCut>();

            #endregion
        }
    }
}
