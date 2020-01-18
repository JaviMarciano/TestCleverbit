using System;
using System.Linq.Expressions;
using System.Reflection;

namespace TestCleverbit.DataAccess.EntityFrameworkConfiguration
{
    public static class LinqExtensions
    {
        public static Expression<Func<TClass, bool>> GetEqualsPredicateForConstant<TClass, TProperty>(
            this Expression<Func<TClass, TProperty>> propertyAccessorExpression,
            TProperty value)
        {
            var predicateExpression = Expression.Equal(propertyAccessorExpression.Body, Expression.Constant(value));
            return Expression.Lambda<Func<TClass, bool>>(predicateExpression, propertyAccessorExpression.Parameters[0]);
        }

        public static Action<TClass, TProperty> GetSetter<TClass, TProperty>(
           this Expression<Func<TClass, TProperty>> propertyAccessorExpression)
        {
            var propertyInfo = (PropertyInfo)((MemberExpression)propertyAccessorExpression.Body).Member;
            return (Action<TClass, TProperty>)Delegate.CreateDelegate(typeof(Action<TClass, TProperty>), propertyInfo.GetSetMethod());
        }
    }
}
