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

        public Expression<Func<T, object>> OrderBy {get; private set;}

        public Expression<Func<T, object>> OrderByDescending {get; private set;}

        public int Take {get; private set;}

        public int Skip {get; private set;}

        public bool IsPagingEnabled {get; private set;}

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }
        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
    }
}