namespace Solution.CrossCutting.Mapping
{
    public interface IMapper
    {
        TSource Clone<TSource>(TSource source);

        TDestination Map<TDestination>(object source);

        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}
