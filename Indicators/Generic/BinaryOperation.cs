using System;

namespace QuantModel.Indicators.Generic
{
    public class BinaryOperation<T1, T2, T3>: Indicator<T3>
    {
        public BinaryOperation(IIndicator<T1> op1, IIndicator<T2> op2, Func<T1, T2, T3> op)
        {
            Op1 = op1;
            Op2 = op2;
            Op = op;
            Op1.Update += OnUpdate;
            Op2.Update += OnUpdate;
        }

        private void OnUpdate()
        {
            Data.FillRange(Count,Math.Min(Op1.Count,Op2.Count),i => Op(Op1[i], Op2[i]));
            FollowUp();
        }

        private IIndicator<T1> Op1 { get; }
        private IIndicator<T2> Op2 { get; }
        private Func<T1, T2, T3> Op { get; }

        public override string ToString()
        {
            return $"Op({Op1}, {Op2})";
        }
    }

    public static class BinaryOperation
    {
        public static BinaryOperation<T1, T2, T3> Create<T1, T2, T3>(IIndicator<T1> op1, IIndicator<T2> op2, Func<T1, T2, T3> op)
        {
            return new BinaryOperation<T1, T2, T3>(op1, op2, op);
        }
    }
}