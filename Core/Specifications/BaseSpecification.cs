using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        private Func<Products, bool> value;

        public BaseSpecification()
        {
        }

        public BaseSpecification(Func<Products, bool> value)
        {
            this.value = value;
        }

        public BaseSpecification(Expression<Func<T, bool>> criteria, List<Expression<Func<T, 
        object>>> includes)
        {
            Criteria = criteria;
        }


        public Expression<Func<T, bool>> Criteria {get;}

        public List<Expression<Func<T, object>>> Includes {get;} = 
            new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}