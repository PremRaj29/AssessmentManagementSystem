import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'assessmentTiming'
})
export class AssessmentTimingPipe implements PipeTransform 
{

  transform(value: any, args?: any): any 
  {
    return (value ? 'Evening' : 'Morning');
  }

}
