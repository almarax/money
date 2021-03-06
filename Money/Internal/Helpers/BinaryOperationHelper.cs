﻿using System;
using System.Linq.Expressions;

namespace Money.Internal.Helpers
{
    public static class BinaryOperationHelper
    {
        public static T Add<T>(T left, T right)
        {
            return Evaluate(left, right, Expression.Add);
        }

        public static T AddChecked<T>(T left, T right)
        {
            return Evaluate(left, right, Expression.AddChecked);
        }

        public static T Subtract<T>(T left, T right)
        {
            return Evaluate(left, right, Expression.Subtract);
        }

        public static T SubtractChecked<T>(T left, T right)
        {
            return Evaluate(left, right, Expression.SubtractChecked);
        }

        public static T Multiply<T>(T left, T right)
        {
            return Evaluate(left, right, Expression.Multiply);
        }

        public static T MultiplyChecked<T>(T left, T right)
        {
            return Evaluate(left, right, Expression.MultiplyChecked);
        }

        public static T Divide<T>(T left, T right)
        {
            return Evaluate(left, right, Expression.Divide);
        }

        public static T Modulo<T>(T left, T right)
        {
            return Evaluate(left, right, Expression.Modulo);
        }

        public static T BitwiseAnd<T>(T left, T right)
        {
            return Evaluate(left, right, Expression.And);
        }

        public static T BitwiseOr<T>(T left, T right)
        {
            return Evaluate(left, right, Expression.Or);
        }

        public static T BitwiseXor<T>(T left, T right)
        {
            return Evaluate(left, right, Expression.ExclusiveOr);
        }

        public static T LeftShift<T>(T left, int right)
        {
            return Evaluate(left, right, Expression.LeftShift);
        }

        public static T RightShift<T>(T left, int right)
        {
            return Evaluate(left, right, Expression.RightShift);
        }

        private static TLeft Evaluate<TLeft, TRight>(TLeft left, TRight right, Func<Expression, Expression, BinaryExpression> binaryOperation)
        {
            var leftOperandType = typeof (TLeft);
            var rightOperandType = typeof (TRight);
            var operandLeft = Expression.Constant(left, leftOperandType);
            var operandRight = Expression.Constant(right, rightOperandType);
            var binaryExpression = binaryOperation(operandLeft, operandRight);
            return Expression.Lambda<Func<TLeft>>(binaryExpression).Compile()();
        }
    }
}