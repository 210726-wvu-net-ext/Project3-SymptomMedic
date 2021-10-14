import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'spfilter'
})
export class SpfilterPipe implements PipeTransform {

  transform(value: any, searchInput: string){
    if (value.length === 0)
    {
      return value;
    }

    const doctors = [];
    for(const doctor of value)
    {
      if (doctor['doctorSpeciality'] === searchInput)
      {
        doctors.push(doctor);
      }
    }
    return doctors;
  }

}
