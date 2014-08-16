using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MageTastic.Utility
{
    class ConstrainedValue
    {
        public readonly float MaxValue;
        public readonly float MinValue;

        private float _v;
        private float Value
        {
            get { return _v; }
            set { _v = Constrain(value); }
        }
        private readonly Action OnDepleted;
        private readonly Action OnFilled;

        public ConstrainedValue(float defaultValue, float min, float max, Action onDepleted = null, Action onFilled = null)
        {
            MinValue = min;
            MaxValue = max;
            Value = defaultValue;

            OnDepleted = onDepleted ?? (() => { });
            OnFilled = onFilled ?? (() => { });
        }

        public void Increase(float increaseValue)
        {
            Value += increaseValue;
        }

        private float Constrain(float value)
        {
            if (value > MaxValue)
            {
                value = MaxValue;
                OnFilled();
            }
            else if (value < MinValue)
            {
                value = MinValue;
                OnDepleted();
            }

            return value;
        }

        public static ConstrainedValue operator *(ConstrainedValue lhs, ConstrainedValue rhs)
        {
            lhs.Value = lhs.Value * rhs.Value;
            return lhs;
        }

        public static ConstrainedValue operator *(ConstrainedValue lhs, float rhs)
        {
            lhs.Value = lhs.Value * rhs;
            return lhs;
        }

        public static ConstrainedValue operator /(ConstrainedValue lhs, float rhs)
        {
            lhs.Value = lhs.Value / rhs;
            return lhs;
        }

        public static ConstrainedValue operator +(ConstrainedValue lhs, float rhs)
        {
            lhs.Value = lhs.Value + rhs;
            return lhs;
        }

        public static ConstrainedValue operator -(ConstrainedValue lhs, float rhs)
        {
            lhs.Value = lhs.Value - rhs;
            return lhs;
        }

        public static bool operator ==(ConstrainedValue lhs, float rhs)
        {
            return lhs.Value == rhs;
        }

        public static bool operator !=(ConstrainedValue lhs, float rhs)
        {
            return lhs.Value != rhs;
        }

        public static bool operator ==(ConstrainedValue lhs, ConstrainedValue rhs)
        {
            return lhs.Value == rhs.Value;
        }

        public static bool operator !=(ConstrainedValue lhs, ConstrainedValue rhs)
        {
            return lhs.Value == rhs;
        }

        public static implicit operator float(ConstrainedValue cv)
        {
            return cv.Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
