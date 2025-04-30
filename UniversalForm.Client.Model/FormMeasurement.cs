using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalForm.Client.Persistence;

namespace UniversalForm.Client.Model
{
    public class FormMeasurement
    {
        private bool _measureCorrections;
        private bool _measureTime;
        private bool _anonymous;
        private bool _focusTracking;
        public List<Statistics> QStatistics { get; } = new();
        public FormMeasurement(Form form)
        {
            _measureCorrections = form.MeasureCorrections;
            _measureTime = form.MeasureTime;
            _anonymous = form.Anonymous;
            _focusTracking = form.FocusTracking;
            form.Questions.ForEach(q => QStatistics.Add(new Statistics() { MultipleAnswers = q is QMultiSelect}));

        }
        public Statistics GetStatistics(int index)
        {
            return QStatistics[index];
        }
    }
}
