using AutoMapper;
using System.Reflection;

namespace Infrastructure.Mappings
{
    public static class AutoMapperExtention
    {
        public static IMappingExpression<TSource, TDestination> IgnoreAllNoneExisting<TSource, TDestination>
            (this IMappingExpression<TSource, TDestination> expression)
        {
            var flags = BindingFlags.Public | BindingFlags.Instance;
            var sourceType = typeof(TSource);
            var destinationProperty = typeof(TDestination).GetProperties(flags);

            foreach (var property in destinationProperty)
                if (sourceType.GetProperty(property.Name, flags) == null)
                    expression.ForMember(property.Name, opt => opt.Ignore());
            return expression;
        }
    }
}
