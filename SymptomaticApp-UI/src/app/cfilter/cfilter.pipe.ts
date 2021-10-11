import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'cfilter'
})
export class CfilterPipe implements PipeTransform {

  transform(value: any, searchInput: string){
    if (value.length === 0)
    {
      return value;
    }

    const doctors = [];
    for(const doctor of value)
    {
      if(doctor['practiceCity'] === searchInput)
      {
        doctors.push(doctor);
      }
    }
    return doctors;
  }
}
