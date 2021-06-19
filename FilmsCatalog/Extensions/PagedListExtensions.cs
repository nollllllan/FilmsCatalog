using AutoMapper;
using System.Collections.Generic;
using X.PagedList;

namespace FilmsCatalog.Extensions
{
    public static class PagedListExtensions
    {
        public static IPagedList<TDestination> ToMappedPagedList<TSource, TDestination>(this IPagedList<TSource> list, IMapper mapper)
        {
            var sourceList = mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(list);
          
            return new StaticPagedList<TDestination>(sourceList, list.GetMetaData());
        }
    }
}