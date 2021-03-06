﻿using System;
using UnityEngine;

// Class representing a full coordinate frame with axis naming conventions
// and rotation order specified
namespace FrameConversions {
    public class CoordinateFrame {
        AxisSet _axes, _rotationOrder;

        public AxisSet Axes { get { return _axes; } }
        public AxisSet RotationOrder { get { return _rotationOrder; } }

        private CoordinateFrame() { }

        #region Constructors
        public CoordinateFrame(string rufAxes, string rotationOrder) {
            _axes = new AxisSet(rufAxes, false);
            _rotationOrder = new AxisSet(rotationOrder, true);
        }
        #endregion
        
        #region API
        public Vector3 ConvertPosition(CoordinateFrame other, Vector3 v) {
            return Conversions.ConvertPosition(_axes, other._axes, v);
        }

        public EulerAngles ConvertEulerAngles(CoordinateFrame other, EulerAngles eulerAngles) {
            return Conversions.ConvertEulerAngles(this, other, eulerAngles);
        }
        #endregion

        #region To String
        public string ToString(bool includeSign = false) {
            return Axes.ToString(includeSign) + ", " + RotationOrder.ToString(includeSign);
        }
        #endregion

        #region Operator Overloads
        public static bool operator ==(CoordinateFrame a, CoordinateFrame b) {
            if (ReferenceEquals(a, b)) return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
            return a.Equals(b);
        }

        public static bool operator !=(CoordinateFrame a, CoordinateFrame b) {
            return !(a == b);
        }

        public override int GetHashCode() {
            return Axes.GetHashCode() ^ RotationOrder.GetHashCode();
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(obj, null) || GetType() != obj.GetType()) return false;
            CoordinateFrame other = (CoordinateFrame)obj;
            return Axes == other.Axes && RotationOrder == other.RotationOrder;
        }
        #endregion
    }
}