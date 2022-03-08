import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'searchByYear'
})

export class SearchByYearPipe implements PipeTransform {

    // pipe to show spacific object in this case by year

  transform(CarTypes:any[],character:number):any[] {
    if(character===undefined){
      return CarTypes;
    }
    else{ 
      return CarTypes.filter(function(type){
        return type.year.toString().includes(character.toString());

     
        
})
  }

  }
}
