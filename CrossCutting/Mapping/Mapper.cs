namespace Solution.CrossCutting.Mapping
{
    public class Mapper : IMapper
    {
        public TSource Clone<TSource>(TSource source)
        {
            return AgileObjects.AgileMapper.Mapper.DeepClone(source);
        }

        public TDestination Map<TDestination>(object source)
        {
            return AgileObjects.AgileMapper.Mapper.Map(source).ToANew<TDestination>();
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return AgileObjects.AgileMapper.Mapper.Map(source).OnTo(destination);
        }
    }
}
