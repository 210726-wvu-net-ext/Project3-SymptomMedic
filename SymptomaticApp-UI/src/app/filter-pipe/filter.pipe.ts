import { Pipe, PipeTransform } from '@angular/core';
import { DoctorSearchComponent } from '../doctor-search/doctor-search.component';

@Pipe({
  name: 'filter'
})
export class FilterPipe implements PipeTransform {

  transform(value: any, searchInput: string): unknown {
    if (value.length === 0)
    {
      return value;
    }

    const doctors = [];
    for(const doctor of value)
    {
      if(doctor['firstName'] === searchInput || (doctor['firstName'] === searchInput && doctor['lastName'] === searchInput))
      {
        doctors.push(doctor);
      }
    }
    return doctors;
  }

}
