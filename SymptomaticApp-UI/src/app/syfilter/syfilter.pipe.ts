import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'syfilter'
})
export class SyfilterPipe implements PipeTransform {

  transform(value: any, searchInput: string){
    if (value.length === 0)
    {
      return value;
    }

    const doctors = [];
    for(const doctor of value)
    {
      if(doctor.doctorSymptoms['symptom'] === searchInput)
      {
        doctors.push(doctor);
      }
    }
    return doctors;
  }

}
