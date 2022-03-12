using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTimeline.Models {
    public class Year {

        private Guid id;
        public Guid Id => this.id;

        private DateTime date;
        public int Name => this.date.Year;

        private List<Week> weeks;

        public Year(DateTime argYear) {
            this.id = Guid.NewGuid();
            this.date = argYear;
            this.weeks = new List<Week>();
        }

    }
}
