using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EodrLngMembrane
{
    public class EodrMeasurementParameter
    {
        int _location_X = 0;
        int _location_Y = 0;
        int _size_Width = 760;
        int _size_Height = 200;
        string _cuurentFormName = string.Empty;
        int _cuurentabPageIndex = 0;
        int _basePointIndex = 0;
        string _horizontalAngle = string.Empty;
        string _varticalAngle = string.Empty;
        string _slopeDistance = string.Empty;
        int _measurementStartSectionNo = 0;
        int _measurementSectionNo = 0;
        int _measurementPointNo = 0;
        string _planedHorizontalAngle = string.Empty;
        string _planedVarticalAngle = string.Empty;
        string _planedSlopeDistance = string.Empty;
        bool _applyFlg = false;

        public int Location_X
        {
            set { _location_X = value; }
            get { return _location_X; }
        }

        public int Location_Y
        {
            set { _location_Y = value; }
            get { return _location_Y; }
        }

        public int Size_Width
        {
            set { _size_Width = value; }
            get { return _size_Width; }
        }

        public int Size_Height
        {
            set { _size_Height = value; }
            get { return _size_Height; }
        }

        public string CuurentFormName
        {
            set { _cuurentFormName = value; }
            get { return _cuurentFormName; }
        }

        public int CuurentabPageIndex
        {
            set { _cuurentabPageIndex = value; }
            get { return _cuurentabPageIndex; }
        }

        public int BasePointIndex
        {
            set { _basePointIndex = value; }
            get { return _basePointIndex; }
        }

        public string HorizontalAngle
        {
            set { _horizontalAngle = value; }
            get { return _horizontalAngle; }
        }

        public string VarticalAngle
        {
            set { _varticalAngle = value; }
            get { return _varticalAngle; }
        }

        public string SlopeDistance
        {
            set { _slopeDistance = value; }
            get { return _slopeDistance; }
        }

        public int MeasurementStartSectionNo
        {
            set { _measurementStartSectionNo = value; }
            get { return _measurementStartSectionNo; }
        }

        public int MeasurementSectionNo
        {
            set { _measurementSectionNo = value; }
            get { return _measurementSectionNo; }
        }

        public int MeasurementPointNo
        {
            set { _measurementPointNo = value; }
            get { return _measurementPointNo; }
        }

        public string PlanedHorizontalAngle
        {
            set { _planedHorizontalAngle = value; }
            get { return _planedHorizontalAngle; }
        }

        public string PlanedVarticalAngle
        {
            set { _planedVarticalAngle = value; }
            get { return _planedVarticalAngle; }
        }

        public string PlanedSlopeDistance
        {
            set { _planedSlopeDistance = value; }
            get { return _planedSlopeDistance; }
        }

        public bool ApplyFlg
        {
            set { _applyFlg = value; }
            get { return _applyFlg; }
        }

        internal void InitializeParameter()
        {
            _measurementStartSectionNo = 0;
            _measurementSectionNo = 0;
            _measurementPointNo = 0;
        }

        internal void SetSectionNo()
        {
            if (_measurementSectionNo == 0) _measurementSectionNo = _measurementStartSectionNo;
            _measurementPointNo += 1;
            if (_measurementPointNo > 5)
            {
                _measurementPointNo = 1;
                _measurementSectionNo += 1;
            }
        }

        internal void CalcPlanedValue()
        {
            _planedHorizontalAngle = "20.3335";
            _planedVarticalAngle = "15.3684";
            _planedSlopeDistance = "16.325";
        }

        internal void SetShellSectionNo()
        {
            if (_measurementSectionNo == 0) _measurementSectionNo = _measurementStartSectionNo;
            _measurementPointNo += 1;
            if (_measurementPointNo > 21)
            {
                _measurementPointNo = 1;
                _measurementSectionNo += 1;
            }
        }
    }
}
