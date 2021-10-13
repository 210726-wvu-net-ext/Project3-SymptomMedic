import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'syfilter'
})
export class SyfilterPipe implements PipeTransform {

  transform(value: any, searchInput: string){
    console.log(value);
    if (value.length === 0)
    {
      return value;
    }

    const doctors = [];
    const symptoms = [];
    for(const doctor of value)
    {
      console.log(doctor);
      
      if(doctor.doctorSymptoms['symptom'] === searchInput)
      {
        doctors.push(doctor);
      }
    }
    return doctors;
  }

}
