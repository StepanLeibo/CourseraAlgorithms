using CA.Algorithms.Data.KargerMinCut;
using CA.Algorithms.Data.MedianMaintenance;
using CA.Algorithms.Data.MergeSort;
using CA.Algorithms.Data.PrimMst;
using CA.Algorithms.Data.QuickSort;
using CA.Algorithms.Data.SccKosaraju;
using CA.Algorithms.Data.SchedulingProblem;
using CA.Algorithms.Data.ShortestPathDijkstra;
using CA.Algorithms.Data._2Sum;
using CA.Algorithms.Implementations.MedianMaintenance;
using CA.Algorithms.Implementations.MergeSort;
using CA.Algorithms.Implementations.QuickSort;
using CA.Algorithms.Implementations.KargerMinKut;
using CA.Algorithms.Implementations.SccKosaraju;
using CA.Algorithms.Implementations.ShortestPathDijkstra;
using CA.Algorithms.Implementations._2Sum;
using CA.Algorithms.Implementations.SchedulingProblem;
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

            #region Dijkstra shortest path

            NinjectKernel.Bind<IGetListVertexes>().To<GetListVertecesFS>();

            NinjectKernel.Bind<Dijkstra>().ToSelf();

            #endregion

            #region Strongly connected component

            //NinjectKernel.Bind<IGetGraphScc>().To<GetGraphSccTest>();
            NinjectKernel.Bind<IGetGraphScc>().To<GetGraphSccFs>();
            NinjectKernel.Bind<SccAlgorithm>().ToSelf();

            #endregion

            #region 2-Sum

            //NinjectKernel.Bind<IGet2SumData>().To<Get2SumDataTest>();
            NinjectKernel.Bind<IGet2SumData>().To<Get2SumDataFs>();

            NinjectKernel.Bind<I2SumAlgorithm>().To<SumHash>();
            //NinjectKernel.Bind<I2SumAlgorithm>().To<SumNativeSolution>();

            #endregion

            #region Median maintenance

            //NinjectKernel.Bind<IGetMedianMaintenanceData>().To<GetMedianMaintenanceDataTest>();
            NinjectKernel.Bind<IGetMedianMaintenanceData>().To<GetMedianMaintenanceDataFs>();

            NinjectKernel.Bind<MedianMaintenanceAlgorith>().ToSelf();

            #endregion

            #region Scheduled jobs

            NinjectKernel.Bind<IJobsDataManager>().To<JobsDataManager>();

            #endregion

            #region Prim MST

            NinjectKernel.Bind<IGetPrimMstData>().To<GetPrimMstDataFs>();

            #endregion
        }
    }
}
