using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TimeFrequencyMeasurementSystem.Structs;

namespace TimeFrequencyMeasurementSystem.Data
{
    public static class MeasurementData
    {
        public static ObservableCollection<MeasurementFrequencyCount> LstFrequencyCount { get; set; }
        public static ObservableCollection<MeasurementBootFeature> LstBootFeature { get; set; }
        public static ObservableCollection<MeasurementPhaseNoise> LstPhaseNoise { get; set; }
        public static ObservableCollection<MeasurementShortTermStability> LstShortTermStability { get; set; }
        public static ObservableCollection<MeasurementFrequencyAccuracy> LstFrequencyAccuracy { get; set; }
        public static ObservableCollection<MeasurementFrequencyReproducibility> LstFrequencyReproducibility { get; set; }
        public static ObservableCollection<MeasurementDriftRateParam> LstDriftRateParam { get; set; }
        public static ObservableCollection<MeasurementBurnInRateParam> LstBurnInRateParam { get; set; }
        public static ObservableCollection<MeasurementInterval> LstInterval { get; set; }
    }
}
